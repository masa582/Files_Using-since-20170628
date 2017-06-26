using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Security.Cryptography;

namespace SearchDataOnIE
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Module variable declaration
        /// </summary>
        HtmlDocument webDoc;
        WebBrowser wb;
        List<HtmlElement> listResult = new List<HtmlElement>();
        HtmlElement m_FirstElem;    // element use for First page
        HtmlElement m_PrevElem;     // element use for Next page
        HtmlElement m_NextElem;     // element use for Previous page

        string URL = "https://naviexp.jp/NaviExp/jsp/A/Login.jsp";
        OnLoadCmd olCommand = OnLoadCmd.NONE;
        bool IsSearching = false;
        bool IsCanceled = false;

        /// <summary>
        /// Form Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// FOrm Load event
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            wb = ucWebEx1.GetWebBrowser();
            this.wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            
            // initial value
            txtUserName.Text = "";
            txtPassword.Text = "";

            txtSearchNumber.Text = "";
            txtSearchDate.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString();
            SetSearchNumDate();
            SetStatus("Ready",SystemColors.ButtonFace);

            expSearch.Colapsed = true;
        }

        /// <summary>
        /// WebBrowser Document complete
        /// </summary>
        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webDoc = wb.Document;
            SetPageElem();              // must be set first

            switch (olCommand)
            {
                case OnLoadCmd.NONE:
                    lstResult.Items.Clear();
                    listResult.Clear();
                    break;

                case OnLoadCmd.LOGIN:
                    ProcessLogin();
                    //olCommand = OnLoadCmd.NONE;
                    break;

                case OnLoadCmd.FIRST_PAGE:
                    ProcessOpenFirstPage();
                    olCommand = OnLoadCmd.NONE;
                    break;

                case OnLoadCmd.PREV_PAGE:
                    break;

                case OnLoadCmd.NEXT_PAGE:
                    break;

                case OnLoadCmd.SEARCH:
                    ProcessSearch();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Search Number text changed
        /// </summary>
        private void txtSearchNumber_TextChanged(object sender, EventArgs e)
        {
            SetSearchNumDate();
        }

        /// <summary>
        /// Search Date text changed
        /// </summary>
        private void txtSearchDate_TextChanged(object sender, EventArgs e)
        {
            SetSearchNumDate();
        }

        /// <summary>
        /// Merge Search and Number text
        /// </summary>
        private void SetSearchNumDate()
        {
            lblSearchNumDate.Text = txtSearchNumber.Text + " " + txtSearchDate.Text;
        }

        /// <summary>
        /// Command Search
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            IsSearching = true;
            IsCanceled = false;
            btnSeacrhCancel.Enabled = true;
            ProcessSearch();
        }

        /// <summary>
        /// Start searching
        /// </summary>
        private void ProcessSearch()
        {
            if (IsCanceled) goto CANCELED_OPERATION;

            lstResult.Items.Clear();
            listResult.Clear();
            SetStatus("Searching...", Color.LimeGreen);

            if (webDoc == null)
            {
                SetStatus("WebBrowser error!", Color.Yellow);
                return;
            }

            HtmlElement DivElem = webDoc.GetElementById("mainContents");
            HtmlElementCollection Elems = webDoc.GetElementsByTagName("A");
            string findText = lblSearchNumDate.Text;
            foreach (HtmlElement item in Elems)
            {
                if (IsCanceled) goto CANCELED_OPERATION;

                string inText = item.InnerText;
                if (inText == null) continue;
                if (inText.Contains(findText))
                {
                    lstResult.Items.Add(inText);
                    listResult.Add(item);
                    item.Style = "background-color:#00FF00";        // highlight item on webBrowser
                    item.ScrollIntoView(true);                      // scroll this item into view on web browser
                }
            }

            // check if found, if not then click next page search
            if (listResult.Count > 0)   // found
            {
                IsSearching = false;
                olCommand = OnLoadCmd.NONE;
                SetStatus("Found : " + listResult.Count.ToString(), SystemColors.ButtonFace);
            }
            else                        // not found, click next page
            {
                if (m_NextElem==null)   // next page not available
                {
                    IsSearching = false;
                    olCommand = OnLoadCmd.NONE;
                    SetStatus("Found : " + listResult.Count.ToString(), SystemColors.ButtonFace);
                }
                else                    // next page available
                {
                    SetStatus("Load next page...", Color.LimeGreen);
                    olCommand = OnLoadCmd.SEARCH;
                    m_NextElem.InvokeMember("click");
                }
            }
            return;

CANCELED_OPERATION:
            SetStatus("Search Canceled!", SystemColors.ButtonFace);
            IsCanceled = false;
            btnSeacrhCancel.Enabled = false;
        }

        /// <summary>
        /// Click item on Result list
        /// </summary>
        private void lstResult_Click(object sender, EventArgs e)
        {
            if (lstResult.Items.Count < 1) return;
            if (lstResult.SelectedIndex < 0) return;

            HtmlElement elem = listResult[lstResult.SelectedIndex];
            if (elem==null) return;
            elem.ScrollIntoView(true);
            //elem.Style = "background-color:#00FF00";
        }

        /// <summary>
        /// Command Login
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (wb==null) return;
            if (URL==null) return;
            olCommand = OnLoadCmd.LOGIN;
            wb.Navigate(URL);
        }

        /// <summary>
        /// Processing Login page
        /// </summary>
        private void ProcessLogin()
        {
            if (webDoc==null) return;
            HtmlElement UserNameElem = webDoc.GetElementById("txtAccount");     // elem for username
            HtmlElement PassWordElem = webDoc.GetElementById("txtpassWord");    // elem for password
            HtmlElement SubmitElem = webDoc.GetElementById("btnLogin");         // elem for login

            if ( UserNameElem!=null &&  PassWordElem!=null &&  SubmitElem!=null)
            {
                // set user input value to html element
                UserNameElem.SetAttribute("value", txtUserName.Text);
                PassWordElem.SetAttribute("value", txtPassword.Text);
                SubmitElem.InvokeMember("click");
                olCommand = OnLoadCmd.FIRST_PAGE;

                expSearch.Colapsed = false;
                expLogin.Colapsed = true;
            }
        }

        /// <summary>
        /// Opening first page
        /// </summary>
        private void ProcessOpenFirstPage()
        {
            if (webDoc == null) return;
            HtmlElement elem = webDoc.GetElementById("menu02");         // elem for first page  menu02 (2nd upper-left menu)
            if (elem != null) elem.InvokeMember("click");
        }

        /// <summary>
        /// Set all page navigation html element
        /// </summary>
        private void SetPageElem()
        {
            // initialize
            m_FirstElem = null;
            m_PrevElem  = null;
            m_NextElem  = null;
            lblCurrentPage.Text = "";
            if (webDoc==null) return;
            
            // first page
            HtmlElement menu02 = webDoc.GetElementById("menu02");           // after login
            HtmlElement menu02on = webDoc.GetElementById("menu02on");       // result page
            if (menu02 != null)     m_FirstElem = menu02;
            if (menu02on != null)   m_FirstElem = menu02on;

            // prev and next page
            var divs = (from HtmlElement element in webDoc.GetElementsByTagName("DIV") select element).ToList();
            HtmlElement divElem = divs.FirstOrDefault(x => x.GetAttribute("ClassName") == "floatRight");
            if (divElem == null) goto Enabled_Button;
            var tds = (from HtmlElement element in divElem.GetElementsByTagName("TD") select element).ToList();
            if (tds.Count > 2)
            {
                // cur page text
                HtmlElement curPage = tds[0];
                lblCurrentPage.Text = curPage.InnerText;

                // prev page elem
                HtmlElement testElem = null;
                HtmlElementCollection testElems = null;
                testElems = tds[1].GetElementsByTagName("A");
                if (testElems.Count > 0) testElem = testElems[0];
                if (testElem != null)
                {
                    string href = testElem.GetAttribute("href");
                    if (href.Contains("javascript:changePage")) m_PrevElem = testElem;
                }

                // next page elem
                testElem = null;
                testElems = null;
                testElems = tds[2].GetElementsByTagName("A");
                if (testElems.Count > 0) testElem = testElems[0];
                if (testElem != null)
                {
                    string href = testElem.GetAttribute("href");
                    if (href.Contains("javascript:changePage")) m_NextElem = testElem;
                }
            }

Enabled_Button:
            // enable button
            btnFirstPage.Enabled = m_FirstElem != null;
            btnPrevPage.Enabled = m_PrevElem != null;
            btnNextPage.Enabled = m_NextElem != null;
            btnSearchNext.Enabled = btnNextPage.Enabled;
        }

        /// <summary>
        /// Command previous page
        /// </summary>
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (m_PrevElem != null) m_PrevElem.InvokeMember("click");
        }

        /// <summary>
        /// Command next page
        /// </summary>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (m_NextElem != null) m_NextElem.InvokeMember("click");
        }

        /// <summary>
        /// Command first page
        /// </summary>
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (m_FirstElem != null) m_FirstElem.InvokeMember("click");
        }

        /// <summary>
        /// Command go next page and start search
        /// </summary>
        private void btnSearchNext_Click(object sender, EventArgs e)
        {
            if (m_NextElem!=null)
            {
                IsSearching = true;
                IsCanceled = false;
                btnSeacrhCancel.Enabled = true;
                olCommand = OnLoadCmd.SEARCH;
                m_NextElem.InvokeMember("click");
            }
        }

        /// <summary>
        /// Set status
        /// </summary>
        private void SetStatus(string msg, Color backColor)
        {
            lblStatus.Text = msg;
            lblStatus.BackColor = backColor;
            lblStatus.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expLogin_OnColapsed(object sender, EventArgs e)
        {
            //flpRight.ScrollControlIntoView(expLogin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expLogin_OnExpanded(object sender, EventArgs e)
        {
            flpRight.ScrollControlIntoView(expLogin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expSearch_OnColapsed(object sender, EventArgs e)
        {
            //flpRight.ScrollControlIntoView(expSearch);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expSearch_OnExpanded(object sender, EventArgs e)
        {
            flpRight.ScrollControlIntoView(expSearch);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeacrhCancel_Click(object sender, EventArgs e)
        {
            IsCanceled = true;
        }

    }

    /// <summary>
    /// On page load command enumeration
    /// </summary>
    public enum OnLoadCmd
    {
        NONE,
        LOGIN,
        FIRST_PAGE,
        PREV_PAGE,
        NEXT_PAGE,
        SEARCH
    }
}

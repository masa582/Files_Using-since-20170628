using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchDataOnIE
{
    public partial class UCWebEx : UserControl
    {
        public HtmlDocument Document = null;

        public UCWebEx()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(tbxURL.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void UCWebEx_Resize(object sender, EventArgs e)
        {
            tbxURL.Width = this.Width - tbxURL.Left -10;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Document = webBrowser1.Document;
        }

        public WebBrowser GetWebBrowser()
        {
            return  webBrowser1;
        }

        public void Navigate(string URL)
        {
            webBrowser1.Navigate(URL);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.ComponentModel;
using System.ComponentModel.Design;


namespace SearchDataOnIE
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class UCVerExpander : UserControl
    {
        public event EventHandler OnExpanded;
        public event EventHandler OnColapsed;

        private int controlHeight;
        private bool _colapsed = false;

        public UCVerExpander()
        {
            InitializeComponent();
        }

        public bool Colapsed
        {
            get { return _colapsed;}
            set
            {
                _colapsed = value;
                SetExpander();
            }
        }

        public string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value;}
        }

        public ContentAlignment CaptionAlignment
        {
            get { return label1.TextAlign; }
            set { label1.TextAlign = value;}
        }

        public Color CaptionBackColor
        {
            get { return label1.BackColor; }
            set { label1.BackColor = value;}
        }

        public Color CaptionForeColor
        {
            get { return label1.ForeColor; }
            set { label1.ForeColor = value;}
        }

        private void label1_Click(object sender, EventArgs e)
        {
            _colapsed = !_colapsed;
            SetExpander();
        }

        private void SetExpander()
        {
            if (_colapsed)
            {
                label1.ImageIndex = 0;
                this.Height =  label1.Height;
                SetVisibleControls(false);
                if (OnColapsed != null)    OnColapsed(this, new EventArgs());
            }
            else
            {
                label1.ImageIndex = 1;
                this.Height = controlHeight;
                SetVisibleControls(true);
                if (OnExpanded != null)    OnExpanded(this, new EventArgs());
            }
        }


        private void UCVerExpander_Load(object sender, EventArgs e)
        {
            controlHeight = this.Height;
        }

        private void SetVisibleControls(bool value)
        {
            for (int i = 1; i < Controls.Count; i++)    // exclude label on index 0
            {
                Controls[i].Visible = value;
            }
        }
    }
}

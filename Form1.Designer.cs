namespace SearchDataOnIE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpRight = new System.Windows.Forms.FlowLayoutPanel();
            this.expLogin = new SearchDataOnIE.UCVerExpander();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.expSearch = new SearchDataOnIE.UCVerExpander();
            this.txtSearchDate = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.btnSearchNext = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.lblSearchNumDate = new System.Windows.Forms.Label();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSeacrhCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchNumber = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flpBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.ucWebEx1 = new SearchDataOnIE.UCWebEx();
            this.flpRight.SuspendLayout();
            this.expLogin.SuspendLayout();
            this.expSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpRight
            // 
            this.flpRight.AutoScroll = true;
            this.flpRight.BackColor = System.Drawing.Color.LightSteelBlue;
            this.flpRight.Controls.Add(this.expLogin);
            this.flpRight.Controls.Add(this.expSearch);
            this.flpRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpRight.Location = new System.Drawing.Point(0, 0);
            this.flpRight.Margin = new System.Windows.Forms.Padding(2);
            this.flpRight.Name = "flpRight";
            this.flpRight.Size = new System.Drawing.Size(242, 566);
            this.flpRight.TabIndex = 0;
            // 
            // expLogin
            // 
            this.expLogin.BackColor = System.Drawing.Color.LightSteelBlue;
            this.expLogin.Caption = "Login";
            this.expLogin.CaptionAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.expLogin.CaptionBackColor = System.Drawing.Color.LightSlateGray;
            this.expLogin.CaptionForeColor = System.Drawing.SystemColors.Window;
            this.expLogin.Colapsed = false;
            this.expLogin.Controls.Add(this.btnLogin);
            this.expLogin.Controls.Add(this.label1);
            this.expLogin.Controls.Add(this.txtPassword);
            this.expLogin.Controls.Add(this.label7);
            this.expLogin.Controls.Add(this.txtUserName);
            this.expLogin.Location = new System.Drawing.Point(2, 2);
            this.expLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.expLogin.Name = "expLogin";
            this.expLogin.Size = new System.Drawing.Size(220, 141);
            this.expLogin.TabIndex = 0;
            this.expLogin.OnExpanded += new System.EventHandler(this.expLogin_OnExpanded);
            this.expLogin.OnColapsed += new System.EventHandler(this.expLogin_OnColapsed);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(15, 107);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(101, 28);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(15, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(15, 82);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(15, 0, 3, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(205, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightSlateGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(15, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "UserName";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(15, 40);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(15, 0, 3, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(205, 20);
            this.txtUserName.TabIndex = 6;
            // 
            // expSearch
            // 
            this.expSearch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.expSearch.Caption = "Search";
            this.expSearch.CaptionAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.expSearch.CaptionBackColor = System.Drawing.Color.LightSlateGray;
            this.expSearch.CaptionForeColor = System.Drawing.SystemColors.Window;
            this.expSearch.Colapsed = false;
            this.expSearch.Controls.Add(this.txtSearchDate);
            this.expSearch.Controls.Add(this.lblStatus);
            this.expSearch.Controls.Add(this.lblCurrentPage);
            this.expSearch.Controls.Add(this.btnSearchNext);
            this.expSearch.Controls.Add(this.btnFirstPage);
            this.expSearch.Controls.Add(this.btnNextPage);
            this.expSearch.Controls.Add(this.btnPrevPage);
            this.expSearch.Controls.Add(this.lblSearchNumDate);
            this.expSearch.Controls.Add(this.lstResult);
            this.expSearch.Controls.Add(this.label4);
            this.expSearch.Controls.Add(this.btnSeacrhCancel);
            this.expSearch.Controls.Add(this.btnSearch);
            this.expSearch.Controls.Add(this.label2);
            this.expSearch.Controls.Add(this.label3);
            this.expSearch.Controls.Add(this.txtSearchNumber);
            this.expSearch.Location = new System.Drawing.Point(2, 147);
            this.expSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.expSearch.Name = "expSearch";
            this.expSearch.Size = new System.Drawing.Size(220, 521);
            this.expSearch.TabIndex = 1;
            this.expSearch.OnExpanded += new System.EventHandler(this.expSearch_OnExpanded);
            this.expSearch.OnColapsed += new System.EventHandler(this.expSearch_OnColapsed);
            // 
            // txtSearchDate
            // 
            this.txtSearchDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchDate.Location = new System.Drawing.Point(15, 81);
            this.txtSearchDate.Margin = new System.Windows.Forms.Padding(15, 0, 3, 3);
            this.txtSearchDate.Name = "txtSearchDate";
            this.txtSearchDate.Size = new System.Drawing.Size(205, 20);
            this.txtSearchDate.TabIndex = 8;
            this.txtSearchDate.TextChanged += new System.EventHandler(this.txtSearchDate_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStatus.Location = new System.Drawing.Point(14, 487);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(205, 23);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCurrentPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentPage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCurrentPage.Location = new System.Drawing.Point(14, 458);
            this.lblCurrentPage.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(205, 23);
            this.lblCurrentPage.TabIndex = 19;
            this.lblCurrentPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearchNext
            // 
            this.btnSearchNext.Enabled = false;
            this.btnSearchNext.Location = new System.Drawing.Point(119, 394);
            this.btnSearchNext.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnSearchNext.Name = "btnSearchNext";
            this.btnSearchNext.Size = new System.Drawing.Size(101, 28);
            this.btnSearchNext.TabIndex = 13;
            this.btnSearchNext.Text = "Search Next";
            this.btnSearchNext.UseVisualStyleBackColor = true;
            this.btnSearchNext.Click += new System.EventHandler(this.btnSearchNext_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Enabled = false;
            this.btnFirstPage.Location = new System.Drawing.Point(14, 394);
            this.btnFirstPage.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(101, 28);
            this.btnFirstPage.TabIndex = 12;
            this.btnFirstPage.Text = "First Page";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Enabled = false;
            this.btnNextPage.Location = new System.Drawing.Point(119, 426);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(101, 28);
            this.btnNextPage.TabIndex = 15;
            this.btnNextPage.Text = "Next Page";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Enabled = false;
            this.btnPrevPage.Location = new System.Drawing.Point(14, 426);
            this.btnPrevPage.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(101, 28);
            this.btnPrevPage.TabIndex = 14;
            this.btnPrevPage.Text = "Prev Page";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // lblSearchNumDate
            // 
            this.lblSearchNumDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSearchNumDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSearchNumDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSearchNumDate.Location = new System.Drawing.Point(15, 100);
            this.lblSearchNumDate.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblSearchNumDate.Name = "lblSearchNumDate";
            this.lblSearchNumDate.Size = new System.Drawing.Size(205, 23);
            this.lblSearchNumDate.TabIndex = 14;
            this.lblSearchNumDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstResult
            // 
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Location = new System.Drawing.Point(15, 178);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(205, 212);
            this.lstResult.TabIndex = 11;
            this.lstResult.Click += new System.EventHandler(this.lstResult_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightSlateGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(15, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Search Result";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSeacrhCancel
            // 
            this.btnSeacrhCancel.Enabled = false;
            this.btnSeacrhCancel.Location = new System.Drawing.Point(119, 128);
            this.btnSeacrhCancel.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnSeacrhCancel.Name = "btnSeacrhCancel";
            this.btnSeacrhCancel.Size = new System.Drawing.Size(101, 28);
            this.btnSeacrhCancel.TabIndex = 10;
            this.btnSeacrhCancel.Text = "Cancel";
            this.btnSeacrhCancel.UseVisualStyleBackColor = true;
            this.btnSeacrhCancel.Click += new System.EventHandler(this.btnSeacrhCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(14, 128);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 28);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightSlateGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(15, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search Number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearchNumber
            // 
            this.txtSearchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchNumber.Location = new System.Drawing.Point(15, 40);
            this.txtSearchNumber.Margin = new System.Windows.Forms.Padding(15, 0, 3, 3);
            this.txtSearchNumber.Name = "txtSearchNumber";
            this.txtSearchNumber.Size = new System.Drawing.Size(205, 20);
            this.txtSearchNumber.TabIndex = 6;
            this.txtSearchNumber.TextChanged += new System.EventHandler(this.txtSearchNumber_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // flpBottom
            // 
            this.flpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBottom.Location = new System.Drawing.Point(242, 545);
            this.flpBottom.Name = "flpBottom";
            this.flpBottom.Size = new System.Drawing.Size(788, 21);
            this.flpBottom.TabIndex = 2;
            // 
            // ucWebEx1
            // 
            this.ucWebEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWebEx1.Location = new System.Drawing.Point(242, 0);
            this.ucWebEx1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ucWebEx1.Name = "ucWebEx1";
            this.ucWebEx1.Size = new System.Drawing.Size(788, 545);
            this.ucWebEx1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 566);
            this.Controls.Add(this.ucWebEx1);
            this.Controls.Add(this.flpBottom);
            this.Controls.Add(this.flpRight);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Search Data on WebBrowser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flpRight.ResumeLayout(false);
            this.expLogin.ResumeLayout(false);
            this.expLogin.PerformLayout();
            this.expSearch.ResumeLayout(false);
            this.expSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpRight;
        private UCWebEx ucWebEx1;
        private System.Windows.Forms.Button button1;
        private UCVerExpander expLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUserName;
        private UCVerExpander expSearch;
        private System.Windows.Forms.Button btnSeacrhCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchNumber;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Button btnSearchNext;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label lblSearchNumDate;
        private System.Windows.Forms.FlowLayoutPanel flpBottom;
    }
}


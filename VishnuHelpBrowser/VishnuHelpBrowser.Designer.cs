namespace NetEti.CustomControls
{
    partial class VishnuHelpBrowser
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VishnuHelpBrowser));
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnForward = new Button();
            btnBack = new Button();
            tbxSearch = new TextBox();
            btnSearch = new Button();
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(0, 0);
            webView21.Margin = new Padding(3, 2, 3, 2);
            webView21.Name = "webView21";
            webView21.Size = new Size(1407, 667);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // btnForward
            // 
            btnForward.BackgroundImageLayout = ImageLayout.Stretch;
            btnForward.Location = new Point(55, 7);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(39, 28);
            btnForward.TabIndex = 1;
            btnForward.UseVisualStyleBackColor = true;
            btnForward.Click += btnForward_Click;
            // 
            // btnBack
            // 
            btnBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnBack.Location = new Point(12, 7);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(37, 28);
            btnBack.TabIndex = 0;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // tbxSearch
            // 
            tbxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbxSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxSearch.Location = new Point(1098, 6);
            tbxSearch.Margin = new Padding(3, 3, 7, 3);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new Size(253, 25);
            tbxSearch.TabIndex = 2;
            tbxSearch.Visible = false;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(1352, 4);
            btnSearch.Margin = new Padding(0, 0, 3, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(34, 28);
            btnSearch.TabIndex = 3;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Visible = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(btnBack);
            splitContainer1.Panel1.Controls.Add(btnForward);
            splitContainer1.Panel1.Controls.Add(tbxSearch);
            splitContainer1.Panel1.Controls.Add(btnSearch);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(webView21);
            splitContainer1.Size = new Size(1407, 699);
            splitContainer1.SplitterDistance = 28;
            splitContainer1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(127, 9);
            label1.Name = "label1";
            label1.Size = new Size(232, 17);
            label1.TabIndex = 4;
            label1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1407, 699);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Vishnu Online Help";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button btnForward;
        private Button btnBack;
        private TextBox tbxSearch;
        private Button btnSearch;
        private SplitContainer splitContainer1;
        private Label label1;
    }
}

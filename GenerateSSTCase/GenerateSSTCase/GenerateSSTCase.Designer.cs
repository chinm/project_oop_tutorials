namespace GenerateSSTCase
{
    partial class GenerateSSTCase
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtViewPointFilePath = new System.Windows.Forms.TextBox();
            this.txtSSTFilePath = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.openFileDialogViewPoint = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSST = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowseViewpointFile = new System.Windows.Forms.Button();
            this.btnBrowseSSTFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Viewpoint File Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SST File Path:";
            // 
            // txtViewPointFilePath
            // 
            this.txtViewPointFilePath.Enabled = false;
            this.txtViewPointFilePath.Location = new System.Drawing.Point(131, 18);
            this.txtViewPointFilePath.Name = "txtViewPointFilePath";
            this.txtViewPointFilePath.Size = new System.Drawing.Size(325, 20);
            this.txtViewPointFilePath.TabIndex = 2;
            // 
            // txtSSTFilePath
            // 
            this.txtSSTFilePath.Enabled = false;
            this.txtSSTFilePath.Location = new System.Drawing.Point(131, 49);
            this.txtSSTFilePath.Name = "txtSSTFilePath";
            this.txtSSTFilePath.Size = new System.Drawing.Size(325, 20);
            this.txtSSTFilePath.TabIndex = 3;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerate.Location = new System.Drawing.Point(278, 79);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(137, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate SST Case";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(421, 79);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // openFileDialogViewPoint
            // 
            this.openFileDialogViewPoint.Filter = "Excel Files|*.xls;*.xlsx";
            // 
            // openFileDialogSST
            // 
            this.openFileDialogSST.Filter = "Excel Files|*.xls;*.xlsx";
            // 
            // btnBrowseViewpointFile
            // 
            this.btnBrowseViewpointFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowseViewpointFile.Location = new System.Drawing.Point(462, 18);
            this.btnBrowseViewpointFile.Name = "btnBrowseViewpointFile";
            this.btnBrowseViewpointFile.Size = new System.Drawing.Size(31, 23);
            this.btnBrowseViewpointFile.TabIndex = 6;
            this.btnBrowseViewpointFile.Text = "...";
            this.btnBrowseViewpointFile.UseVisualStyleBackColor = true;
            this.btnBrowseViewpointFile.Click += new System.EventHandler(this.btnBrowseViewpointFile_Click);
            // 
            // btnBrowseSSTFile
            // 
            this.btnBrowseSSTFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowseSSTFile.Location = new System.Drawing.Point(462, 49);
            this.btnBrowseSSTFile.Name = "btnBrowseSSTFile";
            this.btnBrowseSSTFile.Size = new System.Drawing.Size(31, 23);
            this.btnBrowseSSTFile.TabIndex = 7;
            this.btnBrowseSSTFile.Text = "...";
            this.btnBrowseSSTFile.UseVisualStyleBackColor = true;
            this.btnBrowseSSTFile.Click += new System.EventHandler(this.btnBrowseSSTFile_Click);
            // 
            // GenerateSSTCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 114);
            this.Controls.Add(this.btnBrowseSSTFile);
            this.Controls.Add(this.btnBrowseViewpointFile);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtSSTFilePath);
            this.Controls.Add(this.txtViewPointFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GenerateSSTCase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenerateSSTCase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtViewPointFilePath;
        private System.Windows.Forms.TextBox txtSSTFilePath;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.OpenFileDialog openFileDialogViewPoint;
        private System.Windows.Forms.OpenFileDialog openFileDialogSST;
        private System.Windows.Forms.Button btnBrowseViewpointFile;
        private System.Windows.Forms.Button btnBrowseSSTFile;
    }
}


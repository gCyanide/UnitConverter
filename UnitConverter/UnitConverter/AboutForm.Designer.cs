namespace UnitConverter
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.HeaderMenuStrip = new System.Windows.Forms.MenuStrip();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.GitLabel = new System.Windows.Forms.Label();
            this.GitLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ContactLabel = new System.Windows.Forms.Label();
            this.TelegramLinkLabel = new System.Windows.Forms.LinkLabel();
            this.InfoTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.BackColor = System.Drawing.Color.BlueViolet;
            this.HeaderLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeaderLabel.ForeColor = System.Drawing.Color.White;
            this.HeaderLabel.Location = new System.Drawing.Point(5, 4);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(252, 32);
            this.HeaderLabel.TabIndex = 9;
            this.HeaderLabel.Text = "UnitConverter - About";
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.BlueViolet;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(410, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(40, 40);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "🞩";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // HeaderMenuStrip
            // 
            this.HeaderMenuStrip.AutoSize = false;
            this.HeaderMenuStrip.BackColor = System.Drawing.Color.BlueViolet;
            this.HeaderMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.HeaderMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.HeaderMenuStrip.Name = "HeaderMenuStrip";
            this.HeaderMenuStrip.Size = new System.Drawing.Size(450, 40);
            this.HeaderMenuStrip.TabIndex = 6;
            this.HeaderMenuStrip.Text = "menuStrip1";
            this.HeaderMenuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderMenuStrip_MouseDown);
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Image = global::UnitConverter.Properties.Resources.converter_png;
            this.LogoPictureBox.Location = new System.Drawing.Point(160, 45);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(128, 128);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 11;
            this.LogoPictureBox.TabStop = false;
            // 
            // GitLabel
            // 
            this.GitLabel.AutoSize = true;
            this.GitLabel.Location = new System.Drawing.Point(12, 176);
            this.GitLabel.Name = "GitLabel";
            this.GitLabel.Size = new System.Drawing.Size(49, 32);
            this.GitLabel.TabIndex = 13;
            this.GitLabel.Text = "Git:";
            // 
            // GitLinkLabel
            // 
            this.GitLinkLabel.AutoSize = true;
            this.GitLinkLabel.Location = new System.Drawing.Point(117, 176);
            this.GitLinkLabel.Name = "GitLinkLabel";
            this.GitLinkLabel.Size = new System.Drawing.Size(321, 32);
            this.GitLinkLabel.TabIndex = 14;
            this.GitLinkLabel.TabStop = true;
            this.GitLinkLabel.Text = "https://github.com/gCyanide";
            this.GitLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitLinkLabel_LinkClicked);
            // 
            // ContactLabel
            // 
            this.ContactLabel.AutoSize = true;
            this.ContactLabel.Location = new System.Drawing.Point(12, 208);
            this.ContactLabel.Name = "ContactLabel";
            this.ContactLabel.Size = new System.Drawing.Size(101, 32);
            this.ContactLabel.TabIndex = 12;
            this.ContactLabel.Text = "Contact:";
            // 
            // TelegramLinkLabel
            // 
            this.TelegramLinkLabel.AutoSize = true;
            this.TelegramLinkLabel.Location = new System.Drawing.Point(119, 208);
            this.TelegramLinkLabel.Name = "TelegramLinkLabel";
            this.TelegramLinkLabel.Size = new System.Drawing.Size(247, 32);
            this.TelegramLinkLabel.TabIndex = 15;
            this.TelegramLinkLabel.TabStop = true;
            this.TelegramLinkLabel.Text = "https://t.me/gCyanide";
            this.TelegramLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TelegramLinkLabel_LinkClicked);
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.BackColor = System.Drawing.Color.White;
            this.InfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.InfoTextBox.Location = new System.Drawing.Point(12, 243);
            this.InfoTextBox.Multiline = true;
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.ReadOnly = true;
            this.InfoTextBox.Size = new System.Drawing.Size(426, 133);
            this.InfoTextBox.TabIndex = 16;
            this.InfoTextBox.Text = "Unit Converter Widget App\r\nDistributed under the GNU GPL v3 public license. Feel " +
    "free to use anywhere and anytime.";
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.BlueViolet;
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OkButton.ForeColor = System.Drawing.Color.White;
            this.OkButton.Location = new System.Drawing.Point(0, 410);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(450, 40);
            this.OkButton.TabIndex = 17;
            this.OkButton.Text = "why the long button?";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.InfoTextBox);
            this.Controls.Add(this.TelegramLinkLabel);
            this.Controls.Add(this.GitLinkLabel);
            this.Controls.Add(this.GitLabel);
            this.Controls.Add(this.ContactLabel);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.HeaderMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.Text = "AboutForm";
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.MenuStrip HeaderMenuStrip;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label GitLabel;
        private System.Windows.Forms.LinkLabel GitLinkLabel;
        private System.Windows.Forms.Label ContactLabel;
        private System.Windows.Forms.LinkLabel TelegramLinkLabel;
        private System.Windows.Forms.TextBox InfoTextBox;
        private System.Windows.Forms.Button OkButton;
    }
}
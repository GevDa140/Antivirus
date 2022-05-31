
namespace Antivirus
{
    partial class FormMainAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainAdmin));
            this.addFileSigButton = new System.Windows.Forms.Button();
            this.addDirSigButton = new System.Windows.Forms.Button();
            this.showSigButton = new System.Windows.Forms.Button();
            this.fileScanButton = new System.Windows.Forms.Button();
            this.dirScanButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addFileSigButton
            // 
            this.addFileSigButton.Location = new System.Drawing.Point(55, 12);
            this.addFileSigButton.Name = "addFileSigButton";
            this.addFileSigButton.Size = new System.Drawing.Size(87, 60);
            this.addFileSigButton.TabIndex = 0;
            this.addFileSigButton.Text = "Добавить сигнатуру файла";
            this.addFileSigButton.UseVisualStyleBackColor = true;
            this.addFileSigButton.Click += new System.EventHandler(this.addFileSigButton_Click);
            // 
            // addDirSigButton
            // 
            this.addDirSigButton.Location = new System.Drawing.Point(148, 12);
            this.addDirSigButton.Name = "addDirSigButton";
            this.addDirSigButton.Size = new System.Drawing.Size(87, 60);
            this.addDirSigButton.TabIndex = 1;
            this.addDirSigButton.Text = "Добавить несколько сигнатур из папки";
            this.addDirSigButton.UseVisualStyleBackColor = true;
            this.addDirSigButton.Click += new System.EventHandler(this.addDirSigButton_Click);
            // 
            // showSigButton
            // 
            this.showSigButton.Location = new System.Drawing.Point(241, 12);
            this.showSigButton.Name = "showSigButton";
            this.showSigButton.Size = new System.Drawing.Size(87, 60);
            this.showSigButton.TabIndex = 2;
            this.showSigButton.Text = "Просмотр сигнатуры файла";
            this.showSigButton.UseVisualStyleBackColor = true;
            this.showSigButton.Click += new System.EventHandler(this.showSigButton_Click);
            // 
            // fileScanButton
            // 
            this.fileScanButton.Location = new System.Drawing.Point(55, 78);
            this.fileScanButton.Name = "fileScanButton";
            this.fileScanButton.Size = new System.Drawing.Size(87, 60);
            this.fileScanButton.TabIndex = 3;
            this.fileScanButton.Text = "Сканировать один файл";
            this.fileScanButton.UseVisualStyleBackColor = true;
            this.fileScanButton.Click += new System.EventHandler(this.fileScanButton_Click);
            // 
            // dirScanButton
            // 
            this.dirScanButton.Location = new System.Drawing.Point(148, 78);
            this.dirScanButton.Name = "dirScanButton";
            this.dirScanButton.Size = new System.Drawing.Size(87, 60);
            this.dirScanButton.TabIndex = 4;
            this.dirScanButton.Text = "Сканировать директорию";
            this.dirScanButton.UseVisualStyleBackColor = true;
            this.dirScanButton.Click += new System.EventHandler(this.dirScanButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(241, 78);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(87, 60);
            this.registerButton.TabIndex = 5;
            this.registerButton.Text = "Регистрация пользователя";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // FormMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 146);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.dirScanButton);
            this.Controls.Add(this.fileScanButton);
            this.Controls.Add(this.showSigButton);
            this.Controls.Add(this.addDirSigButton);
            this.Controls.Add(this.addFileSigButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Antivirus (ADM)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainAdmin_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addFileSigButton;
        private System.Windows.Forms.Button addDirSigButton;
        private System.Windows.Forms.Button showSigButton;
        private System.Windows.Forms.Button fileScanButton;
        private System.Windows.Forms.Button dirScanButton;
        private System.Windows.Forms.Button registerButton;
    }
}
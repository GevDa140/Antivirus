
namespace Antivirus
{
    partial class FormMainUser
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainUser));
            this.dirScanButton = new System.Windows.Forms.Button();
            this.scanFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dirScanButton
            // 
            this.dirScanButton.Location = new System.Drawing.Point(217, 40);
            this.dirScanButton.Name = "dirScanButton";
            this.dirScanButton.Size = new System.Drawing.Size(87, 46);
            this.dirScanButton.TabIndex = 2;
            this.dirScanButton.Text = "Сканировать директорию";
            this.dirScanButton.UseVisualStyleBackColor = true;
            this.dirScanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // scanFileButton
            // 
            this.scanFileButton.Location = new System.Drawing.Point(80, 40);
            this.scanFileButton.Name = "scanFileButton";
            this.scanFileButton.Size = new System.Drawing.Size(87, 46);
            this.scanFileButton.TabIndex = 1;
            this.scanFileButton.Text = "Сканировать один файл";
            this.scanFileButton.UseVisualStyleBackColor = true;
            this.scanFileButton.Click += new System.EventHandler(this.scanFileButton_Click);
            // 
            // FormMainUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 141);
            this.Controls.Add(this.scanFileButton);
            this.Controls.Add(this.dirScanButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainUser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Antivirus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainUser_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button dirScanButton;
        private System.Windows.Forms.Button scanFileButton;
    }
}



namespace Antivirus
{
    partial class DeletingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeletingForm));
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.delAllBtn = new System.Windows.Forms.Button();
            this.delSelectedBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox
            // 
            this.checkedListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(384, 124);
            this.checkedListBox.TabIndex = 0;
            // 
            // delAllBtn
            // 
            this.delAllBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.delAllBtn.Location = new System.Drawing.Point(0, 213);
            this.delAllBtn.Name = "delAllBtn";
            this.delAllBtn.Size = new System.Drawing.Size(384, 38);
            this.delAllBtn.TabIndex = 1;
            this.delAllBtn.Text = "Удалить все";
            this.delAllBtn.UseVisualStyleBackColor = true;
            this.delAllBtn.Click += new System.EventHandler(this.delAllBtn_Click);
            // 
            // delSelectedBtn
            // 
            this.delSelectedBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.delSelectedBtn.Location = new System.Drawing.Point(0, 175);
            this.delSelectedBtn.Name = "delSelectedBtn";
            this.delSelectedBtn.Size = new System.Drawing.Size(384, 38);
            this.delSelectedBtn.TabIndex = 2;
            this.delSelectedBtn.Text = "Удалить выбранные";
            this.delSelectedBtn.UseVisualStyleBackColor = true;
            this.delSelectedBtn.Click += new System.EventHandler(this.delSelectedBtn_Click);
            // 
            // DeletingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 251);
            this.Controls.Add(this.delSelectedBtn);
            this.Controls.Add(this.delAllBtn);
            this.Controls.Add(this.checkedListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeletingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаление заражённых файлов";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button delAllBtn;
        private System.Windows.Forms.Button delSelectedBtn;
    }
}
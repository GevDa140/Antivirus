using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using System.Windows.Forms;

namespace Antivirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetMD5FromFile(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                }
            }
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            var md5Signatures = File.ReadAllLines("Signatures.txt");
            if (md5Signatures.Contains(md5TB.Text))
            {
                statusLabel.Text = "Файл заражён!";
                statusLabel.ForeColor = Color.Red;
            }
            else
            {
                statusLabel.Text = "Файл не заражён!";
                statusLabel.ForeColor = Color.Green;
            }
        }
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "Textfiles | *.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                md5TB.Text = GetMD5FromFile(ofd.FileName);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using System.Windows.Forms;

namespace Antivirus
{
    public partial class FormMain : Form
    {
        SqlConnection conn = new SqlConnection(Program.connString);
        string rootPath;
        string[] files;
        string[] hashes;
        List<string> viruses = new List<string>();

        public FormMain()
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
            //Тест
            //md5TB.Text = GetMD5FromFile(files[0]);
            //hashes = files;
            //for (int i = 0; i < files.Length; i++)
            //{
            //    hashes[i] = GetMD5FromFile(files[i]);
            //}


            //Директория
            hashes = files;
            int count = 0;
            for (int i = 0; i < files.Length; i++)
            {
                string sql = @"SELECT count(*) FROM Signatures WHERE signature = @signature";
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql;
                conn.Open();
                hashes[i] = GetMD5FromFile(files[i]);
                command.Parameters.AddWithValue("@signature", hashes[i]);
                int sqlResult = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                if (sqlResult > 0)
                {
                    count += 1;
                    viruses.Add(files[i]);
                }
            }
            if (viruses.Count > 0)
            {
                var message = string.Join(Environment.NewLine, viruses);
                MessageBox.Show("Количество найденных вирусов: " + count + "\nЗаражённые файлы: \n" + message);
            }

            //Один файл
            //string sql = @"SELECT count(*) FROM Signatures WHERE signature = @signature";
            //SqlCommand command = conn.CreateCommand();
            //command.CommandText = sql;
            //command.Parameters.AddWithValue("@signature", md5TB.Text);
            //conn.Open();
            //int sqlResult = Convert.ToInt32(command.ExecuteScalar());
            //conn.Close();
            //if (sqlResult > 0)
            //{
            //    statusLabel.Text = "Файл заражён!";
            //    statusLabel.ForeColor = Color.Red;
            //}
            //else if (md5TB.Text.Length == 0)
            //{
            //    MessageBox.Show("Выберите файл, или введите его сигнатуру!");
            //}
            //else
            //{
            //    statusLabel.Text = "Файл не заражён!";
            //    statusLabel.ForeColor = Color.Green;
            //}
        }
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Директория
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                files = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories);
                //MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
            }

            //Один файл
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    md5TB.Text = GetMD5FromFile(ofd.FileName);
            //}
        }
    }
}

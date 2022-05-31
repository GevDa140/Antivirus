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
    public partial class FormMainAdmin : Form
    {
        SqlConnection conn = new SqlConnection(Program.connString);
        List<string> files = new List<string>();
        List<string> hashes = new List<string>();
        List<string> viruses = new List<string>();


        public FormMainAdmin()
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

        private void showSigButton_Click(object sender, EventArgs e)
        {
            string file = "0";
            string hash = "0";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                file = ofd.FileName;
                hash = GetMD5FromFile(ofd.FileName);
                MessageBox.Show("Сигнатура данного файла:\n" + hash);
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл!", "Ошибка!");
            }

        }

        private void fileScanButton_Click(object sender, EventArgs e)
        {
            bool flag;
            string file = "0";
            string hash = "0";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                flag = true;
                file = ofd.FileName;
                hash = GetMD5FromFile(ofd.FileName);
            }
            else
            {
                flag = false;
            }
            string sql = @"SELECT count(*) FROM Signatures WHERE signature = @signature";
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@signature", hash);
            conn.Open();
            int sqlResult = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            if (flag)
            {
                if (sqlResult > 0)
                {
                    var result = MessageBox.Show("Файл заражён!\nУдалить?", "Обнаружен вирус!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(file);
                            MessageBox.Show("Найденные вирусы успешно удалены!");
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Файл не заражён!");
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл!", "Ошибка!");
            }
        }

        private void dirScanButton_Click(object sender, EventArgs e)
        {
            bool flag;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult res = fbd.ShowDialog();
            if (res == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                flag = true;
                try
                {
                    files = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories).ToList();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                flag = false;
            }


            int count = 0;
            for (int i = 0; i < files.Count; i++)
            {
                string sql = @"SELECT count(*) FROM Signatures WHERE signature = @signature";
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql;
                conn.Open();
                hashes.Add(GetMD5FromFile(files[i]));
                command.Parameters.AddWithValue("@signature", hashes[i]);
                int sqlResult = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                if (sqlResult > 0)
                {
                    count += 1;
                    viruses.Add(files[i]);
                }
            }
            if(flag)
            {
                if (viruses.Count > 0)
                {
                    var message = string.Join(Environment.NewLine, viruses);
                    var result = MessageBox.Show("Количество найденных вирусов: " + count + "\nЗаражённые файлы: \n" + message + "\nУдалить заражённые файлы?", "Найдены вирусы!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (var virus in viruses)
                        {
                            File.Delete(virus);
                        }
                        MessageBox.Show("Найденные вирусы успешно удалены!");
                    }
                }
                else
                {
                    MessageBox.Show("Вирусов не найдено!");
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл!", "Ошибка!");
            }
            files.Clear();
            hashes.Clear();
            viruses.Clear();
        }

        private void addFileSigButton_Click(object sender, EventArgs e)
        {
            //string file = "0";
            bool flag;
            string hash = "0";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //file = ofd.FileName;
                hash = GetMD5FromFile(ofd.FileName);
                flag = true;
            }
            else
            {
                flag = false;
            }
            string sql = @"INSERT INTO Signatures (signature) VALUES (@signature)";
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@signature", hash);
            conn.Open();
            int sqlAdd = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            if (flag)
            {
                MessageBox.Show("Сигнатура успешно добавлена!");
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл!", "Ошибка!");
            }
        }

        private void addDirSigButton_Click(object sender, EventArgs e)
        {
            bool flag;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult res = fbd.ShowDialog();
            if (res == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                flag = true;
                try
                {
                    files = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories).ToList();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                flag = false;
            }

            if (flag)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string sql = @"INSERT INTO Signatures (signature) VALUES (@signature)";
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = sql;
                    hashes.Add(GetMD5FromFile(files[i]));
                    command.Parameters.AddWithValue("@signature", hashes[i]);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                var message = string.Join(Environment.NewLine, files);
                MessageBox.Show("В базу данных добавлены сигнатуры следующих файлов:\n" + message, "База заражённых файлов обновлена!");
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл!", "Ошибка!");
            }
        }

        private void FormMainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("Вы хотите закрыть программу?",
            "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
            DialogResult.Yes;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm.rf.ShowForm();
        }
    }
}

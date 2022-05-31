using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Antivirus
{
    public partial class RegisterForm : Form
    {
        SqlConnection conn = new SqlConnection(Program.connString);
        public RegisterForm()
        {
            InitializeComponent();
        }

        private static RegisterForm regform;

        public static RegisterForm rf
        {
            get
            {
                if (regform == null || regform.IsDisposed) regform = new RegisterForm();
                return regform;
            }
        }

        public void ShowForm()
        {
            Show();
            Activate();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("usp_Login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", emailTextbox.Text);
            cmd.Parameters.AddWithValue("@password", passwordTextbox.Text);
            conn.Open();
            int userExists = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            if (userExists == 0)
            {
                SqlCommand reg = new SqlCommand("usp_Register", conn);
                reg.CommandType = CommandType.StoredProcedure;
                reg.Parameters.AddWithValue("@email", emailTextbox.Text);
                reg.Parameters.AddWithValue("@password", passwordTextbox.Text);
                conn.Open();
                reg.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Пользователь успешно создан!", "Успех!");
                emailTextbox.Clear();
                passwordTextbox.Clear();
            }
            else
            {
                MessageBox.Show("Данный пользователь уже существует!", "Ошибка!");
                emailTextbox.Clear();
                passwordTextbox.Clear();
            }
        }
    }
}

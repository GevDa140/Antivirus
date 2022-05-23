﻿using System;
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
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection(Program.connString);
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("usp_Login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", emailTextbox.Text);
            cmd.Parameters.AddWithValue("@password", passwordTextbox.Text);

            conn.Open();
            int loginResult = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            if (loginResult == 1)
            {
                MessageBox.Show("Добро пожаловать!");
                FormMain f = new FormMain();
                f.Left = this.Left;
                f.Top = this.Top;
                f.Show();
                f.Closed += (s, args) => this.Close();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Данные не верны!");
            }
        }
    }
}

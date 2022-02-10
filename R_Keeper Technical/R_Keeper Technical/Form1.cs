using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R_Keeper_Technical
{
    public partial class Form1 : Form
    {
        DB db = new DB();
        private static int KAcc = 0;
        private string Login;
        private string Password;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLogIN_Click(object sender, EventArgs e)
        {
            Login = textBoxLogin.Text;
            Password = textBoxPassword.Text;
            Ping myPing = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 10000;
            PingOptions pingOptions = new PingOptions();
            PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
            if (reply.Status == IPStatus.Success)
            {

                MySqlCommand command = new MySqlCommand("SELECT * FROM `rktechnicalusers`", db.getConnection());
                db.OpenConnection();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                    {
                        if (Login == reader.GetString("BaseLogin") && Password == reader.GetString("BasePassword"))
                        {
                            KAcc++;
                        }
                    }
                }
                db.CloseConnection();
                if(KAcc > 0)
                {
                    FileSystem.RKeeperLog("Authorization in R-Keeper Technical");
                    Main main = new Main();
                    main.BaseLogin = this.Login;
                    main.BasePassword = this.Password;
                    main.TopMost = true;
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный пароль и/или логин!", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }             
            }
            else
            {
                MessageBox.Show("Отсутствует соединение с интернетом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if(!File.Exists(@"rk7man.bat") || !File.Exists(@"rk7man.ini"))
            //{
            //    MessageBox.Show("R Keeper не был обнаружен!\nR_Kepper Technical должен находится в папке R Keeper", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    Application.Exit();
            //}
        }
    }
}

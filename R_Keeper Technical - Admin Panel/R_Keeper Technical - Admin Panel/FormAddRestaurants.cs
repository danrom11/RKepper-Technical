using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R_Keeper_Technical___Admin_Panel
{
    public partial class FormAddRestaurants : Form
    {
        DB db = new DB();

        public Form1 OwnerForm { get; set; }

        public FormAddRestaurants()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string NameRestaurant = textBoxNameRes.Text;
            string IP = textBoxIP.Text;
            string Port = textBoxP.Text;
            string ServerName = textBoxSN.Text;

            if (NameRestaurant.Trim().Length > 0 && IP.Trim().Length > 0 && Port.Trim().Length > 0 && ServerName.Trim().Length > 0)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `rktechnicalrestaurants`", db.getConnection());
                //command.Parameters.Add("@Key", MySqlDbType.VarChar).Value = Key;

                db.OpenConnection();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                    {
                        if (NameRestaurant == reader.GetString("NameRestaurant"))
                        {
                            MessageBox.Show("Такое имя ресторана уже существует", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            db.CloseConnection();
                            return;
                        }
                    }
                }
                db.CloseConnection();
                AddRestaurant(NameRestaurant, IP, Port, ServerName);
            }
        }

        private void AddRestaurant(string NameRestaurant, string IP, string Port, string ServerName)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `rktechnicalrestaurants` (`ID`, `NameRestaurant`, `IP`, `Port`, `ServerName`) VALUES (NULL, @NAMERESTURE, @IP, @PORT, @SERVERNAME);", db.getConnection());

            command.Parameters.Add("@NAMERESTURE", MySqlDbType.VarChar).Value = NameRestaurant;
            command.Parameters.Add("@IP", MySqlDbType.VarChar).Value = IP;
            command.Parameters.Add("@PORT", MySqlDbType.VarChar).Value = Port;
            command.Parameters.Add("@SERVERNAME", MySqlDbType.VarChar).Value = ServerName;


            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успешно добавлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = (Form1)this.OwnerForm;
                form1.LoadBaseRestaurants();
                this.Close();
            }
            else
            {
                MessageBox.Show("Критическая оишбка базы добавления!", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.CloseConnection();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSN_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNameRes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

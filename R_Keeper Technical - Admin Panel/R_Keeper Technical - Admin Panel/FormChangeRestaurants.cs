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
    public partial class FormChangeRestaurants : Form
    {
        DB db = new DB();

        public Form OwnerForm { get; set; }
        public string ID { get; set; }
        public string NameRestaurant { get; set; }
        public string ServerName { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }

        public FormChangeRestaurants()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
             NameRestaurant = textBoxNameRes.Text;
             IP = textBoxIP.Text;
             Port = textBoxP.Text;
             ServerName = textBoxSN.Text;

            if (NameRestaurant.Trim().Length > 0 && IP.Trim().Length > 0 && Port.Trim().Length > 0 && ServerName.Trim().Length > 0)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `rktechnicalrestaurants`", db.getConnection());

                db.OpenConnection();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                    {
                        if (NameRestaurant == reader.GetString("NameRestaurant") && ID != reader.GetString("ID"))
                        {
                            MessageBox.Show("Такое имя ресторана уже существует", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            db.CloseConnection();
                            return;
                        }
                    }
                }
                db.CloseConnection();
                UpdateRestaurant(ID, NameRestaurant, IP, Port, ServerName);
            }
        }

        private void UpdateRestaurant(string ID, string NameRestaurant, string IP, string Port, string ServerName)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `rktechnicalrestaurants` SET `NameRestaurant` = @NAMERESTURE, `IP` = @IP, `Port` = @PORT, `ServerName` = @SERVERNAME WHERE `rktechnicalrestaurants`.`ID` = @ID", db.getConnection());

            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = ID;
            command.Parameters.Add("@NAMERESTURE", MySqlDbType.VarChar).Value = NameRestaurant;
            command.Parameters.Add("@IP", MySqlDbType.VarChar).Value = IP;
            command.Parameters.Add("@PORT", MySqlDbType.VarChar).Value = Port;
            command.Parameters.Add("@SERVERNAME", MySqlDbType.VarChar).Value = ServerName;


            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успешно Изменено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FormChangeRestaurants_Load(object sender, EventArgs e)
        {
            textBoxNameRes.Text = NameRestaurant;
            textBoxIP.Text = IP;
            textBoxP.Text = Port;
            textBoxSN.Text = ServerName;
        }
    }
}

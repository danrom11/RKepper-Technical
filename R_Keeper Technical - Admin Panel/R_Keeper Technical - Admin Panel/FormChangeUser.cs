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
    public partial class FormChangeUser : Form
    {
        DB db = new DB();
        public Form OwnerForm { get; set; }
        public string ID { get; set; }
        public string FCs { get; set; }
        public string KeeperLogin { get; set; }
        public string KeeperPassword { get; set; }
        public string BaseLogin { get; set; }
        public string BasePassword { get; set; }
        public string Restaurants { get; set; }


        private string RestaurantsUpdate = "";

        public FormChangeUser()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
             FCs = textBoxFCs.Text;
             KeeperLogin = textBoxKL.Text;
             KeeperPassword = textBoxKP.Text;
             BaseLogin = textBoxBL.Text;
             BasePassword = textBoxBP.Text;

            foreach (var index in checkedListBoxRestaurants.CheckedIndices)
            {
                RestaurantsUpdate += checkedListBoxRestaurants.Items[(int)index] + ";";
            }

            if (FCs.Trim().Length > 0 && KeeperLogin.Trim().Length > 0 && KeeperPassword.Trim().Length > 0 && BaseLogin.Trim().Length > 0 && BasePassword.Trim().Length > 0 && Restaurants.Trim().Length > 0)
            {

                MySqlCommand command = new MySqlCommand("SELECT * FROM `rktechnicalusers`", db.getConnection());

                db.OpenConnection();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                    {
                        if (BaseLogin == reader.GetString("BaseLogin") && BasePassword == reader.GetString("BasePassword") && ID != reader.GetString("ID"))
                        {
                            MessageBox.Show("Такой логин и пароль уже используется", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            db.CloseConnection();
                            return;
                        }
                    }
                }
                db.CloseConnection();
                ResUser(FCs, KeeperLogin, KeeperPassword, BaseLogin, BasePassword, RestaurantsUpdate);
            }
        }

        private void ResUser(string FCs, string KeeperLogin, string KeeperPassword, string BaseLogin, string BasePassword, string Restaurants)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `rktechnicalusers` SET `FCs` = @FCS, `KeeperLogin` = @KEEPERLOGIN, `KeeperPassword` = @KEEPERPASSWORD, `BaseLogin` = @BASELOGIN, `BasePassword` = @BASEPASSWORD, `Restaurants` = @RESTAURANTS WHERE `rktechnicalusers`.`ID` = @ID", db.getConnection());

            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = ID;
            command.Parameters.Add("@FCS", MySqlDbType.VarChar).Value = FCs;
            command.Parameters.Add("@KEEPERLOGIN", MySqlDbType.VarChar).Value = KeeperLogin;
            command.Parameters.Add("@KeeperPassword", MySqlDbType.VarChar).Value = KeeperPassword;
            command.Parameters.Add("@BASELOGIN", MySqlDbType.VarChar).Value = BaseLogin;
            command.Parameters.Add("@BASEPASSWORD", MySqlDbType.VarChar).Value = BasePassword;
            command.Parameters.Add("@RESTAURANTS", MySqlDbType.VarChar).Value = Restaurants;


            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успешно Изменено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = (Form1)this.OwnerForm;
                form1.LoadBaseUsers();
                this.Close();
            }
            else
            {
                MessageBox.Show("Критическая оишбка базы добавления!", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.CloseConnection();
        }

        private void FormChangeUser_Load(object sender, EventArgs e)
        {
            textBoxFCs.Text = FCs;
            textBoxKL.Text = KeeperLogin;
            textBoxKP.Text = KeeperPassword;
            textBoxBL.Text = BaseLogin;
            textBoxBP.Text = BasePassword;

            string[] resSplit = new string[] { };

            resSplit = Restaurants.Split(';');

     

            MySqlCommand command = new MySqlCommand("SELECT * FROM `rktechnicalrestaurants`", db.getConnection());

            db.OpenConnection();

            string NameRestaurant = null;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                {

                    NameRestaurant = reader.GetString("NameRestaurant");
                    checkedListBoxRestaurants.Items.Add(NameRestaurant, CheckRes(NameRestaurant, resSplit));

                }
            }

            db.CloseConnection();
        }
        private bool CheckRes(string nameRestaurant, string[] resSplit)
        {
            bool chek = false;
            for(int i = 0; i < resSplit.Length; i++)
            {
                if (nameRestaurant.Trim() == resSplit[i].Trim())
                {
                    chek = true;
                }
                    
            }
            return chek;
        }
    }
}

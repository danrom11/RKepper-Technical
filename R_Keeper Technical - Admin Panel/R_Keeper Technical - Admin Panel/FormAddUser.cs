using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace R_Keeper_Technical___Admin_Panel
{
    public partial class FormAddUser : Form
    {
        public Form OwnerForm { get; set; }

        DB db = new DB();
        public FormAddUser()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string FCs = textBoxFCs.Text;
            string KeeperLogin = textBoxKL.Text;
            string KeeperPassword = textBoxKP.Text;
            string BaseLogin = textBoxBL.Text;
            string BasePassword = textBoxBP.Text;

            string Restaurants = "";
            foreach (var index in checkedListBoxRestaurants.CheckedIndices)
            {
                Restaurants += checkedListBoxRestaurants.Items[(int)index] + ";";
            }

            if (FCs.Trim().Length > 0 && KeeperLogin.Trim().Length > 0 && KeeperPassword.Trim().Length > 0 && BaseLogin.Trim().Length > 0 && BasePassword.Trim().Length > 0 && Restaurants.Trim().Length > 0)
            {

                MySqlCommand command = new MySqlCommand("SELECT * FROM `rktechnicalusers`", db.getConnection());

                db.OpenConnection();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                    {
                        if (BaseLogin == reader.GetString("BaseLogin") && BasePassword == reader.GetString("BasePassword"))
                        {
                            MessageBox.Show("Такой логин и пароль уже используется", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            db.CloseConnection();
                            return;
                        }
                    }
                }
                db.CloseConnection();
                AddUser(FCs, KeeperLogin, KeeperPassword, BaseLogin, BasePassword, Restaurants);
            }
        }

        private void AddUser(string FCs, string KeeperLogin, string KeeperPassword, string BaseLogin, string BasePassword, string Restaurants)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `rktechnicalusers` (`ID`, `FCs`, `KeeperLogin`, `KeeperPassword`, `BaseLogin`, `BasePassword`, `Restaurants`) VALUES (NULL, @FCS, @KEEPERLOGIN, @KEEPERPASSWORD, @BASELOGIN, @BASEPASSWORD, @RESTAURANTS);", db.getConnection());


            command.Parameters.Add("@FCS", MySqlDbType.VarChar).Value = FCs;
            command.Parameters.Add("@KEEPERLOGIN", MySqlDbType.VarChar).Value = KeeperLogin;
            command.Parameters.Add("@KEEPERPASSWORD", MySqlDbType.VarChar).Value = KeeperPassword;
            command.Parameters.Add("@BASELOGIN", MySqlDbType.VarChar).Value = BaseLogin;
            command.Parameters.Add("@BASEPASSWORD", MySqlDbType.VarChar).Value = BasePassword;
            command.Parameters.Add("@RESTAURANTS", MySqlDbType.VarChar).Value = Restaurants;


            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успешно добавлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FormAddUser_Load(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rktechnicalrestaurants`", db.getConnection());

            db.OpenConnection();

            string NameRestaurant = null;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                {
                    NameRestaurant = reader.GetString("NameRestaurant");
                    checkedListBoxRestaurants.Items.Add(NameRestaurant);
                }
            }

            db.CloseConnection();
        }
    }
}

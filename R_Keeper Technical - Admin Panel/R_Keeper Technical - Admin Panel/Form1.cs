using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace R_Keeper_Technical___Admin_Panel
{
    public partial class Form1 : Form
    {
        DB db = new DB();

        public Form1()
        {
            InitializeComponent();
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            LoadBaseUsers();
        }

        public void LoadBaseUsers()
        {
            dataGridView1.Rows.Clear();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `rktechnicalusers`", db.getConnection());

            db.OpenConnection();

            string ID = null;         
            string FCs = null;
            string KeeperLogin = null;
            string KeeperPassword = null;
            string BaseLogin = null;
            string BasePassword = null;
            string Restaurants = null;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                {
                    ID = reader.GetString("ID");
                    FCs = reader.GetString("FCs");
                    KeeperLogin = reader.GetString("KeeperLogin");
                    KeeperPassword = reader.GetString("KeeperPassword");
                    BaseLogin = reader.GetString("BaseLogin");
                    BasePassword = reader.GetString("BasePassword");
                    Restaurants = reader.GetString("Restaurants");
                    dataGridView1.Rows.Add(ID, FCs, KeeperLogin, KeeperPassword, BaseLogin, BasePassword, Restaurants, false);
                }
            }

            db.CloseConnection();
        }
        public void LoadBaseRestaurants()
        {
            dataGridView3.Rows.Clear();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `rktechnicalrestaurants`", db.getConnection());

            db.OpenConnection();

            string ID = null;
            string NameRestaurant = null;
            string ServerName = null;
            string IP = null;
            string Port = null;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                {
                    ID = reader.GetString("ID");
                    NameRestaurant = reader.GetString("NameRestaurant");
                    ServerName = reader.GetString("ServerName");
                    IP = reader.GetString("IP");
                    Port = reader.GetString("Port");
                    dataGridView3.Rows.Add(ID, NameRestaurant, ServerName, IP, Port, false);
                }
            }

            db.CloseConnection();
        }
        public void LoadBaseLog()
        {
            dataGridView2.Rows.Clear();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `logger`", db.getConnection());

            db.OpenConnection();

            string ID = null;
            string FCs = null;
            string Log = null;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                {
                    ID = reader.GetString("ID");
                    FCs = reader.GetString("Fcs");
                    Log = reader.GetString("Log");
                    dataGridView2.Rows.Add(ID, FCs, Log, false);
                }
            }

            db.CloseConnection();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Visible == true)
            {
                FormAddUser formAddUser = new FormAddUser();
                formAddUser.OwnerForm = this;
                formAddUser.Show();
            }
            if (dataGridView3.Visible == true)
            {
                FormAddRestaurants formAddRestaurants = new FormAddRestaurants();
                formAddRestaurants.OwnerForm = this;
                formAddRestaurants.Show();
            }                  
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if(dataGridView1.Visible == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[7].Value == true)
                    {
                        DeletedRowsUsers((string)dataGridView1.Rows[i].Cells[0].Value);
                    }
                }
                LoadBaseUsers();
                MessageBox.Show("Выделенные строки удалены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(dataGridView2.Visible == true)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if ((bool)dataGridView2.Rows[i].Cells[3].Value == true)
                    {
                        DeletedRowsBDLog((string)dataGridView2.Rows[i].Cells[0].Value);
                    }
                }
                LoadBaseLog();
                MessageBox.Show("Выделенные строки удалены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (dataGridView3.Visible == true)
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if ((bool)dataGridView3.Rows[i].Cells[5].Value == true)
                    {
                        DeletedRowsRestaurants((string)dataGridView3.Rows[i].Cells[0].Value);
                    }
                }
                LoadBaseLog();
                MessageBox.Show("Выделенные строки удалены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeletedRowsUsers(string id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `rktechnicalusers` WHERE `ID` = @ID", db.getConnection());
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;

            db.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("Удалён id: " + id);
            }
            else
            {
                MessageBox.Show("Ошибка удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.CloseConnection();
        }
        private void DeletedRowsRestaurants(string id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `rktechnicalrestaurants` WHERE `ID` = @ID", db.getConnection());
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;

            db.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("Удалён id: " + id);
            }
            else
            {
                MessageBox.Show("Ошибка удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.CloseConnection();
        }
        private void DeletedRowsBDLog(string id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `logger` WHERE `ID` = @ID", db.getConnection());
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;

            db.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("Удалён id: " + id);
            }
            else
            {
                MessageBox.Show("Ошибка удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.CloseConnection();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if(dataGridView1.Visible == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[7].Value == true)
                    {
                        FormChangeUser formChangeUser = new FormChangeUser();
                        formChangeUser.OwnerForm = this;
                        formChangeUser.ID = (string)dataGridView1.Rows[i].Cells[0].Value;
                        formChangeUser.FCs = (string)dataGridView1.Rows[i].Cells[1].Value;
                        formChangeUser.KeeperLogin = (string)dataGridView1.Rows[i].Cells[2].Value;
                        formChangeUser.KeeperPassword = (string)dataGridView1.Rows[i].Cells[3].Value;
                        formChangeUser.BaseLogin = (string)dataGridView1.Rows[i].Cells[4].Value;
                        formChangeUser.BasePassword = (string)dataGridView1.Rows[i].Cells[5].Value;
                        formChangeUser.Restaurants = (string)dataGridView1.Rows[i].Cells[6].Value;
                        formChangeUser.Show();
                    }
                }
            }
            if(dataGridView3.Visible == true)
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if ((bool)dataGridView3.Rows[i].Cells[5].Value == true)
                    {
                        FormChangeRestaurants formChangeRestaurants = new FormChangeRestaurants();
                        formChangeRestaurants.OwnerForm = this;
                        formChangeRestaurants.ID = (string)dataGridView3.Rows[i].Cells[0].Value;
                        formChangeRestaurants.NameRestaurant = (string)dataGridView3.Rows[i].Cells[1].Value;
                        formChangeRestaurants.ServerName = (string)dataGridView3.Rows[i].Cells[2].Value;
                        formChangeRestaurants.IP = (string)dataGridView3.Rows[i].Cells[3].Value;
                        formChangeRestaurants.Port = (string)dataGridView3.Rows[i].Cells[4].Value;
                        formChangeRestaurants.Show();
                    }
                }
            }
                  
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible == true)
             LoadBaseUsers();
            if (dataGridView2.Visible == true)
             LoadBaseLog();
        }

        private void админПанельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            label1.Text = "Панель Пользователей";
            LoadBaseUsers();
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            добавитьToolStripMenuItem1.Enabled = true;
            изменитьToolStripMenuItem.Enabled = true;
        }

        private void логиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            label1.Text = "Логи";
            LoadBaseLog();
            dataGridView1.Visible = false;
            dataGridView3.Visible = false;

            добавитьToolStripMenuItem1.Enabled = false;
            изменитьToolStripMenuItem.Enabled = false;
        }

        private void панельРеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView3.Visible = true;
            label1.Text = "Панель ресторанов";
            LoadBaseRestaurants();
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;

            добавитьToolStripMenuItem1.Enabled = true;
            изменитьToolStripMenuItem.Enabled = true;
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                FormChangeRestaurants formChangeRestaurants = new FormChangeRestaurants();
                formChangeRestaurants.OwnerForm = this;
                formChangeRestaurants.ID = (string)dataGridView3.Rows[e.RowIndex].Cells[0].Value;
                formChangeRestaurants.NameRestaurant = (string)dataGridView3.Rows[e.RowIndex].Cells[1].Value;
                formChangeRestaurants.ServerName = (string)dataGridView3.Rows[e.RowIndex].Cells[2].Value;
                formChangeRestaurants.IP = (string)dataGridView3.Rows[e.RowIndex].Cells[3].Value;
                formChangeRestaurants.Port = (string)dataGridView3.Rows[e.RowIndex].Cells[4].Value;
                formChangeRestaurants.Show();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                FormChangeUser formChangeUser = new FormChangeUser();
                formChangeUser.OwnerForm = this;
                formChangeUser.ID = (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                formChangeUser.FCs = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                formChangeUser.KeeperLogin = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                formChangeUser.KeeperPassword = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                formChangeUser.BaseLogin = (string)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                formChangeUser.BasePassword = (string)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                formChangeUser.Restaurants = (string)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
                formChangeUser.Show();             
            }
        }
    }
}

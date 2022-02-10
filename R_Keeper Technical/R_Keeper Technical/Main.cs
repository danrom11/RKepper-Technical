using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace R_Keeper_Technical
{
    public partial class Main : Form
    {
        DB db = new DB();


        ManagementEventWatcher startWatchRK7 = new ManagementEventWatcher(
                new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace WHERE ProcessName = \"rk7man.exe\""));
        ManagementEventWatcher stopWatchRK7 = new ManagementEventWatcher(
                new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace WHERE ProcessName = \"rk7man.exe\""));

        public string BaseLogin { get; set; }
        public string BasePassword { get; set; }


        private string ID;
        private string NameRestaurant;
        private string FCs;
        private string KeeperLogin;
        private string KeeperPassword;
        private string IP;
        private string Port;
        private string ServerName;

        private string[] RestaurantSplit = new string[] { };


        public Main()
        {
            InitializeComponent();
            stopWatchRK7.EventArrived += StopWatchRK7_EventArrived;
            startWatchRK7.EventArrived += StartWatchRK7_EventArrived;
        }

        

        private void StopWatchRK7_EventArrived(object sender, EventArrivedEventArgs e)
        {
            FileSystem.SendLog(FCs, ID, "Log out");
            //Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadInformations(BaseLogin, BasePassword);
        }

        private void LoadInformations(string login, string passwrod)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rktechnicalusers`", db.getConnection());
            db.OpenConnection();
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                {
                    if (login == reader.GetString("BaseLogin") && passwrod == reader.GetString("BasePassword"))
                    {
                        ID = reader.GetString("ID");
                        NameRestaurant = reader.GetString("Restaurants");
                        FCs = reader.GetString("FCs");
                        KeeperLogin = reader.GetString("KeeperLogin");
                        KeeperPassword = reader.GetString("KeeperPassword");
                        RestaurantSplit = NameRestaurant.Split(';');
                        //comboBoxRestauran.Items.Add(reader.GetString("NameRestaurant"));
                    }
                }
            }
            db.CloseConnection();
            
            for(int i = 0; i < RestaurantSplit.Length; i++)
            {
                if(RestaurantSplit[i].Trim().Length > 0)
                {
                    dataGridView1.Rows.Add(RestaurantSplit[i]);
                }
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                NameRestaurant = (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                MySqlCommand command = new MySqlCommand("SELECT * FROM `rktechnicalrestaurants`", db.getConnection());
                db.OpenConnection();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // reader.Read() возвращает true и переходит к следующему ряду.
                    {
                        if (NameRestaurant == reader.GetString("NameRestaurant"))
                        {
                            IP = reader.GetString("IP");
                            Port = reader.GetString("Port");
                            ServerName = reader.GetString("ServerName");
                        }
                    }
                }
                db.CloseConnection();


                //createRK
                if (!Directory.Exists(@"Rk7Manager_" + NameRestaurant))
                {
                    Directory.CreateDirectory(@"Rk7Manager_" + NameRestaurant);
                    DirectoryCopy(@"Rk7Manager", @"Rk7Manager_" + NameRestaurant, true);
                }


                FileSystem.WriteFileRk7(KeeperLogin, BaseLogin, ServerName, IP, Port, "Rk7Manager_" + NameRestaurant);
                FileSystem.WriteFileBat("Rk7Manager_" + NameRestaurant);
                Process.Start(@"Rk7Manager_" + NameRestaurant + "\\" + "rk7man.bat");
               // this.Hide();
                stopWatchRK7.Start();
                startWatchRK7.Start();
            }
        }

        private void StartWatchRK7_EventArrived(object sender, EventArrivedEventArgs e)
        {
            FileSystem.InputRKeeper(NameRestaurant, KeeperPassword, FCs, ID);     
            startWatchRK7.Stop();
        }


        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
             
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R_Keeper_Technical
{
    static public class FileSystem
    {

        static DB db = new DB();

        const int WM_SETTEXT = 0x000C;
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;

        private static class WindowsFinder
        {
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        static bool IsValidHandle(IntPtr hWnd)
        {
            return hWnd != IntPtr.Zero;
        }

        public static void WriteFileRk7(string login, string baseLogin, string serverName, string ip, string port, string patch)
        {
            using (StreamWriter stream = new StreamWriter(@patch + "\\" + "rk7man.ini", false))
            {
                stream.WriteLine("[REFEDIT]");
                stream.WriteLine("UserName=" + login);
                stream.WriteLine("Client=" + login + "-%RANDOM%");
                stream.WriteLine("Server=" + serverName);
                stream.WriteLine("LOCKONEDIT=0");
                stream.WriteLine("LongTimeout=200000");
                stream.WriteLine("[NETKERN]");
                stream.WriteLine("PROTOCOLS=tcpsoc.dll");
                stream.WriteLine("[TCPSOC]");
                stream.WriteLine("LISTEN=0");
                stream.WriteLine("PORT=" + port);
                stream.WriteLine("[TCPDNS]");
                stream.WriteLine(serverName + "=" + ip + ":" + port);
                stream.Close();
            }
        }
        public static void WriteFileBat(string patch )
        {
            using (StreamWriter stream = new StreamWriter(@patch + "\\" + "rk7man.bat", false, System.Text.Encoding.GetEncoding(866)))
            {
                stream.WriteLine("REM RK7Man update and start");
                stream.WriteLine("cd " + patch);
                stream.WriteLine("SET PRELOADPATH=.\\PRELOAD");
                stream.WriteLine("if /%1 == / goto defini");
                stream.WriteLine("SET CASHINIPATH=%1");
                stream.WriteLine("goto now_run");
                stream.WriteLine(":defini");
                stream.WriteLine("SET CASHINIPATH=.\\rk7man.ini");
                stream.WriteLine(":now_run");
                stream.WriteLine("");
                stream.WriteLine("preload.exe %CASHINIPATH%");
                stream.WriteLine("for %%c in (%PRELOADPATH%\\*.dll) do del /F %%~nc.bak");
                stream.WriteLine("for %%c in (%PRELOADPATH%\\*.dll) do ren %%~nc.dll *.bak");
                stream.WriteLine("");
                stream.WriteLine("if not EXIST rk7copy.exe goto nork7copy");
                stream.WriteLine("");
                stream.WriteLine("rk7copy %PRELOADPATH% .\\ /S /C");
                stream.WriteLine("goto continue");
                stream.WriteLine("");
                stream.WriteLine(":nork7copy");
                stream.WriteLine("echo rk7copy.exe not found");
                stream.WriteLine("xcopy %PRELOADPATH% .\\ /S /C /R /Y");
                stream.WriteLine("");
                stream.WriteLine(":continue");
                stream.WriteLine("rmdir %PRELOADPATH% /S /Q");
                stream.WriteLine("start FSupdate.exe /console sch");
                stream.WriteLine("start \"\" rk7man.exe %CASHINIPATH%");
                stream.Close();
            }
        }

        public static void SendLog(string fcs, string id, string log)
        {
            string logText = DateTime.Now + " | " + "Client ID -> " + id + " | " + "Fcs -> " + fcs + " | " + "Log -> " + log;
            MySqlCommand command = new MySqlCommand("INSERT INTO `logger` (`ID`, `Fcs`, `Log`) VALUES (NULL, @FCS, @LOG);", db.getConnection());
            command.Parameters.Add("@FCS", MySqlDbType.VarChar).Value = fcs;
            command.Parameters.Add("@LOG", MySqlDbType.VarChar).Value = logText;


            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                FileSystem.RKeeperLog("Sending a log to the server");
            }
            else
            {
                FileSystem.RKeeperLog("Error sending log to server");
            }

            db.CloseConnection();
        }

        public static void RKeeperLog(string log)
        {
            using (StreamWriter stream = new StreamWriter(@"R-Keeper Technical.log", true))
            {
                stream.WriteLine(DateTime.Now + " | " + "Log -> " + log);
                stream.Close();
            }
        }

        async public static void InputRKeeper(string NameRestaurant, string password, string Fcs, string ID)
        {
            Console.WriteLine("1");
            while (true)
            {
                await Task.Delay(1000);
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(@"Rk7Manager_" + NameRestaurant + "/rk7man.exe");
                string versionNameRkeeper = myFileVersionInfo.FileVersion;
                Console.WriteLine(versionNameRkeeper);
                //"Вход в систему R-Keeper 7 (станция менеджера) "
                //"Login R-Keeper 7 Manager Station "
                IntPtr hWindow = WindowsFinder.FindWindow(null, "Вход в систему R-Keeper 7 (станция менеджера) " + versionNameRkeeper);
                if (!IsValidHandle(hWindow))
                {
                    IntPtr hWindow2 = WindowsFinder.FindWindow(null, "Login R-Keeper 7 Manager Station " + versionNameRkeeper);
                    if (!IsValidHandle(hWindow2))
                    {
                        
                    }
                    else
                    {
                        Console.WriteLine("2");
                        EnterRKeeper(hWindow2, password, Fcs, ID, NameRestaurant);
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("3");
                    EnterRKeeper(hWindow, password, Fcs, ID, NameRestaurant);
                    break;
                }
            }
                               
        }

        async private static void EnterRKeeper(IntPtr hWindow, string password, string FCs, string ID, string NameRestaurant)
        {
            IntPtr Passwrod;
            IntPtr TaskEdit1;
            IntPtr BtnOK;
            IntPtr LabelLoad;
            while (true)
            {
                await Task.Delay(1000);

                hWindow = WindowsFinder.FindWindowEx(hWindow, IntPtr.Zero, "TPanel", null);

                LabelLoad = WindowsFinder.FindWindowEx(hWindow, IntPtr.Zero, "TcxLabel", "Загрузка...");

                if (!IsValidHandle(LabelLoad))
                {
                    LabelLoad = WindowsFinder.FindWindowEx(hWindow, IntPtr.Zero, "TcxLabel", "Loading...");
                    if (!IsValidHandle(LabelLoad))
                        break;
                }
                    

                TaskEdit1 = WindowsFinder.FindWindowEx(hWindow, IntPtr.Zero, "TcxMaskEdit", null);

                Passwrod = WindowsFinder.FindWindowEx(TaskEdit1, IntPtr.Zero, "TcxCustomInnerTextEdit.UnicodeClass", null);
                SendMessage((IntPtr)Passwrod, WM_SETTEXT, IntPtr.Zero, password);


                BtnOK = WindowsFinder.FindWindowEx(hWindow, IntPtr.Zero, "TcxButton", "OK");
                if (!IsValidHandle(BtnOK))
                    BtnOK = WindowsFinder.FindWindowEx(hWindow, IntPtr.Zero, "TcxButton", "ОК");

                Task.Delay(1500).GetAwaiter().GetResult();
                Console.WriteLine("Click");
                SendMessage((IntPtr)BtnOK, WM_LBUTTONDOWN, IntPtr.Zero, null);
                Task.Delay(500).GetAwaiter().GetResult();
                SendMessage((IntPtr)BtnOK, WM_LBUTTONUP, IntPtr.Zero, null);

                
            }
            SendLog(FCs, ID, "Use the system: " + NameRestaurant);
        }
    }
}

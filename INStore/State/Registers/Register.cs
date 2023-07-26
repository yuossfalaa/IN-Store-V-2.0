using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Data.Sqlite;
using System.Windows;

namespace INStore.State.Registers
{
    public class Register : IRegister
    {
        private RegistryKey Rig;
        public Register()
        {
            Rig = Registry.CurrentUser.CreateSubKey("SOFTWARE\\IN Store");
        }
        #region Culture Info
        public CultureInfo GetLanguage()
        {
            //get culture
            string Culture = (string)Rig.GetValue("Language");
            //return culture
            if (!Culture.IsNullOrEmpty())
            {
                return new CultureInfo(Culture);
            }
            // make new culture then return it
            else
            {
                SetLanguage(new CultureInfo("en-US"));
                return new CultureInfo("en-US");
            }
        }

        public void SetLanguage(CultureInfo Culture)
        {
            Rig.SetValue("Language", Culture.ToString());
        }
        #endregion
        #region Data Base String Connection
        public string GetDBConnectionString()
        {
            string dbConnectionString = (string)Rig.GetValue("DBConnectionString");
            if (dbConnectionString.IsNullOrEmpty())
            {
                //get Default path
                string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //AppData\Roaming
                programDataPath += @"\IN Store\DataBase";
                System.IO.Directory.CreateDirectory(programDataPath);
                //set path and return
                dbConnectionString = SetDBConnectionString(programDataPath);
            }
            //Test DataBase Before Sending out the connection string
            try
            {
                //Establish a connection
                SqliteConnection connection = new SqliteConnection(dbConnectionString);
                connection.Open();

                //Turn journal_mode off
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "PRAGMA journal_mode=DELETE;";
                    command.ExecuteNonQuery();
                }
                //Close Connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Application was Terminated due to a problem with the database location,The Application Will Recreate The database in Default Location and Connect To It.");
                string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //AppData\Roaming
                programDataPath += @"\Hyper POS\DataBase";
                System.IO.Directory.CreateDirectory(programDataPath);
                //set path and return
                dbConnectionString = SetDBConnectionString(programDataPath);
            }
            return dbConnectionString;
        }
        public string SetDBConnectionString(string programDataPath)
        {
            //assemble connection string
            string dbConnectionString = "Data Source = " + programDataPath + "\\INStoreDataBase.db";
            //set Value in register
            Rig.SetValue("DBConnectionString", dbConnectionString);
            //return it
            return dbConnectionString;
        }

        #endregion

    }
}

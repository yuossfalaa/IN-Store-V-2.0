using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStore.logger
{
    public class Logger
    {
        private static Logger Instance = null;
        private string LoggerFilePath;
        private Logger()
        {
           
        }
        public Logger Log() 
        {
            if (Instance == null)
            {
                Task Task = new Task (delegate 
                {

                    if (Instance == null)
                    {
                        CreateFile();
                        Instance = new Logger();
                    }

                });
                Task.Start();
            }
            return Instance; 
        }
        private bool CreateFile()
        {
            try
            {
                string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //AppData\Roaming
                FilePath = FilePath + @"\IN Store";
                System.IO.Directory.CreateDirectory(FilePath);
                FilePath += "IN Store.log";
                LoggerFilePath = FilePath;
                return true;
            }
            catch (Exception CreationFailed) 
            {
                return false;
            }
        }
        public void writeLog(string strValue)
        {
            try
            {
                StreamWriter streamWriter;
                if (!File.Exists(LoggerFilePath))
                {
                    streamWriter = File.CreateText(LoggerFilePath);
                }
                else
                {
                    streamWriter = File.AppendText(LoggerFilePath);
                }

                WriteLog(strValue + " : " + DateTime.Now.ToString(), streamWriter);

                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void WriteLog(string strValue, StreamWriter streamWriter)
        {
            streamWriter.WriteLine("{0}", strValue);
            streamWriter.WriteLine("----------------------------------------");
        }
    }

}

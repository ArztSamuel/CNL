using System;
using System.Collections.Generic;
using System.IO;

namespace CNLConfiguration
{
    static class SaveLoad
    {
        public enum Data
        {
            USER = 0, PW, RETRY, CHECK, DEBUG, LENGTH
        }


        private static readonly string SAVE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/CNL"; //Path to save file (Standard OS Application Path)
        private static readonly string SAVE_FILE = "cnl.save"; //Name of actual save file


        //Returns whether or not the save-file already exists on hard disk
        public static bool SaveFileExists()
        {
            return File.Exists(SAVE_PATH + "/" + SAVE_FILE);
        }


        //Loads the save-data from standard save-file path
        public static string[] LoadSave()
        {
            FileStream file = null;
            byte[] byteData = null;
            try
            {
                //Read complete data from file and save it to byteData
                file = new FileStream(SAVE_PATH + "/" + SAVE_FILE, FileMode.Open, FileAccess.Read);
                byteData = new byte[file.Length];
                file.Read(byteData, 0, (int) file.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString() + e.StackTrace);
                return null;
            }
            finally
            {
                //Always close/dispose file if initiated
                if (file != null)
                {
                    file.Close();
                    file.Dispose();
                }
            }
            //Decryption via extern class
            Encryption.Decrypt(byteData);

            string dataString = GetStringFromBytes(byteData); //convert from bytes to string
            List<string> dataList = new List<string>();


            //Split string to get individual values
            int lastDataIndex = 0;
            for(int i = 0; i<dataString.Length; i++)
            {
                if(dataString[i] == ';')
                {
                    if ((i - 1 >= 0 && dataString[i - 1] == ' ') && (i + 1 < dataString.Length && dataString[i+1] == ' '))
                    {
                        string substring = dataString.Substring(lastDataIndex, i - lastDataIndex - 1);
                        
                        dataList.Add(substring.Replace(";;", ";")); //Unescape semi-colon
                        
                        i++;
                        lastDataIndex = i+1;
                    }
                }
            }

            return dataList.ToArray();
        }

        //Deletes save-file (in standard save path)
        public static void DeleteSave()
        {
            File.Delete(SAVE_PATH + "/" + SAVE_FILE);
        }


        //Saves current data from window to file
        public static void Save(string[] saveData)
        {
            FileStream file = null;
            try
            {
                if(!Directory.Exists(SAVE_PATH))
                {
                    //If file doesn't exist yet, create the file
                    Directory.CreateDirectory(SAVE_PATH);
                }

                file = new FileStream(SAVE_PATH + "/" + SAVE_FILE, FileMode.OpenOrCreate, FileAccess.Write);

                //Clear file
                file.SetLength(0);
                file.Flush();

                //Create data string
                string stringData = "";
                for(int strI = 0; strI<saveData.Length; strI++)
                {
                    string s = saveData[strI];
                    s.Replace(";", ";;"); //Escape smicolons
                    stringData += s + " ; ";
                }


                byte[] byteData = GetBytesFromString(stringData); //Convert string to bytes
                //Encrypt data with external class
                Encryption.Encrypt(byteData);

                file.Write(byteData, 0, byteData.Length); //Write data to file on disk
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString() + e.StackTrace);
            }
            finally
            {
                //Always close/dispose file
                if(file != null)
                {
                    file.Close();
                    file.Dispose();
                }
            }
        }


        //Helper methods for converting string to bytes and vice versa
        public static byte[] GetBytesFromString(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetStringFromBytes(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace CNL
{
    static class Load
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
                file.Read(byteData, 0, (int)file.Length);
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

            string dataString = GetStringFromBytes(byteData); //Convert from bytes to string
            List<string> dataList = new List<string>();

            //Split string to get individual values
            int lastDataIndex = 0;
            for (int i = 0; i < dataString.Length; i++)
            {
                if (dataString[i] == ';')
                {
                    if ((i - 1 >= 0 && dataString[i - 1] == ' ') && (i + 1 < dataString.Length && dataString[i + 1] == ' '))
                    {
                        string substring = dataString.Substring(lastDataIndex, i - lastDataIndex - 1);

                        dataList.Add(substring.Replace(";;", ";")); //Unescape semicolons

                        i++;
                        lastDataIndex = i + 1;
                    }
                }
            }

            return dataList.ToArray();
        }


        //Helper method that converts bytes into chars, thus into a string
        public static string GetStringFromBytes(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Team1
{
 
    class Login
    {
        

        static internal bool UserAuthentication(String id, String pwd)
        {
            bool accountExist = false;
            char[] delimiters = new char[] { '\t', ' ' };
            StreamReader sr = new StreamReader("User.txt", Encoding.Default);
            while (!sr.EndOfStream) // 每次讀取一行，直到檔尾            
            {
                string line = sr.ReadLine();    // 讀取文字到 line 變數
                string[] item = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (item[0].Equals(id))
                {
                    if (item[1].Equals(pwd))
                    {
                        accountExist = true;
                        break;
                    }
                }
            }
            sr.Close();

            return accountExist;
        }
    }


    class BorrowInfo
    {
        internal static string Convert(int number)
        {         

            //StreamReader sr = new StreamReader("Library.txt", Encoding.Default);
            //String line;

            //while ((line = sr.ReadLine()) != null)
            //{
            //    Console.WriteLine(line.ToString());
            //}

            return "001";
        }
    }


    class BorrowBook : FindBook
    {



    }
    
}

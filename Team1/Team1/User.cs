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
        struct borrowinformation
        {
            public string studentnumber;
            public string booknumber;
            public string dateborrow;
            public string datereturn;
        };

        borrowinformation[] borrowinfo = new borrowinformation[50];
        int Datacount = 1;

        public BorrowInfo()
        {
            StreamReader sr = new StreamReader("borrow.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                if (Datacount == 0)
                {
                    Datacount++;
                }
                else
                {
                    String[] split = line.Split(' ');
                    borrowinfo[Datacount - 1].studentnumber = split[0];
                    borrowinfo[Datacount - 1].booknumber = split[1];
                   // borrowinfo[Datacount - 1].dateborrow = split[2];
                   // borrowinfo[Datacount - 1].datereturn = split[3];
                    //borrowinfo[Datacount - 1].dateborrow = split[2];
                    //borrowinfo[Datacount - 1].datereturn = split[3];

                    Datacount++;
                }
            }
        }

        public string findinformation(String number)
        {
            string Sentence = "";
            for (int i = 0; i < Datacount; i++)
            {
                if (String.Compare(borrowinfo[i].studentnumber, number) == 0)
                {
                    Sentence = borrowinfo[i].studentnumber + " " + borrowinfo[i].booknumber;//+ " " + borrowinfo[i].dateborrow + " " + borrowinfo[i].datereturn;
                    Sentence = borrowinfo[i].studentnumber + " " + borrowinfo[i].booknumber ; //+ " " + borrowinfo[i].dateborrow + " " + borrowinfo[i].datereturn;
                }
            }

            return Sentence;
        }
    }


    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Team1
{
    public class Search
    {

         struct bookinformation
        {
            public string booknumber;
            public string bookname;
            public string writer;
            public string ifborrow;
            public string borrowdate;
            public string returndate;
        };

        bookinformation[] bookinfo = new bookinformation[50];
        int count = 0;

        public string Search_by_Keyword(string keyword)
        {
            StreamReader sr = new StreamReader("..\\..\\Library.txt", Encoding.Default);
            String str;

            while ((str = sr.ReadLine()) != null)
            {
                if (count == 0)
                {
                    count++;
                }
                else
                {
                    String[] split = str.Split(' ');
                    bookinfo[count - 1].booknumber = split[0];
                    bookinfo[count - 1].bookname = split[1];
                    bookinfo[count - 1].writer = split[2];
                    bookinfo[count - 1].ifborrow = split[3];
                    bookinfo[count - 1].borrowdate = split[4];
                    bookinfo[count - 1].returndate = split[5];
                }
                count++;
            }
            count--;
            sr.Close();

            string response = "";

            for (int i = 1; i < count; i++)
            {
                if (bookinfo[i].booknumber == keyword || bookinfo[i].bookname == keyword || bookinfo[i].writer == keyword)
                {
                    response = bookinfo[i].booknumber + " " + bookinfo[i].bookname + " " + bookinfo[i].writer
                           + " " + bookinfo[i].ifborrow + " " + bookinfo[i].borrowdate + " " + bookinfo[i].returndate;
                    return response;
                }
                
                if (i == (count - 1))
                    response = "找不到符合搜尋字詞的書籍。";
            }

            return response;
        }

        /*
        struct bookinformation
        {
            public string booknumber;
            public string bookname;
            public string writer;
            public string ifborrow;
            public string borrowdate;
            public string returndate;
        };

        bookinformation[] bookinfo = new bookinformation[50];
        int count = 0;

        public Search_by_Keyword()
        {
            StreamReader sr = new StreamReader("..\\..\\Library.txt", Encoding.Default);
            String str;

            while ((str = sr.ReadLine()) != null)
            {
                if (count == 0)
                {
                    count++;
                }
                else
                {
                    String[] split = str.Split(' ');
                    bookinfo[count - 1].booknumber = split[0];
                    bookinfo[count - 1].bookname = split[1];
                    bookinfo[count - 1].writer = split[2];
                    bookinfo[count - 1].ifborrow = split[3];
                    bookinfo[count - 1].borrowdate = split[4];
                    bookinfo[count - 1].returndate = split[5];
                }
                count++;
            }
            count--;
            sr.Close();
        }

        public string Search_by_Keyword_Result (string keyword)
        {
            string response = "";

            for (int i = 0; i < count; i++)
            {
                if (bookinfo[i].booknumber == keyword || bookinfo[i].bookname == keyword || bookinfo[i].writer == keyword)
                {
                    response = bookinfo[count].booknumber + " " + bookinfo[count].bookname + " " + bookinfo[count].writer
                           + " " + bookinfo[count].ifborrow + " " + bookinfo[count].borrowdate + " " + bookinfo[count].returndate;
                    break;
                }
                string a = "aaa";
                if (i == (count - 1))
                    response = bookinfo[1].booknumber;
            }

            return response;
        }
         */


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Team1
{
    class BorrowBook
    {
        private string id;
        private string pwd;
        private string competence;
        private string borrowbooknumber;
        private FindBook bookdata = new FindBook();
        private Login user = new Login();

        struct BookInformation
        {
            public string booknumber;
            public string bookname;
            public string writer;
            public bool borrowornot;
        };
        private BookInformation[] bookinformation = new BookInformation[20];

        public BorrowBook(string ID , string PWD, string num)
        {
            user.FindAccount(ID,PWD);
            id = user.getID();
            pwd = user.getpassword();
            competence = user.getcompetence();
            borrowbooknumber = user.getborrownumber();  
        }

        public string Borrow(string booknumber , DateTime borrowdate)
        {            
            string Sentence = "";
            string returndate = borrowdate.AddDays(30).ToShortDateString();

            Sentence=bookdata.FindBookbyNumber(booknumber);
            if (Sentence == "")
                Sentence = "We don't have this book!";
            else
            {
                Sentence = "";
                if (bookdata.borrowbooks(booknumber))
                {
                    Sentence = "Success borrow book " + booknumber + ",Return day:" + returndate;
                    
                    //測試無法過的原因是因為有可能會同時2個function去存取同一個檔案,也就是OS學的Critical-Section Problem
                    //所以寫了WaitReady function,在執行動作前先去判斷檔案是否正被其他動作所使用,若是則等待
                    bool waitready = WaitReady("..\\..\\Library.txt");
                   
                    if (waitready)
                    {


                        FileStream fs = new FileStream("..\\..\\Library.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                        //FileStream fs = new FileStream("..\\..\\Library.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);//有BUG  找不出原因  by : 陳鈞翰

                        StreamReader sr = new StreamReader(fs);
                        StreamWriter Library_sw = new StreamWriter(fs);

                        String line;
                        int Datacount = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (Datacount == 0)
                            {
                                Datacount++;
                            }
                            else
                            {
                                String[] sr_split = line.Split(' ');
                                bookinformation[Datacount - 1].booknumber = sr_split[0];
                                bookinformation[Datacount - 1].bookname = sr_split[1];
                                bookinformation[Datacount - 1].writer = sr_split[2];
                                if (sr_split[3] == "0")
                                    bookinformation[Datacount - 1].borrowornot = true;
                                else
                                    bookinformation[Datacount - 1].borrowornot = false;

                                String[] splitdate1 = sr_split[4].Split('/');
                                String[] splitdate2 = sr_split[4].Split('/');

                                Datacount++;
                            }
                        }
                        Datacount--;//修正最後一次while
                       

                        String writein;


                        int i = 0;
                        while (bookinformation[i].bookname != null)//
                        {

                            if (bookinformation[i].booknumber == booknumber)
                                writein = bookinformation[i].booknumber + " " + bookinformation[i].bookname + " " + bookinformation[i].writer + " " + "1" + " " + borrowdate + " " + returndate;

                            else
                                writein = bookinformation[i].booknumber + " " + bookinformation[i].bookname + " " + bookinformation[i].writer;

                            Library_sw.Write(writein);
                            writein = "";
                            i++;
                            Library_sw.Flush();
                        }
                        Library_sw.Close();
                        fs.Close();
                        
                    }
                    
                    /*writein = "";
                    StreamReader User_sr = new StreamReader("..\\..\\User.txt", Encoding.Default);
                    StreamWriter User_sw = new StreamWriter("..\\..\\User.txt",true);
                    int i=0;
                    while ((line = User_sr.ReadLine()) != null)
                    {
                        String[] User_split = line.Split(' ','\t');
                        if (User_split[0] == id)
                        {
                            int temp = Convert.ToInt32(User_split[3]);
                            temp += 1;
                            User_split[3] = Convert.ToString(temp);
                            while (User_split[i] != "0") {
                                writein = User_split[i] +" ";
                                i++;
                                }
                            writein = writein + " " + booknumber + " 0" ;
                            User_sw.Write(writein);
                        }
                        else
                            User_sw.Write(line);
                    }/*/
                    //寫檔
                }
                else if (!bookdata.borrowbooks(booknumber))
                    Sentence = "The book is borrowed!";
            }
                    
            return Sentence;
        }

        private bool WaitReady(string _strSourceFileName)
        {
            int i = 0;
            bool bResult = false;

            while (i < 200)//Retry 20次
            {
                try
                {
                    using (Stream stream = System.IO.File.Open(_strSourceFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        if (stream != null)
                        {
                            bResult = true;
                            break;
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    bResult = false;
                }
                catch (IOException ex)
                {
                    bResult = false;
                }
                catch (UnauthorizedAccessException ex)
                {
                    bResult = false;
                }
                finally
                {
                    i++;
                    System.Threading.Thread.Sleep(500);
                }
            }
            return bResult;
        }
    }
}

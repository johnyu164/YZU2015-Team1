using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Team1
{
    [TestClass]
    public class LibraryTest
    {
        [TestMethod]

        public void Login_Test()
        {
            Login test1 = new Login();
            test1.FindAccount("s1001555", "1234");
            Assert.AreEqual(true, test1.UserAuthentication());

            Login test2 = new Login();
            test2.FindAccount("s1001234", "abcd");

            Assert.AreEqual(true, test2.UserAuthentication());
            Login test3 = new Login(); 
            test3.FindAccount("s1009999", "88pp");
            Assert.AreEqual(true,test3.UserAuthentication());

            Login test4 = new Login();
            test4.FindAccount("s100asda", "asdasd");
            Assert.AreEqual(false, test4.UserAuthentication());

            Login test5 = new Login(); 
            test5.FindAccount("s1001555", "5678");
            Assert.AreEqual(false, test5.UserAuthentication());
        }

        [TestMethod]

        public void FindBookbyNumber()
        {
            FindBook fi = new FindBook();
            Assert.AreEqual("00001 書本A 作者a", fi.FindBookbyNumber("00001"));
        }

        [TestMethod]
        public void FindBookbyWriter()
        {
            FindBook fi = new FindBook();
            int[] booknum = new int[20];
            fi.FindBookbyWriter("作者a", booknum);
            Assert.AreEqual(0, booknum[0]);
            Assert.AreEqual(4, booknum[1]);
            fi.FindBookbyWriter("作者b", booknum);
            Assert.AreEqual(1, booknum[0]);
        }

        [TestMethod]
        public void FindBookbyBookname()
        {
            FindBook fi = new FindBook();
            int[] booknum = new int[20];
            fi.FindBookbyBookname("書本C", booknum);
            Assert.AreEqual(2, booknum[0]);
            Assert.AreEqual(3, booknum[1]);
        }


        [TestMethod]
        public void BookBorrowHistoryInfo()
        {
            historyInfo hi = new historyInfo();
            string[] result = new string[20];
            Assert.AreEqual("", hi.historyinformation("001", result));
            Assert.AreEqual("001 00001 2015/6/6 2015/7/6", result[0]);

            Assert.AreEqual("", hi.historyinformation("002", result));
            Assert.AreEqual("002 00002 2015/7/7 2015/8/7", result[0]);

            Assert.AreEqual("", hi.historyinformation("003", result));
            Assert.AreEqual("003 00004 2015/7/17 2015/8/17", result[0]);

            Assert.AreEqual("", hi.historyinformation("004", result));
            Assert.AreEqual("004 00005 2015/7/7 2015/8/7", result[0]);
            Assert.AreEqual("004 00006 2015/7/9 2015/8/9", result[1]);

            Assert.AreEqual("帳號不存在或是尚無借閱紀錄!", hi.historyinformation("005", result));
            Assert.AreEqual("帳號不存在或是尚無借閱紀錄!", hi.historyinformation("006", result));
        }



        [TestMethod]
        public void ReturnBook_Load()
        {
            ReturnBook Rb = new ReturnBook();
            //Load the actual number 
            Assert.AreEqual("00002 書本B 作者b 1 2015/6/6 2015/7/6", Rb.Load_Number_for_Library("00002"));
            Assert.AreEqual("00001 書本A 作者a 0 0 0", Rb.Load_Number_for_Library("00001"));
            Assert.AreEqual("00003 書本C 作者c 0 0 0", Rb.Load_Number_for_Library("00003"));
            Assert.AreEqual("00003 書本C 作者c 0 0 0", Rb.Load_Number_for_Library("00003"));
            Assert.AreEqual("00004 書本C 作者c 1 2015/7/7 2015/8/7", Rb.Load_Number_for_Library("00004"));

            Assert.AreEqual("No Book Found!", Rb.Load_Number_for_Library("00010"));

            //Can get who borrow the book
            Assert.AreEqual("001", Rb.Load_Number_for_borrow("00001"));
            Assert.AreEqual("002", Rb.Load_Number_for_borrow("00002"));
            Assert.AreEqual("003", Rb.Load_Number_for_borrow("00004"));
            Assert.AreEqual("004", Rb.Load_Number_for_borrow("00005"));
            Assert.AreEqual("004", Rb.Load_Number_for_borrow("00006"));
            Assert.AreEqual("No Book Found!", Rb.Load_Number_for_borrow("00099"));

            //Can't actual return
            Assert.AreEqual("書本未被借出，無法歸還!!", Rb.Can_Return(Rb.Load_Number_for_Library("00001")));
            Assert.AreEqual("書本未被借出，無法歸還!!", Rb.Can_Return(Rb.Load_Number_for_Library("00003")));

            Assert.AreEqual("書本尚未逾期", Rb.Can_Return(Rb.Load_Number_for_Library("00002")));

            Assert.AreEqual("沒在目錄中", Rb.Can_Return(Rb.Load_Number_for_Library("00011")));

            DateTime testtime = new DateTime(2015,6,13);

            Assert.AreEqual("逾期1天,要繳交罰鍰50元", Rb.CanReturnInSpecificDate(Rb.Load_Number_for_Library("00006"),testtime));


            Assert.AreEqual("Do return in library.txt", Rb.Fixed_the_time_of_borrow_and_return(Rb.Load_Number_for_Library("00002")));
            Assert.AreEqual("書本未被借出，無法歸還!!", Rb.Fixed_the_time_of_borrow_and_return(Rb.Load_Number_for_Library("00001")));
        }

        [TestMethod]
        public void BorrowBook()
        {
            Login test1 = new Login();
            test1.FindAccount("s1001555", "1234");
            BorrowBook b = new BorrowBook(test1.getID(), test1.getpassword(), "00001");
            DateTime borrowdate = new DateTime(2015,6,18);

            Assert.AreEqual("Success borrow book 00001,Return day:2015/7/18", Convert.ToString(b.Borrow("00001", borrowdate)));
            Assert.AreEqual("The book is borrowed!", Convert.ToString(b.Borrow("00002",borrowdate)));
            Assert.AreEqual("We don't have this book!", Convert.ToString(b.Borrow("00010",borrowdate)));
        }

        [TestMethod]
        public void Search_Keyword()
        {
            Search test = new Search();
            string[] result = new string[20];

            Assert.AreEqual("搜尋結果為 1 筆。", test.Search_by_Keyword("書本A", result));   //以書本名搜尋
            Assert.AreEqual("00001 書本A 作者a 在架上", result[0]);      //搜尋結果

            Assert.AreEqual("搜尋結果為 3 筆。", test.Search_by_Keyword("作者c", result));   //以作者名搜尋
            Assert.AreEqual("00003 書本C 作者c 在架上", result[0]);
            Assert.AreEqual("00004 書本C 作者c 借出中 應還日期2015/8/7", result[1]);
        //    Assert.AreEqual("00006 書本C 作者c 借出中 應還日期2015/6/12", result[2]);

            Assert.AreEqual("搜尋結果為 1 筆。", test.Search_by_Keyword("00005", result));   //以書號名搜尋
            Assert.AreEqual("00005 書本D 作者a 在架上", result[0]);

            Assert.AreEqual("搜尋結果為 1 筆。", test.Search_by_Keyword("小王", result));    //部分書名搜尋
            Assert.AreEqual("00007 小王子 安東尼·德聖艾修伯里 在架上", result[0]);
            Assert.AreEqual("搜尋結果為 7 筆。", test.Search_by_Keyword("哈利波特", result));
            Assert.AreEqual("00078 哈利波特-神祕的魔法石 J·K·羅琳 在架上", result[0]); 
            Assert.AreEqual("00099 哈利波特-消失的密室 J·K·羅琳 借出中 應還日期2015/7/1", result[1]); 
            Assert.AreEqual("00111 哈利波特-阿茲卡班的逃犯 J·K·羅琳 借出中 應還日期2015/7/2", result[2]); 
            Assert.AreEqual("02561 哈利波特-火盃的考驗 J·K·羅琳 在架上", result[3]); 
            Assert.AreEqual("03312 哈利波特-鳳凰會的密令 J·K·羅琳 在架上", result[4]); 
            Assert.AreEqual("03613 哈利波特-混血王子的背叛 J·K·羅琳 借出中 應還日期2015/6/30", result[5]); 
            Assert.AreEqual("15014 哈利波特-死神的聖物 J·K·羅琳 在架上", result[6]);

            Assert.AreEqual("搜尋結果為 7 筆。", test.Search_by_Keyword("K·羅琳", result));  //部分作者名搜尋

            Assert.AreEqual("找不到符合搜尋字詞的書籍。", test.Search_by_Keyword("hello", result));  //沒有結果
            Assert.AreEqual("找不到符合搜尋字詞的書籍。", test.Search_by_Keyword("小屁王", result)); 
        }
    }
}

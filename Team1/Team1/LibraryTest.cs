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
            Assert.AreEqual(true, Login.UserAuthentication("s1001555", "1234"));
            Assert.AreEqual(true, Login.UserAuthentication("s1001234", "abcd"));
            Assert.AreEqual(true, Login.UserAuthentication("s1009999", "88pp"));

            Assert.AreEqual(false, Login.UserAuthentication("s100asda", "asdasd"));
            Assert.AreEqual(false, Login.UserAuthentication("s13333da", "123fas"));
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
            int[] numofbooks = new int[20];
            fi.FindBookbyWriter("作者a", numofbooks);
            Assert.AreEqual(0, numofbooks[0]);
            Assert.AreEqual(4, numofbooks[1]);
            fi.FindBookbyWriter("作者b", numofbooks);
            Assert.AreEqual(1, numofbooks[0]);
        }

        [TestMethod]
        public void FindBookbyBookname()
        {
            FindBook fi = new FindBook();
            int[] nameofbooks = new int[20];
            fi.FindBookbyBookname("書本C", nameofbooks);
            Assert.AreEqual(2, nameofbooks[0]);
            Assert.AreEqual(3, nameofbooks[1]);
        }

        [TestMethod]
        public void BookBorrowInfo()
        {
            Assert.AreEqual("001", BorrowInfo.Convert(1));
        }
        /*[TestMethod]
        public void ReturnBook_Load()
        {
            ReturnBook Rb = new ReturnBook();
            Assert.AreEqual("00001      書本A      0", Rb.Load_Number("00001"));
        }*/

        [TestMethod]
        public void BorrowBook()
        {
            BorrowBook b = new BorrowBook();
            Assert.AreEqual("00001 書本A 作者a False", Convert.ToString(b.checkborrow("00001")));
            Assert.AreEqual("Error", Convert.ToString(b.checkborrow("00010")));

            Assert.AreEqual("Success borrow book 00001", Convert.ToString(b.Borrow("00001")));
            Assert.AreEqual("The book is borrowed!", Convert.ToString(b.Borrow("00002")));
            Assert.AreEqual("We don't have this book!", Convert.ToString(b.Borrow("00010")));
        }
    }
}

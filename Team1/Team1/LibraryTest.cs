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
            Assert.AreEqual("00001 書本A 作者a 0", fi.FindBookbyNumber("00001"));
        }

        [TestMethod]
        public void FindBookbyWriter()
        {
            FindBook fi = new FindBook();
            Assert.AreEqual("2", Convert.ToString(fi.FindBookbyWriter("作者a")));
            Assert.AreEqual("1", Convert.ToString(fi.FindBookbyWriter("作者c")));
        }

        [TestMethod]
        public void FindBookbyBookname()
        {
            FindBook fi = new FindBook();
            Assert.AreEqual("1", Convert.ToString(fi.FindBookbyBookname("書本C")));
            Assert.AreEqual("0", Convert.ToString(fi.FindBookbyBookname("書本E")));
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
            Assert.AreEqual("00001 書本A 作者a 0", Convert.ToString(b.checkborrow("00001")));
            Assert.AreEqual("Error", Convert.ToString(b.checkborrow("00010")));

            Assert.AreEqual("Success borrow book 00001", Convert.ToString(b.Borrow("00001")));
            Assert.AreEqual("The book is borrowed!", Convert.ToString(b.Borrow("00002")));
            Assert.AreEqual("We don't have this book!", Convert.ToString(b.Borrow("00010")));
        }
    }
}

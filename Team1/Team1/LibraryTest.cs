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
            Assert.AreEqual("00001", fi.FindBookbyNumber("00001"));
        }

        [TestMethod]
        public void FindBookbyWriter()
        {
            FindBook fi = new FindBook();
            Assert.AreEqual("2", Convert.ToString(fi.FindBookbyWriter("作者a")));
            Assert.AreEqual("0", Convert.ToString(fi.FindBookbyWriter("作者b")));
        }

        [TestMethod]
        public void FindBookbyBookname()
        {
            FindBook fi = new FindBook();
            Assert.AreEqual("2", Convert.ToString(fi.FindBookbyBookname("書本C")));
            Assert.AreEqual("0", Convert.ToString(fi.FindBookbyBookname("書本D")));
        }

        [TestMethod]
        public void BookBorrowInfo()
        {
            Assert.AreEqual("001", BorrowInfo.Convert(1));
        }
    }
}

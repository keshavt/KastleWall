using System;
using KastleWall.Encryption;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KastleWall.SecurityTests
{
    [TestClass()]
    public class EncryptorTests
    {
        private Encryptor encryptor = new Encryptor();

        [TestMethod]
        
        public void EncryptTest()
        {
            string userString = "test_password";
            string phrase = "password test";
            string encrypted = encryptor.Encrypt(userString, phrase);

            string result = encryptor.Decrypt(encrypted, phrase);

            Assert.AreNotEqual(userString,encrypted);
            Assert.AreEqual(userString, result);

        }
    }
}
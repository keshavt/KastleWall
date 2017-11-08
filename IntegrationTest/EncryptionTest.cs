using System;
using KastleWall.Encryption;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest
{
    [TestClass]
    public class EncryptionTest
    {
        [TestMethod]
        public void TestEncyption()
        {
            string password = "password";
            string phrase = "phrase";
            Encryptor e = new Encryptor();

            string encrypted = e.Encrypt(password, phrase);
            Assert.AreNotEqual(password,encrypted);
            string decrypted = e.Decrypt(encrypted, phrase);
            Assert.AreEqual(password, decrypted);

        }
    }
}

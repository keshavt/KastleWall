using System;
using KastleWall.Encryption;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KastleWall.SecurityTests
{
    [TestClass()]
    public class HashCreatorTests
    {
        HashCreator creator = new HashCreator();

        [TestMethod]
        
        public void truncatedHashTest()
        {
            string userString = "test_password";
            string goodHash = creator.CreateHash(userString);
            string badHash = "";

            int badHashLength = goodHash.Length;

            do
            {
                badHashLength -= 1;
                badHash = goodHash.Substring(0, badHashLength);
                bool raised = false;
                try
                {
                    creator.VerifyPassword(userString, badHash);
                }
                catch (InvalidHashException)
                {
                    raised = true;
                }

                if (!raised)
                {
                    Console.WriteLine("Truncated hash test: FAIL " +
                                      "(At hash length of " + badHashLength + ")");
                    System.Environment.Exit(1);
                }

                // The loop goes on until it is two characters away from the last : it
                // finds. This is because the PBKDF2 function requires a hash that's at
                // least 2 characters long. This will be changed once exceptions are
                // implemented.
            } while (badHash[badHashLength - 3] != ':');

            Console.WriteLine("Truncated hash test: pass");
        }

        [TestMethod]
        public void basicTests()
        {
            // Test password validation
            bool failure = false;
            for (int i = 0; i < 10; i++)
            {
                string password = "" + i;
                string hash = creator.CreateHash(password);
                string secondHash = creator.CreateHash(password);
                if (hash == secondHash)
                {
                    Console.WriteLine("Hashes of same password differ: FAIL");
                    failure = true;
                }
                String wrongPassword = "" + (i + 1);
                if (creator.VerifyPassword(wrongPassword, hash))
                {
                    Console.WriteLine("Validate wrong password: FAIL");
                    failure = true;
                }
                if (!creator.VerifyPassword(password, hash))
                {
                    Console.WriteLine("Correct password: FAIL");
                    failure = true;
                }
            }
            if (failure)
            {
                System.Environment.Exit(1);
            }
        }

        [TestMethod]
        public void testHashFunctionChecking()
        {
            string hash = creator.CreateHash("foobar");
            hash = hash.Replace("sha1:", "sha256:");

            bool raised = false;
            try
            {
                creator.VerifyPassword("foobar", hash);
            }
            catch (InvalidHashOperationException)
            {
                raised = true;
            }

            if (raised)
            {
                Console.WriteLine("Algorithm swap: pass");
            }
            else
            {
                Console.WriteLine("Algorithm swap: FAIL");
                System.Environment.Exit(1);
            }
        }
    }
}
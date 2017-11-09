# KastleWall.Encryption

Summary:
Kastlewall Security provides utilities to generate hask key for string and encrypt/decrypt for string. One way hash key generator is meant to be used for user login.

HashCreator: A simple hash provider utility to hash string using salt.
System.Security.Cryptography.RNGCryptoServiceProvider for cryptographic number generation.
System.Security.Cryptography.Rfc2898DeriveBytes  to implement password-based key derivation functionality, PBKDF2, by using a pseudo-random number generator based on System.Security.Cryptography.HMACSHA1.

Encryptor: Provides encrypt/decrypt for string.
Implements RijndaelManaged key generator and encryptor based on  System.Security.Cryptography.RijndaelManaged.


======================================================================================================================================

One way hash key generator: Create hask key for plain text. Good for using one way verification for user login.

Usage example: 

string stringunderTest = "MyPassword";

           KastleWall.Encryption.HashCreator hashKeyGenerator = new HashCreator();
           string hashed = hashKeyGenerator.CreateHash("test username");


            bool verify = hashKeyGenerator.VerifyPassword(stringunderTest, hashed);

            if (verify)
            {
                // user is verified

            }
            else
            {
                // user entered wrong password
            }


Encryptor: Encrypts plaintext with phrase and decrypts ciper with phrase to plain text.


Usage example:

    using KastleWall.Encryption;

    public class EncryptModule : IEncryptModule
    {
        private Encryptor encryptor;

        public EncryptModule()
        {
            this.encryptor = new Encryptor();
        }

        public string Encrypt(string plainText, string phrase)
        {
            return this.encryptor.Encrypt(plainText, phrase);
        }

        public string Decrypt(string cipher, string phrase)
        {
            return this.Decrypt(cipher, phrase);
        }
    }
    

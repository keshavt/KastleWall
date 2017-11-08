# KastleWall.Encryption

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
    

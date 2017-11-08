# KastleWall

One way hask key generator


Encryptor: Encrypts plaintext with phrase and decrypts ciper with phrase to plain text.


usage:

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
    

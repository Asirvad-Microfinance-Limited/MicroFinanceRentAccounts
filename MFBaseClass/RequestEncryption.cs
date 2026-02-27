using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using System.Collections;

namespace Base
{
    public class RequestEncryption
    {
        public string AngularDecrypt(string EncryptedText)
        {
            //AES decryption Using SymmetricKey --done by Nithin  100367 -- 28-Jul-2021
            string key ="7x!A%D*G-KaPdSgV";

            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(EncryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private  string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.  
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            // Declare the string used to hold  
            // the decrypted text.  
            string plaintext = null;

            // Create an RijndaelManaged object  
            // with the specified key and IV.  
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings  
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.  
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                try
                {
                    // Create the streams used for decryption.  
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {

                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream  
                                // and place them in a string.  
                                plaintext = srDecrypt.ReadToEnd();

                            }

                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }

            return plaintext;
        }

        public string APIEncryptionAES(string cipherText)
        {
            var keybytes = Encoding.UTF8.GetBytes("7x!A%D*G-KaPdSgV");
            var iv = Encoding.UTF8.GetBytes("7x!A%D*G-KaPdSgV");

            //var keybytes = Encoding.UTF8.GetBytes("3x!A%S*I-Ra7dSgV");
            //var iv = Encoding.UTF8.GetBytes("6x!A%D*M-0aFdIgV");

            var encrypted = cipherText;
            var decriptedFromJavascript = EncryptStringToBytes(encrypted, keybytes, iv);
            return Convert.ToBase64String(decriptedFromJavascript);
        }

        public string APIDecryptionAES(string cipherText)
        {
            var keybytes = Encoding.UTF8.GetBytes("7x!A%D*G-KaPdSgV");
            var iv = Encoding.UTF8.GetBytes("7x!A%D*G-KaPdSgV");

            //var keybytes = Encoding.UTF8.GetBytes("3x!A%S*I-Ra7dSgV");
            //var iv = Encoding.UTF8.GetBytes("6x!A%D*M-0aFdIgV");

            var encrypted = Convert.FromBase64String(cipherText);
            var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
            return decriptedFromJavascript;
        }

        public  string DecryptStringAES(string cipherText)
        {
            //var keybytes = Encoding.UTF8.GetBytes("8080808080808080");
            //var iv = Encoding.UTF8.GetBytes("8080808080808080");

            var keybytes = Encoding.UTF8.GetBytes("7x!A%D*G-KaPdSgV");
            var iv = Encoding.UTF8.GetBytes("7x!A%D*G-KaPdSgV");

            //var keybytes = Encoding.UTF8.GetBytes("3x!A%S*I-Ra7dSgV");
            //var iv = Encoding.UTF8.GetBytes("6x!A%D*M-0aFdIgV");

            var encrypted = Convert.FromBase64String(cipherText);
            var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
            return string.Format(decriptedFromJavascript);
        }


        private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.  
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            byte[] encrypted;
            // Create a RijndaelManaged object  
            // with the specified key and IV.  
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.  
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.  
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.  
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.  
            return encrypted;
        }


        public string EncryptStringAES(string cipherText)
        {

            var keybytes = Encoding.UTF8.GetBytes("7x!A%D*G-KaPdSgV");
            var iv = Encoding.UTF8.GetBytes("7x!A%D*G-KaPdSgV");

            //var keybytes = Encoding.UTF8.GetBytes("3x!A%S*I-Ra7dSgV");
            //var iv = Encoding.UTF8.GetBytes("6x!A%D*M-0aFdIgV");

            var encrypted = cipherText;
            var decriptedFromJavascript = EncryptStringToBytes(encrypted, keybytes, iv);
            return Convert.ToString(decriptedFromJavascript);
        }

        public string EncryptedString(string cipherText)
        {
            string original = cipherText;
            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {
                var keybytes = Encoding.UTF8.GetBytes("7x!A%D*G-KaPdSgV");
                var iv = Encoding.UTF8.GetBytes("7x!A%D*G-KaPdSgV");

                //var keybytes = Encoding.UTF8.GetBytes("3x!A%S*I-Ra7dSgV");
                //var iv = Encoding.UTF8.GetBytes("6x!A%D*M-0aFdIgV");
                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes(original, keybytes, iv);
                string cipherText1 = Convert.ToBase64String(encrypted);
                return string.Format(cipherText1);
            }
        }

        public string APIDecryptionAES(object encryptedRqstStr)
        {
            throw new NotImplementedException();
        }
    }
}




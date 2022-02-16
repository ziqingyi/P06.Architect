using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.AuthHelper
{
    public class RSAHelper
    {
        //read RSA key from local file
        public static bool TryGetKeyParameters(string filePath, bool withPrivate, out RSAParameters keyParameters)
        {
            string filename = withPrivate ? "key.json" : "key.public.json";
            string fileFullPath = Path.Combine(filePath, filename);

            keyParameters = default(RSAParameters);
            if(!File.Exists(fileFullPath))
            {
                return false;
            }
            else
            {
                keyParameters = JsonConvert.DeserializeObject<RSAParameters>(File.ReadAllText(fileFullPath));
                return true;
            }
        }


        //generate and save private key and public key, keep in   parameter:  filePath
        public static RSAParameters GenerateAndSaveKey(string filePath, bool withPrivate = true)
        {
            RSAParameters publicKeys, privateKeys;
            using(var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    privateKeys = rsa.ExportParameters(true);
                    publicKeys = rsa.ExportParameters(false);
                }
                finally
                {
                    //     Gets or sets a value indicating whether the key should be persisted in the cryptographic
                    //     service provider (CSP).
                    rsa.PersistKeyInCsp = false;
                }

                File.WriteAllText(Path.Combine(filePath, "key.json"), JsonConvert.SerializeObject(privateKeys));
                File.WriteAllText(Path.Combine(filePath, "key.public.json"), JsonConvert.SerializeObject(publicKeys));

                return withPrivate ? privateKeys : publicKeys;
            }

        }





    }
}

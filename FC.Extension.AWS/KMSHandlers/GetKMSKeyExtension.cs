using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using FC.Extension.AWS.Common;

namespace FC.Extension.AWS.KMSHandlers
{
    /// <summary>
    /// Get the KMS Key details.
    /// </summary>
    public static class GetKMSKeyExtension
    {

        /// <summary>
        /// Used to obtain the keys for encryption from s3
        /// </summary>
        /// <param name="clientAccessKey">ClientAccessKey. Pass null if IAM Role is used</param>
        /// <param name="clientSecretKey">ClientSecretKey. Pass null if IAM Role is used</param>
        /// <param name="awsKeyId">AWSMasterKeyID</param>
        /// <returns>returns KeyInfo used for encryption or decryption </returns>
        public static async  Task<KeyInfo> GetKMSKeyInfo(this string awsKeyId, AWSConfig config)
        {
            KeyInfo keys = new KeyInfo();
            AmazonKeyManagementServiceClient kms = null;
            try
            {
                if(string.IsNullOrEmpty(config.AccessKey))
                {
                    kms = new AmazonKeyManagementServiceClient(config.Region);
                }
                else
                {
                    kms = new AmazonKeyManagementServiceClient(config.AccessKey, config.SecretKey, config.Region);
                }
                
                GenerateDataKeyRequest dataKeyRequest = new GenerateDataKeyRequest
                {
                    KeyId = awsKeyId,
                    KeySpec = AWSConstants.AES256
                };
                GenerateDataKeyResponse dataKeyResult =
                    await kms.GenerateDataKeyAsync(dataKeyRequest);
                keys.Plainkey = Convert.ToBase64String(dataKeyResult.Plaintext.ToArray());
                keys.CypherKey = Convert.ToBase64String(dataKeyResult.CiphertextBlob.ToArray());
                dataKeyRequest = null;
                dataKeyResult = null;
            }
            finally
            {
                kms?.Dispose();
            }
            
            return keys;
        }
    }
}

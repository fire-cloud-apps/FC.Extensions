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
        public static async  Task<KeyInfo> GetKMSKeyInfo(this string awsKeyId, string clientAccessKey, string clientSecretKey, RegionEndpoint region)
        {
            KeyInfo keys = new KeyInfo();

            using (var kms = new AmazonKeyManagementServiceClient(clientAccessKey, clientSecretKey, region))
            {

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
            return keys;
        }
    }
}

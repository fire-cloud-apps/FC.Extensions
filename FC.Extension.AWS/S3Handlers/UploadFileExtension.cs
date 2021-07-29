using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using FC.Extension.AWS.Common;
using System.IO;
using System.Threading.Tasks;

namespace FC.Extension.AWS.S3Handlers
{
    public static class UploadFileExtension
    {

        public static bool UploadFileToS3(this string filePath, AWSConfig awsConfig)
        {
            Stream localFilePath = null;
            TransferUtility utility = null;
            IAmazonS3 client = null;           
            bool result = false;

            try
            {
                localFilePath = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                string accessKey = awsConfig.AccessKey;
                string secretKey = awsConfig.SecretKey;
                if (string.IsNullOrEmpty(accessKey))
                {
                    client = new AmazonS3Client(awsConfig.Region);//Use IAM Role
                }
                else
                {
                    client = new AmazonS3Client(accessKey, secretKey, awsConfig.Region);//Use Access Key & Secret Key
                }

                IAmazonS3 s3Client = client;
                utility = new TransferUtility(client);
                TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
                //Convert to all lower case as S3 object is case sensitive
                filePath = filePath.ToLower();
                string subDirectoryInBucket = awsConfig.S3Configuration.SubDirectoryInBucket.ToLower();
                string bucketName = awsConfig.S3Configuration.BucketName.ToLower();

                if (string.IsNullOrEmpty(subDirectoryInBucket))
                {
                    request.BucketName = bucketName; //no subdirectory just bucket name  
                }
                else
                {   // subdirectory and bucket name  
                    request.BucketName = bucketName + @"/" + subDirectoryInBucket;
                }
                request.Key = awsConfig.S3Configuration.FileNameInS3.ToLower(); //Key is case sensitive hence follow all lower cases.
                request.InputStream = localFilePath;
                request.CannedACL = S3CannedACL.PublicRead;

                utility.Upload(request); //commensing the transfer  

                result = true; //indicate that the file was sent  
            }
            finally
            {
                localFilePath?.Dispose();
                utility?.Dispose();
                client?.Dispose();
            }
            return result;
        }
    }
}


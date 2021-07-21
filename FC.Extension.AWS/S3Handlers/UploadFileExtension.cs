using Amazon;
//using Amazon.S3;
//using Amazon.S3.Model;
//using Amazon.S3.Transfer;
//using Amazon.S3.Util;
//using System.IO;
using System.Threading.Tasks;

namespace FC.Extension.AWS.S3Handlers
{
    public static class UploadFileExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="bucketName"></param>
        /// <param name="subDirectoryInBucket"></param>
        /// <param name="fileNameInS3"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        //public async Task<bool> SendFileToS3(string filePath, string bucketName, 
        //    string subDirectoryInBucket, string fileNameInS3,
        //    ILogger logger, IOptions<AWSConfig> awsConfig)
        //{
        //    Stream localFilePath = null;
        //    TransferUtility utility = null;
        //    IAmazonS3 client = null;
        //    try
        //    {
        //        localFilePath = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //        string accessKey = awsConfig.Value.S3Access.AccessKey;
        //        string secretKey = awsConfig.Value.S3Access.SecretKey;
        //        client = new AmazonS3Client(accessKey, secretKey, RegionEndpoint.APSoutheast1);
        //        IAmazonS3 s3Client = client;
        //        await CreateBucketAsync(s3Client, bucketName);//Create S3 Bucket if bucket is not available.

        //        utility = new TransferUtility(client);
        //        TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
        //        //Convert to all lower case as S3 object is case sensitive
        //        filePath = filePath.ToLower();
        //        subDirectoryInBucket = subDirectoryInBucket.ToLower();
        //        bucketName = bucketName.ToLower();

        //        if (subDirectoryInBucket == "" || subDirectoryInBucket == null)
        //        {
        //            request.BucketName = bucketName; //no subdirectory just bucket name  
        //        }
        //        else
        //        {   // subdirectory and bucket name  
        //            request.BucketName = bucketName + @"/" + subDirectoryInBucket;
        //        }
        //        request.Key = fileNameInS3.ToLower(); //Key is case sensitive hence follow all lower cases.
        //        request.InputStream = localFilePath;
        //        request.CannedACL = S3CannedACL.PublicRead;

        //        utility.Upload(request); //commensing the transfer  

        //        logger.LogInformation("Uploaded to S3 Bucket");

        //        return true; //indicate that the file was sent  
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, "Failed to Upload S3", null);
        //        return false;
        //    }
        //    finally
        //    {
        //        localFilePath?.Dispose();
        //        utility?.Dispose();
        //        client?.Dispose();
        //    }

        //}
    }
}

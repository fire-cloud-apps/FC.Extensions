using Amazon;
using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Extension.AWS.Common
{
    /// <summary>
    /// AWS Configuration file - A Basic configuration items which is applicable for most of the AWS Service
    /// </summary>
    public class AWSConfig : AWSBaseModel
    {
        public S3Config S3Configuration { get; set; }
    }

    public class S3Config 
    {        
        public string S3Region { get; set; }
        public string BucketName { get; set; }
        public string SubDirectoryInBucket { get; set; }
        public string FileNameInS3 { get; set; }        
    }
    /// <summary>
    /// A Base configuration property inherited by AWSConfig
    /// </summary>
    public class AWSBaseModel
    {
        /// <summary>
        /// Access Key to access the AWS Resources
        /// </summary>
        public string AccessKey { get; set; }
        /// <summary>
        /// Secret Key to access the AWS Resources
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// Which region to consume the service.
        /// </summary>
        public RegionEndpoint Region { get; set; } = RegionEndpoint.APSoutheast1;
    }
}


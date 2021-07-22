using Amazon;
using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Extension.AWS.Common
{
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
    public class AWSBaseModel
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public RegionEndpoint Region { get; set; } = RegionEndpoint.APSoutheast1;
    }
}

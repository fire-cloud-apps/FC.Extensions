using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Extension.AWS.Common
{
    public static class AWSConstants
    {
        public const string AES256 = "AES_256";
        /// <summary>
        /// Default chunk size is '10.48 MB'
        /// </summary>
        public const int CHUNK_SIZE = 10485760; //In Bytes.
    }
}

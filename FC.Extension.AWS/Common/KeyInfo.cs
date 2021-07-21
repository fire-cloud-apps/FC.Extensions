using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Extension.AWS.Common
{
    /// <summary>
    /// Key info which is received from AWS KMS
    /// </summary>
    public class KeyInfo

    {
        /// <summary>
        /// Plain Key from KMS Service
        /// </summary>
        public string Plainkey { get; set; }
        /// <summary>
        /// Cypher Key from KMS Service
        /// </summary>
        public string CypherKey { get; set; }
    }
}

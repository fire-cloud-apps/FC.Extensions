using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FC.Core.Extension.ImageHandlers
{
	/// <summary>
	/// Reads the image from the URL and return as Byte array
	/// </summary>
	public class ImageUtility
    {
		/// <summary>
		/// Reads the image from the URL and return as Byte array
		/// </summary>
		/// <param name="url">image url</param>
		/// <example>
		/// <code lang="csharp">
		/// byte[] imageArray = ImageAsByte.GetImageAsByte("https://domain.com/file/avatar.png");
		/// </code>
		/// </example>
		/// <returns>return as byte array</returns>
		public static byte[] GetImageAsByte(string url)
		{
			Stream stream = null;
			byte[] buf;
			HttpWebRequest req = null;
			HttpWebResponse response = null;

			try
			{
				req = WebRequest.Create(url) as HttpWebRequest;
				response = req.GetResponse() as HttpWebResponse;
				stream = response.GetResponseStream();

				using (BinaryReader br = new BinaryReader(stream))
				{
					int len = (int)(response.ContentLength);
					buf = br.ReadBytes(len);
					br.Close();
				}
			}
            finally
            {
				if (stream != null)
				{
					stream.Dispose();
				}
				if (response != null)
				{
					response.Close();
					response.Dispose();
				}
			}

			return (buf);
		}

	}
}

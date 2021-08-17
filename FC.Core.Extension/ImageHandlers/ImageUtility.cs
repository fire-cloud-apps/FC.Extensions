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
		/// <param name="httpURL">image url</param>
		/// <example>
		/// <code lang="csharp">
		/// byte[] imageArray = ImageAsByte.GetImageAsByte("https://domain.com/file/avatar.png");
		/// </code>
		/// </example>
		/// <returns>return as byte array</returns>
		public static byte[] GetImageAsByte(Uri httpURL)
		{
			Stream stream = null;
			byte[] buf;
			HttpWebRequest req = null;
			HttpWebResponse response = null;

			try
			{
				//Uri uri = new Uri(httpURL);
				req = WebRequest.Create(httpURL) as HttpWebRequest;
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

		/// <summary>
		/// Get the http URL image as base64 image string.
		/// </summary>
		/// <param name="httpURL">HTTP URL path of the image.</param>
		/// <returns>returns base64 string as image</returns>
		public static string ImageToBase64(Uri httpURL)
        {
			byte[] imageAsByte = GetImageAsByte(httpURL);
			string base64String = Convert.ToBase64String(imageAsByte);
			return base64String;
		}

		/// <summary>
		/// Get the image as Byte array
		/// </summary>
		/// <param name="fileURL">image form file path eg. @"C:\srg\45896\fileimge.jpg"</param>
		/// <returns>image as byte array</returns>
		public static byte[] GetImageAsByte(string fileURL)
        {			
			byte[] data = File.ReadAllBytes(fileURL);
			return data;
		}

		/// <summary>
		/// Converts the image to Base64 string
		/// </summary>
		/// <param name="fileURL">image form file path eg. @"C:\srg\45896\fileimge.jpg"</param>
		/// <returns>image as base64 string</returns>
		public static string ImageToBase64(string fileURL)
		{
			byte[] imageAsByte = GetImageAsByte(fileURL);
			string base64String = Convert.ToBase64String(imageAsByte);
			return base64String;
		}



	}
}

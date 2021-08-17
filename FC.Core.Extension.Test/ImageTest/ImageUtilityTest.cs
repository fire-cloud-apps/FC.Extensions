using FC.Core.Extension.ImageHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Shouldly;

namespace FC.Core.Extension.Test.ImageTest
{
    public class ImageUtilityTest
    {
        private readonly ITestOutputHelper _output;
        public ImageUtilityTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public async Task GetImageAsByte_Test()
        {
            Uri uri = new Uri("https://blog.cellenza.com/wp-content/uploads/2017/08/article-Migrating-from-TFVC-to-Git.jpg");
            byte[] imageArray = ImageUtility.GetImageAsByte(uri);
            imageArray.Length.ShouldBeGreaterThan(0);
            _output.WriteLine($"Image As Array Length {imageArray.Length}");
        }

        [Fact]
        public async Task GetImageAsBase64_Test()
        {
            Uri uri = new Uri("https://blog.cellenza.com/wp-content/uploads/2017/08/article-Migrating-from-TFVC-to-Git.jpg");
            byte[] imageArray = ImageUtility.GetImageAsByte(uri);
            imageArray.Length.ShouldBeGreaterThan(0);
            _output.WriteLine($"Image As Array Length : {imageArray.Length}");
            string base64Image = ImageUtility.ImageToBase64(uri);
            _output.WriteLine($"Image As Base64 Image : {base64Image}");

        }
    }
}

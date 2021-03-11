using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Infrastructure.Extensions
{
    public class UploaderExtensions
    {
        public static string ConvertToBase64(byte[] bytes)
        {

            string base64 = "data:application/pdf;base64," + Convert.ToBase64String(bytes);
            return base64;
        }

        public static byte[] ConvertToByteArray(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return fileBytes;
            }
        }
    }
}

using System;
using System.IO;
using System.Security.Cryptography;

namespace IEnumerableVisualizerDotNetStandard
{
    public static class Extensions
    {
        public static string GetMd5String(this FileInfo fileInfo)
        {
            string result = null;

            if (fileInfo != null)
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(fileInfo.FullName))
                    {
                        var hash = md5.ComputeHash(stream);

                        if (hash != null)
                        {
                            result = Convert.ToBase64String(hash);
                        }
                    }
                }
            }

            return result;
        }
    }
}

using System;
namespace CrystalLibrary
{
    internal sealed class Helpers
    {
        public static string FileName(string fullPath)
        {
            string result;
            if (fullPath != null)
            {
                int num = fullPath.LastIndexOf("\\");
                if (num > 0)
                {
                    result = fullPath.Substring(num + 1);
                    return result;
                }
            }
            result = fullPath;
            return result;
        }
        public static string FileExtension(string fullPath)
        {
            string result;
            if (fullPath != null && fullPath.Length > 0)
            {
                string text = Helpers.FileName(fullPath);
                int num = text.LastIndexOf(".");
                if (num > 0)
                {
                    result = text.Substring(num + 1);
                    return result;
                }
            }
            result = string.Empty;
            return result;
        }
    }
}

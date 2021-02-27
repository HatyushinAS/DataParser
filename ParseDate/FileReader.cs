using System;
using System.Globalization;
using System.IO;
using System.Linq;
using ParseDate.Models;

namespace ParseDate
{
    public class FileReader
    {
        public static string ReadTextFromFile(FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));
            using (var streamReader = new StreamReader(file.FullName))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static DateTime ParseDate(FileInfo file)
        {
            var fileName = file.Name.Split('.');
            string dateMask = "yyyyMMdd.HH_mm_ss";
            return DateTime.ParseExact(string.Join(".", fileName.Take(2)), dateMask, CultureInfo.InvariantCulture);
        }
        
        public static OneFile GetDateFromFile(FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));
            string text = ReadTextFromFile(file);
            var date = ParseDate(file);
            var recordings = ParseText.ParseInputText(text);
            return new OneFile() {Date = date, Recordings = recordings.ToList()};
        }
    }
}
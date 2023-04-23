using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        using (FileStream istream = new FileStream("C:\\Users\\sadco\\Desktop\\Война и мир.txt", FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[istream.Length];
            istream.Read(buffer, 0, buffer.Length);
            string textFromFile = Encoding.Default.GetString(buffer);
            var text = Regex.Split(textFromFile, @"\W")
                .Where(x => x.Length > 0)
                .GroupBy(x => x)
                .Select(x => new { Word = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count);

            var ans = new StringBuilder();
            foreach (var item in text)
            {
                ans.Append($"{item.Word} {item.Count}").AppendLine();
            }

            using (FileStream ostream = new FileStream("C:\\Users\\sadco\\Desktop\\Ответ.txt", FileMode.OpenOrCreate))
            {
                byte[] buffer2 = Encoding.Default.GetBytes(ans.ToString());
                ostream.Write(buffer2, 0, buffer2.Length);
            }
        }
    }

}

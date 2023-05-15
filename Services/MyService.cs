using ClosedXML.Excel;
using MusicShopc.Models;

namespace MusicShopc.Services
{
    public interface IMyService
    {
        int GetRandomInt();
        string GetRandomText();
        byte[] GetExcelFile();
    }

    public class MyService : IMyService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MyService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public int GetRandomInt()
        {
            Random random = new Random();
            return random.Next();
        }

        public string GetRandomText()
        {
            string[] texts = { "hello", "world", "foo", "bar", "baz" };
            Random random = new Random();
            return texts[random.Next(texts.Length)];
        }

        public byte[] GetExcelFile()
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Sample Sheet");
            ws.Cell("A1").Value = "Hello World!";
            using var stream = new MemoryStream();
            wb.SaveAs(stream);
            return stream.ToArray();
        }
    }



}

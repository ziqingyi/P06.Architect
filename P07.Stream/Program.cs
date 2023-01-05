
using System.Runtime.CompilerServices;

namespace P07.Stream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DownloadByHttpClient();
            Console.WriteLine("Hello, World!");
        }

        private static void DownloadByHttpClient()
        {
            string down = "https://download.visualstudio.microsoft.com/download/pr/5b9d1f0d-9c56-4bef-b950-c1b439489b27/b4aa387715207faa618a99e9b2dd4e35/dotnet-sdk-7.0.100-win-x64.exe";
            string path = AppDomain.CurrentDomain.BaseDirectory + "Files";
            if (!Directory.Exists(path))
            { Directory.CreateDirectory(path); }
            string filename = System.IO.Path.GetFileName(down);
            //main is not async
            TaskAwaiter<bool> rel = DownloadFile(down, path, filename).GetAwaiter();
            Console.WriteLine(rel.GetResult());
        }


        const int BufferSize = 8192;// size of buffer, 8192 byte, 8KB. 
        static readonly HttpClient _httpClient = new HttpClient();//singleton

        static async Task<bool> DownloadFile(string url, string directoryName, string fileName)
        {
            bool sign = true;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    string extension = Path.GetExtension(response.RequestMessage.RequestUri.ToString());
                    using (FileStream fileStream = new FileStream($"{directoryName}/{fileName}{extension}", FileMode.CreateNew))
                    {
                        byte[] buffer = new byte[BufferSize];
                        int readLength = 0;
                        int length;
                        while ((length = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                        {
                            readLength += length;
                            // write some bytes to file stream. 
                            fileStream.Write(buffer, 0, length);
                        }
                    }
                }
            }
            catch (IOException)
            {  
                sign = false;
                Console.WriteLine("please check file name and time limit. ");
            }
            return sign;
        }
    }
}
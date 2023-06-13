using System;
using System.IO;

namespace Wiki_Hitler
{
    class FileWorker : IDataWorker
    {

        string Path = @"D:\HitlerFile.txt";

        public string GetData()
        {
            while (true)
            {

                if (File.Exists(Path))
                {

                    Console.WriteLine("read file\n\n");
                    return File.ReadAllText(Path);
                }
                else
                {
                    Console.WriteLine("no file\n\n");
                    File.Create(Path).Close();
                    File.WriteAllText(Path, "{\"item\":[{\"name\": \"Adolf Hitler\",\"layer\": 0, \"links\":[]}]}");

                    continue;
                }

            }
        }


        public void SafeData(string Data)
        {
            File.WriteAllText(Path, Data);

            Console.WriteLine("data saved\n\n");
        }

    }
}

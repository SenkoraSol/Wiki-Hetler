using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;

namespace Wiki_Hitler
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //создание списка для запроса
            List<string> WorkLoad = new List<string>();

            //создание экземпляра процессора
            DataProcesor procesor = new DataProcesor(new FileWorker());

            //заполнение списка через GetPureLinks 
            WorkLoad.AddRange(procesor.GetPureLinks());

            if (WorkLoad.Count == 0)
            {
                WorkLoad.Add(await WikiRandom.GetRandomTitleAsync());
            }
            if (WorkLoad.Count > 100)
            {
                WorkLoad = WorkLoad.GetRange(0, 99);
            }




            for (int i = 0; i < 4; i++)
            {
                //сообщение о начале цикла
                Console.WriteLine($"\n\n\n   lup {i} start, {WorkLoad.Count} in load\n");

                List<string> tempLinkLoad = new List<string>();
                foreach (var item in WorkLoad)
                {
                    Console.WriteLine("\nstart proces for " + item);
                    try
                    {
                        var test = HtmlCuter.AngleSharpParse(await HtmlGeter.HtmlStringGetAsync(item));
                        procesor.ProcesNewData(item, (List<string>)test);
                        tempLinkLoad.AddRange(test);
                        Thread.Sleep(200);
                        Console.WriteLine("end proces for "+ item);
                    }
                    catch(Exception e)
                    {

                        Console.WriteLine("\n\n");
                        Console.WriteLine("ops\n" + e);
                        Console.WriteLine( "\n\n" );
                        continue;
                    }
                    
                    
                }
                procesor.GetPureLinks(ref tempLinkLoad);
                WorkLoad.Clear(); 
                WorkLoad.AddRange(tempLinkLoad);
                if (WorkLoad.Count > 100)
                {
                    WorkLoad = WorkLoad.GetRange(0, 99);
                }
                tempLinkLoad.Clear();
               
            }
            procesor.PackData();

            Console.WriteLine("work done");
            Console.ReadLine();
            

        }
    }

    
}

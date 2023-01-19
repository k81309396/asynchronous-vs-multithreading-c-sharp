using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace asynchronous_vs_multithreading_c_sharp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Asynchronous Begin
            Console.WriteLine("Asynchronous Start");
            var task1 = Task_Async("https://www.google.com/", 1);
            var task2 = Task_Async("https://www.google.com/", 2);
            var task3 = Task_Async("https://www.google.com/", 3);
            var task4 = Task_Async("https://www.google.com/", 4);
            var task5 = Task_Async("https://www.google.com/", 5);
            var task6 = Task_Async("https://www.google.com/", 6);
            var task7 = Task_Async("https://www.google.com/", 7);
            var task8 = Task_Async("https://www.google.com/", 8);
            var task9 = Task_Async("https://www.google.com/", 9);
            var task10 = Task_Async("https://www.google.com/", 10);
            await Task.WhenAll(task1, task2, task3, task4, task5, task6, task7, task8, task9, task10);
            //Asynchronous End

            //Console.WriteLine("---------------------------------------------------------------\n");
            Console.WriteLine("\n");
            Console.WriteLine("MultiThreading Start");

            ////Multi thread begin
            MultiThreading multithreading = new MultiThreading();
            multithreading.ExecuteThread("https://www.google.com/", 1);
            multithreading.ExecuteThread("https://www.google.com/", 2);
            multithreading.ExecuteThread("https://www.google.com/", 3);
            multithreading.ExecuteThread("https://www.google.com/", 4);
            multithreading.ExecuteThread("https://www.google.com/", 5);
            multithreading.ExecuteThread("https://www.google.com/", 6);
            multithreading.ExecuteThread("https://www.google.com/", 7);
            multithreading.ExecuteThread("https://www.google.com/", 8);
            multithreading.ExecuteThread("https://www.google.com/", 9);
            multithreading.ExecuteThread("https://www.google.com/", 10);
            ////Multi thread End

        }
        public static async Task Task_Async(string url, int seq)
        {
            DateTime start = DateTime.Now;
            Stopwatch s2 = new Stopwatch();
            s2.Start();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                    }
                }
            }

            string msg = string.Concat("Task Async Ke ", seq, ", Start:  ", start.ToString("hh:mm:ss"), ", Total Waktu: ", s2.Elapsed.ToString());
            Console.WriteLine(msg);

        }
    }
}

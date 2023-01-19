using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;

namespace asynchronous_vs_multithreading_c_sharp
{
    public class MultiThreading: IDisposable
    {
        private string _url = "";
        int _seq = 0;
        public void ExecuteThread(string url, int seq)
        {
            _url = url;
            _seq = seq;
            Thread t = new Thread(new ThreadStart(MethodAsync));
            t.Start();
        }
        public void MethodAsync()
        {
            DateTime start = DateTime.Now;
            Stopwatch s2 = new Stopwatch();
            s2.Start();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(_url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = content.ReadAsStringAsync().Result;
                    }
                }
            }


            string msg = string.Concat("Method Thread Ke: ", _seq, ", Start:  ", start.ToString("hh:mm:ss"), ", Total Waktu: ", s2.Elapsed.ToString());
            Console.WriteLine(msg);
            Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

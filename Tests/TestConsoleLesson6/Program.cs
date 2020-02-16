using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsoleLesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Способ 1
            //new Thread(() => { Console.WriteLine("Печать внутри потока"); }) { IsBackground = true }.Start();   //IsBackground = true - поток не блокирует основной поток

            /*
             * Способ 2
            Action<string> printer = str => Console.WriteLine("Печать сообщения из потока {0}:{1}", Thread.CurrentThread.ManagedThreadId, str);
            Вызов v.1 для спб2
            printer("Message 1");
            Вызов v.2 для спб2 
            printer.Invoke("Message 2");            
            
             * Вызов v.3 для спб2. Данный способ вывода в .net core запрещен, как устаревший
            IAsyncResult result = null;
            result = printer.BeginInvoke("Message 3", r=>printer.EndInvoke(result), null);
            */


            //Способ 3
            //BackgroundWorker worker = new BackgroundWorker();
            //worker.DoWork += (s, e) => { /* Здесь выполняется сама асинхронная операция */};
            //worker.ProgressChanged += (s, e) => { /* Здесь выполняются по изменению UI при изменении прогресса операции*/};
            //worker.RunWorkerAsync(); - запускает событие DoWork
            //worker.RunWorkerCompleted - при завершении операции


            // Параллельное выполнение методов
            //Invoke держит основной поток до выполнения всех вызванных потоков            
            /*
            Parallel.Invoke(
                new ParallelOptions { MaxDegreeOfParallelism = 2},  //Максимальное колво параллельных потоков
                ParallelInvokeMethod, 
                ParallelInvokeMethod, 
                ParallelInvokeMethod,
                ()=>Console.WriteLine($"Еще один параллельный вызов {Thread.CurrentThread.ManagedThreadId}"));  
            */

            //Parallel.Invoke(new ParallelOptions { MaxDegreeOfParallelism = 3}, Enumerable.Repeat(new Action(ParallelInvokeMethod), 100).ToArray());





            //параллельный цикл for
            //Parallel.For(0, 100, i => ParallelInvokeMethod($"Message {i}"));
            //Parallel.For(0, 100, new ParallelOptions { MaxDegreeOfParallelism = 2}, i => ParallelInvokeMethod($"Message {i}"));
            /*
            var for_result = Parallel.For(0, 100, new ParallelOptions { MaxDegreeOfParallelism = 2 }, (i, state) =>
            {
                if (i > 15) state.Break();  //прерывание доп потоков
                ParallelInvokeMethod($"Message {i}");
            });
            
            Console.WriteLine("Выполнилось {0} итераций", for_result.LowestBreakIteration);
            */




            //Параллельный foreach
            //var messages = Enumerable.Range(1, 100).Select(i => $"Message {i:000}");//.ToArray();
            //Parallel.ForEach(messages, ParallelInvokeMethod);
            /*
            var foreach_result = Parallel.ForEach(messages, (s, state) =>
            {
                if (s.EndsWith("20")) state.Break();
                ParallelInvokeMethod(s);
            });
            Console.WriteLine("Выполнилось {0} итераций", foreach_result.LowestBreakIteration);
            */





            //Параллельное выполнение LinQ запроса
            /*
            var messages = Enumerable.Range(1, 1000).Select(i => $"Message {i:000}");//.ToArray();
            var long_creating_messages = messages.
                AsParallel().                               //Параллельное выполнение LinQ
                //AsSequential().   //Последовательное выполнение запроса
                WithDegreeOfParallelism(degreeOfParallelism: 3).    //Количество потоков
                WithExecutionMode(ParallelExecutionMode.ForceParallelism).   //Система сама принимает решение о необходимости распараллеливать запрос                
                Select(
                m =>
                {
                    Console.WriteLine("Запрос сообщение {0}", m);
                    Thread.Sleep(250);
                    Console.WriteLine("Сообщение {0} сформировано", m);
                    return m;
                });

            
            var selected_messages = long_creating_messages.                
                Select(m => (msg: m, length: m.Length)).
                Where(m => m.msg.EndsWith("20")).
                ToArray();
            */


            Console.WriteLine("Главный поток завершился");
            Console.ReadLine();
            Console.WriteLine("Приложение должно быть закрыто");
        }

        private static void ParallelInvokeMethod() 
        {
            Console.WriteLine("ThrID: {0} - started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(250);
            Console.WriteLine("ThrID: {0} - finished", Thread.CurrentThread.ManagedThreadId);
        }

        private static void ParallelInvokeMethod(string msg)
        {
            Console.WriteLine("ThrID: {0} - started, {1}", Thread.CurrentThread.ManagedThreadId, msg);
            Thread.Sleep(250);
            Console.WriteLine("ThrID: {0} - finished, {1}", Thread.CurrentThread.ManagedThreadId, msg);
        }
    }
}

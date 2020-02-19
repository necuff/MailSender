using MailSenderLib.Entities;
using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSenderLib.Services
{
    public class MailSchedulerTPL
    {
        private readonly IShedulerTasksStore _TaskStore;
        private volatile CancellationTokenSource _ProcessTaskCancellation;  //volatile - поле используется разными потоками. Инфа для компилятора

        public MailSchedulerTPL(IShedulerTasksStore TaskStore)
        {
            _TaskStore = TaskStore;
        }

        public async Task StartAsync()
        {
            var cancellation = new CancellationTokenSource();
            Interlocked.Exchange(ref _ProcessTaskCancellation, cancellation)?.Cancel();

            var first_task = _TaskStore.GetAll()
                .Where(task => task.Time > DateTime.Now)
                .OrderBy(task => task.Time)
                .FirstOrDefault();
            if (first_task is null) return;

            WaitTaskAsynk(first_task, cancellation.Token);
        }

        private async void WaitTaskAsynk(ShedulerTask task, CancellationToken Cancel)
        {
            var task_time = task.Time;
            var delta = task_time.Subtract(DateTime.Now);

            await Task.Delay(delta, Cancel).ConfigureAwait(false);
            await ExecuteTask(task, Cancel);

            _TaskStore.Remove(task.Id);
            await StartAsync();
        }

        private async Task ExecuteTask(ShedulerTask task, CancellationToken Cancel)
        {

        }
    }
}

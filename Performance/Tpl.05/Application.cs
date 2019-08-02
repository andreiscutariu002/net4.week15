using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tpl._05
{
    public class Application
    {
        private readonly string _directory;
        private CancellationTokenSource _cancellationTokenSource;

        public Application(string directory)
        {
            _directory = directory;

            _cancellationTokenSource = new CancellationTokenSource();

        }

        public void Run()
        {
            var readFilesTask = new Task<List<string>>(() =>
            {
                return Directory.GetFiles(_directory).ToList();
            }, _cancellationTokenSource.Token);

            readFilesTask.Start();

            var readFileContentTask = readFilesTask.ContinueWith(prevTask =>
            {
                var files = prevTask.Result;

                var tasks = new List<Task>();

                foreach (var file in files)
                {
                    var task = new Task(() =>
                    {
                        Console.WriteLine($"Read start for {file}.");
                        var lines = File.ReadAllLines(file);
                        Console.WriteLine($"Read done for {file}; {lines.Length} elements.");
                    }, _cancellationTokenSource.Token);

                    tasks.Add(task);

                    task.Start();
                }

                Task.WaitAll(tasks.ToArray());

            }, _cancellationTokenSource.Token);

            readFileContentTask.Wait();
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tpl._06
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

        public async Task Run()
        {
            var files = await ReadFilesAsync();

            ReadContentFiles(files);
        }

        private void ReadContentFiles(List<string> files)
        {
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
        }

        private async Task<List<string>> ReadFilesAsync()
        {
            List<string> files = Directory.GetFiles(_directory).ToList();
            return files;
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
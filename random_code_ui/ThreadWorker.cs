using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace random_code_ui
{
    internal class ThreadWorker : IDisposable
    {
        Thread th;
        public event EventHandler DoWork;
        public event EventHandler OnCompleted;
        public string Name;
        public event ProcessChangedEventHandler OnProcessChanged;
        public delegate void ProcessChangedEventHandler(object sender, ProgressEventArgs e);

        // 기타 전달할 데이터
        public object Props;

        public ThreadWorker()
        {
            th = new Thread(Work);
            th.IsBackground = true;
        }

        public ThreadState Status()
        {
            return th.ThreadState;
        }

        public void Stop()
        {
            th.Abort();
        }

        public void ReportProgress(float per)
        {
            OnProcessChanged?.Invoke(this, new ProgressEventArgs(per));
        }

        public void Run(bool isJoin = false)
        {
            th.Start();
            if (isJoin)
                th.Join();
        }

        private void Work()
        {
            DoWork?.Invoke(this, EventArgs.Empty);
            OnCompleted?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(float percent)
        {
            this.Percent = percent;
        }

        public float Percent { get; private set; }
    }
}

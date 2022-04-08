using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace random_code_ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "TXT File|*.txt";
            save.Title = "Save File";
            save.ShowDialog();

            if (save.FileName != "")
            {
                lbSaveFile.Text = save.FileName;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            lbSaveFile.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gen.txt";
        }


        private void btnGen_Click(object sender, EventArgs e)
        {

            long motherTree = (long)Math.Pow((int)txtDigit.Value, txtAllowedText.Text.Length);

            if (motherTree < (long)this.txtTotal.Value)
            {
                MessageBox.Show("모수가 더 작습니다.");
                return;
            }

            string msg =
@"동작 중엔 멈출 수 없습니다. 
모수대비 생성갯수의 비율이 크면 오래 걸립니다. 
그래도 생성하시겠습니까?";

            var result = MessageBox.Show(msg, "생성하기", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SetControl(false);

                ThreadWorker tw = new ThreadWorker();
                tw.DoWork += Generate;
                tw.OnCompleted += Tw_OnCompleted;
                tw.OnProcessChanged += Tw_OnProcessChanged;
                tw.Run();

            }
        }

        private void Tw_OnProcessChanged(object sender, ProgressEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.btnGen.Text = (e.Percent * 100).ToString("#,###.00") + "%";
                Application.DoEvents();
            }));
        }

        private void Tw_OnCompleted(object sender, EventArgs e)
        {
            ThreadWorker tw = ((ThreadWorker)sender);
            tw.Dispose();

            this.Invoke(new MethodInvoker(delegate
            {
                MessageBox.Show("완료!");
                SetControl(true);
                btnGen.Text = "생성";
            }));
        }

        private static Dictionary<string, object> map = new Dictionary<string, object>();

        private void Generate(object sender, EventArgs e)
        {
            map.Clear();
            DoRandomDic(sender);

            using (var fs = new FileStream(this.lbSaveFile.Text, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, FileOptions.Asynchronous | FileOptions.SequentialScan))
            {
                using (StreamWriter sw = new StreamWriter(fs, new UTF8Encoding(false)))
                {
                    foreach (var k in map.Keys)
                    {
                        sw.WriteLine(k);
                    }
                }
            }

            ThreadWorker tw = ((ThreadWorker)sender);
            tw.ReportProgress(1);

        }

        private void SetControl(bool flag)
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = flag;
            }
        }

        public void DoRandomDic(object sender)
        {
            ThreadWorker tw = ((ThreadWorker)sender);
            Random r = new Random(Guid.NewGuid().GetHashCode());

            string AllowedChars = this.txtAllowedText.Text;
            int CodeCipher = (int)this.txtDigit.Value;
            int WantedCount = (int)this.txtTotal.Value;

            while (map.Count < WantedCount)
            {
                StringBuilder sb = new StringBuilder();
                for (var i = 0; i < CodeCipher; i++)
                {
                    sb.Append(AllowedChars[r.Next(AllowedChars.Length)]);
                }
                string code = sb.ToString();
                if (!map.ContainsKey(code))
                {
                    map.Add(sb.ToString(), null);

                    if (map.Count % 100 == 0)
                    {
                        // 보고
                        float percent = (float)map.Count / (float)WantedCount;
                        if (percent > 50)
                        {
                            // 파일 생성이 필요하므로 100을 안채우도록 한다.
                            percent = percent - (float)0.1;
                        }
                        tw.ReportProgress(percent);
                    }

                }
            }
        }

    }
}

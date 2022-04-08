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
                btnGen.Enabled = false;

                Thread trd = new Thread(new ThreadStart(this.Generate));
                trd.IsBackground = true;
                trd.Start();


            }
        }


        private static Dictionary<string, object> map = new Dictionary<string, object>();

        private void Generate()
        {
            map.Clear();
            DoRandomDic();

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

            this.Invoke(new MethodInvoker(delegate
            {
                MessageBox.Show("완료!");
                btnGen.Enabled = true;
            }));

        }


        public void DoRandomDic()
        {

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
                    map.Add(sb.ToString(), null);
            }
        }

    }
}

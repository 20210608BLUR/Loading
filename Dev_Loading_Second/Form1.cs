using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Dev_Loading_Second
{
    public partial class LoadingForm : Form
    {
        private BackgroundWorker bw;

        public LoadingForm()
        {
            InitializeComponent();
            initBackgroundWorker();
            pictureBox1.Visible = false;
            btnStart.Enabled = true;
        }

        private void initBackgroundWorker()
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        // 背景執行
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            loadingTime(textBox1.Text);
        }

        // 計算 loading 時間 
        private void loadingTime(string j)
        {
            for (int i = 1; i <= Convert.ToInt32(j); i++)
            {
                // 使用 sleep 模擬運算時的停頓
                System.Threading.Thread.Sleep(100);
                bw.ReportProgress((i * 1));
            }

        }

        // 處理進度
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.lblMsg.Text = $"處理中... " + e.ProgressPercentage.ToString();
        }

        // 執行完成
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lblMsg.Text = "完成!";
            btnStart.Enabled = true;
            pictureBox1.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if (textBox1.Text.All(char.IsDigit))
                {
                    if (bw.IsBusy != true)
                    {
                        btnStart.Enabled = false;
                        pictureBox1.Visible = true;
                        this.lblMsg.Text = "開始";
                        bw.RunWorkerAsync();

                    }
                }
                else
                {
                    MessageBox.Show("請輸入正確格式!");
                }               
            }            
            else
            {
                MessageBox.Show("請輸入數字!");
            }
            
        }

    }
}

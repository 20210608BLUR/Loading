using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Dev_Loading
{
    public partial class Form1 : Form
    {
        WaitFormFunc waitFormFunc = new WaitFormFunc();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Loading_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;//漏斗指標

            ////執行大量的計算時,為了讓使用者知道還在運算中,將Mouse指標變為漏斗
            //System.Threading.Thread.Sleep(5000);//用Sleep模擬大量運算

            //this.Cursor = Cursors.Default;//還原預設

            try
            {
                waitFormFunc.show(this);
                Thread.Sleep(5000);
                this.Cursor = Cursors.WaitCursor;
                waitFormFunc.close();
            }
            catch { }


        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_Loading
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        // 設置等待條
        public WaitForm(Form mainForm)
        {
            InitializeComponent();
            if(mainForm != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(mainForm.Location.X + mainForm.Width / 2 - this.Width / 2,
                                          mainForm.Location.X + mainForm.Height / 2 - this.Height / 2);
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }

        }
        
        public void closeWaitForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            if(lbl_Image.Image != null)
            {
                lbl_Image.Dispose();
            }

        }
    }
}

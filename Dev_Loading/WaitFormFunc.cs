using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_Loading
{
    public class WaitFormFunc
    {
        WaitForm wf;
        Thread td;

        public void show(Form show)
        {
            td = new Thread(new ParameterizedThreadStart(loading));
            td.Start(show);
        }

        public void close()
        {
            if (wf != null)
            {
                wf.BeginInvoke(new ThreadStart(wf.closeWaitForm));
                wf = null;
                td = null;
            }
        }

        private void loading(object load)
        {
            Form loading = load as Form;
            wf = new WaitForm(loading);
            wf.ShowDialog();
        }


    }
  




}

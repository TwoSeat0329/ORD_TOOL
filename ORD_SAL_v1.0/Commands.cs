using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ORD_SAL_v1._0;
using System.Threading;

namespace ORD_SAL_v1
{
    public sealed class Commands
    {
        private BackgroundWorker Worker;
        sendMsg s;
        List<string> missonlist = new List<string>();
        bool beforeround15 = true;
        public bool state;
        bool missionBuild = true;
        

        IntPtr off = IntPtr.Zero;

        public Commands()
        {
            state = true;
            s = sendMsg.getInstance;
            Worker = new BackgroundWorker();
            Worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
            Worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {

            if (missionBuild)
            {
                off = s.GetMissonOffset();

                if (off != IntPtr.Zero)
                {                      
                    missionBuild = false;
                    s.Send("「ORD_TOOL」[미션 건물 설정완료]");
                }
            }
            else
            {
                missonlist = s.GetMissonState(off);
                if (beforeround15)
                {
                    
                    if (missonlist[0] == "매진")
                    {
                        s.Send("「ORD_TOOL」[미션 알리미 시작]");
                        beforeround15 = false;
                    }
                }
                else
                {
                    
                    if (missonlist[0] == "")
                    {
                        s.Send("「ORD_TOOL」[해적단 쿨타임이 돌아왔습니다.]");
                        Thread.Sleep(1000);
                    }
                    if (missonlist[1] == "")
                    {
                        s.Send("「ORD_TOOL」[스모커 쿨타임이 돌아왔습니다.]");
                        Thread.Sleep(1000);
                    }
                }
            }
            
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Task.Delay(200);
            if (state)
                Worker.RunWorkerAsync();
        }
    }
}

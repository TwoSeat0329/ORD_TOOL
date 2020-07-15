using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ORD_SAL_v1._0;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

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
        System.Timers.Timer timer = new System.Timers.Timer();
        System.Timers.Timer timer1 = new System.Timers.Timer();
        bool PiratesPress, SmokerPress = true;
        

        IntPtr off = IntPtr.Zero;

        public Commands()
        {
            state = true;
            s = sendMsg.getInstance;
            Worker = new BackgroundWorker();
            Worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
            Worker.RunWorkerAsync();

            timer.Interval = 1000 * 295;
            timer.Elapsed += new ElapsedEventHandler(timer_Pirates);

            timer1.Interval = 1000 * 505;
            timer1.Elapsed += new ElapsedEventHandler(timer_Smoker);
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
                else
                {               
                    return; 
                }
            }
            else
            {
                missonlist = s.GetMissonState(off);
                if (missonlist == null)
                {
                    return;
                }
                if (beforeround15)
                {

                    if (missonlist[0] == "매진")
                    {
                        timer.Start();
                        s.Send("「ORD_TOOL」[해적단 알리미 시작]");
                        beforeround15 = false;
                        PiratesPress = false;
                    }
                }
                else
                {
                    if (missonlist[0] == "")
                    {
                        PiratesPress = true;
                    }
                    if (missonlist[1] == "")
                    {
                        SmokerPress = true;
                    }
                    if (missonlist[0] == "매진")
                    {
                        if (PiratesPress)
                        {
                            s.Send("「ORD_TOOL」[해적단 알리미 시작]");
                            timer.Start();
                            PiratesPress = false;
                        }

                    }
                    if (missonlist[1] == "매진")
                    {
                        if (SmokerPress)
                        {
                            s.Send("「ORD_TOOL」[스모커 알리미 시작]");
                            timer1.Start();
                            SmokerPress = false;
                        }
                    }                 
                }
            }

        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Task.Delay(200);
            if (state)
            {
                Worker.RunWorkerAsync();
            }
            else
            {
                timer.Stop();
                timer1.Stop();
            }
        }

        private void timer_Pirates(Object source, ElapsedEventArgs e)
        {
            s.Send("「ORD_TOOL」[ 해적단 쿨타임이 5초 남았습니다.]");  
            timer.Stop();
        }
        private void timer_Smoker(Object source, ElapsedEventArgs e)
        {
            s.Send("「ORD_TOOL」[ 스모커 쿨타임이 5초 남았습니다.]");
            timer1.Stop();
        }
    }
}

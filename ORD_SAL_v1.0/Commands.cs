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
        private static BackgroundWorker Worker;
        sendMsg s;
        List<string> missonlist = new List<string>();
        public bool state;
        bool PiratesPress, SmokerPress;
        bool missionBuild = true;
        bool beforeround15 = true;
        bool MissonState = true;
        //System.Timers.Timer timer = new System.Timers.Timer();
       // System.Timers.Timer timer1 = new System.Timers.Timer();
        Thread timer1, timer2;
        String strPirates, strSmoker;

        IntPtr off = IntPtr.Zero;

        public Commands()
        {
            if((s = sendMsg.getInstance) == null)
            {
                state = false;
            }
            else
            {
                state = true;
                Worker = new BackgroundWorker();
                Worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
                Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);               

                timer1 = new Thread(() => timer_Pirates());

                timer2 = new Thread(() => timer_Smoker());

                //timer.Interval = 1000 * 295;
                //timer.Elapsed += new ElapsedEventHandler(timer_Pirates);

                //timer1.Interval = 1000 * 505;
                //timer1.Elapsed += new ElapsedEventHandler(timer_Smoker);
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {

            if (missionBuild)
            {
                off = s.GetMissonOffset();

                if (off != IntPtr.Zero)
                {
                   
                    s.Send("「ORD_TOOL」[미션 건물 설정완료]");
                    missionBuild = false;
                    return;
                }
                else
                {               
                    return; 
                }
            }
            else
            {
                missonlist = s.GetMissonState(off);
                if (missonlist == null) return;
                if (beforeround15)
                {

                    if (missonlist[0] == "매진")
                    {
                        timer1.Start();
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
                            timer1 = new Thread(() => timer_Pirates());
                            timer1.Start();
                            PiratesPress = false;
                        }

                    }
                    if (missonlist[1] == "매진")
                    {
                        if (SmokerPress)
                        {
                            timer2 = new Thread(() => timer_Smoker());
                            timer2.Start();
                            SmokerPress = false;
                        }
                    }
                }
            }

        }

        private async void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            await Task.Delay(200);
          
            if (state)
            {
                Worker.RunWorkerAsync();
            }
            else
            {
                if (timer1.IsAlive) timer1.Join();
                else timer1 = null;
                if (timer2.IsAlive) timer2.Join();
                else timer2 = null;
            }
        }

        async void timer_Pirates()
        {
            s.Send("「ORD_TOOL」[해적단 알리미 시작]");
            await Task.Delay(1000 * 295);
            s.Send("「ORD_TOOL」[ 해적단 쿨타임이 5초 남았습니다.]");
            timer1.Join();
        }

        async void timer_Smoker()
        {
            s.Send("「ORD_TOOL」[스모커 알리미 시작]");
            await Task.Delay(1000 * 505);
            s.Send("「ORD_TOOL」[ 스모커 쿨타임이 5초 남았습니다.]");
            timer2.Join();
        }

        internal static void StartDetect() => Worker.RunWorkerAsync();
    }
}

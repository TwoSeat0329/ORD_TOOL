using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORD_SAL_v1._0
{
    public class random_Pick
    {
        public bool overlap = true;
        int[] overlaplist4 = new int[4];
        int[] overlaplist6 = new int[6];
        int[] overlaplist8 = new int[8];
        private static random_Pick instance;
        private random_Pick() { }
        public static random_Pick getInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new random_Pick();
                }
                return instance;
            }
        }
        public int[] Start_Set(int savecount,int unitcount)
        {
            List<int> falsechecklist = new List<int>();
            foreach(var a in character_Info.Instance.chList)
            {
                if (!a.sel)
                    falsechecklist.Add(a.index);
            }

            int count = Saveroll(savecount);
            int[] randomcount = null;
            if (unitcount == 4)
            {
                randomcount = random(count, unitcount, overlaplist4, overlap, falsechecklist);
                overlaplist4 = randomcount;
            }
            else if (unitcount == 6)
            {
                randomcount = random(count, unitcount, overlaplist6, overlap, falsechecklist);
                overlaplist6 = randomcount;
            }
            else if (unitcount == 8)
            {
                randomcount = random(count, unitcount, overlaplist8, overlap, falsechecklist);
                overlaplist8 = randomcount;
            }
            return randomcount;
        }

        int Saveroll(int a)
        {

            if (a < 5)  // 노 영원함
            {
                return 25;
            }
            else if (a >= 5 && a < 15)  // 에이스
            {
                return 26;
            }
            else if (a >= 15 && a < 30) // 헨콕
            {
                return 27;
            }
            else if (a >= 30 && a < 35) // 오뎅
            {
                return 28;
            }
            else if (a >= 35) //미호크
            {
                return 29;
            }
            return 0;
        }


        // 랜덤 숫자 뽑아주는 함수
        static int[] random(int a, int b,int[] overlaplist, bool overlap, List<int> falsecheck)
        {
            int[] arr = new int[b];
            bool isSame;
            // bool PSame = true;

            Random r = new Random();
            for (int i = 0; i < b; i++)
            {
                while (true)
                {
                    arr[i] = r.Next(0, a);
                    isSame = false;
                    if (overlap)
                    {
                        foreach (int over in overlaplist)
                        {
                            if (arr[i] == over)
                                isSame = true;
                        }
                    }

                    foreach(int index in falsecheck)
                    {
                        if (arr[i] == index - 1)
                            isSame = true;
                    }
                    
                    for (int j = 0; j < i; ++j)
                    {
                        if (arr[i] == arr[j])
                        {
                            isSame = true;
                        }
                    }
                    if (!isSame) break;
                }
            }
            return arr;
        }
        public int[] randomteam(int a)
        {
            int[] arr = new int[a];
            bool isSame;
            // bool PSame = true;

            Random r = new Random();
            for (int i = 0; i < a; ++i)
            {
                while (true)
                {
                    arr[i] = r.Next(1, 100);
                    isSame = false;
                    for (int j = 0; j < i; ++j)
                    {
                        if (arr[i] == arr[j])
                        {
                            isSame = true;
                            break;
                        }
                    }
                    if (!isSame) break;
                }
            }
            return arr;
        }
    }
}

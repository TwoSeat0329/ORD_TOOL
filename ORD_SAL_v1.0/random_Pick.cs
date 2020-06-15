using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORD_SAL_v1._0
{
    public class random_Pick
    {
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
        public int[] start_Set(int savecount,int unitcount)
        {


            int count = saveroll(savecount);

            int[] randomcount = random(count, unitcount);

            return randomcount;
        }

        int saveroll(int a)
        {

            if (a < 5)  // 노 영원함
            {
                return 24;
            }
            else if (a >= 5 && a < 15)  // 에이스
            {
                return 25;
            }
            else if (a >= 15 && a < 35) // 헨콕
            {
                return 26;
            }
            else if (a >= 35) //미호크
            {
                return 27;
            }
            return 0;
        }


        // 랜덤 숫자 뽑아주는 함수
        static int[] random(int a, int b)
        {
            int[] arr = new int[b];
            bool isSame;
            // bool PSame = true;

            Random r = new Random();
            for (int i = 0; i < b; ++i)
            {
                while (true)
                {
                    arr[i] = r.Next(0, a);
                    isSame = false;
                    if (arr[i] == 0 || arr[i] == 16) isSame = true;
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
                    arr[i] = r.Next(1, 99);
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

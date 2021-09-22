using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ORD_SAL_v1._0
{
    //class로 바꿔야 할텐데...
    public struct characterDB
    {
        public int index;
        public string name;
        public string shortname;
        public string Salname;
        public Image img;
        public bool sel;
    }

    public class Commonamount
    {
        [JsonProperty(PropertyName = "이름")]
        public string characterName { get; set; }
        [JsonProperty(PropertyName = "루피")]
        public int Luppi { get; set; }
        [JsonProperty(PropertyName = "조로")]
        public int Zoro { get; set; }
        [JsonProperty(PropertyName = "나미")]
        public int Nami { get; set; }
        [JsonProperty(PropertyName = "우솝")]
        public int Usopp { get; set; }
        [JsonProperty(PropertyName = "상디")]
        public int Sanji { get; set; }
        [JsonProperty(PropertyName = "쵸파")]
        public int Chopper { get; set; }
        [JsonProperty(PropertyName = "버기")]
        public int Buggy { get; set; }
        [JsonProperty(PropertyName = "총병")]
        public int musketeer { get; set; }
        [JsonProperty(PropertyName = "칼병")]
        public int Swordsman { get; set; }
        [JsonProperty(PropertyName = "계")]
        public int TotalCommonamount { get; set; }
    }
    public class character_Info
    {
        public List<characterDB> chList = new List<characterDB>();
        public List<Commonamount> CommonamountList = new List<Commonamount>();


        #region 평천님이 짜준 싱글톤 모양 참고해서 다바꾸기
        private static character_Info _instance;
        private character_Info() { InitList(); }
        public static character_Info Instance => _instance ?? (_instance = new character_Info());
        #endregion
        public void InitList()
        {
            #region characterDB Init
            characterDB temp = new characterDB();
            temp.index = 1;
            temp.name = "|cff00fa9a조로|r";
            temp.img = Properties.Resources.조로;
            temp.shortname = "조로";
            temp.sel = false;
            chList.Add(temp);
            temp.index = 2;
            temp.name = "|cff00fa9a나미|r";
            temp.img = Properties.Resources.나미;
            temp.shortname = "나미";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 3;
            temp.name = "|cff00fa9a상디|r";
            temp.img = Properties.Resources.상디;
            temp.shortname = "상디";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 4;
            temp.name = "|cff00fa9a프랑키|r";
            temp.img = Properties.Resources.프랑키;
            temp.shortname = "프랑키";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 5;
            temp.name = "|cff00fa9a브룩|r";
            temp.img = Properties.Resources.브룩;
            temp.shortname = "브룩";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 6;
            temp.name = "|cff00fa9a샹크스|r";
            temp.img = Properties.Resources.샹크스;
            temp.shortname = "샹크스";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 7;
            temp.name = "|cff00fa9a검은수염|r";
            temp.img = Properties.Resources.검은수염;
            temp.shortname = "검은수염";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 8;
            temp.name = "|cff00fa9a시라호시|r";
            temp.img = Properties.Resources.시라호시;
            temp.shortname = "시라호시";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 9;
            temp.name = "|cff00fa9a아오키지|r";
            temp.img = Properties.Resources.아오키지;
            temp.shortname = "아오키지";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 10;
            temp.name = "|cff00fa9a아카이누|r";
            temp.img = Properties.Resources.아카이누;
            temp.shortname = "아카이누";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 11;
            temp.name = "|cff00fa9a키자루|r";
            temp.img = Properties.Resources.키자루;
            temp.shortname = "키자루";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 12;
            temp.name = "|cff00fa9a로우|r";
            temp.img = Properties.Resources.로우;
            temp.shortname = "로우";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 13;
            temp.name = "|cff00fa9a타시기|r";
            temp.img = Properties.Resources.타시기;
            temp.shortname = "타시기";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 14;
            temp.name = "|c00bc4346빅맘|r";
            temp.img = Properties.Resources.빅맘;
            temp.shortname = "빅맘";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 15;
            temp.name = "|cff00fa9a루치|r";
            temp.img = Properties.Resources.루치;
            temp.shortname = "루치";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 16;
            temp.name = "|cff00fa9a스네이크맨|r";
            temp.img = Properties.Resources.루피;
            temp.shortname = "스네이크맨";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 17;
            temp.name = "|cff00fa9a키드|r";
            temp.img = Properties.Resources.키드;
            temp.shortname = "키드";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 18;
            temp.name = "|c00bc4346레일리|r";//하이브리드
            temp.img = Properties.Resources.레일리;
            temp.shortname = "레일리";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 19;
            temp.name = "|c00bc4346흰수염|r";//하이브리드
            temp.img = Properties.Resources.흰수염;
            temp.shortname = "흰수염";
            temp.sel = false;
            chList.Add(temp);
            temp.index = 20;
            temp.name = "|c00bc4346센고쿠|r";
            temp.img = Properties.Resources.센고쿠;
            temp.shortname = "센고쿠";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 21;
            temp.name = "|c00bc4346시키|r";
            temp.img = Properties.Resources.시키;
            temp.shortname = "시키";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 22;
            temp.name = "|c00bc4346드래곤|r";
            temp.img = Properties.Resources.드래곤;
            temp.shortname = "드래곤";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 23;
            temp.name = "|c00bc4346제트|r";
            temp.img = Properties.Resources.제파;
            temp.shortname = "제트";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 24;
            temp.name = "|cffffd700시노부|r";
            temp.img = Properties.Resources.시노부;
            temp.shortname = "시노부";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 25;
            temp.name = "|cffffd700에넬|r";
            temp.img = Properties.Resources.에넬;
            temp.shortname = "에넬";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 26;
            temp.name = "|cffffd700레드필드|r";
            temp.img = Properties.Resources.레드필드;
            temp.shortname = "레드필드";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 27;
            temp.name = "|CFFC15AF4에이스|r"; 
            temp.img = Properties.Resources.에이스;
            temp.shortname = "에이스";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 28;
            temp.name = "|CFFC15AF4핸콕|r";
            temp.img = Properties.Resources.핸콕;
            temp.shortname = "핸콕";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 29;
            temp.name = "|CFFC15AF4오뎅|r";
            temp.img = Properties.Resources.오뎅;
            temp.shortname = "오뎅";
            temp.sel = true;
            chList.Add(temp);
            temp.index = 30;
            temp.name = "|CFFC15AF4미호크|r";
            temp.img = Properties.Resources.미호크;
            temp.shortname = "미호크";
            temp.sel = true;
            chList.Add(temp);
            #endregion

        }

        public void ListCheckChange(int index, bool ch)
        {
            characterDB temp = chList[index];
            temp.sel = ch;
            chList[index] = temp;
        }
    }
}

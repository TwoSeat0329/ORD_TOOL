using CirnoLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORD_SAL_v1._0
{
    public class sendMsg
    {
        static Process[] war3 = null;
        static IntPtr war3Handle = IntPtr.Zero;
        static IntPtr[] ArrOffset = null;
        IntPtr GlobalOffset = IntPtr.Zero;
        byte[] ChracterGroupSearchPattern = new byte[] { 0xB2, 0x25, 0xBD, 0x25, 0xB2 };
        byte[] TimerSearchPattern = new byte[] { 0x58, 0xFB, 0xFF, 0x24, 0x58 };
        byte[] MessageSearchPattern = new byte[] { 0x94, 0x28, 0x49, 0x65, 0x94 };
        byte[] ChannelListSearchPattern = new byte[] { 0x6E, 0xF6, 0x4C, 0x12, 0x6E };
        public IntPtr processcheck = IntPtr.Zero;
 

        Regex ColorCode = new Regex("\\|([cC][0-9a-fA-F]{8,8}|[rR])");
       
        
        #region [싱글톤 디자인 패턴]
        private static sendMsg instance;
        private sendMsg() { }
        public static sendMsg getInstance
        {
            get
            {
                if(instance == null)
                {
                    
                    war3 = Process.GetProcessesByName("Warcraft III");
                    if (war3.Length == 0)
                    {
                        war3 = Process.GetProcessesByName("War3");
                        if (war3.Length == 0)
                        {
                            MessageBox.Show("워크래프트3를 먼저 실행주세요 "); return null;
                        }
                        else
                        {
                            war3Handle = OpenProcess(0x38, false, (uint)war3[0].Id);
                         
                            instance = new sendMsg();
                        }
                    }
                    else
                    {
                        war3Handle = OpenProcess(0x38, false, (uint)war3[0].Id);
                        instance = new sendMsg();
                    }
                    
                }
                return instance;
            }
        }
        #endregion


        #region 게임에 send를 하기 위한 부분
        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle
        (
            [In] IntPtr hObject
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ReadProcessMemory
        (
            [In]IntPtr hProcess,
            [In]IntPtr lpBaseAddress,
            [Out]byte[] lpBuffer,
            [In]uint dwSize,
            [Out]out uint lpNumberOfBytesRead
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool WriteProcessMemory
        (
            [In]IntPtr hProcess,
            [In]IntPtr lpBaseAddress,
            [In]byte[] lpBuffer,
            [In]uint nSize,
            [Out]out uint lpNumberOfBytesWritten
        );

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage
        (
            [In]IntPtr hWnd,
            [In]uint Msg,
            [In]uint wParam,
            [In]uint lParam
        );
        internal static bool CompareArrays(byte[] a, byte[] b, int num)
        {
            for (int i = 0; i < num; i++)
                try
                {
                    if (a[i] != b[i])
                        return false;
                }
                catch
                {
                    return false;
                }
            return true;
        }

        IntPtr SearchAddress(IntPtr hwnd, byte[] search, uint maxAdd, uint offset, uint interval = 0x10000)
        {
            uint innerNum;
            byte[] lpBuffer = new byte[search.Length];
            for (uint num = 0x10000; num <= maxAdd; num += interval)
            {
                IntPtr lpBaseAddress = new IntPtr(num + offset);
                if (ReadProcessMemory(hwnd, lpBaseAddress, lpBuffer, (uint)search.Length, out innerNum) && CompareArrays(search, lpBuffer, (int)innerNum))
                    return lpBaseAddress;
            }
            return IntPtr.Zero;
        }

        IntPtr[] SearchAllAddress(IntPtr hwnd, byte[] search, uint maxAdd, uint offset, uint startIndex = 0x10000, uint interval = 0x10000)
        {
            List<IntPtr> result = new List<IntPtr>();
            byte[] lpBuffer = new byte[search.Length];
            for (uint num = startIndex; num <= maxAdd; num += interval)
            {
                IntPtr lpBaseAddress = new IntPtr(num + offset);
                if (ReadProcessMemory(hwnd, lpBaseAddress, lpBuffer, (uint)search.Length, out uint innerNum) && CompareArrays(search, lpBuffer, (int)innerNum))
                    result.Add(lpBaseAddress);               
            }
            if (result.Count == 0)
                return null;
            return result.ToArray();
        }
        [DllImport("kernel32", SetLastError = true)]
        internal static extern IntPtr OpenProcess
        (
            [In]uint dwDesiredAccess,
            [In, MarshalAs(UnmanagedType.Bool)]bool bInheritHandle,
            [In]uint dwProcessId
        );

        public void Send(string text)
        { 
            IntPtr offset = SearchAddress(war3Handle, MessageSearchPattern, 0x7FFFFFFF, 4) + 0x84;
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            WriteProcessMemory(war3Handle, offset, buffer, (uint)buffer.Length + 1, out _);
            PostMessage(war3[0].MainWindowHandle, 0x100, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x100, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x101, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x100, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x101, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x100, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x101, 13, 0);
        }
        #endregion


        
        public List<string> GetCharacters(int GroupCount)
        {

            string ret = null;
            List<string> temp = new List<string>();
            int count = 0;
            GlobalOffset = SearchAddress(war3Handle, ChracterGroupSearchPattern, 0x7FFFFFFF, 4);
            if (GlobalOffset != IntPtr.Zero)
            {
                byte[] lpBuffer = new byte[5];
                if (ReadProcessMemory(war3Handle, GlobalOffset, lpBuffer, 5, out _)
                 && CompareArrays(ChracterGroupSearchPattern, lpBuffer, 5))
                {
                    //여기를 for문으로 돌려서 여러개 찾아함 2. +0x6B0 씩 넘어가서 값을 가져와야함
                    byte[] buffer = new byte[0x80];
                    while (true)
                    {
                        if (ReadProcessMemory(war3Handle, GlobalOffset + 0x258 + 0x6B0 * count, buffer, 0x80, out _))
                        {
                            using (ByteStream bs = new ByteStream())
                            {
                                foreach (var item in buffer)
                                {
                                    if (item == 0) break;
                                    bs.WriteByte(item);
                                }
                                ret = ColorCode.Replace(bs.ToArray().GetString(), string.Empty);
                                if (count == GroupCount) break;
                                else temp.Add(ret);
                            }
                        }
                        count++;
                    }
                    return temp;
                }
            }
            GlobalOffset = IntPtr.Zero;
            CloseHandle(war3Handle);
            temp.Clear();
            return temp;
        }

        public List<string> GetMissonState(IntPtr Offset)
        {
            List<string> Listret = new List<string>();
            string ret;

            if (Offset != IntPtr.Zero)
            {
                byte[] lpBuffer = new byte[5];
                if (ReadProcessMemory(war3Handle, Offset, lpBuffer, 5, out _)
                 && CompareArrays(TimerSearchPattern, lpBuffer, 5))
                {
                    //여기를 for문으로 돌려서 여러개 찾아함 2. +0x6B0 씩 넘어가서 값을 가져와야함
                    byte[] buffer = new byte[6];
                    if (ReadProcessMemory(war3Handle, Offset + 0x1D2C, buffer, 6, out _))
                    {
                        using (ByteStream bs = new ByteStream())
                        {
                            foreach (var item in buffer)
                            {
                                if (item == 0) break;
                                bs.WriteByte(item);
                            }
                            ret = ColorCode.Replace(bs.ToArray().GetString(), string.Empty); ;
                            Listret.Add(ret);
                        }
                    }
                    if (ReadProcessMemory(war3Handle, Offset + 0x322C, buffer, 6, out _))
                    {
                        using (ByteStream bs = new ByteStream())
                        {
                            foreach (var item in buffer)
                            {
                                if (item == 0) break;
                                bs.WriteByte(item);
                            }
                            ret = ColorCode.Replace(bs.ToArray().GetString(), string.Empty); ;
                            Listret.Add(ret);
                        }
                    }
                    if (Listret.Count == 2) return Listret;
                }
            }
            for (int i = 0; i < ArrOffset.Length; i++)
            {
                ArrOffset[i] = IntPtr.Zero;
            }
            Listret.Clear();
            CloseHandle(war3Handle);
            return null;
        }

        public IntPtr GetMissonOffset()
        {
            string ret;
            ArrOffset = SearchAllAddress(war3Handle, TimerSearchPattern, 0x7FFFFFFF, 4);
            Console.WriteLine(0);
            if (ArrOffset.Length != 0)
            {
                for (int i = 0; i < ArrOffset.Length; i++)
                {
                    if (ArrOffset[i] != IntPtr.Zero)
                    {
                        byte[] lpBuffer = new byte[5];
                        if (ReadProcessMemory(war3Handle, ArrOffset[i], lpBuffer, 5, out _)
                         && CompareArrays(TimerSearchPattern, lpBuffer, 5))
                        {
                            //여기를 for문으로 돌려서 여러개 찾아함 2. +0x6B0 씩 넘어가서 값을 가져와야함
                            byte[] buffer = new byte[6];
                            if (ReadProcessMemory(war3Handle, ArrOffset[i] + 0x15DD, buffer, 6, out _))
                            {
                                using (ByteStream bs = new ByteStream())
                                {
                                    foreach (var item in buffer)
                                    {
                                        if (item == 0) break;
                                        bs.WriteByte(item);
                                    }
                                    ret = ColorCode.Replace(bs.ToArray().GetString(), string.Empty);
                                    if (ret == "거프")
                                        return ArrOffset[i];
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < ArrOffset.Length; i++)
            {
                ArrOffset[i] = IntPtr.Zero;
            }
            CloseHandle(war3Handle);
            return IntPtr.Zero;
        }
    }
}


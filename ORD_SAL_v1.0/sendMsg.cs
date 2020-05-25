using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORD_SAL_v1._0
{
    public class sendMsg
    {
        private static sendMsg instance;
        private sendMsg() { }
        public static sendMsg getInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new sendMsg();
                }
                return instance;
            }
        }

        #region 게임에 send를 하기 위한 부분
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
        [DllImport("kernel32", SetLastError = true)]
        internal static extern IntPtr OpenProcess
        (
            [In]uint dwDesiredAccess,
            [In, MarshalAs(UnmanagedType.Bool)]bool bInheritHandle,
            [In]uint dwProcessId
        );

        public void Send(string text)
        {
            uint written;
            Process[] war3 = Process.GetProcessesByName("Warcraft III");
            if (war3.Length == 0)
            {
                war3 = Process.GetProcessesByName("War3");
                if (war3.Length == 0) return;
            }
            IntPtr hwnd = OpenProcess(0x38, false, (uint)war3[0].Id);
            IntPtr offset = SearchAddress(hwnd, new byte[] { 0x94, 0x28, 0x49, 0x65, 0x94 }, 0x7FFFFFFF, 4) + 0x84;
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            WriteProcessMemory(hwnd, offset, buffer, (uint)buffer.Length + 1, out written);
            PostMessage(war3[0].MainWindowHandle, 0x100, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x100, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x101, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x100, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x101, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x100, 13, 0);
            PostMessage(war3[0].MainWindowHandle, 0x101, 13, 0);
        }
        #endregion
    }
}

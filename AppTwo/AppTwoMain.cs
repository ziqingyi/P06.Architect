using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;



namespace AppTwo
{
    public partial class AppTwoMain : Form
    {
        const int INVALID_HANDLE_VALUE = -1;

        const int PAGE_READWRITE = 0x04;

        //共享内存
        [DllImport("Kernel32.dll", EntryPoint = "CreateFileMapping")]

        private static extern IntPtr CreateFileMapping(IntPtr hFile, //HANDLE hFile,

         UInt32 lpAttributes,//LPSECURITY_ATTRIBUTES lpAttributes,  //0

         UInt32 flProtect,//DWORD flProtect

         UInt32 dwMaximumSizeHigh,//DWORD dwMaximumSizeHigh,

         UInt32 dwMaximumSizeLow,//DWORD dwMaximumSizeLow,

         string lpName//LPCTSTR lpName

         );



        [DllImport("Kernel32.dll", EntryPoint = "OpenFileMapping")]

        private static extern IntPtr OpenFileMapping(

         UInt32 dwDesiredAccess,//DWORD dwDesiredAccess,

         int bInheritHandle,//BOOL bInheritHandle,

         string lpName//LPCTSTR lpName

         );



        const int FILE_MAP_ALL_ACCESS = 0x0002;

        const int FILE_MAP_WRITE = 0x0002;



        [DllImport("Kernel32.dll", EntryPoint = "MapViewOfFile")]

        private static extern IntPtr MapViewOfFile(

         IntPtr hFileMappingObject,//HANDLE hFileMappingObject,

         UInt32 dwDesiredAccess,//DWORD dwDesiredAccess

         UInt32 dwFileOffsetHight,//DWORD dwFileOffsetHigh,

         UInt32 dwFileOffsetLow,//DWORD dwFileOffsetLow,

         UInt32 dwNumberOfBytesToMap//SIZE_T dwNumberOfBytesToMap

         );



        [DllImport("Kernel32.dll", EntryPoint = "UnmapViewOfFile")]

        private static extern int UnmapViewOfFile(IntPtr lpBaseAddress);



        [DllImport("Kernel32.dll", EntryPoint = "CloseHandle")]

        private static extern int CloseHandle(IntPtr hObject);

        private Semaphore m_Write;  //可写的信号

        private Semaphore m_Read;  //可读的信号

        private IntPtr handle;     //文件句柄

        private IntPtr addr;       //共享内存地址

        uint mapLength;            //共享内存长

        Thread threadRed;

        public AppTwoMain()
        {
            InitializeComponent();

            //threadRed = new Thread(new ThreadStart(init));

            //threadRed.Start();

            mapLength = 1024;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                m_Write = Semaphore.OpenExisting("WriteMap");

                m_Read = Semaphore.OpenExisting("ReadMap");

                handle = OpenFileMapping(FILE_MAP_WRITE, 0, "shareMemory");

                addr = MapViewOfFile(handle, FILE_MAP_ALL_ACCESS, 0, 0, 0);

                m_Write.WaitOne();

                byte[] sendStr = Encoding.Default.GetBytes(textBox1.Text.ToString() + '\0');

                //如果要是超长的话，应另外处理，最好是分配足够的内存

                if (sendStr.Length < mapLength)

                    Copy(sendStr, addr);

                m_Read.Release();

            }

            catch (WaitHandleCannotBeOpenedException)

            {

                MessageBox.Show("不存在系统信号量!");

                return;

            }

        }



        static unsafe void Copy(byte[] byteSrc, IntPtr dst)
        {
            fixed (byte* pSrc = byteSrc)
            {

                byte* pDst = (byte*)dst;

                byte* psrc = pSrc;

                for (int i = 0; i < byteSrc.Length; i++)

                {

                    *pDst = *psrc;

                    pDst++;

                    psrc++;

                }
            }

        }

      
    }
}

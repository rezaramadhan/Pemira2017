using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace PemiraClient
{
        public partial class MainForm : Form
        {
            /***===========================DISABLE KEY==============================***/
            [DllImport("user32.dll")]
            public static extern int FindWindow(string lpClassName, string lpWindowName);
            [DllImport("user32.dll")]
            public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool PostMessage(int hWnd, uint Msg, int wParam, int lParam);
            /* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Starts Here */

            // Structure contain information about low-level keyboard input event 
            [StructLayout(LayoutKind.Sequential)]
            private struct KBDLLHOOKSTRUCT
            {
                public Keys key;
                public int scanCode;
                public int flags;
                public int time;
                public IntPtr extra;
            }
            //System level functions to be used for hook and unhook keyboard input  
            private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern bool UnhookWindowsHookEx(IntPtr hook);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string name);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern short GetAsyncKeyState(Keys key);
            //Declaring Global objects     
            private IntPtr ptrHook;
            private LowLevelKeyboardProc objKeyboardProcess;

            private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
            {
                if (nCode >= 0)
                {
                    KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                    // Disabling Windows keys 

                    if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.F4 && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        return (IntPtr)1; // if 0 is returned then All the above keys will be enabled
                    }
                }
                return CallNextHookEx(ptrHook, nCode, wp, lp);
            }

            bool HasAltModifier(int flags)
            {
                return (flags & 0x20) == 0x20;
            }
            private void MainForm_Load(object sender, EventArgs e)
            {
                //killExplorer(); //GALAU MAU PAKE ATAU ENGGA
                KeyPreview = true;
                ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
                objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
                ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
            }
            /* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Ends Here */
            /***==============================================================================***/
            /***===================================KILLEXPLORER===============================***/
            private void killExplorer()
            {
                int hwnd;
                hwnd = FindWindow("Progman", null);
                PostMessage(hwnd, /*WM_QUIT*/ 0x12, 0, 0);
                return;
            }
            /***===============================================================================***/
            /***=====================================DISABLE ALT + F4==========================***/
            private bool _altF4Pressed;
            private void MainForm_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Alt && e.KeyCode == Keys.F4)
                {
                    _altF4Pressed = true;
                }
            }
            private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (_altF4Pressed)
                {
                    if (e.CloseReason == CloseReason.UserClosing)
                        e.Cancel = true;
                    _altF4Pressed = false;
                }
            }
            public void StartListening(Label x)
            {
                var tcp = new TcpListener(IPAddress.Any, 25565);
                tcp.Start();
                x.Text = "Listening ...";
                var listeningThread = new Thread(() =>
                {
                    while (true)
                    {
                        var tcpClient = tcp.AcceptTcpClient();
                        x.Text = "Accepted";
                        ThreadPool.QueueUserWorkItem(param =>
                        {
                            NetworkStream stream = tcpClient.GetStream();
                            string incomming;
                            byte[] bytes = new byte[1024];
                            int i = stream.Read(bytes, 0, bytes.Length);
                            incomming = System.Text.Encoding.ASCII.GetString(bytes, 0, i);


                            MessageBox.Show(String.Format("Received: {0}", incomming));

                            tcpClient.Close();
                        }, null);
                    }
                });

                listeningThread.IsBackground = true;
                listeningThread.Start();
            }
            /***===================================================================================***/
            public MainForm()
            {
                InitializeComponent();
                StartListening(labelStatus);
            }
        
    }
}

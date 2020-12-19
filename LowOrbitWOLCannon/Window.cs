using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace LowOrbitWOLCannon
{
    public partial class Window : Form
    {

        ///////////////////// CONFIG //////////////////////////////////////////

        // Port
        //
        // If ICMP Ping fails check if this port is open
        private readonly int PORT_TO_CHECK = 3389; //RDP
        private readonly int PORT_TIMEOUT = 250;
        private readonly int PORT_THREAD_TICK_MILLISECONDS = 1000;

        // WOL
        private readonly int HOW_MANY_WOL_PACKETS = 3;

        // FAKE BOOT TIME
        private readonly int BOOTING_TIME_MILLISECONDS = 20000;

        ////////////////////////////////////////////////////////////////////////

        private Status portStatus = Status.UNKNOWN;
        private Thread portThread;

        enum Status
        {
            UNKNOWN,
            ONLINE,
            OFFLINE
        }

        public Window()
        {
            InitializeComponent();
        }

        private void pingStatusUIRefresher_Tick(object sender, EventArgs e)
        {
            if (bootingProgress.Value == bootingProgress.Maximum)
            {
                bootingProgress.Visible = false;
            }
            switch (portStatus)
            {
                case Status.UNKNOWN:
                    {
                        label3.Text = "Unknown";
                        label3.BackColor = Color.Gray;
                        openRDP.Visible = false;
                        turnOn.Visible = true;
                        break;
                    }
                case Status.ONLINE:
                    {
                        label3.Text = "Online";
                        label3.BackColor = Color.Green;
                        openRDP.Visible = true;
                        bootingProgress.Visible = false;
                        turnOn.Visible = false;
                        break;
                    }
                case Status.OFFLINE:
                    {
                        label3.Text = "Offline";
                        label3.BackColor = Color.Red;
                        openRDP.Visible = false;
                        turnOn.Visible = true;
                        break;
                    }
            }

        }


        void portThreadRun()
        {
            while (Visible)
            {
                if (workstation.Text.Length != 0)
                {
                    // Port fallback check if ICMP Ping is blocked
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        var result = tcpClient.BeginConnect(workstation.Text, PORT_TO_CHECK, null, null);
                        bool portFallbackFlag = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(PORT_TIMEOUT));

                        portStatus = portFallbackFlag ? Status.ONLINE : Status.OFFLINE;
                    }
                }
                else
                {
                    portStatus = Status.UNKNOWN;
                }

                Thread.Sleep(PORT_THREAD_TICK_MILLISECONDS);
            }

        }

        private void StopThread()
        {
            portThread.Abort();
            portStatus = Status.UNKNOWN;
        }

        private void StartThread()
        {
            portThread = new Thread(portThreadRun);
            portThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bootingProgress.Visible = false;
            openRDP.Visible = false;
            Properties.Settings.Default.SettingsLoaded += Default_SettingsLoaded;
            StartThread();
        }

        private void Default_SettingsLoaded(object sender, System.Configuration.SettingsLoadedEventArgs e)
        {
            workstation.Text = (string)Properties.Settings.Default["workstation"];
            mac.Text = (string)Properties.Settings.Default["mac"];
            broadcast.Text = (string)Properties.Settings.Default["broadcast"];
        }

        private void IP_TextChanged(object sender, EventArgs e)
        {
            StopThread();
            StartThread();

            Properties.Settings.Default["workstation"] = workstation.Text;
            Properties.Settings.Default.Save();
        }

        private void mac_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["mac"] = mac.Text;
            Properties.Settings.Default.Save();
        }

        private void broadcast_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["broadcast"] = broadcast.Text;
            Properties.Settings.Default.Save();
        }

    

        private void FIRE_Click(object sender, EventArgs e)
        {
            
            AnimateProgBar(BOOTING_TIME_MILLISECONDS);
            for (int i = 0; i < HOW_MANY_WOL_PACKETS; ++i)
            {
                Thread t = new Thread(() => WOL.WakeOnLan(mac.Text, broadcast.Text));
                t.Start();
            }
        }

        private void Window_Closing(object sender, FormClosingEventArgs e)
        {
            StopThread();
        }

        private void openRDP_Click(object sender, EventArgs e)
        {
            Process.Start("mstsc.exe", "/v:" + workstation.Text);
        }

        public void AnimateProgBar(int milliSeconds)
        {
            if (!bootingTimer.Enabled)
            {
                bootingProgress.Value = 0;
                bootingTimer.Interval = milliSeconds / 100;
                bootingTimer.Enabled = true;
                bootingProgress.Visible = true;
            }
        }

        private void bootingTimer_Tick(object sender, EventArgs e)
        {
            if (bootingProgress.Value < 100)
            {
                bootingProgress.Value += 1;
                bootingProgress.Refresh();
            }
            else
            {
                bootingTimer.Enabled = false;
                
            }
        }

    }
}

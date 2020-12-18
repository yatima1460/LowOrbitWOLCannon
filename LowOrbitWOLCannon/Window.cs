using System;
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
        
        // Ping
        private readonly int PING_TIMEOUT = 250;
        private readonly int PINGER_THREAD_TICK_MILLISECONDS = 1000;

        // Port
        //
        // If ICMP Ping fails check if this port is open
        private readonly int PORT_TO_CHECK = 3389; //RDP
        private readonly int PORT_TIMEOUT = 250;
        private readonly int PORT_THREAD_TICK_MILLISECONDS = 1000;

        // WOL
        private readonly int HOW_MANY_WOL_PACKETS = 3;

        ////////////////////////////////////////////////////////////////////////

        private Status portStatus = Status.UNKNOWN;
        private Status pingStatus = Status.UNKNOWN;
        private Thread pingThread;
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
            if (pingStatus == Status.UNKNOWN && portStatus == Status.UNKNOWN)
            {
                label3.Text = "Unknown";
                label3.BackColor = Color.Gray;
            }
            else if (pingStatus == Status.ONLINE | portStatus == Status.ONLINE)
            {
                label3.Text = "Online";
                label3.BackColor = Color.Green;
            }
            else if (pingStatus == Status.OFFLINE && portStatus == Status.OFFLINE)
            {
                label3.Text = "Offline";
                label3.BackColor = Color.Red;
            }
            else
            {
                label3.Text = "Offline?";
                label3.BackColor = Color.DarkOrange;
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




        void pingThreadRun()
        {
            while (Visible)
            {

                if (workstation.Text.Length != 0)
                {
                    // Default ICMP Ping
                    Ping pinger = null;
                    try
                    {
                        pinger = new Ping();
                        PingReply reply = pinger.Send(workstation.Text, PING_TIMEOUT);
                        pingStatus = (reply.Status == IPStatus.Success) ? Status.ONLINE : Status.OFFLINE;
                    }
                    catch (PingException)
                    {
                        pingStatus = Status.OFFLINE;
                    }
                    finally
                    {
                        if (pinger != null)
                        {
                            pinger.Dispose();
                        }
                    }

                }
                else
                {
                    portStatus = Status.UNKNOWN;
                }

                Thread.Sleep(PINGER_THREAD_TICK_MILLISECONDS);
            }

        }


        private void StopThreads()
        {
            pingThread.Abort();
            pingStatus = Status.UNKNOWN;

            portThread.Abort();
            portStatus = Status.UNKNOWN;
        }

        private void StartThreads()
        {
            pingThread = new Thread(pingThreadRun);
            pingThread.Start();
            
            portThread = new Thread(portThreadRun);
            portThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.SettingsLoaded += Default_SettingsLoaded;
            StartThreads();
        }

        private void Default_SettingsLoaded(object sender, System.Configuration.SettingsLoadedEventArgs e)
        {
            workstation.Text = (string)Properties.Settings.Default["workstation"];
            mac.Text = (string)Properties.Settings.Default["mac"];
            broadcast.Text = (string)Properties.Settings.Default["broadcast"];
        }

        private void IP_TextChanged(object sender, EventArgs e)
        {
            StopThreads();
            StartThreads();

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
            for (int i = 0; i < HOW_MANY_WOL_PACKETS; ++i)
            {
                Thread t = new Thread(() => WOL.WakeOnLan(mac.Text, broadcast.Text));
                t.Start();
            }
        }

        private void Window_Closing(object sender, FormClosingEventArgs e)
        {
            StopThreads();
        }
    }
}

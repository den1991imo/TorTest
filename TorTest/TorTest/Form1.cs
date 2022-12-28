using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TorTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Chilkat 
            {
                Chilkat.Global glob = new Chilkat.Global();
                bool success = glob.UnlockBundle("Cry6mV.CBX0525_LtLoMzcPljAB");
                if (success != true)
                {
                    Ladd2(glob.LastErrorText, this);
                    return;
                }

                int status = glob.UnlockStatus;
                if (status == 2)
                {
                    // Ladd("Unlocked using purchased unlock code.");
                }
                else
                {
                    Ladd2("Unlocked in trial mode.",this);
                    Ladd2(glob.LastErrorText, this);
                }
            }
        }
        private TelnetConnection tc = new TelnetConnection("127.0.0.1", 9051);
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (tc.IsConnected)
            {
                richTextBox1.AppendText(tc.Read() + Environment.NewLine);
                string cmd = "protocolinfo";
                tc.WriteLine(cmd.ToLower());
                richTextBox1.AppendText(tc.Read() + Environment.NewLine);
                cmd = "authenticate";
                string passwd = "Cry650230";
                tc.WriteLine(cmd.ToLower()+" \""+passwd+"\"");
                richTextBox1.AppendText(tc.Read() + Environment.NewLine);
            }
            else
            {
                richTextBox1.AppendText("Not connect" + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tc.IsConnected)
            {
                tc.WriteLine("SIGNAL NEWNYM");
                richTextBox1.AppendText(tc.Read() + Environment.NewLine);
            }
        }
        public void Ladd2(string message, Form1 form)
        {
            try
            {
                string log = DateTime.Now.ToString() + ". " + message;
                Invoke((Action)(() =>
                {
                    form.richTextBox1.AppendText(log + Environment.NewLine);
                }));
                //File.AppendAllText("del_log.txt", log + Environment.NewLine);
            }
            catch (Exception e)
            {
                string log = DateTime.Now.ToString() + ". " + e.Message;
                Invoke((Action)(() =>
                {
                    form.richTextBox1.AppendText(log + Environment.NewLine);
                }));
                //listBox1.TopIndex = listBox1.Items.Count - 1;
                //listBox1.SelectedIndex = -1;
                //File.AppendAllText("del_log.txt", log + Environment.NewLine);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chilkat.Http http = new Chilkat.Http();
            http.SocksHostname = "127.0.0.1";
            http.SocksPort = 9050;
            http.SocksVersion = 4;
            string html = http.QuickGetStr("http://ip-api.com/json/?");
            if (http.LastMethodSuccess != true)
            {
                Ladd2(http.LastErrorText,this);
                return;
            }

            Ladd2(html,this);
            http.CloseAllConnections();
           // Debug.WriteLine("----");
           // Debug.WriteLine("Success!");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "C:\\Users\\Cry\\Downloads\\Tor Browser\\Browser\\TorBrowser\\Tor\\tor.exe";
            //process.StartInfo = startInfo;
            //process.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tc.IsConnected)
            {
                tc.WriteLine(textBox1.Text.ToUpper());
                richTextBox1.AppendText(tc.Read() + Environment.NewLine);
            }
        }
    }
}

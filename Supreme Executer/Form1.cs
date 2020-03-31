using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreDevs_API

;
namespace Supreme_Executer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ExploitAPI api = new ExploitAPI();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = fastColoredTextBox1.Text;
            this.api.SendLuaScript(text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialogfile = new OpenFileDialog();
            opendialogfile.Filter = "Lua File (*.lua)|*.lua|Text File (*.txt)|*.txt";
            opendialogfile.FilterIndex = 2;
            opendialogfile.RestoreDirectory = true;
            if (opendialogfile.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                fastColoredTextBox1.Text = "";
                System.IO.Stream stream;
                if ((stream = opendialogfile.OpenFile()) == null)
                    return;
                using (stream)
                    this.fastColoredTextBox1.Text = System.IO.File.ReadAllText(opendialogfile.FileName);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("An unexpected error has occured", "oof lmao", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) => fastColoredTextBox1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Function.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Function.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            api.SendLimitedLuaScript("game.Players.LocalPlayer.Character.Humanoid.WalkSpeed=100");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            api.SendCommand("btools me");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string username = inputTPTo.Text;
            api.SendCommand("teleport " + username);
        }

        //Changes UI text to say if the exploit is injected or not
        //Challenge: Try making the attach button only show if the exploit is not injected
        private void CheckInjected()
        {
            if (api.isAPIAttached())
            {
                //The exploit is injected and now ready to execute scripts/commands
                txtIsInjected.Text = "Is Injected: true";
            }
            else
            {
                //The exploit is not injected... The client must inject
                txtIsInjected.Text = "Is Injected: false";
            }
        }

        //Check if the exploit is injected on load
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckInjected();
        }

        //Check if the exploit is injected every 3 seconds
        private void InjectedChecker_Tick(object sender, EventArgs e)
        {
            CheckInjected();
        }

        private void txtIsInjected_Click(object sender, EventArgs e)
        {

        }

        private void inputTPTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            api.SendCommand("sparkles me");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            api.SendCommand("nosparkles me");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            api.SendCommand("fire me");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            api.SendCommand("nofire me");
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            api.SendCommand("smoke me");
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            api.SendCommand("nosmoke me");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            api.SendCommand("ff me");
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            api.SendCommand("noff me");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            api.SendCommand("kill me");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            api.SendCommand("nofloat me");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            api.SendCommand("float me");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            api.SendCommand("boxesp");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            api.SendCommand("boxesplines");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            api.SendCommand("boxespdistance");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            api.SendCommand("boxespnames");
        }
    }
}

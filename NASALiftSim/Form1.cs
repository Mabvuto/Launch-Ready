using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NASALiftSim
{
    public partial class Form1 : Form
    {
        int stage = 0;
        int maxStage = 4;
        String[] piccies = {"boardroom1", "Hangar", "", "", "", ""};

        private int _countDown = 235; // Seconds
        private Timer _timer;


        void timer_Tick(object sender, EventArgs e)
        {
            _countDown--;
            if (_countDown < 1)
            {
                _countDown = 60;
            }

            var timespan = TimeSpan.FromSeconds(_countDown);
 
            lblCountDown.Text = "0:" + timespan.ToString(@"mm\:ss");
        }

        public Form1()
        {
            _timer = new Timer();
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Interval = 1000;
           

            InitializeComponent();
            progBar.Value = 0;
            updateScreen();
        }

        private void updateScreen() {

            switch (stage)
            {

                case 0:
                    missionPanel.BringToFront();
                    missionPanel.Location = new Point(60, 58);
                    break;
                case 1:
                    rocketPanel.BringToFront();
                    rocketPanel.Location = new Point(60, 58);
                    break;
                case 2:
                    takeoffPanel.BringToFront();
                    takeoffPanel.Location = new Point(60, 58);
                    break;
                case 3:
                    button1.Enabled = false;
                    prelaunchPanel.BringToFront();
                    prelaunchPanel.Location = new Point(60, 58);
                    button1.Enabled = false;
                    break;
                case 4:
                    finalPanel.BringToFront();
                    finalPanel.Location = new Point(60, 58);
                    break;
            }

            if (stage == 0)
            {
                if ((radioButton5.Checked == false) && (radioButton6.Checked == false) && (radioButton7.Checked == false) && (radioButton8.Checked == false))
                {
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
            }

            if (stage == 3)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
            
            if ((progBar.Value < 100 && progBar.Value > 0) || (stage > 0 && progBar.Value == 0) || (stage == maxStage))
            {
                progBar.Value = 25 * stage;

                object O = Properties.Resources.ResourceManager.GetObject(piccies[stage]); //Return an object from the image chan1.png in the project
                picBox.Image = (Image)O; //Set the Image property of channelPic to the returned object as Image

   
            }
           // richTextBox1.Text = "" + stage;

            if (stage == 0)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }

            if (stage == maxStage)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            stage++;
            updateScreen();

            if (stage == 3)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stage = (stage == 0) ? 0 : stage - 1;
            updateScreen();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            fuelLabel.Text = "" + (fuelTrack.Value * 100) + " Litres";
            fuelBar.Value = (fuelTrack.Value);
            label5.Text = "$" + (1.31 * fuelTrack.Value * 100);
        }

        private void fuelTrack_ValueChanged(object sender, EventArgs e)
        {
            fuelBar.Value = (fuelTrack.Value);
        }

        private void payloadTrack_Scroll(object sender, EventArgs e)
        {
            payloadLabel.Text = "" + (payloadTrack.Value * 100) + " Kg";
            payloadBar.Value = (payloadTrack.Value);
            label7.Text = "" + (304.5 * payloadTrack.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblCountDown.BringToFront();
            _timer.Start();
        }

        private void missionPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;

            if (radioButton9.Checked == true)
            {

                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;

            if (radioButton10.Checked == true)
            {

                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stage++;
            updateScreen();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            label9.Text = "" + trackBar1.Value;
            label7.Text = "$" + (304.5 * payloadTrack.Value + trackBar1.Value  * 90);
        
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            stage = 0;
            progBar.Value = 0;
            updateScreen();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liftoff mass: 939 tons\nLiftoff height: 62.2 m\nThrust: 15,000 kN\n3 stage rocket\nFirst launched in 1997");
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        
        private int score = 0;
        private int missed = 0;
        private Random rand = new Random();
        private List<PictureBox> pictureBoxes = new List<PictureBox>();

        
        
        public Form1()
        {
            InitializeComponent();
            timer3.Interval = 10;
            timer3.Start();
            timer1.Interval = 10;
            timer1.Start();
            timer2.Interval = 550;
            timer2.Start();

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(var item in pictureBoxes)
            {
               
                item.Location = new Point(item.Location.X, item.Location.Y + 1);
            }
           

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox picture1 = (PictureBox)sender;
            
            this.Controls.Remove(picture1);
            
            score++;
            label1.Text = $"Score: {score.ToString()}";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            PictureBox picture = new PictureBox();
            picture.Location = new Point(randForY(), 9);
            picture.Size = new Size(50, 50);
            picture.Image = Image.FromFile("C:\\ball11.png");
            picture.Click += pictureBox1_Click;
            this.Controls.Add(picture);
            pictureBoxes.Add(picture);
        }


        private int randForY()
        {
            return rand.Next(100, Screen.PrimaryScreen.Bounds.Width);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            foreach (var item in pictureBoxes)
            {
                // cycle for
                if(item.Location.Y > Screen.PrimaryScreen.Bounds.Height)
                {
                    label2.Text = $"Missed: {missed.ToString()}";
                    missed++;

                    pictureBoxes.Remove(item);
                    
                }
                
            }
        }
    }
}

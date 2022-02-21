using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace disp_jpg_mix
{

    public partial class Form1 : Form
    {
        int stop_flag = 0;
        int inc_interval = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stop_flag = 0;
            openFileDialog1.Filter = "JPEGファイル|*.jpg";
            DialogResult dr = openFileDialog1.ShowDialog();

            textBox1.Text = openFileDialog1.FileName;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.ImageLocation = textBox1.Text;


            Thread t = new Thread(new ThreadStart(ThreadProc2));

            t.Start();
        }

        public void ThreadProc2()
        {

            string s = textBox1.Text;
            string s3 = "";

            s3 = System.IO.Path.GetDirectoryName(s);


            string[] files = System.IO.Directory.GetFiles(
                s3, "*.jpg", System.IO.SearchOption.AllDirectories);

            int interval = 0;
            try
            {
                foreach (string file in files)
                {
                    pictureBox1.Width = int.Parse(textBox2.Text);
                    pictureBox1.Height = int.Parse(textBox3.Text);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.ImageLocation = file;
                    interval = int.Parse(textBox4.Text);
                    Thread.Sleep(interval);
                    if (stop_flag == 1) break;
                }

            }
            catch (Exception a)
            {
                Console.WriteLine(a.ToString());
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            stop_flag = 1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (int.Parse(textBox4.Text) > 0)
            {
                textBox4.Text = (int.Parse(textBox4.Text) - 100).ToString();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = (int.Parse(textBox4.Text) + 100).ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox2.Text) > 0)
            {
                textBox2.Text = (int.Parse(textBox2.Text) - 10).ToString();
                textBox3.Text = (int.Parse(textBox3.Text) - 10).ToString();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = (int.Parse(textBox2.Text) + 10).ToString();
            textBox3.Text = (int.Parse(textBox3.Text) + 10).ToString();

        }
    }
}
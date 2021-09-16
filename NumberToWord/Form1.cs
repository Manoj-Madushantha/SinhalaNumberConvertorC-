using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberToWord
{
    public partial class Form1 : Form
    {

        int number;
        StringBuilder sb;

        public Form1()
        {
            InitializeComponent();         
        }


        private void button1_Click(object sender, EventArgs e)
        {
            sb = new StringBuilder();
            StringBuilder log = new StringBuilder();
            string word = "";
            textBox1.Text = "";
            Stopwatch sw = new Stopwatch();

            if (textBox2.Text != "" && textBox3.Text != "")
            {
                int startVal = int.Parse(textBox2.Text);
                int lastVal = int.Parse(textBox3.Text);

                if (startVal > lastVal) {

                    if (radioBtnEn.Checked)
                    {
                        MessageBox.Show("Starting Value cannot exceed Ending Value");
                    }
                    else
                    {
                        MessageBox.Show("ආරම්භක අගය අවසන් අගයට වඩා වැඩි විය නොහැක");
                    }                   
                    return;

                }

                if (startVal > 1000000 || lastVal > 1000000)
                {
                    MessageBox.Show("සිංහල භාෂාව සඳහා සහය දක්වනුයේ මිලියනය දක්වා පමණි");
                    return;
                }


                sw.Start();

                for (number = startVal; number <= lastVal; number++)
                {
                    
                    //number = int.Parse(textBox1.Text);
                    if (radioBtnSin.Checked)
                    {
                        word = NumberWordConvertor.ConvertSinhala(number);
                        textBox1.AppendText(word + Environment.NewLine);
                        sb.AppendLine(word);
                    }

                    if (radioBtnEn.Checked)
                    {
                        word = NumberWordConvertor.ConvertEnglish(number);
                        textBox1.AppendText(word + Environment.NewLine);
                        sb.AppendLine(word);
                    }
                    

                }
                
                sw.Stop();
                double ts = sw.ElapsedTicks;
                double seconds = ts / Stopwatch.Frequency;
                label5.Text = seconds.ToString();

                log.AppendLine(DateTime.Now.ToString());
                log.AppendLine(radioBtnEn.Checked?"Language: English": "Language: Sinhala");
                log.AppendLine("StopWatch Frequency : " + Stopwatch.Frequency.ToString());
                log.AppendLine("Range : " + startVal + " - " + lastVal);
                log.AppendLine("Time Elapsed: " + label5.Text);
                log.AppendLine(Environment.NewLine);

                System.IO.File.WriteAllText(@"D:\TextFile.txt", sb.ToString());

                System.IO.File.AppendAllText(@"D:\log.txt", log.ToString());
                              
            }
            else
            {
                if (radioBtnEn.Checked)
                {
                    MessageBox.Show("Provide Star Value & End Value");
                }
                else
                {
                    MessageBox.Show("ආරම්භක සහ අවසන් පරාමිති සඳහන් කරන්න");
                }

            }           

        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                number = int.Parse(textBox4.Text);

                if (radioBtnSin.Checked)
                {
                    if (number > 1000000)
                    {
                        MessageBox.Show("සිංහල භාෂාව සඳහා සහය දක්වනුයේ මිලියනය දක්වා පමණි");
                        return;
                    }

                    label4.Text = NumberWordConvertor.ConvertSinhala(number);
                }

                if (radioBtnEn.Checked)
                {
                    label4.Text = NumberWordConvertor.ConvertEnglish(number); 
                }
                
            }

            else
            {
                if (radioBtnEn.Checked)
                {
                    MessageBox.Show("Please provide a value");
                }
                else
                {
                    MessageBox.Show("අගය සඳහන් කරන්න");                
                }
                
            }
        }


        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Alt && e.KeyCode == Keys.O)
            {
                MessageBox.Show("You Pressed Alt + O");
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBox4.Text != "")
                {
                    number = int.Parse(textBox4.Text);

                    
                    if (radioBtnSin.Checked)
                    {
                        if (number > 1000000)
                        {
                            MessageBox.Show("සිංහල භාෂාව සඳහා  සහය දක්වනුයේ මිලියනය දක්වා පමණි");
                            return;
                        }

                        label4.Text = NumberWordConvertor.ConvertSinhala(number);
                    }

                    if (radioBtnEn.Checked)
                    {
                        label4.Text = NumberWordConvertor.ConvertEnglish(number);
                    }

                }
                
                else
                {
                    MessageBox.Show("අගය සඳහන් කරන්න");
                }
            }   
    
        }

        private void radioBtnEn_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLang();
        }

        private void ChangeLang()
        {

            if(radioBtnEn.Checked)
            {
                label1.Font = new System.Drawing.Font("Iskoola Pota", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Text = "English Number Reader";

                label2.Font = new System.Drawing.Font("Iskoola Pota", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Text = "Start Value";

                label3.Font = new System.Drawing.Font("Iskoola Pota", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label3.Text = "End Value";

                tabControl1.Font = new System.Drawing.Font("Iskoola Pota", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tabControl1.TabPages[0].Text = "Value";

                tabControl1.TabPages[1].Text = "Range";
                
                button1.Text = "OK";
                button2.Text = "OK";
              
            }
            else
            {
                label1.Font = new System.Drawing.Font("Iskoola Pota", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Text = "සිංහල ඉලක්කම් කියවනය";

                label2.Font = new System.Drawing.Font("Iskoola Pota", 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Text = "ආරම්භක අගය";

                label3.Font = new System.Drawing.Font("Iskoola Pota", 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label3.Text = "අවසන් අගය";

                tabControl1.Font = new System.Drawing.Font("Iskoola Pota", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tabControl1.TabPages[0].Text = "අගයක්";

                tabControl1.TabPages[1].Text = "පරාසයක්";

                button1.Text = "ඔබන්න";
                button2.Text = "ඹබන්න";
                
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox4;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(System.IO.File.Exists(@"D:\log.txt"))
                textBox1.Text = System.IO.File.ReadAllText( @"D:\log.txt");

        }
    }
}

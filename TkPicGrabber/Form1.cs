using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Windows.Forms;

namespace TkPicGrabber
{
    public partial class Form1 : Form
    {

        Thread LoadThread;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = d.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        public void GetFiles()
        {
            int Minimum, Maximum;
            Minimum = Convert.ToInt32(textBox4.Text);
            Maximum = Convert.ToInt32(textBox5.Text);
            WebClient wc = new WebClient();
            for (int i = Minimum; i <= Maximum; i++)
            {
                groupBox5.Text = i.ToString();
                try
                {
                    wc.DownloadFile(textBox1.Text.Replace("[[number]]", i.ToString()), textBox2.Text + "/" + textBox3.Text.Replace("[[number]]", i.ToString()));
                }
                catch (Exception e)
                {
                    //MessageBox.Show(textBox1.Text.Replace("[[number]]", i.ToString()) + "-------------" + e.ToString());
                }
        
                
            }
            MessageBox.Show("Done! :-)");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox5.Text = "";
            if (textBox1.Text.Length > 0)
            {
                if (textBox1.Text.IndexOf("[[number]]") > -1)
                {
                    if (textBox2.Text.Length > 0)
                    {
                        if (textBox3.Text.Length > 0)
                        {
                            if (textBox3.Text.IndexOf("[[number]]") > -1)
                            {
                                if (textBox4.Text.Length > 0)
                                {
                                    if (textBox5.Text.Length > 0)
                                    {
                                    //    if (textBox7.Text.Length > 0)
                                    //    {
                                        progressBar1.Style = ProgressBarStyle.Marquee;
                                            LoadThread = new Thread(new ThreadStart(GetFiles));
                                            LoadThread.Start();
                                    //    }
                                    //    else
                                    //    {
                                    //        MessageBox.Show("Du musst die Anzahl der anführenden Nullen definieren!");
                                    //    }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Du musst einen Zahlenbereich definieren!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Du musst einen Zahlenbereich definieren!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Der Speicher-Dateiname muss einen Platzhalter enthalten!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Du musst einen Speicher-Dateinamen angeben!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Du musst einen Speicherpfad angeben!");
                    }
                }
                else
                {
                    MessageBox.Show("Die URL muss einen Platzhalter enthalten!");
                }
            }
            else
            {
                MessageBox.Show("Du musst eine URL angeben!");
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }



      

    }
}

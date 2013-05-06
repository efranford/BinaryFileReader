using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BinaryFileReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = File.Open(openFileDialog1.FileName, FileMode.Open))
                    {
                        using (System.IO.BinaryReader reader = new System.IO.BinaryReader(fs))
                        {
                            int count = reader.ReadInt32();
                            if (count > 0)
                            {
                                textBox1.Clear();
                                for (int i = 0; i < count; i++)
                                {
                                    textBox1.AppendText(reader.ReadString());
                                }
                            }
                        }
                        label1.Text = "Contents of file " + openFileDialog1.FileName;
                    }
                }
                catch (Exception ex)
                {
                    textBox1.AppendText("Error reading file " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

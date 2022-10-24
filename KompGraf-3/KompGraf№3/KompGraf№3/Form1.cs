using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KompGraf_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String fullPath = Application.StartupPath.ToString() + "/MyProject.txt";

        private void Clear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            Font font1 = new Font("Corbel", 24, FontStyle.Italic);

            Font font2 = new Font("Imprint MT Shadow", 36, FontStyle.Regular);

            Font font3 = new Font("Arial Black", 26 , FontStyle.Bold);

            Graphics graphics = pictureBox1.CreateGraphics();

            StringFormat sf1 = (StringFormat)StringFormat.GenericTypographic.Clone();
            StringFormat sf2 = (StringFormat)StringFormat.GenericTypographic.Clone();
            StringFormat sf3 = (StringFormat)StringFormat.GenericTypographic.Clone();

            sf1.Alignment = StringAlignment.Far;
            sf1.LineAlignment = StringAlignment.Near;
            sf1.Trimming = StringTrimming.EllipsisWord;

            sf2.Alignment = StringAlignment.Center;
            sf2.LineAlignment = StringAlignment.Near;
            sf2.Trimming = StringTrimming.EllipsisWord;
            sf2.FormatFlags = StringFormatFlags.DirectionVertical;


            sf3.Alignment = StringAlignment.Center;
            sf3.LineAlignment = StringAlignment.Near;
            sf3.Trimming = StringTrimming.EllipsisWord;

            using (StreamReader readtext = new StreamReader(fullPath))
            {
                for(int i = 0; i < 6; i++)
                {
                    graphics.DrawString(readtext.ReadLine(), font1, Brushes.Green, 550, i * 40,  sf1);
                }
                for (int i = 0; i < 5; i++)
                {
                    graphics.DrawString(readtext.ReadLine(), font2, Brushes.Red, i * 60, 150, sf2);
                }
                graphics.DrawString(readtext.ReadLine(), font3, Brushes.Blue, 400, 10, sf3);
            }
        }

        private void Write_Click(object sender, EventArgs e)
        {
            string str1 = "Hello";
            string str2 = "How are you";
            string str3 = "Bye Bye";

            using (StreamWriter writetext = new StreamWriter(fullPath, false))
            {
                for(int i = 0; i < 6; i++)
                {
                    writetext.WriteLine(str1);
                }
                for (int i = 0; i < 5; i++)
                {
                    writetext.WriteLine(str2);
                }
                writetext.WriteLine(str3);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpiderCardGame.Gui.Properties;
using SpiderCardGame.Data;


namespace SpiderCardGame.Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            images = new List<Image>() { Resources.ace_of_spades2,Resources._2_of_spades, Resources._3_of_spades, Resources._4_of_spades, Resources._5_of_spades, Resources._6_of_spades, Resources._7_of_spades, Resources._8_of_spades, Resources._9_of_spades, Resources._10_of_spades, Resources.king_of_spades2, Resources.queen_of_spades2, Resources.jack_of_spades2, 
              Resources.ace_of_clubs, Resources._2_of_clubs, Resources._3_of_clubs, Resources._4_of_clubs, Resources._5_of_clubs, Resources._6_of_clubs, Resources._7_of_clubs, Resources._8_of_clubs, Resources._9_of_clubs, Resources._10_of_clubs, Resources.king_of_clubs2, Resources.queen_of_clubs2, Resources.jack_of_clubs2,
                Resources.ace_of_diamonds, Resources._2_of_diamonds, Resources._3_of_diamonds, Resources._4_of_diamonds, Resources._5_of_diamonds, Resources._6_of_diamonds, Resources._7_of_diamonds, Resources._8_of_diamonds, Resources._9_of_diamonds, Resources._10_of_diamonds, Resources.king_of_diamonds2, Resources.queen_of_diamonds2, Resources.jack_of_diamonds2,
                Resources.ace_of_hearts, Resources._2_of_hearts, Resources._3_of_hearts, Resources._4_of_hearts, Resources._5_of_hearts, Resources._6_of_hearts, Resources._7_of_hearts, Resources._8_of_hearts, Resources._9_of_hearts, Resources._10_of_hearts, Resources.king_of_hearts2, Resources.queen_of_hearts2, Resources.jack_of_hearts2
                };
        }

        List<PictureBox> curCards = new List<PictureBox>();
        List<Image> images;


        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            
        }

        private void RemovePictureBox(Board board, int sendLine, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var picture = (from x in curCards
                               where x.Text.Split(',')[0] == sendLine.ToString() && x.Text.Split(',')[1] == board.boardLines[sendLine - 1].Count.ToString()
                               select x).Take(1);
                foreach (var p in picture)
                {
                    Controls.Remove(p);
                    curCards.Remove(p);
                } 
            }
        }
        
        private void MakePictureBoxes(Board board, int recvLine, int amount, string name, Point location, Image image, int width = 90, int height = 130)
        {
            for (int i = 0; i < amount; i++)
            {
                PictureBox picture = new PictureBox
                {
                    Name = name,
                    Width = width,
                    Height = height,
                    Location = location,
                    Image = image,
                    Text = $"{recvLine},{board.boardLines[recvLine-1].Count}",
                };
                Controls.Add(picture);
                curCards.Add(picture);
                picture.BringToFront();
            }

            //PictureBox picture2 = new PictureBox
            //{
            //    Name = "pictureBox",
            //    Width = 90,
            //    Height = 130,
            //    Location = new Point(500, 120),
            //    Image = Resources._10_of_clubs,
            //    SizeMode = PictureBoxSizeMode.StretchImage,
            //    Text = "helllo",
            //};
        }

    }
}

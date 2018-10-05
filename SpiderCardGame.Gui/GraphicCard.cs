using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using SpiderCardGame.Data;
using SpiderCardGame.Gui.Properties;
using System.Windows.Forms;

namespace SpiderCardGame.Gui
{
    public class GraphicCard
    {
        private const int HOR_LOCATION = 50;    //가로 시작위치
        private const int VER_LOCATION = 120;   //세로 시작위치
        private const int HOR_INTERVAL = 100;   //한 줄 사이간 가로 간격
        private const int VER_INTERVAL = 25;    //한 줄에서의 카드들간 세로 간격

        public List<List<PictureBox>> curCards = new List<List<PictureBox>>(); //winForm에 나타난 카드 이미지들
        public List<Image> images;  //트럼프카드 리소스 데이터
        private Form1 _form1;       //winForm


        public GraphicCard(Form1 form1)
        {
            _form1 = form1;

            for (int i = 0; i < Board.MAX_LINES; i++)
            {
                curCards.Add(new List<PictureBox>());
            }

            DefineCardImageFiles();
        }

        
        // picturebox를 생성
        public void MakePictureBox(Board board, int line, int amount = 1, int width = 77, int height = 110)
        {
            for (int i = 0; i < amount; i++)
            {
                if (curCards[line - 1].Count >= Form1.MAX_PICTURE_AMOUNT) break;

                PictureBox picture = new PictureBox
                {
                    Tag = 3,
                    Name = $"Card{line - 1}{amount}",
                    Width = width,
                    Height = height,
                    Location = new Point(HOR_LOCATION + (HOR_INTERVAL * (line - 1)),
                                         VER_LOCATION + (VER_INTERVAL * (curCards[line - 1].Count - 1))),
                    Image = Resources.backcard,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                _form1.Controls.Add(picture);
                curCards[line - 1].Add(picture);
                picture.BringToFront();
            }

            //var boxes = Controls.AsQueryable().OfType<PictureBox>().Where(x => x.Location.X > 100 && x.Location.X < 200);


            //PictureBox picture2 = new PictureBox
            //{
            //    Name = "pictureBox",
            //    Padding = new Padding(7),
            //    BackColor = Color.White,
            //    Width = 90,
            //    Height = 130,
            //    Location = new Point(500, 120),
            //    Image = Resources._10_of_clubs,
            //    SizeMode = PictureBoxSizeMode.StretchImage,
            //    Text = "helllo",
            //};
        }

        // picturebox 객체를 삭제
        public void RemovePictureBox(Board board, int line, int amount)
        {
            List<PictureBox> cards = curCards[line - 1];
            List<PictureBox> removeCards = GetPictureBoxes(board, line, amount);

            foreach (var card in removeCards)
            {
                _form1.Controls.Remove(card);
                cards.Remove(card);
            }
        }

        // 해당 line의 amount만큼의 카드에 대응되는 picturebox를 반환
        public List<PictureBox> GetPictureBoxes(Board board, int line, int amount)
        {
            List<PictureBox> list = curCards[line - 1];

            var pictures = list.Skip(list.Count - amount).Take(amount);

            return pictures.ToList();
        }

        // 카드의 문양, 숫자에 따라 그에 맞는 리소스 이미지를 반환
        public Image FindImage(Card card)
        {
            int index = images.Count - 1;
            if (card.isOpened)
                index = ((int)card.Pattern_ * 13) + card.Number - 1;
            return images[index];
        }
        
        // 카드 리소스 이미지들을 배열에 추가
        void DefineCardImageFiles()
        {
            images = new List<Image>() { Resources.ace_of_spades2,Resources._2_of_spades, Resources._3_of_spades, Resources._4_of_spades, Resources._5_of_spades, Resources._6_of_spades, Resources._7_of_spades, Resources._8_of_spades, Resources._9_of_spades, Resources._10_of_spades, Resources.jack_of_spades2, Resources.queen_of_spades2, Resources.king_of_spades2,
                Resources.ace_of_clubs, Resources._2_of_clubs, Resources._3_of_clubs, Resources._4_of_clubs, Resources._5_of_clubs, Resources._6_of_clubs, Resources._7_of_clubs, Resources._8_of_clubs, Resources._9_of_clubs, Resources._10_of_clubs, Resources.jack_of_clubs2, Resources.queen_of_clubs2, Resources.king_of_clubs2,
                Resources.ace_of_diamonds, Resources._2_of_diamonds, Resources._3_of_diamonds, Resources._4_of_diamonds, Resources._5_of_diamonds, Resources._6_of_diamonds, Resources._7_of_diamonds, Resources._8_of_diamonds, Resources._9_of_diamonds, Resources._10_of_diamonds, Resources.jack_of_diamonds2, Resources.queen_of_diamonds2, Resources.king_of_diamonds2,
                Resources.ace_of_hearts, Resources._2_of_hearts, Resources._3_of_hearts, Resources._4_of_hearts, Resources._5_of_hearts, Resources._6_of_hearts, Resources._7_of_hearts, Resources._8_of_hearts, Resources._9_of_hearts, Resources._10_of_hearts, Resources.jack_of_hearts2, Resources.queen_of_hearts2, Resources.king_of_hearts2,
                Resources.backcard,
            };
        }
    }
}

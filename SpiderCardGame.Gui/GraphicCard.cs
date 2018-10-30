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
    public enum SelectState
    {
        None = -1,
        Cancled,
        Select,
        Unselect
    }

    public class GraphicCard
    {
        public const int HOR_LOCATION = 50;    //가로 시작위치
        public const int VER_LOCATION = 120;   //세로 시작위치
        public const int HOR_INTERVAL = 100;   //한 줄 사이간 가로 간격
        public const int VER_INTERVAL = 25;    //한 줄에서의 카드들간 세로 간격

        public SelectState state_ = SelectState.None;                          //카드들을 선택 중인지에 대한 상태
        public List<List<PictureBox>> curCards = new List<List<PictureBox>>(); //winForm에 나타난 카드 이미지들
        public List<Image> images;                                             //트럼프카드 리소스 데이터
        private Form1 _form1;       

        List<PictureBox> _selectedPics = new List<PictureBox>(); //카드들을 선택했을 경우 모아두는 리스트
        int _selectLine = 0;                                     //카드들을 선택했을 경우 해당 카드의 줄 번호를 저장해두는 변수


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
                    // Name
                    Tag = $"{line},{curCards[line - 1].Count}",
                    Width = width,
                    Height = height,
                    Location = new Point(LocationXOf(line), LocationYOf(curCards[line - 1].Count)),
                    Image = Resources.backcard,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                picture.MouseClick += MouseClickEvent;

                curCards[line - 1].Add(picture);
                _form1.Controls.Add(picture);
                picture.BringToFront();
            }

            //var boxes = Controls.AsQueryable().OfType<PictureBox>().Where(x => x.Location.X > 100 && x.Location.X < 200);
        }
        
        // 마우스를 클릭할 경우 생성되는 이벤트
        private void MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (!_form1.gameEnd)
            {
                // 현재 상태에 따라 다른 이벤트 발생
                if (state_ == SelectState.Select)
                    MouseUpEvent(sender, e);
                else
                    MouseDownEvent(sender, e);

                // 게임 상황 갱신
                _form1.PrintBoard();
            }
        }

        
        // 카드를 보내기 위해 보낼 라인을 클릭할 경우의 이벤트
        public void MouseUpEvent(object sender, MouseEventArgs e)
        {
            // 현재 마우스의 위치를 얻어옴
            int xPos = Cursor.Position.X - _form1.Location.X;

            for (int line = 1; line <= 10; line++)
            {
                // 마우스가 선택한 라인 확인
                if (xPos > LocationXOf(line) && xPos < LocationXOf(line+1))
                {
                    // 해당 라인으로 지금 선택해둔 카드를 옮길 수 있다면
                    if (_form1.judge.CanConveyCard(_selectLine, _selectedPics.Count, line))
                    {
                        // 카드 전달
                        _form1.board.ConveyCardLineToLine(_selectLine, _selectedPics.Count, line);
                        
                        //옮긴 후 움직임 수 증가 및 스코어 1 감소
                        _form1.score.GetMovePenalty();
                        //카드 한 세트가 완성되면
                        if (_form1.judge.LineHasCardSet(line))
                        {
                            _form1.score.GetOneCardSetScore();
                            _form1.board.RemoveOneCardSet(line);
                        }

                        // 게임의 결과가 판별됐는지 확인
                        _form1.CheckGameEnd();

                        // gui용으로 사용한 picturebox들은 form에서 제거하고 이후 게임상황 갱신 중 생기게 한다.
                        foreach (var p in _selectedPics)
                        {
                            //p.Tag = $"{line},{curCards[line - 1].Count}";
                            //Point point = new Point(HOR_LOCATION + (HOR_INTERVAL * (line - 1)),
                            //                     VER_LOCATION + (VER_INTERVAL * (curCards[line - 1].Count - 1)));
                            //p.Location = point;
                            //p.BringToFront();
                            _form1.Controls.Remove(p);
                            //curCards[line - 1].Add(p);
                        }
                        // 예전 줄에 있었던 picturebox들은 삭제
                        curCards[_selectLine - 1].RemoveAll(x => _selectedPics.Contains(x));

                        // 아무것도 선택하고 있지 않은 상태로 변경
                        state_ = SelectState.Unselect;
                        break;
                    }
                }
            }
            // 옮길 수 없는 상황일 경우
            if (state_ != SelectState.Unselect)
            {
                state_ = SelectState.Unselect;
                // 카드들을 예전 위치로 돌려보냄
                for(int i = 0; i < _selectedPics.Count; i++)
                {
                    Point point = new Point(LocationXOf(_selectLine),
                                        LocationYOf(curCards[_selectLine - 1].Count - _selectedPics.Count + i));
                    _selectedPics[i].Location = point;
                    _selectedPics[i].BringToFront();
                }
                // 게임 상태 보내기 불가능 상태로 설정
                _form1.SetGameState(GameState.CantTransferCards);
            }

            // 어떤 결과든 간에 리스트는 비운다.
            _selectedPics.Clear();
        }
        

        // 카드들을 보내려고 선택할 때의 클릭 이벤트
        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            // 이벤트가 벌어진 카드 이미지로부터 해당 라인과 가져갈 카드의 장수를 파악
            PictureBox pb = (PictureBox)sender;
            string tag = pb.Tag.ToString();
            string[] tags = tag.Split(',');
            _selectLine = int.Parse(tags[0]);
            int count = _form1.board.boardLines[_selectLine - 1].Count;
            count = count >= 13 ? 13 : count;
            int num = int.Parse(tags[1]);
            int chainedAmount = _form1.board.GetCardChainAmountFromLine(_selectLine);

            // 해당 라인의 연쇄된 카드량 범위 내에서 카드를 선택했다면
            if (num >= count - chainedAmount)
            {
                // 될 경우 카드는 클릭한 범위부터 끝까지로 리스트로 묶어둠 
                while(num < count && num < 13)
                {
                    PictureBox p = curCards[_selectLine - 1][num++];
                    _selectedPics.Add(p);
                    p.BringToFront();
                }
                // 카드를 선택한 상태로 만듦 
                state_ = SelectState.Select;
                
                //mouseXInterval = e.X;
                //mouseYInterval = e.Y;
            }
            // 예외라면 카드 들고가기 불가
            else
            {
                state_ = SelectState.Cancled;
                _form1.SetGameState(GameState.TooManyCards);
            }
        }


        // 마우스가 움직일 때마다 발생하는 이벤트
        public void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            //카드들을 선택한 상황에서만
            if (state_ == SelectState.Select)
            {
                // 선택한 PictureBox 리스트의 요소들이 현재 마우스 위치로 이동
                for (int i = 0; i < _selectedPics.Count; i++)
                {
                    Point pos = new Point(e.X, e.Y + (i * VER_INTERVAL));
                    _selectedPics[i].Location = pos;
                } 
            }
        }


        private int LocationXOf(int line)
        {
            return HOR_LOCATION + (HOR_INTERVAL * (line - 1));
        }

        private int LocationYOf(int number)
        {
            return VER_LOCATION + (VER_INTERVAL * (number - 1));
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

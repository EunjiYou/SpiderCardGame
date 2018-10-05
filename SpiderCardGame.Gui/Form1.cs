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
    public enum GameState
    {
        None = -1,
        WrongInput, //라인 입력 에러
        TooManyCards, //옮기는 카드량 오버 에러
        CantTransferCards, //교환 불가 에러
        DealerIsEmpty,
        BoardLineIsEmpty,
        Hint,
        GetNewCard,
        NoMoreHint,
        Win, //승리
        GameOver //패배
    }
    
    public partial class Form1 : Form
    {
        private const int HOR_LOCATION = 50;
        private const int VER_LOCATION = 120;
        private const int HOR_INTERVAL = 100;
        private const int VER_INTERVAL = 25;
        private const int MAX_PICTURE_AMOUNT = 13;


        private static GameState _state = GameState.None;

        Dealer dealer = new Dealer();
        Score score = new Score();
        Board board = new Board();

        List<List<PictureBox>> curCards = new List<List<PictureBox>>();
        List<Image> images;

        int select = -1;
        int sendLine = -1;
        int recvLine = -1;
        int amount = -1;

        private bool gameEnd = false;


        public Form1()
        {
            InitializeComponent();

            images = new List<Image>() { Resources.ace_of_spades2,Resources._2_of_spades, Resources._3_of_spades, Resources._4_of_spades, Resources._5_of_spades, Resources._6_of_spades, Resources._7_of_spades, Resources._8_of_spades, Resources._9_of_spades, Resources._10_of_spades, Resources.jack_of_spades2, Resources.queen_of_spades2, Resources.king_of_spades2, 
              Resources.ace_of_clubs, Resources._2_of_clubs, Resources._3_of_clubs, Resources._4_of_clubs, Resources._5_of_clubs, Resources._6_of_clubs, Resources._7_of_clubs, Resources._8_of_clubs, Resources._9_of_clubs, Resources._10_of_clubs, Resources.jack_of_clubs2, Resources.queen_of_clubs2, Resources.king_of_clubs2,
                Resources.ace_of_diamonds, Resources._2_of_diamonds, Resources._3_of_diamonds, Resources._4_of_diamonds, Resources._5_of_diamonds, Resources._6_of_diamonds, Resources._7_of_diamonds, Resources._8_of_diamonds, Resources._9_of_diamonds, Resources._10_of_diamonds, Resources.jack_of_diamonds2, Resources.queen_of_diamonds2, Resources.king_of_diamonds2,
                Resources.ace_of_hearts, Resources._2_of_hearts, Resources._3_of_hearts, Resources._4_of_hearts, Resources._5_of_hearts, Resources._6_of_hearts, Resources._7_of_hearts, Resources._8_of_hearts, Resources._9_of_hearts, Resources._10_of_hearts, Resources.jack_of_hearts2, Resources.queen_of_hearts2, Resources.king_of_hearts2,
                Resources.backcard,
            };

            for (int i = 0; i < Board.MAX_LINES; i++)
            {
                curCards.Add(new List<PictureBox>()); 
            }

            //SetGameDifficulTyAndGameStart(Difficulty.Normal);
        }

        private void SetGameDifficulTyAndGameStart(Difficulty difficulty)
        {
            lblDifficulty.Text = "난이도 : " + difficulty.ToString();
            dealer.SetDifficulty(difficulty);
            //난이도 선택 판넬 닫기
            difficultyPanel.Visible = false;

            //난이도에 따라 딜러가 셔플
            dealer.Shuffle();
            //셔플 후 딜러가 보드에 카드 배분
            ConveyCardToFirst(dealer, board);
            //보드 상태 확인(print)
            PrintBoard(board, score, dealer);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!gameEnd)
            {
                if (int.TryParse(txtRecvLine.Text, out recvLine) &&
                        int.TryParse(txtAmount.Text, out amount) &&
                        int.TryParse(txtSendLine.Text, out sendLine))
                {
                    if (recvLine > 10 || sendLine > 10 || amount < 1) _state = GameState.WrongInput;
                    else
                    {
                        //양의 경우 연속된 만큼만 가능하게 한다.
                        int chainAmount = board.GetCardChainAmountFromLine(sendLine);
                        if (amount > chainAmount)
                        {
                            _state = GameState.TooManyCards;
                        }
                        else
                        {
                            if (CanConveyCard(board, sendLine, amount, recvLine))
                            {
                                //카드 옮기기
                                ConveyCardLineToLine(board, sendLine, amount, recvLine);

                                //옮긴 후 움직임 수 증가 및 스코어 1 감소
                                score.moveCnt++;
                                score.score--;
                                //카드 한 세트가 완성되면
                                if (LineHasCardSet(board, recvLine))
                                {
                                    MakeOneCardSet(score, board, recvLine);
                                }
                            }
                            else
                                _state = GameState.CantTransferCards;

                        }
                    }
                }
                else
                    _state = GameState.WrongInput;

                if (BoardIsEmpty(board, dealer))
                {
                    _state = GameState.Win;
                    gameEnd = true;
                    DisableGameBoard();
                }
                else if (IsGameOver(score))
                {
                    _state = GameState.GameOver;
                    gameEnd = true;
                    DisableGameBoard();
                }
                //보드 상태 확인(print)
                PrintBoard(board, score, dealer); 
            }
        }


        //힌트 주기
        private void btnHint_Click(object sender, EventArgs e)
        {
            if (!gameEnd)
            {
                //힌트를 줄 수 있는 상황이라면 힌트 주기
                if (CanTransferCard(board))
                {
                    score.score--;
                    _state = GameState.Hint;
                }
                else //아닐 경우
                {
                    //딜러가 카드를 줄 수 있다면 새 카드 받기 권유
                    if (dealer.CanPlayCard())
                        _state = GameState.GetNewCard;
                    else
                    {
                        for (int i = 1; i <= board.boardLines.Count; i++)
                        {
                            if (LineIsEmpty(board, i))
                            {
                                _state = GameState.NoMoreHint;
                            }
                            else
                            {
                                _state = GameState.GameOver;
                                break;
                            }
                        }
                    }
                }

                if (IsGameOver(score))
                {
                    _state = GameState.GameOver;
                    gameEnd = true;
                    DisableGameBoard();
                }

                //보드 상태 확인(print)
                PrintBoard(board, score, dealer); 
            }
        }
        
        //새로 받을 경우
        private void btnNew_Click(object sender, EventArgs e)
        {
            //딜러에게 카드가 있고 보드에 카드가 빈 줄이 하나도 없을 경우에만
            if (!dealer.CanPlayCard())
                _state = GameState.DealerIsEmpty;
            else if (!LinesAreNotEmpty(board))
                _state = GameState.BoardLineIsEmpty;
            else
                //보드의 모든 줄에 카드 열 장씩 배부
                ConveyCardToAllLine(dealer, board);

            //보드 상태 확인(print)
            PrintBoard(board, score, dealer);
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            SetGameDifficulTyAndGameStart(Difficulty.Normal);
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            SetGameDifficulTyAndGameStart(Difficulty.Hard);
        }

        private void btnVeryHard_Click(object sender, EventArgs e)
        {
            SetGameDifficulTyAndGameStart(Difficulty.VerryHard);
        }


        private static bool CanTransferCard(Board board)
        {
            board.SetHintLines(-1, -1);

            for (int i = 0; i < board.boardLines.Count; i++)
            {
                List<Card> line = board.boardLines[i];
                if (line.Count == 0)
                {
                    board.SetHintLines(i + 1, -1);
                    continue;
                }

                int amount = board.GetCardChainAmountFromLine(i + 1);

                Card card = line[line.Count - amount];

                for (int j = 0; j < board.boardLines.Count; j++)
                {
                    if (i == j) continue;

                    List<Card> line2 = board.boardLines[j];
                    if (line2.Count == 0) continue;

                    if (CanConveyCard(board, i + 1, amount, j + 1))
                    {
                        board.SetHintLines(i + 1, j + 1);
                        return true;
                    }
                }
            }

            if (board.hintLines[0] != -1)
            {
                for (int j = 0; j < board.boardLines.Count; j++)
                {
                    if (board.hintLines[0] == j) continue;

                    List<Card> line = board.boardLines[j];
                    int openCardCnt = board.GetCardChainAmountFromLine(j + 1);

                    if (line.Count == 0 && line.Count == openCardCnt) continue;
                    else
                    {
                        board.SetHintLines(j + 1, board.hintLines[0]);
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool LineIsEmpty(Board board, int line)
        {
            List<Card> list = board.boardLines[line - 1];
            if (list.Count == 0) return true;
            return false;
        }

        private static bool CanConveyCard(Board board, int sendLine, int amount, int recvLine)
        {
            List<Card> sendLineList = board.boardLines[sendLine - 1];
            List<Card> recvLineList = board.boardLines[recvLine - 1];

            if (recvLineList.Count == 0) return true;

            return sendLineList[sendLineList.Count - amount].number + 1
                   == recvLineList[recvLineList.Count - 1].number ? true : false;

        }

        //LineIsNotEmpty를 활용할 수도 있지만 foreach문을 활용
        private static bool LinesAreNotEmpty(Board board)
        {
            foreach (List<Card> list in board.boardLines)
            {
                if (list.Count == 0) return false;
            }

            return true;
        }

        //아무것도 없는 보드에 초기 정해진 카드량만큼 배분해줌
        private void ConveyCardToFirst(Dealer dealer, Board board)
        {
            int min = 5;
            int additionalLine = 4;

            for (int i = 0; i < min; i++)
                ConveyCardToAllLine(dealer, board, false);

            for (int i = 1; i <= additionalLine; i++)
            {
                Card card = dealer.PlayCard();
                board.TakeCard(i, card);
            }

            foreach (List<Card> list in board.boardLines)
            {
                list[list.Count - 1].isOpened = true;
            }
        }

        //딜러로부터 카드 새로 받아오기
        private void ConveyCardToAllLine(Dealer dealer, Board board, bool isOpened = true)
        {
            for (int i = 1; i <= board.boardLines.Count; i++)
            {
                Card card = dealer.PlayCard();
                card.isOpened = isOpened;
                board.TakeCard(i, card);
            }
        }

        //sendline에서 receive라인으로 amount만큼 카드가 이동
        private void ConveyCardLineToLine(Board board, int sendLine, int amount, int recvLine)
        {
            List<Card> cards = board.BringCards(sendLine, amount);
            board.TakeCards(recvLine, cards);

            //이동 후 새 카드가 보이도록 설정
            List<Card> list = board.boardLines[sendLine - 1];
            if (list.Count > 0)
                list[list.Count - 1].isOpened = true;
        }

        private bool LineHasCardSet(Board board, int recvLine)
        {
            List<Card> list = board.boardLines[recvLine - 1];
            int number = list[list.Count - 1].number;
            Card.Pattern pattern = list[list.Count - 1].Pattern_;

            if (list.Count - Dealer.MAX_CARD_NUMBER < 0) return false;

            for (int i = 1; i <= Dealer.MAX_CARD_NUMBER; i++)
            {
                if (list[list.Count - i].number != i || !list[list.Count - i].isOpened ||
                    list[list.Count - i].Pattern_ != pattern) return false;
            }

            return true;
        }

        //카드 한 셋트를 처리했을 경우의 함수
        private void MakeOneCardSet(Score score, Board board, int recvLine)
        {
            score.cardSetCnt++;
            score.score += 100;
            board.BringCards(recvLine, Dealer.MAX_CARD_NUMBER);

            List<Card> list = board.boardLines[recvLine - 1];
            if (list.Count > 0)
                list[list.Count - 1].isOpened = true;
        }

        //보드와 딜러 모두 카드가 없으면 true
        private static bool BoardIsEmpty(Board board, Dealer dealer)
        {
            if (dealer.CanPlayCard()) return false;
            foreach (List<Card> list in board.boardLines)
            {
                if (list.Count != 0) return false;
            }

            return true;
        }

        private static bool IsGameOver(Score score)
        {
            if (score.score <= 0) return true;
            return false;
        }


        //보드의 상태 프린트
        private void PrintBoard(Board board, Score score, Dealer dealer)
        {
            //보드에 놓인 카드들 이미지 변환
            for (int i = 1; i <= Board.MAX_LINES; i++)
            {
                List<Card> cardList = board.boardLines[i-1];
                List<PictureBox> pictureList = curCards[i-1];

                //각 줄마다 카드 갯수에 변경이 생겼을 경우 그림도 추가, 삭제
                int diff = pictureList.Count - cardList.Count;
                if (diff != 0)
                {
                    if (diff > 0)
                    {
                        RemovePictureBox(board, i, diff);
                    }
                    else
                    {
                        MakePictureBox(board, i, diff * -1);
                    }
                }

                //한 줄당 출력해줄 갯수는 최대 13개로 제한
                int amount = cardList.Count > MAX_PICTURE_AMOUNT ? MAX_PICTURE_AMOUNT : cardList.Count;

                //픽쳐박스가 있는 위치에 들어갈만한 카드로부터 이미지를 찾아옴
                List<PictureBox> pictureBoxes = GetPictureBoxes(board, i, amount);
                for (int j = 0; j < pictureBoxes.Count; j++)
                {
                    pictureBoxes[j].Image = FindImage(cardList[cardList.Count - amount + j]);
                }
            }
            
            lblRemainCardSet.Text = $" 남은 카드 세트 : {(dealer.cards.Count / Dealer.MAX_CARD_NUMBER) - score.cardSetCnt}";
            lblScore.Text = $" 점수 : {score.score}";

            string state = "";
            switch (_state)
            {
                case GameState.DealerIsEmpty:
                    state = "더이상 카드를 줄 수 없습니다";
                    break;
                case GameState.BoardLineIsEmpty:
                    state = "카드가 없는 라인이 있습니다";
                    break;
                case GameState.GetNewCard:
                    state = "새 카드를 받아오세요";
                    break;
                case GameState.NoMoreHint:
                    state = "힌트를 줄 수 없습니다";
                    break;
                case GameState.CantTransferCards:
                    state = "카드를 교환할 수 없습니다";
                    break;
                case GameState.WrongInput:
                    state = "잘못된 입력입니다";
                    break;
                case GameState.TooManyCards:
                    state = "그만큼 보낼 수 없습니다";
                    break;
                case GameState.Win:
                    state = "You Win!";
                    break;
                case GameState.GameOver:
                    state = "You Lose ㅠㅠ";
                    break;
                befault:
                    state = "";
                    break;
            }
            lblState.Text = state;

            if (_state == GameState.Hint)
            {
                txtSendLine.Text = board.hintLines[0].ToString();
                txtRecvLine.Text = board.hintLines[1].ToString();
                txtAmount.Text = board.GetCardChainAmountFromLine(board.hintLines[0]).ToString();
            }
            else
            {
                txtAmount.Text = "";
                txtSendLine.Text = "";
                txtRecvLine.Text = "";
            }

            _state = GameState.None;
        }

        private Image FindImage(Card card)
        {
            int index = images.Count - 1;
            if (card.isOpened)
                index = ((int) card.Pattern_ * 13) + card.number - 1;
            return images[index];
        }

        private void RemovePictureBox(Board board, int line, int amount)
        {
            List<PictureBox> cards = curCards[line - 1];
            List<PictureBox> removeCards = GetPictureBoxes(board, line, amount);

            foreach (var card in removeCards)
            {
                Controls.Remove(card);
                cards.Remove(card);
            }
        }

        private List<PictureBox> GetPictureBoxes(Board board, int line, int amount)
        {
            List<PictureBox> list = curCards[line - 1];

            var pictures = list.Skip(list.Count - amount).Take(amount);
            
            return pictures.ToList();
        }

        private void MakePictureBox(Board board, int line, int amount = 1, int width = 77, int height = 110)
        {
            for (int i = 0; i < amount; i++)
            {
                if (curCards[line - 1].Count >= MAX_PICTURE_AMOUNT) break;

                PictureBox picture = new PictureBox
                {
                    Tag = 3,
                    Name = $"Card{line-1}{amount}",
                    Width = width,
                    Height = height,
                    Location = new Point(HOR_LOCATION + (HOR_INTERVAL * (line - 1)),
                                         VER_LOCATION + (VER_INTERVAL * (curCards[line - 1].Count - 1))),
                    Image = Resources.backcard,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                Controls.Add(picture);
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
        
        private void DisableGameBoard()
        {
            btnOK.Enabled = false;
            btnHint.Enabled = false;
            btnNew.Enabled = false;
            lblLineNumber.Text = "";
            lblLineNumber2.Text = "";
        }
    }
}

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
        WrongInput,         //입력값 에러
        TooManyCards,       //옮기는 카드량 오버
        CantTransferCards,  //교환 불가 에러
        DealerIsEmpty,      //딜러 카드 없음
        BoardLineIsEmpty,   //카드가 비어있는 줄이 있음
        Hint,               //힌트 제공
        GetNewCard,         //새카드 제공
        NoMoreHint,         //힌트 제공 불가
        Win,                //승리
        GameOver            //패배
    }
    
    public partial class Form1 : Form
    {
        public const int MAX_PICTURE_AMOUNT = 13;

        private static GameState _state = GameState.None;

        Dealer dealer;
        Score score;
        Board board;
        Judge judge;
        GraphicCard graphicCard;
        

        int select = -1;
        int sendLine = -1;
        int recvLine = -1;
        int amount = -1;

        private bool gameEnd = false;
        
        public Form1()
        {
            InitializeComponent();
            
            dealer = new Dealer();
            score = new Score();
            board = new Board(dealer);
            judge = new Judge(board, dealer);
            graphicCard = new GraphicCard(this);
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
            board.InitBoard();
            //보드 상태 확인(print)
            PrintBoard(board, score, dealer);
        }

        // 카드 이동
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
                            if (judge.CanConveyCard(sendLine, amount, recvLine))
                            {
                                //카드 옮기기
                                board.ConveyCardLineToLine(sendLine, amount, recvLine);

                                //옮긴 후 움직임 수 증가 및 스코어 1 감소
                                score.GiveMovePenalty();
                                //카드 한 세트가 완성되면
                                if (judge.LineHasCardSet(recvLine))
                                {
                                    score.GiveOneCardSetScore();
                                    board.RemoveOneCardSet(recvLine);
                                }
                            }
                            else
                                _state = GameState.CantTransferCards;

                        }
                    }
                }
                else
                    _state = GameState.WrongInput;

                if (judge.BoardIsEmpty())
                {
                    _state = GameState.Win;
                    gameEnd = true;
                    DisableGameBoard();
                }
                else if (score.IsGameOver())
                {
                    _state = GameState.GameOver;
                    gameEnd = true;
                    DisableGameBoard();
                }
                //보드 상태 확인(print)
                PrintBoard(board, score, dealer); 
            }
        }


        //힌트 제공
        private void btnHint_Click(object sender, EventArgs e)
        {
            if (!gameEnd)
            {
                //힌트를 줄 수 있는 상황이라면 힌트 주기
                if (judge.CanGiveHint())
                {
                    score.GiveHintPenalty();
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
                            if (board.LineIsEmpty(i))
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

                if (score.IsGameOver())
                {
                    _state = GameState.GameOver;
                    gameEnd = true;
                    DisableGameBoard();
                }

                //보드 상태 확인(print)
                PrintBoard(board, score, dealer); 
            }
        }
        
        // 카드 새로받기
        private void btnNew_Click(object sender, EventArgs e)
        {
            //딜러에게 카드가 있고 보드에 카드가 빈 줄이 하나도 없을 경우에만
            if (!dealer.CanPlayCard())
                _state = GameState.DealerIsEmpty;
            else if (!board.LinesAreNotEmpty())
                _state = GameState.BoardLineIsEmpty;
            else
                //보드의 모든 줄에 카드 열 장씩 배부
                board.ConveyCardToAllLine();

            //보드 상태 확인(print)
            PrintBoard(board, score, dealer);
        }

        // 난이도 노말로 설정
        private void btnNormal_Click(object sender, EventArgs e)
        {
            SetGameDifficulTyAndGameStart(Difficulty.Normal);
        }
        
        // 난이도 어려움으로 설정
        private void btnHard_Click(object sender, EventArgs e)
        {
            SetGameDifficulTyAndGameStart(Difficulty.Hard);
        }

        // 난이도 매우어려움으로 설정
        private void btnVeryHard_Click(object sender, EventArgs e)
        {
            SetGameDifficulTyAndGameStart(Difficulty.VerryHard);
        }


        //보드의 상태 프린트
        private void PrintBoard(Board board, Score score, Dealer dealer)
        {
            //보드에 놓인 카드들 이미지 변환
            for (int i = 1; i <= Board.MAX_LINES; i++)
            {
                List<Card> cardList = board.boardLines[i-1];
                List<PictureBox> pictureList = graphicCard.curCards[i-1];

                //각 줄마다 카드 갯수에 변경이 생겼을 경우 그림도 추가, 삭제
                int diff = pictureList.Count - cardList.Count;
                if (diff != 0)
                {
                    if (diff > 0)
                    {
                        graphicCard.RemovePictureBox(board, i, diff);
                    }
                    else
                    {
                        graphicCard.MakePictureBox(board, i, diff * -1);
                    }
                }

                //한 줄당 출력해줄 갯수는 최대 13개로 제한
                int amount = cardList.Count > MAX_PICTURE_AMOUNT ? MAX_PICTURE_AMOUNT : cardList.Count;

                //픽쳐박스가 있는 위치에 들어갈만한 카드로부터 이미지를 찾아옴
                List<PictureBox> pictureBoxes = graphicCard.GetPictureBoxes(board, i, amount);
                for (int j = 0; j < pictureBoxes.Count; j++)
                {
                    pictureBoxes[j].Image = graphicCard.FindImage(cardList[cardList.Count - amount + j]);
                }
            }
            
            lblRemainCardSet.Text = $" 남은 카드 세트 : {(dealer.cards.Count / Dealer.MAX_CARD_NUMBER) - score.CardSetCount}";
            lblScore.Text = $" 점수 : {score.Scores}";

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

            if (!dealer.CanPlayCard())
                pbxDealer.Visible = false;

            _state = GameState.None;
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

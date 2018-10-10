using System;
using System.CodeDom;
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
        SelectCards,       //클릭하여 카드를 옮기기 시작하는 상태
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

        private static GameState state_ = GameState.None;

        public Dealer dealer;
        public Score score;
        public Board board;
        public Judge judge;
        public GraphicCard graphicCard;
        

        int select = -1;
        int sendLine = -1;
        int recvLine = -1;
        int amount = -1;

        public bool gameEnd = false;
        
        public Form1()
        {
            InitializeComponent();
            
            dealer = new Dealer();
            score = new Score();
            board = new Board(dealer);
            judge = new Judge(board, dealer);
            graphicCard = new GraphicCard(this);
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


        //힌트 제공
        private void btnHint_Click(object sender, EventArgs e)
        {
            if (!gameEnd)
            {
                //힌트를 줄 수 있는 상황이라면 힌트 주기
                if (judge.CanGiveHint())
                {
                    score.GiveHintPenalty();
                    state_ = GameState.Hint;
                }
                else //아닐 경우
                {
                    //딜러가 카드를 줄 수 있다면 새 카드 받기 권유
                    if (dealer.CanPlayCard())
                        state_ = GameState.GetNewCard;
                    else
                    {
                        for (int i = 1; i <= board.boardLines.Count; i++)
                        {
                            if (board.LineIsEmpty(i))
                            {
                                state_ = GameState.NoMoreHint;
                            }
                            else
                            {
                                SetGameOver();
                                break;
                            }
                        }
                    }
                }

                if (score.IsGameOver())
                {
                    SetGameOver();
                }

                
                //보드 상태 확인(print)
                PrintBoard(board, score, dealer); 
            }
        }
        
        
        // 카드 새로받기
        private void pbxNewCard_Click(object sender, EventArgs e)
        {
            //딜러에게 카드가 있고 보드에 카드가 빈 줄이 하나도 없을 경우에만
            if (!dealer.CanPlayCard())
                state_ = GameState.DealerIsEmpty;
            else if (!board.LinesAreNotEmpty())
                state_ = GameState.BoardLineIsEmpty;
            else
                //보드의 모든 줄에 카드 열 장씩 배부
                board.ConveyCardToAllLine();

            //보드 상태 확인(print)
            PrintBoard(board, score, dealer);
        }
        
        // 마우스를 움직일 경우의 이벤트
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            graphicCard.MouseMoveEvent(sender, e);
        }


        // 난이도 설정 후 게임 시작
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
        
        // 게임 상태 변환
        public void SetGameState(GameState state)
        {
            state_ = state;
        }

        // 게임이 끝났는지 확인
        public void CheckGameEnd()
        {
            if (judge.BoardIsEmpty())
            {
                state_ = GameState.Win;
                
            }
            else if (score.IsGameOver())
            {
                state_ = GameState.GameOver;
            }
            else return;

            gameEnd = true;
            DisableGameBoard();
        }

        // 게임오버 판정
        public void SetGameOver()
        {
            state_ = GameState.GameOver;
            gameEnd = true;
            DisableGameBoard();
        }


        public void PrintBoard()
        {
            PrintBoard(board, score, dealer);
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
            switch (state_)
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
                case GameState.Hint:
                    state = $"{board.hintLines[0].ToString()}번 줄에서 {board.hintLines[1].ToString()}번으로 옮길 수 있습니다";
                    break;
                case GameState.NoMoreHint:
                    state = "힌트를 줄 수 없습니다";
                    break;
                case GameState.CantTransferCards:
                    state = "카드를 교환할 수 없습니다";
                    break;
                case GameState.TooManyCards:
                    state = "그만큼 보낼 수 없습니다";
                    break;
                case GameState.GameOver:
                    state = "You lose ㅠㅠ";
                    break;
                befault:
                    state = "";
                    break;
            }
            lblState.Text = state;
            

            if (!dealer.CanPlayCard())
                pbxNewCard.Visible = false;
            
            if(state_ != GameState.GameOver)
                state_ = GameState.None;
        }
        
        // 게임이 끝나고 버튼 비활성화
        private void DisableGameBoard()
        {
            btnHint.Enabled = false;
            if(state_ == GameState.Win)
                lblResult.Visible = true;
        }
    }
}

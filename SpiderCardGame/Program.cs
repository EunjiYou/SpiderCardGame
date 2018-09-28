using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderCardGame.Data;

namespace SpiderCardGame
{
    public enum GameState
    {
        None = -1,
        DealerIsEmpty,
        BoardLineIsEmpty,
        Hint,
        GetNewCard,
        NoMoreHint,
        GameOver
    }

    class Program
    {
        private static GameState _state = GameState.None;

        static void Main(string[] args)
        {
            Console.WriteLine("스파이더 게임 시작");
            
            Dealer dealer = new Dealer();
            Score score = new Score();
            Board board = new Board();

            //게임 난이도 선택
            int difficulty = -1;
            while (true)
            {
                Console.Write("게임 난이도를 선택해주세요. (1: 보통 / 2: 어려움 / 3: 매우 어려움) ");
                try
                {
                    difficulty = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }

                if (difficulty >= 1 && difficulty <= 3) break;
                else Console.WriteLine("잘못된 입력입니다.");
            }

            switch (difficulty)
            {
                case 1 : dealer.SetDifficulty(Difficulty.Normal); break;
                case 2 : dealer.SetDifficulty(Difficulty.Hard); break;
                case 3 : dealer.SetDifficulty(Difficulty.VerryHard); break;
            }

            List<int> list = new List<int>();

            //난이도에 따라 딜러가 셔플
            dealer.Shuffle();
            //셔플 후 딜러가 보드에 카드 배분
            ConveyCardToFirst(dealer, board);


            int select = -1;
            int sendLine = -1;
            int recvLine = -1;
            int amount = -1;
            //보드에 카드가 남아있는 동안 
            while (!BoardIsEmpty(board, dealer) || IsGameOver(score))
            {
                //보드 상태 확인(print)
                PrintBoard(board, score);
                //카드를 옮길 지, 새로 받을 지 결정
                while (true)
                {
                    Console.Write("나의 행동은? (1:카드 옮기기 / 2:새카드 받기 / 0:힌트) ");
                    try
                    {
                        select = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                    }

                    if (select >= 0 && select <= 2) break;
                    else Console.WriteLine("잘못된 입력입니다.");
                }

                //카드 옮기기일 경우
                if(select == 1)
                {
                    // 옮길 카드 줄, 양을 선택. 
                    while (true)
                    {
                        Console.Write("옮기고 싶은 카드가 속한 라인을 선택하세요 (1~10 / 0:취소) ");
                        try
                        {
                            sendLine = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            continue;
                        }
                        
                        if (sendLine >= 0 && sendLine <= 10)
                        {
                            if (sendLine == 0 || !LineIsEmpty(board, sendLine)) break;
                            else Console.WriteLine("이 라인에는 카드가 없습니다.");
                        }
                        else Console.WriteLine("잘못된 입력입니다.");
                    }
                    //카드 옮기기 선택 취소
                    if (sendLine == 0) continue;


                    //양의 경우 연속된 만큼만 가능하게 한다.
                    amount = GetAmountFromLine(board, sendLine);
                    while (true)
                    {
                        Console.Write($"몇 개의 카드를 옮기시겠습니까? (최대 {amount}장 / 0:취소) ");
                        try
                        {
                            select = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            continue;
                        }

                        if (select >= 0 && select <= amount) break;
                        else Console.WriteLine("그만큼 옮길 수 없습니다.");
                    }
                    if (select == 0) continue;


                    //옮길 위치 선택
                    while (true)
                    {
                        Console.Write("선택한 카드를 옮길 라인을 선택하세요 (1~10 / 0:취소) ");
                        try
                        {
                            recvLine = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            continue;
                        }

                        //동일 라인으로 이동 불가
                        if (recvLine == sendLine) Console.WriteLine("동일한 라인입니다. 다시 선택해주세요.");
                        else if (recvLine >= 0 && recvLine <= 10)
                        {
                            //받을 라인의 카드와 내가 보낼 카드가 연속될 수 있는가 확인
                            if(recvLine == 0 || CanConveyCard(board, sendLine, select, recvLine)) break;
                            else Console.WriteLine("이 라인으로는 옮길 수 없습니다.");
                        }
                        else Console.WriteLine("잘못된 입력입니다.");
                    }
                    if (recvLine == 0) continue;

                    //카드 옮기기
                    ConveyCardLineToLine(board, sendLine, select, recvLine);

                    //옮긴 후 움직임 수 증가 및 스코어 1 감소
                    score.moveCnt++;
                    score.score--;
                    //카드 한 세트가 완성되면
                    if(LineHasCardSet(board, recvLine))
                    {
                        MakeOneCardSet(score, board, recvLine);
                    }
                }
                //새로 받을 경우
                else if (select == 2) 
                {
                    //딜러에게 카드가 있고 보드에 카드가 빈 줄이 하나도 없을 경우에만
                    if (!dealer.CanPlayCard())
                        _state = GameState.DealerIsEmpty;
                    else if (!LinesAreNotEmpty(board))
                        _state = GameState.BoardLineIsEmpty;
                    else
                        //보드의 모든 줄에 카드 열 장씩 배부
                        ConveyCardToAllLine(dealer, board);     
                }
                //힌트를 줘야하는 경우
                else
                {
                    //힌트를 줄 수 있는 상황이라면 힌트 주기
                    if (CanTransferCard(board))
                    {
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
                                    _state = GameState.GameOver;
                            }
                        }
                    }
                }
            }

            //게임이 끝나면 점수 표시
            PrintResult(board, score);
        }

        private static bool CanTransferCard(Board board)
        {
            for (int i = 0; i < board.boardLines.Count; i++)
            {
                List<Card> line = board.boardLines[i];
                if (line.Count == 0) continue;

                int amount = GetAmountFromLine(board, i + 1);

                Card card = line[line.Count - amount];

                for (int j = 0; j < board.boardLines.Count; j++)
                {
                    if (i == j) continue;

                    List<Card> line2 = board.boardLines[j];
                    if (line2.Count == 0) continue;

                    Card card2 = line2[line2.Count - 1];

                    if (card.number == card2.number - 1)
                    {
                        board.SetHintLines(i + 1, j + 1);
                        return true;
                    }
                }
            }

            return false;
        }

        private static void MakeOneCardSet(Score score, Board board, int recvLine)
        {
            score.cardSetCnt++;
            score.score += 100;
            board.RemoveCardSet(recvLine);

            List<Card> list = board.boardLines[recvLine - 1];
            if (list.Count > 0)
                list[list.Count - 1].isOpened = true;
        }

        //sendline에서 receive라인으로 amount만큼 카드가 이동
        private static void ConveyCardLineToLine(Board board, int sendLine, int amount, int recvLine)
        {
            List<Card> cards = board.BringCards(sendLine, amount);
            board.TakeCards(recvLine, cards);

            //이동 후 새 카드가 보이도록 설정
            List<Card> list = board.boardLines[sendLine - 1];
            if(list.Count > 0)
                list[list.Count - 1].isOpened = true;
        }

        private static void ConveyCardToFirst(Dealer dealer, Board board)
        {
            for (int i = 0; i < 5; i++)
                ConveyCardToAllLine(dealer, board, false);

            for (int i = 1; i <= 4; i++)
            {
                Card card = dealer.PlayCard();
                board.TakeCard(i, card);
            }

            for (int i = 0; i < board.boardLines.Count; i++)
            {
                List<Card> list = board.boardLines[i];
                list[list.Count - 1].isOpened = true;
            }
        }

        private static bool LineIsEmpty(Board board, int line)
        {
            List<Card> list = board.boardLines[line - 1];
            if (list.Count == 0) return true;
            return false;
        }

        //LineIsNotEmpty를 활용할 수도 있지만 foreach문을 활용
        private static bool LinesAreNotEmpty(Board board)
        {
            foreach(List<Card> list in board.boardLines)
            {
                if (list.Count == 0) return false;
            }

            return true;
        }

        //딜러로부터 카드 새로 받아오기
        private static void ConveyCardToAllLine(Dealer dealer, Board board, bool isOpened = true)
        {
            for(int i = 1; i <= board.boardLines.Count; i++)
            {
                Card card = dealer.PlayCard();
                card.isOpened = isOpened;
                board.TakeCard(i, card);
            }
        }

        private static void PrintResult(Board board, Score score)
        {
            //이겼을 경우 스코어 표시 You Win
            if (!IsGameOver(score))
            {
                Console.WriteLine("You Win!");
            }
            else //졌을 경우 You Lose
            {
                Console.WriteLine("You Lose...");
            }
        }

        private static bool IsGameOver(Score score)
        {
            if (_state == GameState.GameOver || score.score <= 0) return true;
            return false;
        }
        
        private static bool LineHasCardSet(Board board, int recvLine)
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

        private static bool CanConveyCard(Board board, int sendLine, int amount, int recvLine)
        {
            List<Card> sendLineList = board.boardLines[sendLine - 1];
            List<Card> recvLineList = board.boardLines[recvLine - 1];

            if (recvLineList.Count == 0) return true;

            return sendLineList[sendLineList.Count - amount].number + 1 
                == recvLineList[recvLineList.Count - 1].number? true : false;

        }

        private static int GetAmountFromLine(Board board, int line)
        {
            List<Card> list = board.boardLines[line - 1];
            int number = list[list.Count - 1].number;
            Card.Pattern pattern = list[list.Count - 1].Pattern_;
            int cnt = 1;

            while (list.Count - cnt >= 0)
            {
                if (list[list.Count - cnt].isOpened)
                {
                    if (list[list.Count - cnt].number != number++ ||
                        list[list.Count - cnt].Pattern_ != pattern) return cnt-1;
                    cnt++;
                }
                else return cnt-1;
            }

            return cnt-1;
        }

        //보드와 딜러 모두 카드가 없으면 true
        private static bool BoardIsEmpty(Board board, Dealer dealer)
        {
            if (dealer.CanPlayCard()) return false;
            foreach(List<Card> list in board.boardLines)
            {
                if (list.Count != 0) return false;
            }

            return true;
        }

        private static void PrintBoard(Board board, Score score)
        {
            Console.Clear(); Console.WriteLine();

            //보드의 상태 프린트
            for (int i = 0; i < board.GetMaxCardsLine() + 5; i++)
            {
                for(int j = 0; j < board.boardLines.Count; j++)
                {
                    if (i < board.boardLines[j].Count)
                    {
                        if (board.boardLines[j][i].isOpened) Console.Write(board.boardLines[j][i].ToString() + "\t");
                        else Console.Write("[   ]\t"); 
                    }
                    else
                        Console.Write("\t");
                }
                Console.WriteLine();
            }

            for(int i = 1; i <= board.boardLines.Count; i++)
                Console.Write($"  {i}\t");

            Console.WriteLine($" 남은 카드 세트 :{Dealer.MAX_CARD_SET * Dealer.MAX_TRUMPCARD_SET - score.cardSetCnt}");

            Console.WriteLine();
            switch (_state)
            {
                case GameState.DealerIsEmpty:
                    Console.WriteLine("더이상 카드를 줄 수 없습니다.");
                    break;
                case GameState.BoardLineIsEmpty:
                    Console.WriteLine("카드가 없는 라인이 있습니다.");
                    break;
                case GameState.Hint:
                    Console.WriteLine($"{board.hintLines[0]}번의 카드를 {board.hintLines[1]}번으로 옮길 수 있습니다.");
                    break;
                case GameState.GetNewCard:
                    Console.WriteLine("새 카드를 받아오세요.");
                    break;
                case GameState.NoMoreHint:
                    Console.WriteLine("힌트를 줄 수 없습니다.");
                    break;
            }
            _state = GameState.None;
            Console.WriteLine();
        }


    }
}

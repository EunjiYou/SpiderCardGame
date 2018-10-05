using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderCardGame.Data
{
    public class Board
    {
        public const int MAX_LINES = 10;

        public List<List<Card>> boardLines;
        public List<int> hintLines;

        private Dealer _dealer;

        public Board(Dealer dealer)
        {
            _dealer = dealer;
            boardLines = new List<List<Card>>();

            for (int i = 0; i < MAX_LINES; i++)
                boardLines.Add(new List<Card>());

            hintLines = new List<int>() {0, 0};
        }


        //해당 line으로 카드를 받음
        public void TakeCard(int line, Card card)
        {
            boardLines[line - 1].Add(card);
        }

        //카드리스트를 빼냄
        public List<Card> BringCards(int line, int amount)
        {
            List<Card> cards = new List<Card>();
            List<Card> list = boardLines[line - 1];

            for(int i = amount; i > 0; i--)
            {
                cards.Add(list[list.Count - i]);
            }

            list.RemoveAll(x => cards.Contains(x));
            
            return cards;
        }

        public int GetCardChainAmountFromLine(int line)
        {
            List<Card> list = boardLines[line - 1];
            if (list.Count == 0) return 0;

            int number = list[list.Count - 1].number;
            Card.Pattern pattern = list[list.Count - 1].Pattern_;
            int cnt = 1;

            while (list.Count - cnt >= 0)
            {
                if (list[list.Count - cnt].isOpened)
                {
                    if (list[list.Count - cnt].number != number++ ||
                        list[list.Count - cnt].Pattern_ != pattern) return cnt - 1;
                    cnt++;
                }
                else return cnt - 1;
            }

            return cnt - 1;
        }
        

        public void SetHintLines(int sendLine, int recvLine)
        {
            hintLines[0] = sendLine;
            hintLines[1] = recvLine;
        }

        // 제일 많은 카드를 가지고 있는 라인의 카드양을 반환
        public int GetMaxCardsLine()
        {
            List<int> maxCardline = (from x in boardLines
                orderby x.Count descending
                select x.Count).Take(1).ToList();
            
            return maxCardline[0];
        }

        //sendline에서 receive라인으로 amount만큼 카드가 이동
        public void ConveyCardLineToLine(int sendLine, int amount, int recvLine)
        {
            List<Card> cards = BringCards(sendLine, amount);
            foreach (Card card in cards)
            {
                TakeCard(recvLine, card);
            }

            //이동 후 새 카드가 보이도록 설정
            List<Card> list = boardLines[sendLine - 1];
            if (list.Count > 0)
                list[list.Count - 1].isOpened = true;
        }

        public bool LineIsEmpty(int line)
        {
            if (boardLines[line - 1].Count == 0) return true;
            return false;
        }

        //LineIsNotEmpty를 활용할 수도 있지만 foreach문을 활용
        public bool LinesAreNotEmpty()
        {
            for (int i = 0; i < MAX_LINES; i++)
            {
                if (boardLines[i].Count == 0) return false;
            }

            return true;
        }

        public void InitBoard()
        {
            for (int i = 0; i < 5; i++)
                ConveyCardToAllLine(false);

            for (int i = 1; i <= 4; i++)
            {
                Card card = _dealer.PlayCard();
                TakeCard(i, card);
            }

            foreach (List<Card> list in boardLines)
            {
                list[list.Count - 1].isOpened = true;
            }
        }

        //딜러로부터 카드 새로 받아오기
        public void ConveyCardToAllLine(bool isOpened = true)
        {
            for (int i = 1; i <= boardLines.Count; i++)
            {
                Card card = _dealer.PlayCard();
                card.isOpened = isOpened;
                TakeCard(i, card);
            }
        }

        //카드 한 셋트를 처리했을 경우의 함수
        public void RemoveOneCardSet(int recvLine)
        {
            BringCards(recvLine, Dealer.MAX_CARD_NUMBER);

            List<Card> list = boardLines[recvLine - 1];
            if (list.Count > 0)
                list[list.Count - 1].isOpened = true;
        }
    }
}

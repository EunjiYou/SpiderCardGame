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

        public Board()
        {
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

        //해당 line으로 카드를 받음
        public void TakeCards(int line, List<Card> cards)
        {
            foreach(Card card in cards)
            {
                boardLines[line - 1].Add(card);
            }
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

            foreach(Card card in cards)
            {
                list.Remove(card);
            }

            return cards;
        }

        public int GetAmountFromLine(int line)
        {
            List<Card> list = boardLines[line - 1];
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


        ////해당 line의 카드 13장을 전부 삭제
        //public void RemoveCardSet(int line)
        //{
        //    List<Card> lineCards = boardLines[line - 1];

        //    for (int i = 0; i < Dealer.MAX_CARD_NUMBER; i++)
        //    {
        //        lineCards.RemoveAt(lineCards.Count - 1);
        //    }
        //}

        public void SetHintLines(int sendLine, int recvLine)
        {
            hintLines[0] = sendLine;
            hintLines[1] = recvLine;
        }

        // 제일 많은 카드를 가지고 있는 라인의 카드양을 반환
        public int GetMaxCardsLine()
        {
            int max = 0;

            foreach(List<Card> list in boardLines)
            {
                if (list.Count > max)
                    max = list.Count;
            }

            return max;
        }
    }
}

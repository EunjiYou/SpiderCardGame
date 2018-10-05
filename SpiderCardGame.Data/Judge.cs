using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderCardGame.Data
{
    public class Judge
    {
        private Board _board;
        private Dealer _dealer;

        public Judge(Board board, Dealer dealer)
        {
            _board = board;
            _dealer = dealer;
        }


        // line에서 line으로 amount만큼 카드 전달이 가능한지 판단
        public bool CanConveyCard(int sendLine, int amount, int recvLine)
        {
            List<Card> sendLineList = _board.boardLines[sendLine - 1];
            List<Card> recvLineList = _board.boardLines[recvLine - 1];

            if (recvLineList.Count == 0) return true;

            return sendLineList[sendLineList.Count - amount].Number + 1
                   == recvLineList[recvLineList.Count - 1].Number ? true : false;

        }

        // 힌트를 줄 수 있는지 판단
        public bool CanGiveHint()
        {
            _board.SetHintLines(-1, -1);

            for (int i = 0; i < _board.boardLines.Count; i++)
            {
                List<Card> line = _board.boardLines[i];
                if (line.Count == 0)
                {
                    _board.SetHintLines(i + 1, -1);
                    continue;
                }

                int amount = _board.GetCardChainAmountFromLine(i + 1);

                Card card = line[line.Count - amount];

                for (int j = 0; j < _board.boardLines.Count; j++)
                {
                    List<Card> line2 = _board.boardLines[j];
                    if (line2.Count == 0) continue;

                    if (CanConveyCard(i + 1, amount, j + 1))
                    {
                        _board.SetHintLines(i + 1, j + 1);
                        return true;
                    }
                }
            }

            if (_board.hintLines[0] != -1)
            {
                for (int j = 0; j < _board.boardLines.Count; j++)
                {
                    if (_board.hintLines[0] == j) continue;

                    int openCardCnt = _board.GetCardChainAmountFromLine(j + 1);

                    if (_board.boardLines[j].Count == 0 && _board.boardLines[j].Count == openCardCnt) continue;
                    else
                    {
                        _board.SetHintLines(j + 1, _board.hintLines[0]);
                        return true;
                    }
                }
            }

            return false;
        }

        // line에 13장 카드세트가 다 모였는지 판단
        public bool LineHasCardSet(int recvLine)
        {
            List<Card> list = _board.boardLines[recvLine - 1];
            int number = list[list.Count - 1].Number;
            Card.Pattern pattern = list[list.Count - 1].Pattern_;

            if (list.Count - Dealer.MAX_CARD_NUMBER < 0) return false;

            for (int i = 1; i <= Dealer.MAX_CARD_NUMBER; i++)
            {
                if (list[list.Count - i].Number != i || !list[list.Count - i].isOpened ||
                    list[list.Count - i].Pattern_ != pattern) return false;
            }

            return true;
        }

        // 모든 카드들이 완성되었는지 판단
        public bool BoardIsEmpty()
        {
            if (_dealer.CanPlayCard()) return false;
            foreach (List<Card> list in _board.boardLines)
            {
                if (list.Count != 0) return false;
            }

            return true;
        }
    }
}

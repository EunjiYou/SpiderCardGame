using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderCardGame.Data
{
    public class Judge
    {
        Board _board;
        Dealer _dealer;

        public Judge(Board board, Dealer dealer)
        {
            _board = board;
            _dealer = dealer;
        }


        public bool LineHasCardSet(int recvLine)
        {
            List<Card> list = _board.boardLines[recvLine - 1];
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

        public bool CanConveyCard(int sendLine, int amount, int recvLine)
        {
            List<Card> sendLineList = _board.boardLines[sendLine - 1];
            List<Card> recvLineList = _board.boardLines[recvLine - 1];

            if (recvLineList.Count == 0) return true;

            return sendLineList[sendLineList.Count - amount].number + 1
                   == recvLineList[recvLineList.Count - 1].number ? true : false;

        }

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

        //보드와 딜러 모두 카드가 없으면 true
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

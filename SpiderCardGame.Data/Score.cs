using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderCardGame.Data
{
    public class Score
    {
        public int score;
        public int moveCnt;
        public int cardSetCnt;

        public Score()
        {
            cardSetCnt = 0;
            score = 500;
        }

        public void GiveMovePenalty()
        {
            score--;
            moveCnt++;
        }

        public void GiveHintPenalty()
        {
            score--;
        }

        public void GiveOneCardSetScore()
        {
            cardSetCnt++;
            score += 100;
        }

        public bool IsGameOver()
        {
            if (score <= 0) return true;
            return false;
        }
    }
}

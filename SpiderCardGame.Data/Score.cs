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
    }
}

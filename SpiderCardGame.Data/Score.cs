using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderCardGame.Data
{
    public class Score
    {
        public int Scores { get; set; }         //게임점수
        public int MoveCount { get; set; }      //카드 이동 횟수
        public int CardSetCount { get; set; }   //완성된 카드 세트의 갯수

        public Score()
        {
            CardSetCount = 0;
            Scores = 500;
        }

        // 카드를 움직였을 경우 이동수 증가와 스코어 감소
        public void GetMovePenalty()
        {
            Scores--;
            MoveCount++;
        }

        // 힌트를 받을 경우 스코어 감소
        public void GetHintPenalty()
        {
            Scores--;
        }

        // 한 카드세트를 완성시켰을 경우 스코어 증가 및 완성된 카드세트 증가 
        public void GetOneCardSetScore()
        {
            CardSetCount++;
            Scores += 100;
        }

        // 스코어가 0이 되면 GameOver로 간주
        public bool IsGameOver()
        {
            if (Scores <= 0) return true;
            return false;
        }
    }
}

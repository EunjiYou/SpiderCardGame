using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderCardGame.Data
{
    public enum Difficulty
    {
        None,
        Normal = 1,
        Hard = 2,
        VerryHard = 4,
    }

    public class Dealer
    {
        public const int MAX_TRUMPCARD_SET = 2;     //최대로 사용하는 트럼프 카드 세트의 갯수
        public const int MAX_CARD_SET = 4;          //한 트럼프 카드 세트 당 존재하는 카드 세트 갯수
        public const int MAX_CARD_NUMBER = 13;      //한 세트의 기준이 되는 카드 장 수

        private int _index = 0; //딜러의 card list에 접근하는 index
    
        public Difficulty Difficulty_ = Difficulty.None; //게임의 난이도

        public List<Card> cards = new List<Card>(); //게임에 사용할 카드들
        private int _pattern = 0;                   //난이도에 따른 카드 배치를 위한 변수


        // 게임에 사용할 카드들을 생성 후 셔플
        public void Shuffle()
        {
            //트럼프카드 두 벌을 가지고 게임을 한다.
            for(int i = 1; i <= MAX_TRUMPCARD_SET; i++)
            { 
                //트럼프카드는 13장의 카드 4세트가 모여서 완성된다.
                for (int j = 1; j <= MAX_CARD_SET; j++)
                {
                    //카드는 1~13의 숫자까지 가능
                    for (int k = 1; k <= MAX_CARD_NUMBER; k++)
                    {
                        Card card = new Card((Card.Pattern)_pattern, k);
                        cards.Add(card);
                    }

                    if (_pattern == (int)Difficulty_ - 1)
                    {
                        _pattern = 0;
                    }
                    else _pattern++;
                }
            }

            cards = cards.OrderBy(a => Guid.NewGuid()).ToList();
        }

        // 게임 난이도 선택
        public void SetDifficulty(Difficulty Difficulty_)
        {
            this.Difficulty_ = Difficulty_;
        }

        // 카드를 전달
        public Card PlayCard()
        {
            return cards[_index++];
        }

        // 딜러에게서 카드를 가져올 수 있는지의 여부 확인
        public bool CanPlayCard()
        {
            if (_index < cards.Count) return true;
            return false;
        }
    }
}

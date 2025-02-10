using Unity.VisualScripting;
using UnityEngine;

namespace Oliver
{
    public class practise_2_Davinci_Code : MonoBehaviour
    {
        // 啟動判斷
        private enum gameStart
        {
            Stop, Start
        }
        [SerializeField, Header("啟程")]
        private gameStart START = gameStart.Stop;
        [SerializeField, Header("請輸入1~100數字")]
        public int Number;
        public int Round;
        public int randomInt;
        private int oldNumber;
        private void Awake()
        {
            randomInt = Random.Range(1, 101);
            Number = 0;
            Round = 0;
            oldNumber = 101;

        }
        private void Update()
        {
            if ((int)START == 1)
            {
                while (randomInt != Number && Number >= 1 && oldNumber != Number)
                {
                    if (randomInt < Number)
                    {
                        Debug.Log("<color=#ff0> 你猜的數字太大了 </color>");
                        oldNumber = Number;
                        Round = Round + 1;
                    }
                    else if (randomInt > Number)
                    {
                        Debug.Log("<color=#ff0> 你猜的數字太小了 </color>");
                        oldNumber = Number;
                        Round = Round + 1;
                    }
                }
                if (randomInt == Number)
                {
                    Debug.Log("<color=#ff0> --被你猜到啦-- </color>");
                    Debug.Log($"<color=#0f0> ---總共用了{Round}回合--- </color>");
                    oldNumber = 101;
                    START = gameStart.Stop;
                }

            }

        }


    }
}


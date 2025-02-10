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
        [SerializeField, Header("歡迎來到終極密碼，請下拉至Start")]
        private gameStart START = gameStart.Stop;
        [SerializeField, Header("請輸入1~100數字")]
        public int Number;
        public int Round;
        public int randomInt;
        private int oldNumber;

        [SerializeField, Header("確認輸入(y)")]
        public string Enter;


        private void Awake()
        {
            randomInt = Random.Range(1, 101);
            Number = 0;
            Round = 1;
            oldNumber = 101;

        }
        private void Update()
        {
            if ((int)START == 1)
            {
                while (randomInt != Number && Number >= 1 && oldNumber != Number && Enter == "y")
                {
                    if (randomInt < Number)
                    {
                        Debug.Log("<color=#ff0> 你猜的數字太大了 </color>");
                        oldNumber = Number;
                        Round = Round + 1;
                        Enter = "";
                    }
                    else if (randomInt > Number)
                    {
                        Debug.Log("<color=#ff0> 你猜的數字太小了 </color>");
                        oldNumber = Number;
                        Round = Round + 1;
                        Enter = "";
                    }
                }
                if (randomInt == Number && Enter == "y")
                {
                    Debug.Log("<color=#ff0> --被你猜到啦-- </color>");
                    Debug.Log($"<color=#0f0> ---總共用了{Round}回合--- </color>");
                    oldNumber = 101;
                    Enter = "";
                    START = gameStart.Stop;
                }

            }
            else if ((int)START == 0 && Number>0 && Enter =="y")
            {
                Debug.Log("<color=#f00> --您忘了啟動遊戲，請將START選單下拉至start-- </color>");
                Enter = "";
            }

        }


    }
}


using UnityEngine;

namespace Oliver
{
    /// <summary>
    /// 迴圈、列舉、不規則陣列、屬性
    /// </summary>
    public class practise_3_weapon_shop : MonoBehaviour
    {
        [SerializeField, Header("玩家屬性")]
        public string playerName = "Pan";
        public int Hp = 100;
        public int Mp = 80;
        public int Attack = 18;
        public int Defence = 3;
        public int Coin = 1000;

        private enum Type
        {
            武器, 防具, 飾品,
        }
        [SerializeField, Header("---歡迎來到武器商人---")]
        private Type commodity = Type.武器;
        public string[] item;
        private int[] effect;

        [SerializeField, Header("請輸入道具編號No.")]
        [Range(1, 12)]
        public int Number;
        [SerializeField, Header("確認輸入(y)")]
        public string Enter;

        private void Update()
        {
            switch (commodity)
            {
                case Type.武器:
                    item = new string[] { "No.1全能之劍", "No.2魔靈之弓", "No.3燃燒之刃" };
                    break;
                case Type.防具:
                    item = new string[] { "No.4龍鱗之鎧", "No.5忍者衣", "No.6比基尼", "No.7國王新衣" };
                    break;
                case Type.飾品:
                    item = new string[] { "No.8鑽戒", "No.9金釵", "No.10玉鐲", "No.11玻璃鞋", "No.12光頭" };
                    break;
            }
            switch (Number)
            {
                case 1:
                    commodity = Type.武器;
                    effect = new int[] { 15, 15, 10, 10, 400 };
                    Debug.Log($"<color=#7f0>{item[0]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    break;
                case 2:
                    commodity = Type.武器;
                    effect = new int[] { 0, 10, 3, 0, 80 };
                    Debug.Log($"<color=#7f0>{item[1]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    break;
                case 3:
                    commodity = Type.武器;
                    if (item[2] == "No.3燃燒之刃")
                    {
                        effect = new int[] { 0, 0, 15, 0, 75 };
                        Debug.Log($"<color=#7f0>{item[2]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    }
                    break;
                case 4:
                    commodity = Type.防具;
                    if (item[0] == "No.4龍鱗之鎧")
                    {
                        effect = new int[] { 10, 0, 0, 20, 95 };
                        Debug.Log($"<color=#f07>{item[0]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    }
                    break;
                case 5:
                    commodity = Type.防具;
                    effect = new int[] { 0, 0, 5, 5, 50 };
                    Debug.Log($"<color=#f07>{item[1]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    break;
                case 6:
                    commodity = Type.防具;
                    effect = new int[] { 0, 80, 0, 1, 120 };
                    Debug.Log($"<color=#f07>{item[2]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    break;
                case 7:
                    commodity = Type.防具;
                    if (item[3] == "No.7國王新衣")
                    {
                        effect = new int[] { 0, 0, 0, 0, 300 };
                        Debug.Log($"<color=#f07>{item[3]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    }
                    break;
                case 8:
                    commodity = Type.飾品;
                    if (item[0] == "No.8鑽戒")
                    {
                        effect = new int[] { 0, 3, 3, 3, 120 };
                        Debug.Log($"<color=#f00>{item[0]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    }
                    break;
                case 9:
                    commodity = Type.飾品;
                    effect = new int[] { 8, 3, 5, 0, 100 };
                    Debug.Log($"<color=#f00>{item[1]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    break;
                case 10:
                    commodity = Type.飾品;
                    effect = new int[] { 0, 10, 10, 0, 90 };
                    Debug.Log($"<color=#f00>{item[2]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    break;
                case 11:
                    commodity = Type.飾品;
                    effect = new int[] { 0, 20, 0, 5, 40 };
                    Debug.Log($"<color=#f00>{item[3]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    break;
                case 12:
                    commodity = Type.飾品;
                    effect = new int[] { 0, 0, 100, 0, 800 };
                    Debug.Log($"<color=#f00>{item[4]} : 效果 hp+{effect[0]}、mp+{effect[1]}、att+{effect[2]}、def+{effect[3]}、價格 : {effect[4]}");
                    break;
            }
            while (Enter == "y")
            {
                int balance = Coin - effect[4];

                if (balance >= 0)
                {
                    if (commodity == Type.武器)
                    {
                        int n = Number - 1;
                        Debug.Log($"<color=#ff0>---您已購買{item[n]}，花費{effect[4]}，請檢查屬性面板");
                    }
                    else if (commodity == Type.防具)
                    {
                        int n = Number - 4;
                        Debug.Log($"<color=#ff0>---您已購買{item[n]}，花費{effect[4]}，請檢查屬性面板");
                    }
                    else if (commodity == Type.飾品)
                    {
                        int n = Number - 8;
                        Debug.Log($"<color=#ff0>---您已購買{item[n]}，花費{effect[4]}，請檢查屬性面板");
                    }
                    Hp = Hp + effect[0];
                    Mp = Mp + effect[1];
                    Attack = Attack + effect[2];
                    Defence = Defence + effect[3];
                    Coin = Coin - effect[4];
                    Enter = "";
                }
                else
                {
                    Debug.Log($"<color=#ff0>---您的餘額不足---");
                    Enter = "";
                }


            }
        }
    }
}


using UnityEngine;

namespace Oliver
{
    public class practise_1_sample_RPG : MonoBehaviour
    {
        // 玩家資訊
        [SerializeField, Header("玩家")]
        public string playerName = "Pan";
        public int HP = 100;
        public int Attack = 10;

        // 敵人資訊
        private enum npcName
        {
            小擊敗人, 大擊敗人, 老擊敗人, 超擊敗人
        }
        [SerializeField, Header("NPC")]
        private npcName name = npcName.小擊敗人;
        private int[] hpArrary = { 50, 80, 110, 200 };
        private int[] attackArrary = { 5, 8, 11, 20 };
        public int npcHP;
        public int npcAttack;

        // 啟動判斷
        private enum gamble
        {
            Stop, Start
        }
        [SerializeField, Header("啟程")]
        private gamble go = gamble.Stop;

        private void Update()
        {
            // 敵人屬性
            if ((int)go == 0)
            {
                HP = 100;
                switch (name)
                {
                    case npcName.小擊敗人:
                        npcHP = hpArrary[0];
                        npcAttack = attackArrary[0];
                        break;
                    case npcName.大擊敗人:
                        npcHP = hpArrary[1];
                        npcAttack = attackArrary[1];
                        break;
                    case npcName.老擊敗人:
                        npcHP = hpArrary[2];
                        npcAttack = attackArrary[2];
                        break;
                    case npcName.超擊敗人:
                        npcHP = hpArrary[3];
                        npcAttack = attackArrary[3];
                        break;
                    default:
                        break;
                }

            }

            if ((int)go == 1)
            {
                if (HP > 0 && npcHP > 0)
                {
                    while (HP > 0 && npcHP > 0)
                    {
                        HP = HP - npcAttack;
                        npcHP = npcHP - Attack;
                        Debug.Log($"<color=#ff0>你造成了{Attack}點傷害，並受到{npcAttack}點傷害，血量剩於 : {HP}、敵人血量 : {npcHP}</color>");
                    }
                }
                else if (HP <= 0 && npcHP > 0)
                {
                    Debug.Log("<color=#f00>你已經死了</color>");
                    go = gamble.Stop;
                }
                else if (HP > 0 && npcHP <= 0)
                {
                    Debug.Log($"<color=#f00>你擊敗了{name}</color>");
                    go = gamble.Stop;
                }
            }

        }
    }

}


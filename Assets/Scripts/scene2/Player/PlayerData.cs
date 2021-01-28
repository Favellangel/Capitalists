using UnityEngine;

namespace Player
{
    public class PlayerData
    {
        public Color color { get; }
        public string nicName { get; }
        public int сapital { get; set; }
        public int income { get; set; }
        public bool isWin { get; set; }

        public PlayerData()
        {
            color = GameInfo.colors.Dequeue();
            nicName = GameInfo.namePlayers.Dequeue();
            сapital = GameInfo.startCapital;
            income = 0;
            isWin = false;
        }
    }
}



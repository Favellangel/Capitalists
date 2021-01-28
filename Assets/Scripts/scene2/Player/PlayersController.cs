using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayersController : Singleton<PlayersController>,
                                     IPlayer, IPlayers
    {
        private List<Player> players;
        public int countPlayer { get; private set; }
        public int turn { get; private set; }

        public string Name => players[turn].data.nicName;
        public Color Color => players[turn].data.color;
        public int Capital { get => players[turn].data.сapital; set => players[turn].data.сapital = value; } 
        public int Income { get => players[turn].data.income; set => players[turn].data.income = value; }

        public int Turn => turn;

        public PlayersController()
        {
            countPlayer = GameInfo.namePlayers.Count;
            players = new List<Player>();
            for(int i = 0; i < countPlayer; i++)
                players.Add(new Player());
            turn = 0;
        }

        private bool IsBankrupts()
        {
            int countBankrupts = 0;
            for (int i = 0; i < players.Count; i++)
                if (players[i].IsBankrupt())
                    countBankrupts++;
            // если все банкроты
            if (countBankrupts == players.Count)
                return true;
            return false;
        }

        public void NextPlayer()
        {
            ++turn;
            if (turn >= countPlayer)
                turn = 0;
        }

        public void SellBuilding(string name, int cost) // опустить в player
        {
            for (int i = 0; i < players.Count; i++)
                if (players[i].data.nicName == name) 
                   players[i].data.сapital += cost;
        }

        public bool IsAnyWin()
        {
            if (IsBankrupts() || players[turn].IsMillionaire())
            {
                players[turn].data.isWin = true;
                return true;
            }
            return false;
        }

        public bool IsAnyLose()
        {
            if (players[turn].IsBankrupt())
            {
                players.RemoveAt(turn);
                return true;
            }
            return false;
        }

        public bool PurchaseBuilding(int cost)
        {
            return players[turn].PurchaseBuilding(cost);
        }
    }
}
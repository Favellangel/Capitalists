namespace Player
{
    public class PlayersProxy : IPlayers
    {
        int IPlayers.Turn => PlayersController.Instance.Turn;

        public void Destroy()
        {
            PlayersController.Instance.Destroy();
        }

        public bool IsAnyLose()
        {
           return PlayersController.Instance.IsAnyLose();
        }

        public bool IsAnyWin()
        {
            return PlayersController.Instance.IsAnyWin();
        }

        public void NextPlayer()
        {
            PlayersController.Instance?.NextPlayer();
        }

        public void SellBuilding(string name, int cost)
        {
            PlayersController.Instance?.SellBuilding(name, cost);
        }
    }
}




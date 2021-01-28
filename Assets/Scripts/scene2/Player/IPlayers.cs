namespace Player
{
    public interface IPlayers {
        int Turn { get; }
        void NextPlayer();
        bool IsAnyWin();
        bool IsAnyLose();
        void SellBuilding(string name, int cost);
        void Destroy();
    }
}


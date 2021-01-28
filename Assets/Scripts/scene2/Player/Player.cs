namespace Player
{
    public class Player 
    {
        public PlayerData data;

        public Player()
        {
            data = new PlayerData();
        }

        public bool IsMillionaire()
        {
            if (data.сapital >= 1000000)
                return true;
            return false;
        }

        public bool IsBankrupt()
        {
            if (data.сapital <= 0 &&
                data.income < 0)
                return true;
            return false;
        }

        public bool PurchaseBuilding(int cost)
        {
            if (cost <= data.сapital)
            {
                data.сapital -= cost;
                return true;
            }
            return false;
        }
    }
}


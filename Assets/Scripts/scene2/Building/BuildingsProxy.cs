namespace Building
{
    public class BuildingsProxy : IBuildings
    {
        public void ChangePrice()
        {
            BuildingController.Instance?.ChangePrice();
        }

        public void UpdateBuildings()
        {
            BuildingController.Instance?.UpdateBuildings();
        }

        public void CountIncomeCurrentPlayer()
        {
            BuildingController.Instance?.CountIncomeCurrentPlayer();
        }

        public void Destroy()
        {
            BuildingController.Instance?.Destroy();
        }
    }
}
public class BuildingData
{
    public const int TimeToFailureDef = 6;
    public int startingCostBuilding;
    public string name;
    public string owner;
    public bool isSale;
    public int TimeToFailure;

    public int costBuilding;
    public int costGoods;
    public int costUpdate;

    public int oldcostBuilding;
    public int oldCostGoods;

    public float kUpdate;
    public float kGoods;
    public int lvl;

    public enum typeBuilding
    {
        Home,
        Shop,
        Factory
    }

    public BuildingData(typeBuilding building)
    {
        switch (building)
        {
            case typeBuilding.Home:
                Create(Constants.home, 3000, 0.50f, 0.55f);
                break;
            case typeBuilding.Shop:
                Create(Constants.shop, 7000, 0.55f, 0.45f);
                break;
            case typeBuilding.Factory:
                Create(Constants.factory, 14000, 0.6f, 0.4f);
                break;
        }
        startingCostBuilding = costBuilding;
        owner = Constants.neutral;
        TimeToFailure = TimeToFailureDef;
        this.lvl = 1;
        isSale = true;
    }

    void Create(string name, int costBuilding, float kUpdate, float kGoods)
    {
        this.name = name;
        this.costBuilding = costBuilding;
        this.oldcostBuilding = costBuilding;
        this.kUpdate = kUpdate;
        costUpdate = Math.calculatePercentage(costBuilding, kUpdate);
        this.kGoods = kGoods;
        costGoods = Math.calculatePercentage(costBuilding, kGoods);
        this.oldCostGoods = costGoods;
    }

}

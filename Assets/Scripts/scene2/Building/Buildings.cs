using Building;
/// <summary>
/// Класс провайдер, для предоставления данных об игроках
/// </summary>
    class Buildings 
    {
        public static IBuildings all => Proxy<BuildingsProxy>.Instance; 
        public static IBuilding current => Proxy<BuildingProxy>.Instance;   
    }


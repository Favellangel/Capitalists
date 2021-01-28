using UnityEngine;

namespace Building
{
    class BuildingProxy : IBuilding
    {
        public int costUpdate => BuildingController.Instance.costUpdate;
        public int costBuilding => BuildingController.Instance.costBuilding;
        public int lvl => BuildingController.Instance.lvl;

        public string owner
        {
            get => BuildingController.Instance.owner;
            set => BuildingController.Instance.owner = value;
        }

        public bool isSale
        {
            get => BuildingController.Instance.isSale;
            set => BuildingController.Instance.isSale = value;
        }

        public void ChangeSpriteColor(Color color)
        {
            BuildingController.Instance?.ChangeSpriteColor(color);
        }

        public void IncriptSaleVisible(bool visible)
        {
            BuildingController.Instance?.IncriptSaleVisible(visible);
        }

        public void Upgrade()
        {
            BuildingController.Instance?.Upgrade();
        }
    }
}

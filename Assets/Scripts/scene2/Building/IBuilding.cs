using UnityEngine;

namespace Building
{
    interface IBuilding
    {
        int costUpdate { get; }
        int costBuilding { get; }
        string owner { get; set; }
        int lvl { get ; }
        bool isSale { get; set; }

        void IncriptSaleVisible(bool visible);
        void ChangeSpriteColor(Color color);
        void Upgrade();
    }
}

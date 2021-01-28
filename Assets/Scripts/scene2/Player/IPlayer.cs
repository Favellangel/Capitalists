using UnityEngine;

namespace Player
{
    public interface IPlayer
    {
        Color Color{ get; }
        string Name { get; }
        int Capital { get; set; }
        int Income { get; set; }
        bool PurchaseBuilding(int cost);
    }
}


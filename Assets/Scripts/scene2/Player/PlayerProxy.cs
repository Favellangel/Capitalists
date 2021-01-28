using UnityEngine;

namespace Player
{
    /// <summary>
    /// Прокси класс, предоставляет доступ к текущему игроку
    /// </summary>
    public class PlayerProxy : IPlayer
    {
        // нужно возвращать и когда true и когда false 
            // поэтому сейчас не работает оператор Instance?
        public string Name => PlayersController.Instance.Name;

        public Color Color => PlayersController.Instance.Color;

        public int Capital { get => PlayersController.Instance.Capital; set => PlayersController.Instance.Capital = value; }

        public int Income { get => PlayersController.Instance.Income; set => PlayersController.Instance.Income = value; }

        public bool PurchaseBuilding(int cost)
        {
            return PlayersController.Instance.PurchaseBuilding(cost);
        }
    }
}

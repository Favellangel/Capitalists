using UnityEngine;

namespace Building
{
    public class BuildingController : Singleton<BuildingController>,
                                      IBuildings, IBuilding
    {        
        private Building[] buildings = GameObject.FindObjectsOfType<Building>();
        public static string nameCurrent;

        public int costUpdate => buildings[Current].data.costUpdate; 
        public int costBuilding => buildings[Current].data.costBuilding; 
        public int lvl => buildings[Current].data.lvl; 

        public string owner {
            get => buildings[Current].data.owner; 
            set => buildings[Current].data.owner = value; 
        }
        
        public bool isSale {
            get => buildings[Current].data.isSale;
            set => buildings[Current].data.isSale = value; 
        }        

        private int Current
        {
            get
            {                
                int i = 0;
                while (buildings[i].name != nameCurrent)
                {
                    ++i;
                    if (i >= buildings.Length - 1)
                         break;
                }
                return i;
            }
        }

        public void ChangePrice()
        {
            int newCost;
            for (int i = 0; i < buildings.Length; i++)
            {
                newCost = buildings[i].data.costBuilding + Math.Random(buildings[i].data.costBuilding);
                newCost = Math.IsNumAcceptable(newCost, buildings[i].data.startingCostBuilding);
                buildings[i].ChangeCosts(newCost);
            }    
        }        
        public void UpdateBuildings() 
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                buildings[i].ShowInscriptionSale(Players.current.Name); 
                //buildings[i].isBroken(Players.current.Name); // это для логики сломанных объектов
            }
        }
        public void CountIncomeCurrentPlayer()
        {
            for (int i = 0; i < buildings.Length; i++)
            if (Players.current.Name  == buildings[i].data.owner) // если игрок владелец строения
                Players.current.Income += buildings[i].data.costBuilding; 
        }

        public void IncriptSaleVisible(bool visible)
        {
            buildings[Current].IncriptSaleVisible(visible); 
        }

        public void ChangeSpriteColor(Color color)
        {
            buildings[Current].spritesManager.ChangeSpriteColor(color); 
        }

        public void Upgrade()
        {
            buildings[Current].Upgrade();
        }
    }
}

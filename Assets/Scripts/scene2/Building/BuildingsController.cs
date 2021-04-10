using UnityEngine;

namespace Building
{
    public class BuildingsController
    {        
        private Building[] buildings = Object.FindObjectsOfType<Building>();
        
        public int length => buildings.Length;

        public static string nameCurrent;
        public int costUpdate => buildings[Current].data.costUpdate; 
        public int costBuilding => buildings[Current].data.costBuilding; 
        public int lvl => buildings[Current].data.lvl; 

        public string Owner {
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
                /*foreach (var building in buildings)
                {
                    if (building.name == nameCurrent)
                        return ;
                }*/
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

        public string GetOwner(int i)
        {
            return buildings[i].data.owner;
        }

        public int  GetCostGoods(int i)
        {
            return buildings[i].data.costGoods;
        }

        public void ChangePrice()
        {
            int newCost;
            int cost;
            for (int i = 0; i < buildings.Length; i++)
            {
                cost = buildings[i].data.costBuilding;
                newCost = cost + Random.Range(-cost / 3, cost / 3);
                //Math.Random(buildings[i].data.costBuilding);
                //newCost = Math.IsNumAcceptable(newCost, buildings[i].data.startingCostBuilding);
                newCost = Math.IsNumAcceptable(newCost, cost);
                buildings[i].ChangeCosts(newCost);
            }    
        }        
        public void UpdateBuildings(string name) 
        {
            foreach (var building in buildings)
                building.ShowInscriptionSale(name);
        }

        public void UpdateBroken(string name)
        {                        
            foreach (var building in buildings)
            {
                if (name != building.data.owner)
                    continue;
                building.breaking.DecreaseTime();
                if (building.breaking.IsBroken())
                {
                    building.breaking.UpdateTime();
                    building.breaking.UpdateSeverity(lvl);
                    building.Broken();
                }
                
            }
                
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

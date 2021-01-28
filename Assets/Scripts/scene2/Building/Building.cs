using UnityEngine;
using UnityEngine.EventSystems;

namespace Building
{
    public class Building : MonoBehaviour
    {
        [SerializeField] BuildingData.typeBuilding typeBuilding;

        [System.NonSerialized] public spritesManager spritesManager;
        [System.NonSerialized] public BuildingData data;
        Transform inscriptionSale;

        void Start()
        {
            data = new BuildingData(typeBuilding);
            spritesManager = this.GetComponent<spritesManager>();
            inscriptionSale = gameObject.transform.Find("Sale");
            ShowInscriptionSale("");
        }

        void OnMouseDown()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                UI.containerInfo.SetActive(false);
                // заполнение инф
                UI.txtNameBuilding.text = gameObject.name +
                                " урв:" + data.lvl + " (" + data.owner + ")";
                UI.txtCost.text = data.costBuilding.ToString();
                UI.txtIncome.text = data.costGoods.ToString();
                UI.txtUpgrade.text = data.costUpdate.ToString();

                BuildingController.nameCurrent = gameObject.name;
                UIRefresher.UpdateUICost(data.oldcostBuilding, data.oldCostGoods, data.costGoods);
                UI.containerInfo.SetActive(true);
            }
        }

        public void ChangeCosts(int cost) 
        {
            data.oldcostBuilding = data.costBuilding;
            data.oldCostGoods = data.costGoods;
            data.costBuilding = cost;
            data.costGoods = Math.calculatePercentage(data.costBuilding, data.kGoods);
        }

        public void ShowInscriptionSale(string nameCurrentPlayer)
        {
            if (data.isSale && nameCurrentPlayer == data.owner) // я владелец и продаю
                IncriptSaleVisible(false);
            else if (data.isSale)
                IncriptSaleVisible(true);
        }

        public void IncriptSaleVisible(bool visible)
        {
            inscriptionSale.gameObject.SetActive(visible);
        }

        public void Upgrade()
        {
            ++data.lvl;
            ChangeCosts((int)(data.costBuilding * 1.4f));
            data.costUpdate = Math.calculatePercentage(data.costBuilding, data.kUpdate);
            data.startingCostBuilding = data.costBuilding;
            spritesManager.ChangeSprite(data.lvl);
        }

        public void isBroken(string nameCurrentPlayer)
        {
            if (nameCurrentPlayer == data.owner)
            {
                --data.TimeToFailure;
                if (data.TimeToFailure == 0)
                {
                    Broken();
                    data.TimeToFailure = 6;
                }
            }
        }
        public void Broken()
        {
            data.oldcostBuilding = data.costBuilding;
            ChangeCosts(0);
            //добваить картинку гаечного ключа (а лучше анимацию)
        }
    }
}
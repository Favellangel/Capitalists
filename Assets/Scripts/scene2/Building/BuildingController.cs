using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingController : MonoBehaviour
{ 
    [SerializeField] BuildingData.typeBuilding typeBuilding;

    [System.NonSerialized] public spritesManager spritesManager;
    BuildingData buildingData;
    Transform inscriptionSale;

    public int startingCostBuilding { get => buildingData.startingCostBuilding; private set { } }
    public int lvl { get => buildingData.lvl; }
    public bool isSale { get => buildingData.isSale; set => buildingData.isSale = value; }
    public string owner { get => buildingData.owner; set => buildingData.owner = value; }
    public int costBuilding { get => buildingData.costBuilding; private set => buildingData.costBuilding = value; }
    public int costGoods { get => buildingData.costGoods; }
    public int costUpdate { get => buildingData.costUpdate; }
    public string nameBuilding { get => buildingData.name; }

    void Start()
    {
        buildingData = new BuildingData(typeBuilding);
        spritesManager = GetComponent<spritesManager>();
        inscriptionSale = gameObject.transform.Find("Sale");
        showInscriptionSale("");
    }
 
    void IsCostAcceptable()
    {
        if (costBuilding < startingCostBuilding / 2 ||
           costBuilding > startingCostBuilding * 2)
            costBuilding = startingCostBuilding; 
    }

    void OnMouseDown() 
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // заполнение инф
            UI.txtNameBuilding.text = nameBuilding +
                            " урв:" + buildingData.lvl + " (" + owner + ")";
            UI.txtCost.text = costBuilding.ToString();
            UI.txtIncome.text = costGoods.ToString();
            UI.txtUpgrade.text = costUpdate.ToString();

            Scripts.contInfo.GetBuildingName(gameObject.name);
            UpdateUICost();
            Scripts.contInfo.setNameBtnAction();
            Scripts.contInfo.SetBtnUpgrate();
        }
    }

    private void UpdateUICost() // можжно вынести в cпец класс с обн UI
    {
        // меняем цвет цены в контейнер инфо
        UI.txtLastMonthCost.text = buildingData.oldcostBuilding.ToString();
        UI.txtLastMonthIncome.text = buildingData.oldCostGoods.ToString();
        UIRefresher.ChangeColor(buildingData.oldcostBuilding, UI.txtCost.text, ref UI.txtCost);
        UIRefresher.ChangeColor(costGoods, UI.txtLastMonthIncome.text, ref UI.txtIncome);
    }

    public void changePrice()
    {
        buildingData.oldcostBuilding = costBuilding;
        buildingData.oldCostGoods = costGoods;
        int rand = UnityEngine.Random.Range(-costBuilding / 3, costBuilding / 3);
        costBuilding += rand;
        IsCostAcceptable();
        buildingData.CountCostGoods();
    }

    public void ChangeCostBuilding(int cost)
    {
        buildingData.costBuilding = cost;
        buildingData.CountCostGoods();
        buildingData.CountCostUpdate();
    }

    public void showInscriptionSale(string nameCurrentPlayer)
    {
        if (isSale && nameCurrentPlayer == owner) // я владелец и продаю
            IncriptSaleVisible(false); 
        else if (isSale)
            IncriptSaleVisible(true);
    }

    public void IncriptSaleVisible(bool visible) 
    {
        inscriptionSale.gameObject.SetActive(visible);   
    }

    public void Upgrade()
    {
        ++buildingData.lvl;
       ChangeCostBuilding((int)(buildingData.costBuilding * 1.4f));
       buildingData.startingCostBuilding = buildingData.costBuilding;
       spritesManager.changeSprite(lvl); 
    }

    public void isBroken(string nameCurrentPlayer)
    {
        if(nameCurrentPlayer == owner)
        {
            --buildingData.TimeToFailure;
            if(buildingData.TimeToFailure == 0)
            {
                Broken();
                buildingData.TimeToFailure = 6;
            }
        }
    }
    public void Broken()
    {
        buildingData.oldcostBuilding = buildingData.costBuilding;
        ChangeCostBuilding(0);
        //добваить картинку гаечного ключа (а лучше анимацию)
    }
}

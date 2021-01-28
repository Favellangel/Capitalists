using UnityEngine;

public class ContainerInfo : MonoBehaviour
{
    GameObject tmp;
    GameManager gameManager;
    BuildingController building;
    string buildingName;

    private void OnEnable()
    {
        tmp = GameObject.Find("GameObjects");
        gameManager = tmp.GetComponent<GameManager>();
    }

    public void GetBuildingName(string name)
    {
        buildingName = name;
    }

    private void setBuilding()
    {
        tmp = GameObject.Find(buildingName);
        building = tmp.GetComponent<BuildingController>();
    }

    public void BuyingBuilding()
    {
        if (gameManager.players.PurchaseBuilding(building.costBuilding))
        {
            if (building.owner != Constants.neutral)
                gameManager.players.SellBuilding(building.owner, building.costBuilding);
            building.owner = gameManager.players.nameCurent;
            building.isSale = false;
            UI.txtBtnAction.text = Constants.sell;
            building.IncriptSaleVisible(false);
            building.spritesManager.changeSpriteColor(gameManager.players.colorCurent);
        }
        else
            UIRefresher.MsgInsufficientFunds();
    }

    public void SetBtnUpgrate()
    {
        UI.btnUpdate.SetActive(false);
        if (gameManager.players.nameCurent == building.owner)
            if(building.lvl > 0 && building.lvl  < 5)
                UI.btnUpdate.SetActive(true);
    }

    public void setNameBtnAction() 
    {
        UI.containerInfo.SetActive(true);
        UI.btnAction.SetActive(true);
        setBuilding();
        //   если текущий игрок владелец и объект продается
        if (building.owner == gameManager.players.nameCurent && building.isSale)
            UI.txtBtnAction.text = Constants.RemoveFromSale;
        // назв купить        если дом государственный или выставлен другими игроками
        else if (building.owner == Constants.neutral || building.isSale)
            UI.txtBtnAction.text = Constants.buy;
        else if (building.owner == gameManager.players.nameCurent)
        {
            if (!building.isSale) // продать    если дом твой и не выставлен
                UI.txtBtnAction.text = Constants.sell;
            else // снять с продажи      если дом твой и выставлен на продажу  
                UI.txtBtnAction.text = Constants.RemoveFromSale;
        }
        else
           UI.btnAction.SetActive(false); 
    }

    public void Click_On_BtnAction()
    {
        setBuilding();
        if (UI.txtBtnAction.text == Constants.buy)
            BuyingBuilding();
        else if (UI.txtBtnAction.text == Constants.sell)
        {
            UI.txtBtnAction.text = Constants.RemoveFromSale;
            building.isSale = true;
        }
        else if (UI.txtBtnAction.text == Constants.RemoveFromSale)
        {
            UI.txtBtnAction.text = Constants.sell;
            building.isSale = false;
        }
        UI.containerInfo.SetActive(false);
    }

    public void Click_On_BtnUgrade()
    {
        if (gameManager.players.PurchaseBuilding(building.costUpdate))
        {
            building.Upgrade();
            building.spritesManager.changeSpriteColor(gameManager.players.colorCurent);
            UI.containerInfo.SetActive(false);
            //произвести анимацию перехода строения на новый уровень
        }
        else
            UIRefresher.MsgInsufficientFunds();
    }

    public void Click_On_BtnClose()
    {
        UI.containerInfo.SetActive(false);
    }
}

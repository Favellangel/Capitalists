using UnityEngine;

public class ContainerInfo : MonoBehaviour
{
    private void OnEnable() // ссылка на container info создается раньше чем на остальное
    {
        if(UI.btnAction != null)
        {
            setNameBtnAction();
            SetBtnUpgrate();
        }
    }
    public void BuyingBuilding() // эти методы должны быть в объединеном классе контроллере
    {        
        if (Players.current.PurchaseBuilding(Buildings.current.costBuilding))
        {
            UIRefresher.TxtResizingEffect(new Color(1, 0, 0, 1), UI.resizingEffect);
            if (Buildings.current.owner != Constants.neutral)
                Players.all.SellBuilding(Buildings.current.owner, Buildings.current.costBuilding);
            Buildings.current.owner = Players.current.Name;
            Buildings.current.isSale = false;
            UI.txtBtnAction.text = Constants.sell;
            Buildings.current.IncriptSaleVisible(false);
            Buildings.current.ChangeSpriteColor(Players.current.Color);
        }
        else
            UIRefresher.MsgInsufficientFunds();
    }

    public void SetBtnUpgrate() // эти методы должны быть в объединеном классе контроллере
    {
        UI.btnUpdate.SetActive(false);
        if (Players.current.Name == Buildings.current.owner)
            if(Buildings.current.lvl > 0 && Buildings.current.lvl  < 5)
                UI.btnUpdate.SetActive(true);
    }

    public void setNameBtnAction() // эти методы должны быть в объединеном классе контроллере
    {
        UI.btnAction.SetActive(true);
        //   если текущий игрок владелец и объект продается         
        if (Buildings.current.owner == Players.current.Name && Buildings.current.isSale)
            UI.txtBtnAction.text = Constants.RemoveFromSale;
        // назв купить        если дом государственный или выставлен другими игроками
        else if (Buildings.current.owner == Constants.neutral || Buildings.current.isSale)
            UI.txtBtnAction.text = Constants.buy;
        else if (Buildings.current.owner == Players.current.Name)
        {
            if (!Buildings.current.isSale) // продать    если дом твой и не выставлен
                UI.txtBtnAction.text = Constants.sell;
            else // снять с продажи      если дом твой и выставлен на продажу  
                UI.txtBtnAction.text = Constants.RemoveFromSale;
        }
        else
           UI.btnAction.SetActive(false); 
    }

    public void Click_On_BtnAction()
    {
        if (UI.txtBtnAction.text == Constants.buy)
            BuyingBuilding();
        else if (UI.txtBtnAction.text == Constants.sell)
        {
            UI.txtBtnAction.text = Constants.RemoveFromSale;
            Buildings.current.isSale = true;
        }
        else if (UI.txtBtnAction.text == Constants.RemoveFromSale)
        {
            UI.txtBtnAction.text = Constants.sell;
            Buildings.current.isSale = false;
        }
        UI.containerInfo.SetActive(false);
    }

    public void Click_On_BtnUgrade()
    { 
        if (Players.current.PurchaseBuilding(Buildings.current.costUpdate))
        {
            Buildings.current.Upgrade();
            Buildings.current.ChangeSpriteColor(Players.current.Color);
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
using UnityEngine;

public class ContainerInfo : MonoBehaviour
{
    private void OnEnable()
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
            if (Buildings.current.owner != Txt.neutral)
                Players.all.SellBuilding(Buildings.current.owner, Buildings.current.costBuilding);
            Buildings.current.owner = Players.current.Name;
            Buildings.current.isSale = false;
            UI.txtBtnAction.text = Txt.sell;
            Buildings.current.IncriptSaleVisible(false);
            Buildings.current.ChangeSpriteColor(Players.current.Color);
        }
        else
            UIRefresher.MsgInsufficientFunds();
    }

    public void SetBtnUpgrate()
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
            UI.txtBtnAction.text = Txt.RemoveFromSale;
        // назв купить        если дом государственный или выставлен другими игроками
        else if (Buildings.current.owner == Txt.neutral || Buildings.current.isSale)
            UI.txtBtnAction.text = Txt.buy;
        else if (Buildings.current.owner == Players.current.Name)
        {
            if (!Buildings.current.isSale) // продать    если дом твой и не выставлен
                UI.txtBtnAction.text = Txt.sell;
            else // снять с продажи      если дом твой и выставлен на продажу  
                UI.txtBtnAction.text = Txt.RemoveFromSale;
        }
        else
           UI.btnAction.SetActive(false); 
    }

    public void Click_On_BtnAction()
    {
        if (UI.txtBtnAction.text == Txt.buy)
            BuyingBuilding();
        else if (UI.txtBtnAction.text == Txt.sell)
        {
            UI.txtBtnAction.text = Txt.RemoveFromSale;
            Buildings.current.isSale = true;
        }
        else if (UI.txtBtnAction.text == Txt.RemoveFromSale)
        {
            UI.txtBtnAction.text = Txt.sell;
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
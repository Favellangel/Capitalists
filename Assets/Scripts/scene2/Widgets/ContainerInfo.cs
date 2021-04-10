using UnityEngine;

public class ContainerInfo : MonoBehaviour
{
    ObjectController gameEvent;

    private void OnEnable()
    {
        gameEvent = UI.gameManager.objController;

        if (UI.btnAction != null && UI.gameManager.objController != null)
        {
            setNameBtnAction();
            SetBtnUpgrate();
        }
    }

    public void SetBtnUpgrate()
    {
        UI.btnUpdate.SetActive(false);
        if (gameEvent.players.Name == gameEvent.buildings.Owner)  
            if(gameEvent.buildings.lvl > 0 && gameEvent.buildings.lvl < 5)  
                UI.btnUpdate.SetActive(true);
    }

    public void setNameBtnAction() // эти методы должны быть в объединеном классе контроллере
    {
        UI.btnAction.SetActive(true);
        //   если текущий игрок владелец и объект продается         
        if (gameEvent.buildings.Owner == gameEvent.players.Name && gameEvent.buildings.isSale) 
            UI.txtBtnAction.text = Txt.RemoveFromSale;
        // назв купить        если дом государственный или выставлен другими игроками
        else if (gameEvent.buildings.Owner == Txt.neutral || gameEvent.buildings.isSale) 
            UI.txtBtnAction.text = Txt.buy;
        else if (gameEvent.buildings.Owner == gameEvent.players.Name)
        {
            if (!gameEvent.buildings.isSale) // продать    если дом твой и не выставлен
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
            gameEvent.BuyingBuilding(); 
        else if (UI.txtBtnAction.text == Txt.sell)
        {
            UI.txtBtnAction.text = Txt.RemoveFromSale;
            gameEvent.buildings.isSale = true; 
        }
        else if (UI.txtBtnAction.text == Txt.RemoveFromSale)
        {
            UI.txtBtnAction.text = Txt.sell;
            gameEvent.buildings.isSale = false;
        }
        UI.containerInfo.SetActive(false);
    }

    public void Click_On_BtnUgrade()
    { 
        if (gameEvent.players.PurchaseBuilding(gameEvent.buildings.costUpdate)) 
        {
            gameEvent.buildings.Upgrade();
            gameEvent.buildings.ChangeSpriteColor(gameEvent.players.Color);
            UI.containerInfo.SetActive(false);
            //произвести анимацию перехода строения на новый уровень
        }
        else
            UIRefresher.MsgInsufficientFunds();
    }
}
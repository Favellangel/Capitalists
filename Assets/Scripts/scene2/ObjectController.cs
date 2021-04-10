using Building;
using Player;
using UnityEngine;

public class ObjectController 
{
    public PlayersController players = new PlayersController();
    public BuildingsController buildings = new BuildingsController();

    private void CountIncomeCurrentPlayer()
    {
        players.Income = 0;
        for (int i = 0; i < buildings.length; i++)
            if (players.Name == buildings.GetOwner(i)) // если игрок владелец строения 
                players.Income += buildings.GetCostGoods(i);
    }

    public void UpdateObj()
    {
        players.NextPlayer(); 
        UpdatePlayer();
        buildings.UpdateBuildings(players.Name);
        buildings.UpdateBroken(players.Name); // вот тут логика сломанных объектов
    }

    public void BuyingBuilding() 
    {
        if (players.PurchaseBuilding(buildings.costBuilding)) 
        {
            UIRefresher.TxtResizingEffect(new Color(1, 0, 0, 1), UI.resizingEffect);
            if (buildings.Owner != Txt.neutral) 
                players.SellBuilding(buildings.Owner, buildings.costBuilding);
            buildings.Owner = players.Name;
            buildings.isSale = false;
            UI.txtBtnAction.text = Txt.sell;
            buildings.IncriptSaleVisible(false);
            buildings.ChangeSpriteColor(players.Color);
        }
        else
            UIRefresher.MsgInsufficientFunds();
    }

    public void UpdatePlayer()
    {                            
        CountIncomeCurrentPlayer();             
        players.Capital += players.Income;

        if (players.Income > 0)
            UIRefresher.TxtResizingEffect(new Color(0, 1, 0, 1), UI.resizingEffect);
        UIRefresher.Player(players.Name, players.Color);
    }
}


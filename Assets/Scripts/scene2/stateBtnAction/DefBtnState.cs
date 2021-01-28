public class defBtnState : IBtnState
{
    public void Update(BtnAction btn)
    {
        UI.txtBtnAction.text = Constants.buy;
        btn.State = new BuyBtnState();
    }
    public void OpenConteinerInfo()//BtnAction btn, bool isSale)
    {
        UI.txtBtnAction.text = Constants.buy;
        //btn.state = new BuyBtnState();
        
        //building.owner == gameManager.players.nameCurent && building.isSale
        //building.owner == Constants.neutral || building.isSale
        //building.owner == gameManager.players.nameCurent
        //!building.isSale

        //building.owner 3
        //building.isSale 3
        //gameManager.players.nameCurent 2
        //Constants.neutral 1

    }
}

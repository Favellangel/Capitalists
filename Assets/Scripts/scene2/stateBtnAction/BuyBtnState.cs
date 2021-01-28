public class BuyBtnState : IBtnState
{
    public void Update(BtnAction btn)
    {
        UI.txtBtnAction.text = Constants.sell;
        //Scripts.contInfo.BuyingBuilding(); // не очень красиво и правильно
        btn.State = new SellBtnState();
    }

}
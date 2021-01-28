public class HideBtnState : IBtnState
{
    public void Update(BtnAction btn)
    {
        UI.btnAction.SetActive(true);
        btn.State = new SellBtnState();
    }
}
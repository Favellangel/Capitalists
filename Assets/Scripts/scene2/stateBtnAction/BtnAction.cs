public interface IBtnState
{
    void Update(BtnAction btn);
}

public class BtnAction //: MonoBehaviour
{
    public IBtnState State {get; set;} 

    public BtnAction(IBtnState bs)
    {
        State = bs;
    }
    public void SetState(IBtnState state)
    {
        this.State = state;
    }

    public void Update()
    {
        State.Update(this);
    }
}



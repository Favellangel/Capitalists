using UnityEngine;

public class ContainerResult : MonoBehaviour
{
    bool isWin = false;

    void OnEnable()
    {        
        if (Players.all.IsAnyWin())
        {
            PrintMsg(Txt.winner);
            isWin = true;
        }
        else if(Players.all.IsAnyLose())
            PrintMsg(Txt.losser);
    }

    private void PrintMsg(string txt)
    {
        transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, 0);
        UIRefresher.UpdateContaineResult(txt);
    }

    public void Click_On_Btn()
    {
        if (isWin)
        {
            garbageCollector.FreeMemory();
            garbageCollector.ChangeScene();
            return;
        }
        gameObject.SetActive(false);       
    }
}

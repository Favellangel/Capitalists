using UnityEngine;

public class ContainerResult : MonoBehaviour
{
    bool isWin = false;

    ObjectController gameEvent;

    void OnEnable()
    {
        gameEvent = UI.gameManager.objController;
        if (UI.gameManager.objController == null)
            return;

        if (gameEvent.players.IsAnyWin()) 
        {
            PrintMsg(Txt.winner);
            isWin = true;
        }
        else if(gameEvent.players.IsAnyLose())
            PrintMsg(Txt.losser);
    }

    private void PrintMsg(string txt)
    {
        transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, 0);
        UIRefresher.UpdateContaineResult(txt, gameEvent.players.Name); 
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

    public void CloseGame()
    {
        garbageCollector.ChangeScene();
    }
}

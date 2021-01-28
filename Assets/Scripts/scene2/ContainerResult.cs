using UnityEngine.SceneManagement;
using UnityEngine;

public class ContainerResult : MonoBehaviour
{
    [SerializeField] Transform Blocking;
    bool isWin = false;

    void OnEnable()
    {
        if (Players.all.IsAnyWin())
        {
            isWin = true;
            UpdateUI(Constants.winner);
        }
        else if(Players.all.IsAnyLose())
            UpdateUI(Constants.losser);
    }

    private void UpdateUI(string result) // вынести в UIRefresher
    {
        Blocking.transform.position = new Vector3(Blocking.transform.position.x, Blocking.transform.position.y, 0);
        UI.txtResult.text = result; 
        UI.txtWinPlayer.text = Players.current.Name;
    }

    public void Click_On_Btn()
    {
        if (isWin)
        {
            garbageCollector.FreeMemory();
            garbageCollector.ChangeScene();
        }
            else
                gameObject.SetActive(false);       
    }
}

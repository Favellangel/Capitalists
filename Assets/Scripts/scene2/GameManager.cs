using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public ObjectController objController;
    TimeManager timeManager;

    private void Start()
    {
        objController = new ObjectController();
        timeManager = new TimeManager();
        UIRefresher.Player(objController.players.Name,
                           objController.players.Color);

        StartCoroutine(routine: timeManager.CoroutineTime());
        StartCoroutine(routine: NextMove());
    }

    private void Update()
    {
        UI.txtCapital.text = objController.players.Capital.ToString();
    }

    public IEnumerator NextMove()
    {
        while (true)
        {
            if (timeManager.MovingTime <= 0)
                NextPlayer();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void NextPlayer()
    {
        resultGame();
        timeManager.UpdateTime();
        objController.UpdateObj();

        timeManager.NewMonth(objController.players.turn);
        if(timeManager.Isquarter())
            objController.buildings.ChangePrice();     
        UI.containerInfo.SetActive(false);
    }

    private void resultGame()
    {
        if (objController.players.IsAnyWin()) 
        {
            UI.containerResult.SetActive(true);
            StopAllCoroutines();
        }
        if (objController.players.IsAnyLose())
            UI.containerResult.SetActive(true);
    }
}
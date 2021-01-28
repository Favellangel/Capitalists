using UnityEngine;

public class GameManager : MonoBehaviour
{
    TimeManager timeManager;

    private void Start()
    {
        timeManager = new TimeManager();
        UIRefresher.Player(Players.current.Name,
                           Players.current.Color);

        StartCoroutine(routine: timeManager.CoroutineTime());
    }

    private void Update()
    {
        UI.txtCapital.text = Players.current.Capital.ToString();
    }

    public void NextPlayer()
    {
        Players.current.Income = 0;
        Buildings.all.CountIncomeCurrentPlayer();
        Players.current.Capital += Players.current.Income;

        resultGame();
        Players.all.NextPlayer();
        if (Players.current.Income > 0) 
            UIRefresher.TxtResizingEffect(new Color(0, 1, 0, 1), UI.resizingEffect);
        UIRefresher.Player(Players.current.Name, Players.current.Color);
        timeManager.UpdateTime();
        Buildings.all.UpdateBuildings();

        timeManager.NewMonth();
        if(timeManager.Isquarter())
            Buildings.all.ChangePrice();        
        UI.containerInfo.SetActive(false);
    }

    private void resultGame()
    {
        if (Players.all.IsAnyWin())
        {
            UI.containerResult.SetActive(true);
            StopAllCoroutines();
        }
        if (Players.all.IsAnyLose())
            UI.containerResult.SetActive(true);
    }
}
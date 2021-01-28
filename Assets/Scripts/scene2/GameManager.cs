using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int month;
    float maxMovingTime;
    float movingTime;

    private void Start()
    {
        maxMovingTime = GameInfo.movingTime;
        UpdateUIPlayer();
        month = 0;
        StartCoroutine(routine: CoroutineTime());
    }

    private void Update()
    {
        UI.txtCapital.text = Players.current.Capital.ToString();
    }

    private void UpdateUIPlayer()
    {
        UIRefresher.Player(Players.current.Name, 
                                   Players.current.Color); 
        movingTime = maxMovingTime;
        UI.txtMovingTime.text = movingTime.ToString();
    }

    private IEnumerator CoroutineTime()
    {
        yield return new WaitForSeconds(1);
         while (true)
         {
            UI.txtMovingTime.text = movingTime.ToString();
             yield return new WaitForSeconds(1);
             movingTime -= 1;
            if (movingTime <= 0)
                NextPlayer();
         }
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
        UpdateUIPlayer();
        Buildings.all.UpdateBuildings();

        if (Players.all.Turn == 0) // если очередь игроков закончилась
            month++;
        if(Isquarter())
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

    public bool Isquarter()
    {
        if(month == 4)
        {
            month = 0;
            return true;
        }
        return false;
    }
}
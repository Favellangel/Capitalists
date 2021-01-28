using System.Collections;
using UnityEngine;

public class TimeManager
{
    int month;
    float maxMovingTime;
    float movingTime;

    GameManager gameManager; // не правильно, потом подумать как избавиться от зависимости

    public TimeManager()
    {
        gameManager = GameObject.Find("GameObjects").GetComponent<GameManager>();

        maxMovingTime = GameInfo.movingTime;
        UpdateTime();
        month = 0;
    }

    public void UpdateTime()
    {
        movingTime = maxMovingTime;
        UI.txtMovingTime.text = movingTime.ToString();
    }

    public IEnumerator CoroutineTime()
    {
        while (true)
        {
            UI.txtMovingTime.text = movingTime.ToString();
            yield return new WaitForSeconds(1);
            movingTime -= 1;
            if (movingTime <= 0)
                gameManager.NextPlayer();             
        }
    }

    public bool Isquarter()
    {
        if (month == 4)
        {
            month = 0;
            return true;
        }
        return false;
    }

    public void NewMonth()
    {
        if (Players.all.Turn == 0)
            month++;
    }
}

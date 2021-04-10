using System.Collections;
using UnityEngine;

public class TimeManager
{
    int month;
    float maxMovingTime;
    float movingTime;

    public float MovingTime => movingTime;

    public TimeManager()
    {
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

    public void NewMonth(int turn)
    {
        if (turn == 0) 
            month++;
    }
}

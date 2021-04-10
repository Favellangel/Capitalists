using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaking
{
    const int TimeToFailureDef = 6;    
    public Severity severity { get; private set; }
    public int timeToFailure { get; private set; }

    public Breaking()
    {
        timeToFailure = TimeToFailureDef;
        severity = Severity.none;
    }

    public void DecreaseTime()
    {
        --timeToFailure;
    }

    public bool IsBroken()
    {
        if (timeToFailure == 0)       
            return true;
        return false;
    }

    public void UpdateTime()
    {
        timeToFailure = 6;
    }

    public void UpdateSeverity(int lvl)
    {
       int tmp = Random.Range(1, 4) + lvl;
        if (tmp == 0)
            severity = Severity.none;
        if (tmp > 0 && tmp < 4)
            severity = Severity.easy;
        if (tmp > 3 && tmp < 7)
            severity = Severity.middle;
        if (tmp > 6 && tmp <= 9)
            severity = Severity.hard;
        else
            severity = Severity.easy; // если получится число меньше 0 или больше 10. 
                                      // То степень тяжести не адекватна и уровень тяжести принимает за default
    }

}

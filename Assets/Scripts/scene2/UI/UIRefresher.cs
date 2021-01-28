using System;
using UnityEngine;
using UnityEngine.UI;

public static class UIRefresher 
{
    /// <summary>
    /// меняет цвет на зеленый если цена выше чем в TxtUI, на красный если цена ниже чем в TxtUI, белый если равны
    /// </summary>
    /// <param name="cost">цена</param>
    /// <param name="txt">цена из TxtUI</param>
    /// <param name="txtCost">TxtUI которому меняет цвет</param>
    public static void ChangeColor(int cost, string txt, ref Text txtCost)
    {
        if (cost > Convert.ToInt32(txt))
            txtCost.color = new Color(0, 1, 0);
        else if (cost < Convert.ToInt32(txt))
            txtCost.color = new Color(1, 0, 0);
        else
            txtCost.color = new Color(1, 1, 1);
    }

    public static void UpdateUIPlayer(string nicName, Color color)
    {
        //вывести сообщение о ходе нового игрока
        UI.GOMassage.SetActive(false);
        UI.TxtMassage.text = Constants.moving + " " + nicName;
        UI.GOMassage.SetActive(true);

        UI.colorPlayer.color = color;
        UI.txtNamePlayer.text = nicName;
    }  

    public static void UpdateUITimeAndCapital(string movingTime, string сapital)
    {
        UI.txtMovingTime.text = movingTime;
        UI.txtCapital.text = сapital;
    }

    /// <summary>
    /// вывести сообщение о недостатке средств
    /// </summary>
    public static void MsgInsufficientFunds()
    {
        UI.TxtMassage.text = Constants.insufficientFunds;
        UI.GOMassage.SetActive(true);
    }
}

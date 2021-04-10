using System;
using UnityEngine;
using UnityEngine.UI;

public static class UIRefresher 
{
    /// <summary>
    /// меняет цвет на зеленый если цена выше чем в TxtUI, на красный если цена ниже чем в TxtUI, белый если равны
    /// </summary>
    /// <param name="cost">цена</param>
    /// <param name="txt">цена из Интерфейса</param>
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

    public static void Player(string nicName, Color color)
    {
        //вывести сообщение о ходе нового игрока
        UI.GOMassage.SetActive(false);
        UI.TxtMassage.text = Txt.moving + " " + nicName;
        UI.GOMassage.SetActive(true);

        UI.colorPlayer.color = color;
        UI.txtNamePlayer.text = nicName;
    }  

    /// <summary>
    /// вывести сообщение о недостатке средств
    /// </summary>
    public static void MsgInsufficientFunds()
    {
        UI.TxtMassage.text = Txt.insufficientFunds;
        UI.GOMassage.SetActive(true);
    }

    public static void UpdateUICost(int oldcostBuilding, int oldCostGoods, int costGoods) 
    {        
        UI.txtLastMonthCost.text = oldcostBuilding.ToString();
        UI.txtLastMonthIncome.text = oldCostGoods.ToString();
        // меняем цвет цены в контейнер инфо
        UIRefresher.ChangeColor(oldcostBuilding, UI.txtCost.text, ref UI.txtCost);
        UIRefresher.ChangeColor(costGoods, UI.txtLastMonthIncome.text, ref UI.txtIncome);
    }

    /// <summary>
    /// вызывает эффект изменения размера и цвета текста текста
    /// </summary>
    /// <param name="ResizingEffect">ссылка, на конкретный объект</param>
    public static void TxtResizingEffect(Color color, TxtResizingEffect ResizingEffect)
    {
        ResizingEffect.StartCoroutine(routine: ResizingEffect.StartEffect(color));
    }

    public static void UpdateContaineResult(string result, string name)
    {
        UI.txtResult.text = result;
        UI.txtWinPlayer.text = name;
    }
}

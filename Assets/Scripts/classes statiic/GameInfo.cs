using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public static class GameInfo
{
    public static Queue<Color> colors = new Queue<Color>();
	public static Queue<string> namePlayers = new Queue<string>();
	public static int startCapital;
 	public	static float movingTime; // int

    /// <summary>
    /// получение текстовых данных из элементов интерфейса
    /// </summary>
    /// <typeparam name="T">тип, который нужно вернуть</typeparam>
    /// <param name="name">Название компонента c интерфейса игры</param>
    /// <returns></returns>
    public static T GetDataOfType<T>(string name)
    {
        string txt = GameObject.Find(name).GetComponentInChildren<Text>().text;
        return (T)Convert.ChangeType(txt, typeof(T));
    }

}

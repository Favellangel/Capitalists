using System.Collections.Generic;
using UnityEngine;

public class PlayersController 
{
    private static PlayersController instance;

    public int countPlayer { get; private set; }
    public List<PlayerData> playersData;
    public int turn { get; private set; }

    public Color colorCurent { get => playersData[turn].color; }
    public string nameCurent { get => playersData[turn].nicName; }
    public int capitalCurent { get => playersData[turn].сapital; }
    public int incomeCurrent { get => playersData[turn].income; set => playersData[turn].income = value; }

    public PlayersController()
    {
        countPlayer = GameInfo.namePlayers.Count;
        playersData = new List<PlayerData>();
        for (int i = 0; i < countPlayer; i++)
            playersData.Add(new PlayerData());
        turn = 0;
    }

    public void Destroy()
    {
        instance = null;
    }

    public static PlayersController GetInstance()
    {
        if (instance == null)
            instance = new PlayersController();
        return instance;
    }

    private bool IsMillionaire()
    {
        if (playersData[turn].сapital >= 1000000)
            return true;
        return false;
    }

    private bool IsBankrupts()
    {
        int countBankrupts = 0;
        for (int i = 0; i < playersData.Count; i++)
            if (IsBankrupt(i))
                countBankrupts++;
        // если все банкроты
        if (countBankrupts == playersData.Count)
            return true;
        return false;
    }

    private bool IsBankrupt(int turn)
    {
        if (playersData[turn].сapital <= 0 &&
            playersData[turn].income < 0)
            return true;
        return false;
    }

    public void NextPlayer()
    {
        ++turn;
        if (turn >= countPlayer)
            turn = 0;
    }

    public bool PurchaseBuilding(int cost)
    {
        if (cost <= playersData[turn].сapital)
        {
            playersData[turn].сapital -= cost;
            return true;
        }
        return false;
    }

    public void SellBuilding(string name, int cost) 
    {
        for (int i = 0; i < playersData.Count; i++)
            if (playersData[i].nicName == name)
                playersData[i].сapital += cost;
    }

    public bool IsWin()
    {
        if (IsBankrupts() || IsMillionaire())
        {
            playersData[turn].isWin = true;
            return true;
        }
        return false;
    }

    public bool IsLose()
    {
        if (IsBankrupt(turn))
        {
            playersData.RemoveAt(turn);
            return true;
        }
        return false;
    }
}

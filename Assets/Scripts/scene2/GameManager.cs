using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int month;
    float maxMovingTime;
    float movingTime;

    BuildingController[] buildings;

    public PlayersController players { get; set; }

    private void Start()
    {
        buildings = GameObject.FindObjectsOfType<BuildingController>();
        players = PlayersController.GetInstance();
        maxMovingTime = GameInfo.movingTime;
        UpdateUIPlayer();
        month = 0;
        StartCoroutine(routine: CoroutineTime());
    }

    private void UpdateUIPlayer()
    {
        UIRefresher.UpdateUIPlayer(players.nameCurent, players.colorCurent);
        movingTime = maxMovingTime;
        UIRefresher.UpdateUITimeAndCapital(movingTime.ToString(),
                                            players.capitalCurent.ToString());
    }

    private IEnumerator CoroutineTime()
    {
        while (true)
        {
            UIRefresher.UpdateUITimeAndCapital(movingTime.ToString(), 
                                               players.capitalCurent.ToString());
            yield return new WaitForSeconds(1);
            movingTime -= 1;
            if (movingTime <= 0)
                StartCoroutine(routine: NextPlayer());
        }
    }

    private IEnumerator NextPlayer()
    {
        //начать анимацию часиков
        CountIncomeCurrentPlayer();
        resultGame();
        players.NextPlayer();
        UpdateUIPlayer();
        SetIncriptionSale();

        if (players.turn == 0) // если очередь игроков закончилась
            month++;
        if(Isquarter())
            for (int i = 0; i < buildings.Length; i++)
                buildings[i].changePrice();
        
        UI.containerInfo.SetActive(false);        
        yield return new WaitForSeconds(0.5f);
        //завершить анимацию
    }

    private void CountIncomeCurrentPlayer()
    {
        for (int i = 0; i < buildings.Length; i++)
            if (players.nameCurent == buildings[i].owner) // если игрок владелец строения
                players.incomeCurrent += buildings[i].costGoods;
        players.playersData[players.turn].сapital += players.incomeCurrent; 
        players.incomeCurrent = 0;
    }

    private void resultGame()
    {
        if (players.IsWin())
        {
            UI.containerResult.SetActive(true);
            StopAllCoroutines();
        }
        if (players.IsLose())
            UI.containerResult.SetActive(true);
    }

    public void SetIncriptionSale() // переименовать в UpdateBuildings
    {
        //SetIncriptionSale
        for (int i = 0; i < buildings.Length; i++)
        {
            buildings[i].showInscriptionSale(players.nameCurent);
            buildings[i].isBroken(players.nameCurent);
        }
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

    public void Click_On_BtnNext()
    {
        StartCoroutine(routine: NextPlayer());       
    }
}

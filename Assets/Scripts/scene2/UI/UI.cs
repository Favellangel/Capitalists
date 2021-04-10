using UnityEngine.UI;
using UnityEngine;

public static class UI
{
    public static GameManager gameManager;
    // объекты из ContainerPlayer
    public static TxtResizingEffect resizingEffect;
    public static Image colorPlayer;
    public static Text txtNamePlayer;
    public static Text txtMovingTime;
    public static Text txtCapital;

    // объекты из ContainerInfo
    public static GameObject containerInfo;
    public static GameObject btnAction;
    public static GameObject btnUpdate;
    public static Text txtNameBuilding;
    public static Text txtCost;
    public static Text txtIncome;
    public static Text txtUpgrade;
    public static Text txtBtnAction;
    public static Text txtLastMonthCost;
    public static Text txtLastMonthIncome;
    public static Text txtState;

    // объекты из ContainerResult
    public static GameObject containerResult;
    public static Text txtResult;
    public static Text txtWinPlayer;

    //объекты из ContainerCloseGame
    public static GameObject containerCloseGame;

    // текстовое сообщение 
    public static GameObject GOMassage;
    public static Text TxtMassage;
}

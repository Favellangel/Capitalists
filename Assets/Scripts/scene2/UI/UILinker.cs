using UnityEngine;
using UnityEngine.UI;

public class UILinker : MonoBehaviour
{
    GameObject tmp;
    Text tmpTxt;

    void Start()
    {
        GetContainerPlayer();
        GetContainerInfo();
        GetContainerResult();

        UI.GOMassage = GameObject.Find("TxtMassage");
        UI.TxtMassage = GetFrom("TxtMassage");
        UI.GOMassage.SetActive(false);

        Destroy(this);
    }

    private void GetContainerPlayer()
    {
        //  получение объектов из ContainerPlayer
        tmp = GameObject.Find("Color Player");
        UI.colorPlayer = tmp.GetComponent<Image>();
        tmp = GameObject.Find("TxtCapital");
        UI.resizingEffect = tmp.GetComponent<TxtResizingEffect>();
        UI.txtNamePlayer = GetFrom("TxtPlayer");
        UI.txtMovingTime = GetFrom("TxtValueTime");
        UI.txtCapital = GetFrom("TxtCapital");
    }

    private void GetContainerInfo()
    {
        //  получение объектов из ContainerInfo
        UI.containerInfo = GameObject.Find("ContainerInfo");
        UI.btnAction = GameObject.Find("BtnAction");
        UI.btnUpdate = GameObject.Find("BtnUpgrade");
        UI.txtNameBuilding = GetFrom("TxtName");
        UI.txtCost = GetFrom("TxtValueCost");
        UI.txtIncome = GetFrom("TxtValueIncome");
        UI.txtUpgrade = GetFrom("TxtValueUpdate");
        UI.txtBtnAction = GetFrom("TxtBtnAction");
        UI.txtLastMonthCost = GetFrom("TxtLastMonthCost");
        UI.txtLastMonthIncome = GetFrom("TxtLastMonthIncome");
        UI.containerInfo.SetActive(false);
    }

    private void GetContainerResult()
    {
        //получение объектов из ContainerResult
        UI.containerResult = GameObject.Find("ContainerResult");
        UI.txtResult = GetFrom("TxtResult");
        UI.txtWinPlayer = GetFrom("TxtWinPlayer");
        UI.containerResult.SetActive(false);
    }

    private Text GetFrom(string name)
    {
        tmp = GameObject.Find(name);
        tmpTxt = tmp.GetComponent<Text>();
        return tmpTxt;
    }

}

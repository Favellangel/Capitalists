using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public void Click_On_BtnExit()
    {
        garbageCollector.FreeMemory();
        garbageCollector.ChangeScene();
    }
}

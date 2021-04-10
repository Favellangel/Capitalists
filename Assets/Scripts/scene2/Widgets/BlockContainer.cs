using UnityEngine;
using UnityEngine.EventSystems;

public class BlockContainer : MonoBehaviour
{
    public void Click_On_Empty()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
        }
    }
}

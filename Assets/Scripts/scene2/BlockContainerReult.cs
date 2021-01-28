using UnityEngine;
using UnityEngine.EventSystems;

public class BlockContainerReult : MonoBehaviour
{
    public void Click_On_Empty()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
        }
    }
}

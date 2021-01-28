using UnityEngine;

public class ScriptsLinker : MonoBehaviour
{
    void Start()
    {
        Scripts.contInfo = UI.containerInfo.GetComponent<ContainerInfo>();
    }

}

using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerResult : MonoBehaviour, IPointerEnterHandler
{
    GameObject tmp;
    GameManager gameManager;
    bool isWin;

    void OnEnable()
    {
            tmp = GameObject.Find("GameObjects");
            gameManager = tmp.GetComponent<GameManager>();
            if (gameManager.players == null)
                return;
            for (int i = 0; i < gameManager.players.playersData.Count; i++)
            {
                if (gameManager.players.playersData[i].isWin)
                    isWin = true;
            }
            if (isWin)
                UpdateUI(Constants.winner);
            else
                UpdateUI(Constants.losser);
        // все равно можно щелкать по объектам. Нужно заблочить все. То есть пока не нажмешь ок. Ни чего нельзя делать\
    }

   /* private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {

        }
    }*/

    private void UpdateUI(string result)
    {
        UI.txtResult.text = result;
        UI.txtWinPlayer.text = gameManager.players.nameCurent;
    }

    public void Click_On_Btn()
    {
            if (isWin)
            {
                SceneManager.UnloadSceneAsync("GameScene"); 
                SceneManager.LoadScene("MainMenu");
                gameManager.players.Destroy();
            }
            else
                gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void OnPlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnGoToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}

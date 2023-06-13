using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    private static int BestScore;
    private static int Score;

    [SerializeField]
    private Text bestScoreText;
    
    [SerializeField]
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Score = PlayerPrefs.GetInt("Score");
        scoreText.text = $"Score: {Score}";

        if (Score > BestScore)
        {
            BestScore = Score;
            
        }

        bestScoreText.text = $"Best score: {BestScore}";
    }

    public void OnPlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnGoToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}

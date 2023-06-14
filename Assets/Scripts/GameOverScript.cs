using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public const string RecordsFileName = "records";

    private static int BestScore;
    private static int Score;

    [SerializeField]
    private Text bestScoreText;
    
    [SerializeField]
    private Text scoreText;

    static GameOverScript()
    {

    }

    private void Awake()
    {
        string pathToRecordsFile = Path.Combine(Application.persistentDataPath, RecordsFileName);

        if (File.Exists(pathToRecordsFile))
        {
            string text = File.ReadAllText(pathToRecordsFile);

            int.TryParse(text, out BestScore);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        Score = PlayerPrefs.GetInt("Score");
        scoreText.text = $"Score: {Score}";

        if (Score > BestScore)
        {
            BestScore = Score;
            string pathToRecordsFile = Path.Combine(Application.persistentDataPath, RecordsFileName);
            File.WriteAllText(pathToRecordsFile, BestScore.ToString());
        }

        bestScoreText.text = $"Best score: {BestScore}";
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
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

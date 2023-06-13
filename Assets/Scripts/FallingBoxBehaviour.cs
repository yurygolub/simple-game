using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingBoxBehaviour : MonoBehaviour
{
    private static int Score;

    [SerializeField]
    private GameObject prefab;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Score = PlayerPrefs.GetInt("Score");
    }

    public void SpawnFallingBox()
    {
        const float Min = -8, Max = 8, Height = 6;

        Instantiate(prefab, new Vector3(Random.Range(Min, Max), Height, 0), Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !this.gameOver)
        {
            this.SpawnFallingBox();
            Destroy(gameObject);

            Score++;

            PlayerPrefs.SetInt("Score", Score);
            PlayerPrefs.Save();
        }
        else if (collision.gameObject.tag == "GroundTag")
        {
            this.gameOver = true;
            Debug.Log("GAME OVER!");

            SceneManager.LoadScene(2);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private const float PlayerSpeed = 50;
    private static int Score;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private FallingBoxBehaviour fallingBoxBehaviour;

    private Rigidbody2D rb;
    private float inputHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
        this.fallingBoxBehaviour.SpawnFallingBox();

        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        Score = PlayerPrefs.GetInt("Score");
        scoreText.text = $"Score: {Score}";

        this.inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (this.inputHorizontal != 0)
        {
            this.rb.AddForce(new Vector2(this.inputHorizontal * PlayerSpeed, 0));
        }
    }
}

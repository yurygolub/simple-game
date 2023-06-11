using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PlayerSpeed = 15;

    [SerializeField]
    private FallingBoxBehaviour fallingBoxBehaviour;

    private Rigidbody2D rb;
    private float inputHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
        this.fallingBoxBehaviour.SpawnFallingBox();
    }

    // Update is called once per frame
    void Update()
    {
        this.inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (this.inputHorizontal != 0)
        {
            this.rb.AddForce(new Vector2(this.inputHorizontal * PlayerSpeed, 0));
        }
    }
}

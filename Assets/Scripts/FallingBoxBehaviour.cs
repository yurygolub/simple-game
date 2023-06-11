using UnityEngine;

public class FallingBoxBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private bool gameOver;

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
        }
        else if (collision.gameObject.tag == "GroundTag")
        {
            this.gameOver = true;
            Debug.Log("GAME OVER!");
        }
    }
}

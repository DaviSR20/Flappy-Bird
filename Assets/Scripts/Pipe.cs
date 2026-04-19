using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed = 2f;
    private GameObject GM;
    private GameManager gameManager;

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = GM.GetComponent<GameManager>();
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    // Trigger del hueco → sumar puntos
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore();
        }
    }

    // Colisión con la tubería → perder
    public void PipeHit()
    {
        gameManager.GameOver();
    }
}
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f; // fuerza del salto
    public GameManager gameManager;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }   

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // click izquierdo
        {
            rb.linearVelocity = Vector2.up * jumpForce; // fuerza hacia arriba
            gameManager.PlayClickSound();
        }
    }
}
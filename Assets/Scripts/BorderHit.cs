using UnityEngine;

public class BorderHit : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        gameManager.GameOver();
    }
}

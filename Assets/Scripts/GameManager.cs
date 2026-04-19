using System;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public GameObject gameOverUI;
    public TextMeshProUGUI LiveScoreText;
    public TextMeshProUGUI FinalScoreText;
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI BestScoreCongrats;
    public GameObject Player;
    public GameObject PipeSpawner;
    public GameObject startUI;
    public AudioClip clickSound;
    public AudioClip deathSound;
    public AudioClip scoreSound;
    private AudioSource audioSource;
    private Rigidbody playerRB;
    private bool gameStarted = false;
    private int bestScore = 0;
    int score = 0;
    private Animator playerAnimator;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerAnimator = Player.GetComponent<Animator>();
        playerRB = Player.GetComponent<Rigidbody>();
        // Estado inicial
        PipeSpawner.SetActive(false);
        playerRB.isKinematic = true;
        
        LiveScoreText.gameObject.SetActive(true);
        startUI.SetActive(true);
        
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        BestScoreText.text = "Best Score: " + bestScore;
        
        BestScoreCongrats.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }
    public void AddScore()
    {
        score++;
        Debug.Log(score);
        LiveScoreText.text = "Score: " + score.ToString();
        PlayScoreSound();
    }
    public void GameOver()
    {   
        // Audio de mort
        PlayDeathSound();
        
        // animación de choque
        playerAnimator.SetBool("OnHit", true);

        // detener física del player
        playerRB.linearVelocity = Vector3.zero;
        playerRB.isKinematic = true;

        // detener spawner
        PipeSpawner.SetActive(false);

        // detener pipes existentes
        Pipe[] pipes = FindObjectsOfType<Pipe>();
        foreach (Pipe pipe in pipes)
        {
            pipe.enabled = false;
        }
        // comprobar si es nuevo récord
        if (score > bestScore)
        {
            bestScore = score;
            BestScoreCongrats.gameObject.SetActive(true);
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }

        FinalScoreText.text = "Score: " + score;
        BestScoreText.text = "Best Score: " + bestScore;
        LiveScoreText.gameObject.SetActive(false);
        
        gameOverUI.SetActive(true);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f; // volver a activar el tiempo
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void StartGame()
    {
        gameStarted = true;
        
        // activar física
        playerRB.isKinematic = false;

        // activar spawner
        PipeSpawner.SetActive(true);

        // ocultar UI inicial
        startUI.SetActive(false);
        // Activa so
    }
    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }

    public void PlayScoreSound()
    {
        audioSource.PlayOneShot(scoreSound);
    }
}

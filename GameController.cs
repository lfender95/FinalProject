using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float scrollSpeed;

    public Text ScoreText;
    public Text winText;
    public Text restartText;
    public Text gameOverText;
    public int score;
    public AudioSource victory;
    public AudioSource BGM;
    public AudioSource defeat;

    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        victory.Stop();
        BGM.Play();
    }

    void Update()
    {
        SceneManager.LoadScene("Space Shooter 2"); // or whatever the name of your scene is
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (score >= 100)
        {
            scrollSpeed = -30;
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                BGM.Stop();
                defeat.Play();
                restartText.text = "Press 'F' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "POINTS " + score;
        if (score >= 100)
        {
            winText.text = "You win! Game created by Luke Fender!";
            gameOver = true;
            restart = true;
            scrollSpeed = 20;
            BGM.Stop();
            victory.Play();
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over! Game created by Luke Fender!";
        gameOver = true;
    }
}
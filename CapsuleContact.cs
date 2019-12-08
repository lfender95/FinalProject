
using UnityEngine;
using System.Collections;

public class CapsuleContact : MonoBehaviour
{
    public int scoreValue;
    public float speed;

    private GameController gameController;
    private PlayerController playerController;
    public AudioSource Activate;
    public GameObject explosion;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }


        if (other.tag == "Player")
        {
           Instantiate(explosion, other.transform.position, other.transform.rotation);
            Activate.Play();
            Destroy(gameObject);
        }

        gameController.AddScore(scoreValue);
    }
}
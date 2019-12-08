using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    public int score;
    public GameController gamecon;


    private Vector3 startPosition; 
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        gamecon = gamecon.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        if (gamecon.score >= 100)
        {
            scrollSpeed = -30;
        }
    }
}
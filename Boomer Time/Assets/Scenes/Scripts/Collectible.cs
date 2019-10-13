using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points;
    public BoxCollider2D col;
    public GameObject gm;

    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
        gm = GameObject.Find("GameManager (1)");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 9)
        {
            gm.GetComponent<ScoreManager>().AddPoints(1, points);
            Destroy(gameObject);
            FindObjectOfType<AudioMAnager>().Play("collectible");
        }
        else if(collider.gameObject.layer == 10)
        {
            gm.GetComponent<ScoreManager>().AddPoints(2, points);
            Destroy(gameObject);
            FindObjectOfType<AudioMAnager>().Play("collectible");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomScale : MonoBehaviour
{
    public GameObject blood;

    // Start is called before the first frame update
    void Start()
    {
        float rng = Random.Range(100, 300)/100f;
        transform.localScale = new Vector3(rng, rng, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "manifPassifs")
        {
            Instantiate(blood, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 9)
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 10)
        {
            Destroy(collision.gameObject);
        }

    }
}

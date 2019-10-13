using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    public float fadespeed;
    private float realfadespeed;
    // Start is called before the first frame update
    void Start()
    {
        realfadespeed = gameObject.GetComponent<SpriteRenderer>().color.a / fadespeed;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, realfadespeed * Time.deltaTime);
    }
}

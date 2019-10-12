using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Sprite player, lawnmower, truck, temp;
    public PlayerMovement playmov;
    public bool isLawnmower;
    public bool isTruck;
    public bool isNormal;

    // Start is called before the first frame update
    void Start()
    {
        playmov = gameObject.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Lawnmower Pup")
        {
            TurnIntoLawnmower();
        }
        if (other.name == "Truck Pup")
        {
            TurnIntoTruck();
        }
        Destroy(other.gameObject);
    }


    void TurnIntoLawnmower()
    {
        temp = gameObject.GetComponent<SpriteRenderer>().sprite;
  
        IEnumerator TransformLawnmower()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = truck;
            yield return new WaitForSecondsRealtime(0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = temp;
            yield return new WaitForSecondsRealtime(0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = truck;
            yield return new WaitForSecondsRealtime(0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = temp;
            yield return new WaitForSecondsRealtime(0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = truck;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        StopAllCoroutines();
        TurnIntoBoomer();
        IEnumerator BeLawnmower()
        {
            isLawnmower = true;
            isNormal = false;
            yield return new WaitForSeconds(10);
            gameObject.GetComponent<SpriteRenderer>().sprite = player;
            TurnIntoBoomer();
        }
        StartCoroutine(BeLawnmower());
    }

    void TurnIntoTruck()
    {
        temp = gameObject.GetComponent<SpriteRenderer>().sprite;
        IEnumerator Transforming()
        {
            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(0.5f);
            Time.timeScale = 1;
        }
        IEnumerator TransformTruck()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = truck;
            yield return new WaitForSecondsRealtime(0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = temp;
            yield return new WaitForSecondsRealtime(0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = truck;
            yield return new WaitForSecondsRealtime(0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = temp;
            yield return new WaitForSecondsRealtime(0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = truck;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        StopAllCoroutines();
        StartCoroutine(TransformTruck());
        StartCoroutine(Transforming());
        TurnIntoBoomer();
        IEnumerator BeTruck()
        {
            isTruck = true;
            isNormal = false;
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<SpriteRenderer>().sprite = player;
            TurnIntoBoomer();
        }
        StartCoroutine(BeTruck());
    }

    void TurnIntoBoomer()
    {
        isTruck = false;
        isLawnmower = false;
        isNormal = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (lawnmower)
        {
            playmov.speed = 150;
        }
        if (isTruck)
        {
            playmov.speed = 250;
        }
        if (isNormal)
        {
            playmov.speed = 100;
        }
    }
}

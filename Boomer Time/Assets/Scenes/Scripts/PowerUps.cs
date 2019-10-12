using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Sprite player, lawnmower, truck;
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
        isTruck = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = lawnmower;
        StopAllCoroutines();
        IEnumerator BeLawnmower()
        {
            isLawnmower = true;
            yield return new WaitForSeconds(10);
            gameObject.GetComponent<SpriteRenderer>().sprite = player;
            isLawnmower = false;
        }
        StartCoroutine(BeLawnmower());
    }

    void TurnIntoTruck()
    {
        isLawnmower = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = truck;
        StopAllCoroutines();
        IEnumerator BeTruck()
        {
            isTruck = true;
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<SpriteRenderer>().sprite = player;
            isTruck = false;
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
            playmov.speed = 250;
        }
    }
}

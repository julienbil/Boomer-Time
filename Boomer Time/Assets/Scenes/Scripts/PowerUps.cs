using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Sprite lawnmower, truck;
    public GameObject player;
    public bool isLawnmower;
    public bool isTruck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag == "Powerup")
        {
            TurnIntoLawnmower();
        }
    }


    void TurnIntoLawnmower()
    {
        isTruck = false;
        player.GetComponent<SpriteRenderer>().sprite = lawnmower;
        IEnumerator BeLawnmower()
        {
            isLawnmower = true;
            yield return new WaitForSeconds(10);
            isLawnmower = false;
        }
        StartCoroutine(BeLawnmower());
    }

    // Update is called once per frame
    void Update()
    {

    }
}

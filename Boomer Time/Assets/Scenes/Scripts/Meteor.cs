using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer sr;

    public float radiusMax, delTime, animationSpeed, radiusSpeed;

    public CircleCollider2D col;

    float debutTime;
    bool animStarted = false;
    float posPreAnim;


    void Start()
    {
        debutTime = Time.realtimeSinceStartup;
        sr.sprite = sprites[0];
        this.transform.localScale += new Vector3(0.01f * radiusSpeed, 0.01f * radiusSpeed, 0);
        col.enabled = false;
        posPreAnim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - debutTime <= delTime)
        {
            if(this.transform.localScale.x/2 < radiusMax)
            {
                this.transform.localScale += new Vector3(0.01f * radiusSpeed, 0.01f * radiusSpeed, 0);
            }
        }
        else if(!animStarted)
        {
            FallingAnimation();
            animStarted = true;
        }
        
        
        //faire suivre la scene???
        //this.transform.position = new Vector3();
    }

    void FallingAnimation()
    {
        posPreAnim = this.transform.position.y;
        sr.sprite = sprites[1];
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 5, 0);
        //transform.Translate(Vector3.down * Time.deltaTime);
        StartCoroutine(ActivateOnTimer());
        col.enabled = true;
    }

    private IEnumerator ActivateOnTimer()
    {
        while (this.transform.position.y >= posPreAnim)
        {
            yield return new WaitForSeconds(0.01f);
            this.transform.Translate(Vector3.down * Time.deltaTime * animationSpeed);
            Debug.Log("descend");
        }
    }
}

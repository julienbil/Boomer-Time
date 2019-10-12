using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChooser : MonoBehaviour
{
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = spriteArray[Random.Range(0, spriteArray.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

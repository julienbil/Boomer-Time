using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
    void Start()
    {
        StartCoroutine(Explode());
    }
   
    private void OnDestroy()
    {
        Debug.Log("Boom.");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

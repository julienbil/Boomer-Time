using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    public GameObject prefag;
    // Start is called before the first frame update
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
    void Start()
    {
        transform.parent = null;
        StartCoroutine(Explode());
    }
   
    private void OnDestroy()
    {
        Destroy(Instantiate(prefag, transform.position, transform.rotation), 0.5f);
        FindObjectOfType<AudioMAnager>().Play("explosion");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

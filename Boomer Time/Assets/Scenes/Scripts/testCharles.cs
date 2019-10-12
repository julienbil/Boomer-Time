using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCharles : MonoBehaviour
{
    public GameObject ffyyf;
    bool testing = true;

    void Start()
    {
        //StartCoroutine(ActivateOnTimer());
    }


    // Update is called once per frame

    private IEnumerator ActivateOnTimer()
        {
            while (true)
            {
                
                yield return new WaitForSeconds(4);
                if (testing)
                {
                    testing = false;
                    Destroy(Instantiate(ffyyf), 10);
                }
            }
        }
    }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TremblementEvent : MonoBehaviour
{
    GameObject cameraHolder;

    // Start is called before the first frame update
    void Start()
    {
        cameraHolder = GameObject.FindGameObjectWithTag("cameraHolder");
        cameraHolder.GetComponent<Scroll>().ActivateShake();
    }

    // Update is called once per frame
    void OnDestroy()
    {
        cameraHolder.GetComponent<Scroll>().DeactivateShake();
    }
}

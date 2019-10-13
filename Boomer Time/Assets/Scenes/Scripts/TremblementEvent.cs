using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TremblementEvent : MonoBehaviour
{
    public GameObject cameraHolder;

    // Start is called before the first frame update
    void Start()
    {
        cameraHolder.GetComponent<Scroll>().ActivateShake();
    }

    // Update is called once per frame
    void OnDestroy()
    {
        cameraHolder.GetComponent<Scroll>().DeactivateShake();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public float horizontalSpeed;
    public float verticalSpeed;
    public int acceleration;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        horizontalSpeed = Input.GetAxis("X");
        verticalSpeed = Input.GetAxis("Y");
    }
}

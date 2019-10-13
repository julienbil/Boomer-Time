using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMove : MonoBehaviour
{
    public Image img;
    public int startAngle = -15;
    public int endAngle = 15;
    public float angle = 0;
    public bool right = true;
    public double speed = 0.5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            if (angle < endAngle)
            {
                angle += 1 * (float)speed;
                img.transform.eulerAngles = new Vector3(0, 0, angle);
            }
            else
            {
                right = !right;
            }
        }
        else
        {
            if (angle > startAngle)
            {
                angle -= 1 * (float)speed;
                img.transform.eulerAngles = new Vector3(0, 0, angle);
            }
            else
            {
                right = !right;
            }
        }
        
    }
}

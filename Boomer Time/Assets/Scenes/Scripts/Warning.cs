using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    public bool warningTime = false, fading = false, timerStart = false;
    public float startTime, transitionTime, timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (warningTime)
        {
            if (!fading)
            {
                if (!timerStart)
                {
                    timerStart = true;
                    timer = Time.time;
                }

                gameObject.GetComponent<Image>().color += new Color(0, 0, 0, 2 * Time.deltaTime);
                if (Time.time - timer >= 0.5)
                {
                    fading = true;
                    timerStart = false;
                }

            }
            else if (fading)
            {
                if (!timerStart)
                {
                    timerStart = true;
                    timer = Time.time;
                }
                gameObject.GetComponent<Image>().color -= new Color(0, 0, 0, 2 * Time.deltaTime);
                if (Time.time - timer >= 0.5)
                {
                    fading = false;
                    timerStart = false;
                }

            }
            if (Time.time - startTime >= 3)
                gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        warningTime = true;
        startTime = Time.time;
    }

    void OnDisable()
    {
        warningTime = false;
    }
}

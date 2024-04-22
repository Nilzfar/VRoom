using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleAnim : MonoBehaviour
{   

    public float scaleSpeed =.1f; 
    public float maxScale = .3f; 
    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (transform.localScale.x < maxScale)
        {
            // increase the scale until it reaches the maximum
            transform.localScale += new Vector3(scaleSpeed, .1f, scaleSpeed) * Time.deltaTime ;
        }
        else
        {
           
            transform.localScale = initialScale * 0.1f; // Reset scale 
        }

    }
}

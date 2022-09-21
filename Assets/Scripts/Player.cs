using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    
    void Update()
    {
        
        transform.Translate(0, Input.GetAxis("P1") * speed * Time.deltaTime,0);
    }
}

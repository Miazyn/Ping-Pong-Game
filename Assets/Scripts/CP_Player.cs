using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP_Player : MonoBehaviour
{

    public GameObject ball,topboundary, bottomboundary;
    public float CP_Speed;
    public float speed;
    Vector3 move;

    public float startPosX;

    

    void Start()
    {
        startPosX = transform.position.x;
    }

   
    void Update()
    {

       
        if (VarManager.IsSingleplayer == true && VarManager.IsGameRunning == true) {
            if (ball != null)
            {
                
                if (ball.transform.position.y > transform.position.y)
                {
                    Debug.LogError("MOVE UP");
                    
                    Movement();
                }
                if (ball.transform.position.y < transform.position.y && bottomboundary.transform.position.y < transform.position.y)
                {
                    
                   
                }
               

            }
            else
            {
                Debug.LogError("No Ball has been defined");
            }

        }
        else if (VarManager.IsSingleplayer == false && VarManager.IsGameRunning == true)
        {
           
                
                transform.Translate(0, Input.GetAxis("P2") * speed * Time.deltaTime, 0);
            
           
        }
    }

    void Movement()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}

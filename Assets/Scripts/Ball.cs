using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public static float speed;
    Rigidbody2D rb;
    [SerializeField] AudioSource pingSound, loseSound;
    [SerializeField] AudioClip pingClip, loseClip;

    public float factor;
    public GameObject ballPosition;

    public GameObject leftgoal1, leftgoal2, rightgoal1, rightgoal2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); ;
        if (rb == null)
        {
            Debug.LogError("Could not find Rigidbody2D component!");
        }

        

    }

    void Update()
    {
        if(VarManager.IsTitleScreen == true)
        {
            VarManager.HasGameStarted = true;
            VarManager.IsTitleScreen = false;
        }
        if (VarManager.HasGameStarted == true)
        {

            Invoke("Launch", 3f);
            VarManager.HasGameStarted = false;
        }

        if(VarManager.counterNumRight == 10 || VarManager.counterNumRight == 10)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void Launch()
    {
        speed = 4;
        //Chooses a random x axis to go to
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        //Debug.LogError(x + "This is x");
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        //Debug.LogError(y + "This is y");

        rb.velocity = new Vector2(speed * x, speed * y);
    }

    void HitWall()
    {
        

        gameObject.SetActive(false);
        gameObject.transform.position = ballPosition.transform.position;
        gameObject.SetActive(true);
        Invoke("Launch", 1f);
    }

    void GoalLeft()
    {
        if (VarManager.counterNumRight != 10) 
        {
            VarManager.counterNumRight += 1;
        }
    }

    void GoalRight()
    {
        if (VarManager.counterNumLeft != 10)
        {
            VarManager.counterNumLeft += 1;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == leftgoal1)
        {
            GoalLeft();
            HitWall();

        }
        if (col.gameObject == leftgoal2)
        {
            GoalLeft();
            HitWall();
        }

        if (col.gameObject == rightgoal1 )
        {
            GoalRight();
            HitWall();
        }

        if (col.gameObject == rightgoal2)
        {
            GoalRight();
            HitWall();
        }
        #region[Sound]
        if(pingSound != null)
        {
            pingSound.PlayOneShot(pingClip);
        }
        /*
        if (pingSound != null)
        {
            if (col.gameObject != leftgoal1 && col.gameObject != leftgoal2 && col.gameObject != rightgoal1 && col.gameObject != rightgoal2)
            {
                pingSound.Play();
            }
        }
        //Will not play yet
        if (loseSound != null)
        {
            if (col.gameObject == leftgoal1 && col.gameObject == leftgoal2 && col.gameObject == rightgoal1 && col.gameObject == rightgoal2)
            {
                loseSound.Play();
            }
        }
        */
        #endregion

        #region[Detect fall into wrong area]
        //Dot result of two Vectors
        var dot = Vector3.Dot(rb.velocity.normalized, Vector3.up);
        if(dot > 0.98 || dot < -0.98)
        {
            Debug.LogError("Added force");
            var v = Random.insideUnitCircle * factor;

            rb.velocity += v;
        }

        #endregion
    }
}

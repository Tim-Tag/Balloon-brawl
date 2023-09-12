using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public LogicScript logic;
    public float velocityHorizontal = 0f;
    public float velocityVertical = 0f;
    public float maxVelocity = 1f;
    bool previousGround = true;

    //f Text;
    public float up = 2f;
    public float distToGround;
    public GameObject ground;
    public LayerMask groundLayer;
    public float speedGround = 0.5f;
    public float speedAir = 2f;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(ground.transform.position, distToGround + 0.1f, groundLayer);
    }
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z") == true)
        {
            velocityVertical = Rigidbody.velocity.y + up;
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, velocityVertical);
          

            if (Input.GetAxis("Horizontal") != 0)
            {
               /* if (Rigidbody.velocity.x >= maxVelocity)
                {
                    velocityHorizontal = maxVelocity;
                }
                else if (Rigidbody.velocity.x <= (maxVelocity * -1))
                {
                    velocityHorizontal = maxVelocity * -1;
                }
                else
                {*/
                    velocityHorizontal = Rigidbody.velocity.x + Input.GetAxis("Horizontal") * speedAir;
                //}
                Rigidbody.velocity = new Vector2(velocityHorizontal, Rigidbody.velocity.y);
            }
        }

        else if (isGrounded())
        {
            //Debug.Log("Grounded");
            if (previousGround == false)
            {
                logic.IncreaseScore();
            }
            previousGround = true;
            if (Input.GetKeyDown("z") == true)
            {
                velocityVertical = Rigidbody.velocity.y + up;
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, velocityVertical);
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                if (Rigidbody.velocity.x >= maxVelocity)
                {
                    velocityHorizontal = maxVelocity;
                }
                else if (Rigidbody.velocity.x <= (maxVelocity * -1))
                {
                    velocityHorizontal = maxVelocity * -1;
                }
                else
                {
                    velocityHorizontal = Rigidbody.velocity.x + Input.GetAxis("Horizontal") * speedGround;
                }
                Rigidbody.velocity = new Vector2(velocityHorizontal, Rigidbody.velocity.y);
            }


        }
        else
        {
            previousGround = false;
        }
    }
}

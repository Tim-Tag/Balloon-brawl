using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public LogicScript logic;
    public float velocityHorizontal = 0f;
    public float velocityVertical = 0f;
    public float maxVelocityGround = 1f;
    public float maxUpSpeed = 5f;
    public float maxFlySpeed = 10;
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
            if (velocityVertical > maxUpSpeed)
            {
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, maxUpSpeed);
            }
            else
            {
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, velocityVertical);
            }



            if (Input.GetAxis("Horizontal") != 0)
            {
                 if (Rigidbody.velocity.x >= maxFlySpeed && Input.GetAxis("Horizontal") > 0)
                 {
                     velocityHorizontal = maxFlySpeed;
                 }
                 else if (Rigidbody.velocity.x <= (maxFlySpeed * -1) && Input.GetAxis("Horizontal") < 0)
                 {
                     velocityHorizontal = maxFlySpeed * -1;
                 }
                 else
                 {
                    velocityHorizontal = Rigidbody.velocity.x + Input.GetAxis("Horizontal") * speedAir;
                 }
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
                if (Rigidbody.velocity.x >= maxVelocityGround)
                {
                    velocityHorizontal = maxVelocityGround;
                }
                else if (Rigidbody.velocity.x <= (maxVelocityGround * -1))
                {
                    velocityHorizontal = maxVelocityGround * -1;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector3 mouvement;
    public float maxSpeed;
    public float masse;
    private float acc;
    public float speed;
    private Vector3 mouvementSubmarine;
    private float limit;
    private bool isMoving;
    private bool goForward;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        acc = 1f;
        limit = acc;
        isMoving = false;
        goForward = false;
        speed = 0;
        masse = 1;
    }

    // Update is called once per frame
    void Update()
    {
        /* Déplacement */
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (speed == 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
            goForward = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(speed == 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
            goForward = false;
        }
        if (isMoving)
        {
            if(goForward == true)
            {
                speed += (acc / masse) * Time.deltaTime;
                if (speed >= maxSpeed)
                {
                    speed = maxSpeed;
                }
            }
            else
            {
                speed -= (acc / masse) * Time.deltaTime;
                if (speed <= -maxSpeed)
                {
                    speed = -maxSpeed;
                }
            }
        } else
        {
            if (goForward == false)
            {
                speed -= (2 * acc / masse) * Time.deltaTime;
                if (goForward == false && speed <= 0)
                {
                    speed = 0;
                }
            }
            if(goForward == true)
            {
                speed += (2 * acc / masse) * Time.deltaTime;
                if (goForward == true && speed >= 0)
                {
                    speed = 0;
                }
            }

        }
        /*Rotation*/
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 20, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * 20, Space.World);
        }

    }

    private void FixedUpdate()
    {
         _rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime); //Déplacement du joueur
    }
}

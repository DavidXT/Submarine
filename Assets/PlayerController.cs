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
    public float essence;
    private bool isRefuel;
    private float maxFuel;
    public float oxygene;
    private bool rechargeOxygene;
    public float maxOxygene;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        acc = 1f;
        limit = acc;
        maxFuel = essence;
        isMoving = false;
        goForward = false;
        speed = 0;
        masse = 1;
        isRefuel = false;
        rechargeOxygene = false;
        maxOxygene = oxygene;
    }

    // Update is called once per frame
    void Update()
    {
        /* Fuel */
        if (Input.GetKeyDown(KeyCode.R)){
            isRefuel = true;
            if (goForward)
            {
                goForward = false;
            }
            else
            {
                goForward = true;
            }
            isMoving = false;
        }
        if (isRefuel)
        {
            essence += 2f * Time.deltaTime;
            if (essence >= maxFuel)
            {
                essence = maxFuel;
                isRefuel = false;
            }
        }

        /* Déplacement */
        if (Input.GetKeyDown(KeyCode.RightArrow) && essence > 0 && !isRefuel && !rechargeOxygene)
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
        if (Input.GetKeyDown(KeyCode.LeftArrow) && essence > 0 && !isRefuel && !rechargeOxygene)
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
        if (isMoving && essence > 0)
        {
            if(goForward == true)
            {
                speed += (acc / masse) * Time.deltaTime;
                essence -= Time.deltaTime;
                if (speed >= maxSpeed)
                {
                    speed = maxSpeed;
                }
            }
            else
            {
                speed -= (acc / masse) * Time.deltaTime;
                essence -= Time.deltaTime;
                if (speed <= -maxSpeed)
                {
                    speed = -maxSpeed;
                }
            }
        } else
        {
            if(essence <= 0)
            {
                if (goForward == true)
                {
                    speed -= (2 * acc / masse) * Time.deltaTime;
                    if (goForward == true && speed <= 0)
                    {
                        speed = 0;
                    }
                }
                if (goForward == false)
                {
                    speed += (2 * acc / masse) * Time.deltaTime;
                    if (goForward == false && speed >= 0)
                    {
                        speed = 0;
                    }
                }
            }
            else
            {
                if (goForward == false)
                {
                    speed -= (2 * acc / masse) * Time.deltaTime;
                    if (goForward == false && speed <= 0)
                    {
                        speed = 0;
                    }
                }
                if (goForward == true)
                {
                    speed += (2 * acc / masse) * Time.deltaTime;
                    if (goForward == true && speed >= 0)
                    {
                        speed = 0;
                    }
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

        /*oxygene*/
        if (Input.GetKeyDown(KeyCode.C))
        {
            rechargeOxygene = true;
            if (goForward)
            {
                goForward = false;
            }
            else
            {
                goForward = true;
            }
            isMoving = false;
        }
        if (!rechargeOxygene)
        {
            oxygene -= 1 * Time.deltaTime;
        }
        else
        {
            oxygene += 2 * Time.deltaTime;
            if(oxygene >= maxOxygene)
            {
                oxygene = maxOxygene;
                rechargeOxygene = false;
            }
        }

    }

    private void FixedUpdate()
    {
         _rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime); //Déplacement du joueur
    }
}

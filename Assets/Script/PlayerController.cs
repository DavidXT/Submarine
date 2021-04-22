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
    public GameObject torpille;
    public int nbTorpille;
    private int maxTorpille;
    public float cdTorpille;
    public float cdRechargeTorpille;
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
        nbTorpille = 5;
        maxTorpille = nbTorpille;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnTorpille();
        }
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

        /* D�placement */
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
            if(oxygene > 0)
            {
                oxygene -= 5 * Time.deltaTime;
            }
        }
        else
        {
            oxygene += 20 * Time.deltaTime;
            if(oxygene >= maxOxygene)
            {
                oxygene = maxOxygene;
                rechargeOxygene = false;
            }
        }

        /*Reload Torpille*/
        if (nbTorpille < maxTorpille)
        {
            cdTorpille += Time.deltaTime;
            if(cdTorpille >= cdRechargeTorpille)
            {
                nbTorpille++;
                cdTorpille = 0;
            }
        }
    }

    private void FixedUpdate()
    {
         _rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime); //D�placement du joueur
    }

    private void SpawnTorpille()
    {
        if (nbTorpille>0)
        {
            nbTorpille--;
            GameObject tempObj = Instantiate(torpille, transform.right + transform.position, transform.rotation);
        }
    }
}

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
    public int limitMoteur=0;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        acc = 1f;
        limit = acc;
        maxFuel = essence;
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
            limitMoteur = 0;
        }
        if (isRefuel)
        {
            essence += 10f * Time.deltaTime;
            if (essence >= maxFuel)
            {
                essence = maxFuel;
                isRefuel = false;
            }
        }

        /* Déplacement */
        if (Input.GetKeyDown(KeyCode.RightArrow) && essence > 0 && !isRefuel && !rechargeOxygene)
        {
            if(limitMoteur < maxSpeed)
            {
                limitMoteur++;
            }
            if (limitMoteur > 0)
            {
                goForward = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && essence > 0 && !isRefuel && !rechargeOxygene)
        {
            if (limitMoteur > -maxSpeed)
            {
                limitMoteur--;
            }
            if (limitMoteur < 0)
            {
                goForward = false;
            }
        }
        if (limitMoteur!=0 && essence > 0)
        {
            if(goForward == true)
            {

                essence -= 2f * Time.deltaTime;
                if (speed >= limitMoteur)
                {
                    speed -= Time.deltaTime ;
                }
                else
                {
                    speed += (acc / masse) * Time.deltaTime;
                }
            }
            else
            {

                essence -= 2f * Time.deltaTime;
                if (speed <= limitMoteur)
                {
                    speed += Time.deltaTime;
                }
                else
                {
                    speed -= (acc / masse) * Time.deltaTime;
                }
            }
        } else
        {
            if (essence <= 0)
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
            limitMoteur = 0;
        }
        if (!rechargeOxygene)
        {
            if(oxygene > 0)
            {
                oxygene -= 3 * Time.deltaTime;
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
         _rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime); //Déplacement du joueur
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

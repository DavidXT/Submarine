using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector3 mouvement;
    public float speed;
    private float acc;
    private Vector3 mouvementSubmarine;
    private float limit;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        acc = speed;
        limit = acc;
    }

    // Update is called once per frame
    void Update()
    {
        mouvement = Vector3.zero;
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");

        /* Déplacement */
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mouvementSubmarine.x = mouvement.x;
            limit += 1;
            while (acc < limit)
            {
                acc += Time.deltaTime;
            }
        }        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            limit = limit - 1;
            while (acc > limit)
            {
                acc -= Time.deltaTime;
            }
            if (acc < 0)
            {
                mouvementSubmarine.x = -mouvement.x;
            }
        }

        /*Rotation*/
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 10, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * 10, Space.World);
        }

        if(acc == 0)
        {
            mouvementSubmarine = mouvement;
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + transform.right * acc * Time.deltaTime); //Déplacement du joueur

    }
}

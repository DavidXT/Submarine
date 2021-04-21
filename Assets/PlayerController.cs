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
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        acc = speed;
    }

    // Update is called once per frame
    void Update()
    {
        mouvement = Vector3.zero;
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mouvementSubmarine.x = mouvement.x;
            acc += 1;
        }        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            acc -= 1;
            if(acc < 0)
            {
                mouvementSubmarine.x = -mouvement.x;
            }
        }        
        if(acc == 0)
        {
            mouvementSubmarine = mouvement;
        }
        
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + mouvementSubmarine * acc * Time.deltaTime); //Déplacement du joueur
    }
}

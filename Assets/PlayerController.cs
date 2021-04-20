using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector3 mouvement;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mouvement = Vector3.zero;
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (mouvement != Vector3.zero)
        {
            Move();
        }
    }

    void Move()
    {
        _rb.MovePosition(transform.position + mouvement * speed * Time.deltaTime); //D�placement du joueur
    }
}

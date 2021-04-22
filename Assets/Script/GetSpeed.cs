using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeed : MonoBehaviour
{
    public GameObject target;
    private float arrowRotation;
    PlayerController playerscript;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        playerscript = target.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = playerscript.speed;
        arrowRotation = 18 * speed;
        transform.rotation = Quaternion.Euler(0, 0, -arrowRotation); ;
    }
}

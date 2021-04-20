using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(player.transform.position, enemy.transform.position);
            if (distanceToEnemy <= range)
            {
                //Draw l'ennemy
            }
        }
    }
}

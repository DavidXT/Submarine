using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public float ratio;
    public GameObject mm_Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GenerateMinimap();
    }

    void GenerateMinimap()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] mm_ennemies = GameObject.FindGameObjectsWithTag("Minimap_Enemy");
        foreach (GameObject mm_ennemy in mm_ennemies)
        {
            Destroy(mm_ennemy);
        }

        foreach (GameObject enemy in ennemies)
        {
            Vector3 minimapPosition = new Vector3(0, 0, 0);
            float distanceToEnemy = Vector3.Distance(player.transform.position, enemy.transform.position);
            float alpha = Mathf.Atan((enemy.transform.position.x-player.transform.position.x)/(enemy.transform.position.y-player.transform.position.y));
            float newX = Mathf.Cos(alpha) * (distanceToEnemy*(1/10));
            float newY = Mathf.Sin(alpha) * (distanceToEnemy*(1/10));
            minimapPosition.x = (newX + ((1/10)*distanceToEnemy * Mathf.Cos(alpha)));
            minimapPosition.y = (newY + ((1/10)*distanceToEnemy * Mathf.Sin(alpha)));
            Instantiate(mm_Enemy, enemy.transform.position, Quaternion.identity);
        }
    }
}

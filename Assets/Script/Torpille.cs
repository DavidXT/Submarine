using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpille : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 15;

    private void Start()
    {
        Destroy(gameObject, 100);//si la balle est toujours vivantes après 100 secondes, on la détruit
    }

    public void Update()
    {
        //on la fait avancer toujours tout droit à vitesse constante
        transform.position += transform.right * Time.deltaTime * _moveSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class GetTorpille : MonoBehaviour
{
    public GameObject target;
    PlayerController playerscript;
    public Image torpilleImg1;
    public Image torpilleImg2;
    public Image torpilleImg3;
    public Image torpilleImg4;
    public Image torpilleImg5;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        playerscript = target.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        int nbTorpille = playerscript.nbTorpille;
        torpilleImg1.color = new Color32(0, 0, 0, 255);
        torpilleImg2.color = new Color32(0, 0, 0, 255);
        torpilleImg3.color = new Color32(0, 0, 0, 255);
        torpilleImg4.color = new Color32(0, 0, 0, 255);
        torpilleImg5.color = new Color32(0, 0, 0, 255);
        if (nbTorpille >= 1)
        {
            torpilleImg1.color = new Color32(72, 72, 72, 255);
        }        
        if (nbTorpille >= 2)
        {
            torpilleImg2.color = new Color32(72, 72, 72, 255);
        }        
        if (nbTorpille >= 3)
        {
            torpilleImg3.color = new Color32(72, 72, 72, 255);
        }        
        if (nbTorpille >= 4)
        {
            torpilleImg4.color = new Color32(72, 72, 72, 255);
        }        
        if (nbTorpille >= 5)
        {
            torpilleImg5.color = new Color32(72, 72, 72, 255);
        }
    }
}

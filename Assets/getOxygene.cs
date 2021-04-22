using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class getOxygene : MonoBehaviour
{
    public GameObject target;
    private float arrowRotation;
    PlayerController playerscript;
    public Image oxygeneImg;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        playerscript = target.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float FilledOxygene = playerscript.oxygene / playerscript.maxOxygene;
        oxygeneImg.fillAmount = FilledOxygene;
    }
}

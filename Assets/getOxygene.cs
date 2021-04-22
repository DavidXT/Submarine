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
    public Image alarm;
    public float ratioAlarm;
    public float compteurAlarm;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        playerscript = target.GetComponent<PlayerController>();
        compteurAlarm = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float FilledOxygene = playerscript.oxygene / playerscript.maxOxygene;
        oxygeneImg.fillAmount = FilledOxygene;
        if (playerscript.oxygene <= playerscript.maxOxygene / 10)
        {
            oxygeneImg.color = new Color32(255, 14, 0, 255);
            compteurAlarm += Time.deltaTime;
            float timerAlarm = Mathf.Sin(ratioAlarm * 2 * 3.14f * compteurAlarm);
            if (timerAlarm <= 0)
            {
                alarm.color = new Color32(0, 0, 0, 255);
            }
            else
            {
                alarm.color = new Color32(255, 14, 0, 255);
            }
        }
        else{
            oxygeneImg.color = new Color32(49, 255, 0, 255);
            alarm.color = new Color32(0, 0, 0, 255);
        }
    }
}

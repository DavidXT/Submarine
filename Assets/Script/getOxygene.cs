using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class getOxygene : MonoBehaviour
{
    public GameObject target;
    private float arrowRotation;
    PlayerController playerscript;
    public Image oxygeneImg1;
    public Image oxygeneImg2;
    public Image oxygeneImg3;
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
        if(playerscript.oxygene <= (playerscript.maxOxygene - 200))
        {
            oxygeneImg1.fillAmount = (playerscript.oxygene) / (playerscript.maxOxygene-200);
            oxygeneImg2.fillAmount = 0;
            oxygeneImg3.fillAmount = 0;
        }
        else if (playerscript.oxygene <= (playerscript.maxOxygene - 100))
        {
            oxygeneImg1.fillAmount = 1;
            oxygeneImg2.fillAmount = (playerscript.oxygene - 100) / (playerscript.maxOxygene - 200);
            oxygeneImg3.fillAmount = 0;
        }
        else
        {
            oxygeneImg1.fillAmount = 1;
            oxygeneImg2.fillAmount = 1;
            oxygeneImg3.fillAmount = (playerscript.oxygene - 200) / (playerscript.maxOxygene - 200);
        }

        if (playerscript.oxygene <= playerscript.maxOxygene / 10)
        {
            oxygeneImg1.color = new Color32(255, 14, 0, 255);
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
            compteurAlarm = 0;
            oxygeneImg1.color = new Color32(49, 255, 0, 255);
            oxygeneImg2.color = new Color32(49, 255, 0, 255);
            oxygeneImg3.color = new Color32(49, 255, 0, 255);
            alarm.color = new Color32(0, 0, 0, 255);
        }
    }
}

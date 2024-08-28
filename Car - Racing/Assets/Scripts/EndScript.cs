using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScript : MonoBehaviour
{
    public Canvas standingsUI;
    public TMP_Text OneCar;
    public TMP_Text TwoCar;
    public TMP_Text OneTime;
    public TMP_Text TwoTime;
    private float redTime;
    private float blueTime;
    public Camera podiumCam;

    // Start is called before the first frame update
    void Start()
    {
        standingsUI.enabled = false;
        podiumCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RedCarScriptBasic.RedFinished == true && CarScriptBasic.BlueFinished == true) {
            podiumCam.enabled = true;
            standingsUI.enabled = true;
            Debug.Log("yo");
            redTime = RedCarScriptBasic.ElapsedTime;
            blueTime = CarScriptBasic.ElapsedTime;

            if (redTime < blueTime)
            {
                OneCar.text = "Red";
                TwoCar.text = "Blue";
                OneTime.text = redTime.ToString();
                TwoTime.text = blueTime.ToString();
            }
            else
            {
                OneCar.text = "Blue";
                TwoCar.text = "Red";
                OneTime.text = blueTime.ToString();
                TwoTime.text = redTime.ToString();
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class TrackMenuManager : MonoBehaviour
{
    public static int Laps = 1;
    public static int track;
    public TMP_Text lapsDisplay;



    public void SelectTrack(int trackId)
    {
        track = trackId;
        SceneManager.LoadScene("Race Track");
    }

    public void SelectLaps(int button)
    {
        if (Laps >0) { 
            if (Laps ==1 && button ==-1)
            {
                button = 0;
            }
            Laps += button;
        }
        Debug.Log(Laps);
        lapsDisplay.text = Laps.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackMenuManager : MonoBehaviour
{

    public static int track;

    public void SelectTrack(int trackId)
    {
        track = trackId;
        SceneManager.LoadScene("Race Track");
    }
}

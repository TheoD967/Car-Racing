using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierManager : MonoBehaviour
{
    public List<GameObject> barriers = new List<GameObject>();

    private int[] trackOne = { 0, 1, 2, 3, 4, 5 };
    private int[] trackTwo = { 0, 1, 6, 7, 5 };
    private int[] trackThree = { 1, 6, 9, 12, 13, 14, 16, 17 };
    private int[] trackFour = { 18, 6, 7, 8, 9, 10, 11 };
    private int[] trackBarriers;

    // Start is called before the first frame update
    void Start() {
        if (TrackMenuManager.track == 0)
        {
            trackBarriers = trackOne;
        }
        if (TrackMenuManager.track == 1)
        {
            trackBarriers = trackTwo;
        }
        if (TrackMenuManager.track == 2)
        {
            trackBarriers = trackThree;
        }
        if (TrackMenuManager.track == 3)
        {
            trackBarriers = trackFour;
        }

        foreach (int item in trackBarriers)
        {
            GameObject barrier = barriers[item];
            barrier.SetActive(true);
            

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

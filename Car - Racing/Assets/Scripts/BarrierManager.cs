using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierManager : MonoBehaviour
{
    public List<GameObject> barriers = new List<GameObject>();

    private int[] trackOne = { 0, 1, 2, 3, 4, 5 };
    private int[] trackTwo = { 0, 1, 6, 7, 5 };
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

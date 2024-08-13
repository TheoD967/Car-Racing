using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Update is called once per frame
    public void Load()
    {
        Debug.Log("yo");
        SceneManager.LoadScene("Race Track");
    }
}

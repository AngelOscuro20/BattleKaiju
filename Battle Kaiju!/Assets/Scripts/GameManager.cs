using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    TimeSpan horaReal;
    public Volume volume;
    public VolumeProfile noche;
    public VolumeProfile dia;
    public VolumeProfile tarde;
    void Start()
    {
        horaReal = DateTime.Now.TimeOfDay;
        print(horaReal);
        if (7 <= horaReal.Hours && horaReal.Hours < 16)
        {
            volume.profile = dia;
        }
        else if (16 <= horaReal.Hours && horaReal.Hours < 20)
        {
            volume.profile = tarde;
        }
        else 
        {
            volume.profile = noche;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }


    //Para pasar de una escena a otra 
    public float interLevelWaitTime = 3f;
    public void GoToNextScene(float waitTime = -1)
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("YOU WIN!");
        }
        else
        {
            Debug.Log("Prepare for next scene!");
            StartCoroutine(WaitAndLoadNextScene(waitTime));
        }
    }

    private IEnumerator WaitAndLoadNextScene(float waitSeconds)
    {
        if (waitSeconds < 0)
        {
            waitSeconds = interLevelWaitTime;
        }
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}

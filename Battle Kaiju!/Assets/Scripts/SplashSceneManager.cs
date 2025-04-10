using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSceneManager : MonoBehaviour
{
   // public AudioClip splashTheme;
    public float waitTime = 10f;
    private float startedAt;
    private bool hasMoveOn = false;

    private void Start()
    {
     //   if (splashTheme != null) GameManager.Instance.audioManager.PlayMusic(splashTheme);
        startedAt = Time.time;
    }
    void Update()
    {
        if (hasMoveOn) return;
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) ||
        Time.time - startedAt > waitTime)
        {
            Done();
        }
    }
    private void Done()
    {
        hasMoveOn = true;
        GameManager.Instance.GoToNextScene(0);
        Destroy(gameObject); // para evitar que se ejecute más de una vez
    }
}

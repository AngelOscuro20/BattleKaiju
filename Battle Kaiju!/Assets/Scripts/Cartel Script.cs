using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartelScript : MonoBehaviour
{
    public bool paused = false;
    private void OnMouseDown()
    {
        if (!paused)
        {
            SceneManager.LoadScene("SelectorNivel");
        }
    }
}

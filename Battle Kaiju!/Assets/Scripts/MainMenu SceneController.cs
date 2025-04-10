using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneController : MonoBehaviour
{
    public GameObject nombre1;
    public GameObject nombre2;
    public GameObject nombre3;
    public Animator animatorcreditos;

    private void Start()
    {
        nombre1.SetActive(false);
        nombre2.SetActive(false);
        nombre3.SetActive(false);  
    }
    public void Quit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void IniciarPartida() { GameManager.Instance.GoToNextScene(0); }

    public void Creditos() {
        nombre1.SetActive(true);
        nombre2.SetActive(true);
        nombre3.SetActive(true);
        animatorcreditos.Play("PopInCreditos"); 
    }
}

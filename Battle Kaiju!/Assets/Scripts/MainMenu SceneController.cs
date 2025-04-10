using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void IniciarPartida() {
        Destroy(GameObject.FindGameObjectWithTag("musica"));
        GameManager.Instance.GoToNextScene(0); 
    }

    public void Creditos() {
        SceneManager.LoadScene("CreditosScene");
    }
}

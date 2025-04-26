using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneController : MonoBehaviour
{
  

    private void Start()
    {
        
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

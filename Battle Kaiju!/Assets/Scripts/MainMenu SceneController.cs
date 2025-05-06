using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneController : MonoBehaviour
{

    public TMP_Text boton;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().intro) { boton.text = "Continuar"; }
    }
    public void Quit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void IniciarPartida() {
        Destroy(GameObject.FindGameObjectWithTag("musica"));

        if (!GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().intro)
        {
            SceneManager.LoadScene("intro");
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().intro = true;
        }
        else
        {
            SceneManager.LoadScene("CareScene");
        }
    }

    public void Creditos() {
        SceneManager.LoadScene("CreditosScene");
    }
}

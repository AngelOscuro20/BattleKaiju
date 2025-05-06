using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartelScript : MonoBehaviour
{
    public bool paused = false;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    public void Update()
    {
        if (gameManager.GetComponent<GameManager>().ultimoNivelCompletado > 15) { 
            this.GetComponent<SpriteRenderer>().sprite = Sprite2;
            this.GetComponent<EdificioInfo>().Nombre = "Trofeo";
            this.GetComponent<EdificioInfo>().descripcion = "Enhorabuena! Eres el campeón de la isla kaiju! Pulsa aqui si quieres volver a pelear en algún nivel.";
        }
    }
    private void OnMouseDown()
    {
        if (!paused)
        {
            SceneManager.LoadScene("SelectorNivel");
        }
    }
}

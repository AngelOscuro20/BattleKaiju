using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotiquinScript : MonoBehaviour
{
    public Sprite Sprite1;
    public Sprite Sprite2;
    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    private void Update()
    {
        if (gameManager.GetComponent<GameManager>().ultimoNivelCompletado > 0) { 
            this.GetComponent<SpriteRenderer>().sprite = Sprite2;
            this.GetComponent<EdificioInfo>().Nombre = "Botiquin";
            this.GetComponent<EdificioInfo>().descripcion = "Si tu kaiju está herido, pulsa aqui para curarlo. Deberias cuidar mejor de él, si es herido muchas veces podría morir";
        }
    }
    private void OnMouseDown()
    {
        if (gameManager.GetComponent<GameManager>().ultimoNivelCompletado > 2) { CareManager.Instance.Heal(); }
    }
}

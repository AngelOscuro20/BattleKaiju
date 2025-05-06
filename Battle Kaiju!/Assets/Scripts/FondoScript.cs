using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoScript : MonoBehaviour
{

    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManager.GetComponent<GameManager>().nivelSeleccionado >5) { this.GetComponent<SpriteRenderer>().sprite = Sprite2; }
        if (gameManager.GetComponent<GameManager>().nivelSeleccionado >10) { this.GetComponent<SpriteRenderer>().sprite = Sprite3; }
    }
}

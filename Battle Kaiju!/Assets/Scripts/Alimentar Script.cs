using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentarScript : MonoBehaviour
{
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    private void Update()
    {
        if (gameManager.GetComponent<GameManager>().ultimoNivelCompletado > 3) { this.GetComponent<SpriteRenderer>().sprite = Sprite2; }
        if (gameManager.GetComponent<GameManager>().ultimoNivelCompletado > 7) { this.GetComponent<SpriteRenderer>().sprite = Sprite3; }
    }
    private void OnMouseDown()
    {
        CareManager.Instance.Eat();
    }
}

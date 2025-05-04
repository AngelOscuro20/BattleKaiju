using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LupaScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 mousePosition;
    private Vector2 dragOffset;
    public GameObject panelInfo;
    public TMP_Text Titulo;
    public Image Imagen;
    public Sprite ofensivo;
    public Sprite defensivo;
    public Sprite evasivo;
    public Image tipo;
    public TMP_Text estadioTexto;
    public TMP_Text tipotexto;
    public TMP_Text VidaTexto;
    public TMP_Text AtaqueTexto;
    public TMP_Text DefensaTexto;
    public TMP_Text VelocidadTexto;
    private void OnMouseDown()
    {
        dragOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition - dragOffset;
    }

    private void OnMouseUp()
    {
        transform.position = new Vector2(5f, 3f);
        panelInfo.transform.position = new Vector2(1000f, 1000f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        print("Prueba");
        if (!other.CompareTag("barrera"))
        {
            if (other.CompareTag("kaiju"))
            {
                print(other.gameObject.GetComponent<Stats>().ID);
                print(other.gameObject.GetComponent<Stats>().Nombre);
                Titulo.text = other.gameObject.GetComponent<Stats>().Nombre;
                Imagen.sprite = other.gameObject.GetComponent<SpriteRenderer>().sprite;
                print(other.gameObject.GetComponent<Stats>().estadioEvolutivo);
                estadioTexto.text = other.gameObject.GetComponent<Stats>().estadioEvolutivo;
                VidaTexto.text = "Vida: " + other.gameObject.GetComponent<Stats>().HP.ToString();
                AtaqueTexto.text = "Ataque: " + other.gameObject.GetComponent<Stats>().attack.ToString();
                DefensaTexto.text = "Defensa: " + other.gameObject.GetComponent<Stats>().Defense.ToString();
                VelocidadTexto.text = "Velocidad: " + other.gameObject.GetComponent<Stats>().speed.ToString();
                switch (other.gameObject.GetComponent<Stats>().tipo)
                
                {
                    //ofensivo
                    case 1:
                        tipo.sprite = ofensivo;
                        tipotexto.text = "Ofensivo";
                        ;break;
                    //Defensivo
                    case 2:
                        tipo.sprite = defensivo;
                        tipotexto.text = "Defensivo";
                        ; break;
                    //Evasivo
                    case 3:
                        tipo.sprite = evasivo;
                        tipotexto.text = "Evasivo";
                        ;break;
                    default:;break;
                }
                panelInfo.transform.position = transform.position + new Vector3(0,0,-3);
            }
            string nombre = other.gameObject.name;
            print(nombre);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panelInfo.transform.position = new Vector2(1000f, 1000f);
    }
}

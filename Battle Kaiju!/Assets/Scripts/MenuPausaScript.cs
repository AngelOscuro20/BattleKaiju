using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuPausaScript : MonoBehaviour
{
    public GameObject menupausa;
    public AudioSource audio;
    public Animator animator;
    public Sprite newImage;
    public Sprite oldImage;
    public Button botonsonido;
    public GameObject careManager;
    public GameObject cartel;
    public GameObject lupa;
  

    bool musica = true;
    // Start is called before the first frame update
    void Start()
    {
        menupausa.SetActive(false);
        animator = this.GetComponent<Animator>();
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { ReanudarJuego(); }
    }
    public void botonAudio() 
    {
        if (musica) 
        { 
            audio.volume = 0;
            musica = false;
            changeButton();


        }
        else
        {
            audio.volume = 0.5f;
            musica = true;
            changeButton();
        }
    
    }

    public void botonMenuPrincipal() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Portada");
        
    }

    public void PausarJuego() 
    {
        StartCoroutine(Wait(false));
    }

    public void ReanudarJuego() 
    {
        
        StartCoroutine(Wait(true));
        
    }

    IEnumerator Wait(bool tipo) 

    {
        if (tipo) 
        {
            Time.timeScale = 1;
            animator.Play("Volver");
            yield return new WaitForSeconds(1);
            Time.timeScale = 1;
            menupausa.SetActive(false);
            Time.timeScale = 1;
            careManager.GetComponent<CareManager>().paused = false;
            cartel.GetComponent<CartelScript>().paused = false;
            lupa.GetComponent<LupaScript>().paused = false;
        } else 
        {
            menupausa.SetActive(true);
            animator.Play("Entrada");
            yield return new WaitForSeconds(1);
            Time.timeScale = 0;
            careManager.GetComponent<CareManager>().paused = true;
            cartel.GetComponent<CartelScript>().paused = true;
            lupa.GetComponent<LupaScript>().paused = true;
        }

        
    }

    public void changeButton() {
        if (botonsonido.image.sprite == newImage) { botonsonido.image.sprite = oldImage; }
        else  { botonsonido.image.sprite = newImage; }



    }
}

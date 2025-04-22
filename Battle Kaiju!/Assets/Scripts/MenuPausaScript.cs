using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausaScript : MonoBehaviour
{
    public GameObject menupausa;
    public AudioSource audio;
    public Animator animator;
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
        }
        else
        {
            audio.volume = 0.5f;
            musica = true;
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
        } else 
        {
            menupausa.SetActive(true);
            animator.Play("Entrada");
            yield return new WaitForSeconds(1);
            Time.timeScale = 0;
        }
        
    }
}

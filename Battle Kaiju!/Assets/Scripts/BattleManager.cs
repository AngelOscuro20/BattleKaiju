using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : Singleton<BattleManager>
{
    double bonfTipoKaiju = 1.5;
    double bonfTipoAtaque = 1.5;
    double pentTipoKaiju = 0.5;
    double pentTipoAtaque = 0.5;
    int tipoAtaqueSeleccionadoJugador;
    int tipoAtaqueSeleccionadoEnemigo;
    bool ready;
    int turn;
    int vidaActualJugador;
    int vidaActualEnemigo;

    public GameObject gameManager;
    public GameObject kaiju1;
    public GameObject kaiju2;
    public GameObject kaiju3;
    public GameObject kaiju4;
    public GameObject kaiju5;
    public GameObject kaiju6;
    public GameObject kaiju7;
    public GameObject kaiju8;
    public GameObject kaiju9;
    public GameObject kaiju10;
    public GameObject kaiju11;
    public GameObject kaiju12;
    public GameObject kaiju13;

    public GameObject kaijuJugador;

    public GameObject kaijuEnemigoActual;
    public GameObject kaijuEnemigo1;
    public GameObject kaijuEnemigo2;
    public GameObject kaijuEnemigo3;

    public Stats kaijuJugadorStats;
    public Stats kaijuEnemigoStats;

    public Animator animatorKaijuJugador;
    public Animator animatorKaijuEnemigo;

    public RectTransform rectTransformVidaFondo;
    public RectTransform rectTransformVidaMarco;
    public RectTransform rectTransformVidaFondoEnemigo;
    public RectTransform rectTransformVidaMarcoEnemigo;
    int ronda = 1;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        GameObject.FindGameObjectWithTag("CareManager").GetComponent<CareManager>().enabled = false;
        kaijuJugador = GameObject.FindGameObjectWithTag("kaiju");
        animatorKaijuJugador = kaijuJugador.GetComponent<Animator>();
        kaijuJugadorStats = kaijuJugador.GetComponent<Stats>();
        vidaActualJugador =  kaijuJugadorStats.HP;

        switch (gameManager.GetComponent<GameManager>().nivelSeleccionado)
        {
            case 1: kaijuEnemigo1 = Instantiate(kaiju1); kaijuEnemigo2 = Instantiate(kaiju1); kaijuEnemigo3 = Instantiate(kaiju2); ;break;
            case 2: kaijuEnemigo1 = Instantiate(kaiju1); kaijuEnemigo2 = Instantiate(kaiju2); kaijuEnemigo3 = Instantiate(kaiju3); ; break;
            case 3: kaijuEnemigo1 = Instantiate(kaiju3); kaijuEnemigo2 = Instantiate(kaiju2); kaijuEnemigo3 = Instantiate(kaiju6); ; break;
            case 4: kaijuEnemigo1 = Instantiate(kaiju3); kaijuEnemigo2 = Instantiate(kaiju6); kaijuEnemigo3 = Instantiate(kaiju7); ; break;
            case 5: kaijuEnemigo1 = Instantiate(kaiju2); kaijuEnemigo2 = Instantiate(kaiju7); kaijuEnemigo3 = Instantiate(kaiju4); ; break;
            case 6: kaijuEnemigo1 = Instantiate(kaiju6); kaijuEnemigo2 = Instantiate(kaiju6); kaijuEnemigo3 = Instantiate(kaiju6); ; break;
            case 7: kaijuEnemigo1 = Instantiate(kaiju3); kaijuEnemigo2 = Instantiate(kaiju7); kaijuEnemigo3 = Instantiate(kaiju8); ; break;
            case 8: kaijuEnemigo1 = Instantiate(kaiju5); kaijuEnemigo2 = Instantiate(kaiju4); kaijuEnemigo3 = Instantiate(kaiju7); ; break;
            case 9: kaijuEnemigo1 = Instantiate(kaiju6); kaijuEnemigo2 = Instantiate(kaiju7); kaijuEnemigo3 = Instantiate(kaiju8); ; break;
            case 10: kaijuEnemigo1 = Instantiate(kaiju4); kaijuEnemigo2 = Instantiate(kaiju5); kaijuEnemigo3 = Instantiate(kaiju8); ; break;
            case 11: kaijuEnemigo1 = Instantiate(kaiju5); kaijuEnemigo2 = Instantiate(kaiju8); kaijuEnemigo3 = Instantiate(kaiju11); ; break;
            case 12: kaijuEnemigo1 = Instantiate(kaiju4); kaijuEnemigo2 = Instantiate(kaiju7); kaijuEnemigo3 = Instantiate(kaiju9); ; break;
            case 13: kaijuEnemigo1 = Instantiate(kaiju4); kaijuEnemigo2 = Instantiate(kaiju11); kaijuEnemigo3 = Instantiate(kaiju13); ; break;
            case 14: kaijuEnemigo1 = Instantiate(kaiju8); kaijuEnemigo2 = Instantiate(kaiju9); kaijuEnemigo3 = Instantiate(kaiju12); ; break;
            case 15: kaijuEnemigo1 = Instantiate(kaiju13); kaijuEnemigo2 = Instantiate(kaiju12); kaijuEnemigo3 = Instantiate(kaiju10); ; break;
            default: kaijuEnemigo1 = Instantiate(kaiju1); kaijuEnemigo2 = Instantiate(kaiju1); kaijuEnemigo3 = Instantiate(kaiju2); ; break;
        }

        kaijuEnemigo1.transform.position = new Vector2(5, -0.5f);
        kaijuEnemigo2.transform.position = new Vector2(5, -0.5f);
        kaijuEnemigo3.transform.position = new Vector2(5, -0.5f);
        kaijuEnemigo1.GetComponent<Movement>().enabled = false;
        kaijuEnemigo2.GetComponent<Movement>().enabled = false;
        kaijuEnemigo3.GetComponent<Movement>().enabled = false;
        kaijuEnemigo1.GetComponent<ParticleSystem>().Stop();
        

        kaijuEnemigoActual = kaijuEnemigo1;
        kaijuEnemigoStats = kaijuEnemigoActual.GetComponent<Stats>();
        animatorKaijuEnemigo = kaijuEnemigoActual.GetComponent<Animator>();
        vidaActualEnemigo = kaijuEnemigoStats.HP;

        kaijuJugador.GetComponent<Movement>().enabled = false;
        kaijuJugador.transform.position = new Vector3(-5f,-0.5f,-1f);
        kaijuJugador.GetComponent<SpriteRenderer>().flipX = true;
        kaijuJugador.GetComponent<ParticleSystem>().Stop();

        rectTransformVidaMarco = GameObject.FindGameObjectWithTag("VidaMarco").GetComponent<RectTransform>();
        rectTransformVidaFondo = GameObject.FindGameObjectWithTag("VidaFondo").GetComponent<RectTransform>();
        rectTransformVidaMarcoEnemigo = GameObject.FindGameObjectWithTag("VidaMarcoEnemigo").GetComponent<RectTransform>();
        rectTransformVidaFondoEnemigo = GameObject.FindGameObjectWithTag("VidaFondoEnemigo").GetComponent<RectTransform>();

        rectTransformVidaMarco.sizeDelta = new Vector2(vidaActualJugador*2, 25);
        rectTransformVidaFondo.sizeDelta = new Vector2(vidaActualJugador*2, 25);
        rectTransformVidaMarcoEnemigo.sizeDelta = new Vector2(vidaActualEnemigo * 2, 25);
        rectTransformVidaFondoEnemigo.sizeDelta = new Vector2(vidaActualEnemigo * 2, 25);

        kaijuEnemigoActual = kaijuEnemigo1;
        
        kaijuEnemigo2.SetActive(false);
        kaijuEnemigo3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ready) CalcularDanyos();
    }

    public void AtaqueJugador(int tipoAtaque) 
    {
        tipoAtaqueSeleccionadoJugador = tipoAtaque;
        Debug.Log("Tipo ataque jugador " + tipoAtaqueSeleccionadoJugador);
        ataqueEnemigo();
    }

    //objetiva hace referencia a true = enemigo, false = jugador
    public void restarVida(double danyoJugador, double danyoEnemigo) {
        
            vidaActualEnemigo = vidaActualEnemigo - (int)danyoJugador;
            vidaActualJugador = vidaActualJugador - (int)danyoEnemigo;
        if(vidaActualEnemigo<0) {vidaActualEnemigo = 0; ronda++; cambiarKaijuEnemigo();}
        if(vidaActualJugador<0) {vidaActualJugador = 0; peleaPerdida();} 
        rectTransformVidaFondo.sizeDelta = new Vector2(vidaActualJugador*2, 25);
        rectTransformVidaFondoEnemigo.sizeDelta = new Vector2(vidaActualEnemigo * 2, 25);
    }

    public void ataqueEnemigo()
    {
        tipoAtaqueSeleccionadoEnemigo = Random.Range(1, 4);
        Debug.Log("Tipo ataque enemigo " + tipoAtaqueSeleccionadoEnemigo);

        ready = true;
    }

    public void CalcularDanyos()
    {
        
        ready = false;
        double danyoJugador = 0;
        double danyoEnemigo = 0;
        if (tipoAtaqueSeleccionadoJugador != 4)
        {
            switch (tipoAtaqueSeleccionadoJugador)
            {

                //ofensivo
                case 1:

                    danyoJugador = kaijuJugadorStats.attack;
                    Debug.Log("Daño jugador =" + danyoJugador);
                    //Bonificadores tipo kaiju

                    if (kaijuEnemigoStats.tipo == 1)
                    {
                        danyoEnemigo = kaijuEnemigoStats.attack;
                        Debug.Log("Ataque Neutro en kaiju");
                    }
                    else if (kaijuEnemigoStats.tipo == 2)
                    {
                        danyoEnemigo = kaijuEnemigoStats.Defense;
                        danyoJugador *= pentTipoKaiju;
                        Debug.Log("Ataque Debil en kaiju");
                    }
                    else
                    {
                        danyoEnemigo = kaijuEnemigoStats.speed;
                        danyoJugador *= bonfTipoKaiju;
                        Debug.Log("Ataque Fuerte en kaiju");
                    }

                    //Bonificadores tipo ataque
                    if (tipoAtaqueSeleccionadoEnemigo == 2) { danyoJugador *= pentTipoAtaque; danyoEnemigo *= bonfTipoAtaque; Debug.Log("Enemigo gana"); }
                    else if (tipoAtaqueSeleccionadoEnemigo == 3) { danyoJugador *= bonfTipoAtaque; danyoEnemigo *= pentTipoAtaque; Debug.Log("Jugador gana"); }
                    ; break;
                //defensivo
                case 2:

                    danyoJugador = kaijuJugadorStats.Defense;
                    Debug.Log("Daño jugador =" + danyoJugador);
                    //Bonificadores tipo kaiju

                    if (kaijuEnemigoStats.tipo == 1)
                    {
                        danyoEnemigo = kaijuEnemigoStats.attack;
                        danyoJugador *= bonfTipoKaiju;
                        Debug.Log("Ataque Fuerte en kaiju");
                    }
                    else if (kaijuEnemigoStats.tipo == 2)
                    {
                        danyoEnemigo = kaijuEnemigoStats.Defense;
                        Debug.Log("Ataque Neutro en kaiju");
                    }
                    else
                    {
                        danyoEnemigo = kaijuEnemigoStats.speed;
                        danyoJugador *= pentTipoKaiju;
                        Debug.Log("Ataque Debil en kaiju");

                    }

                    //Bonificadores tipo ataque
                    if (tipoAtaqueSeleccionadoEnemigo == 3) { danyoJugador *= pentTipoAtaque; danyoEnemigo *= bonfTipoAtaque;
                        Debug.Log("Enemigo gana");
                    }
                    else if (tipoAtaqueSeleccionadoEnemigo == 1) { danyoJugador *= bonfTipoAtaque; danyoEnemigo *= pentTipoAtaque; Debug.Log("Jugador gana"); }
                    ; break;
                //evasivo
                case 3:
                    danyoJugador = kaijuJugadorStats.speed;
                    Debug.Log("Daño jugador =" + danyoJugador);
                    //Bonificadores tipo kaiju

                    if (kaijuEnemigoStats.tipo == 1)
                    {
                        danyoEnemigo = kaijuEnemigoStats.attack;
                        danyoJugador *= pentTipoKaiju;
                        Debug.Log("Ataque Debil en kaiju");
                    }
                    else if (kaijuEnemigoStats.tipo == 2)
                    {
                        danyoEnemigo = kaijuEnemigoStats.Defense;
                        danyoJugador *= bonfTipoKaiju;
                        Debug.Log("Ataque Fuerte en kaiju");
                    }
                    else
                    {
                        danyoEnemigo = kaijuEnemigoStats.speed;
                        Debug.Log("Ataque Neutro en kaiju");
                    }

                    //Bonificadores tipo ataque
                    if (tipoAtaqueSeleccionadoEnemigo == 1) { danyoJugador *= pentTipoAtaque; danyoEnemigo *= bonfTipoAtaque; Debug.Log("Enemigo gana"); }
                    else if (tipoAtaqueSeleccionadoEnemigo == 2) { danyoJugador *= bonfTipoAtaque; danyoEnemigo *= pentTipoAtaque; Debug.Log("Jugador gana"); }
                    ; break;

                default:; break;




            }
        }
        else 
        { 
            danyoJugador = kaijuJugadorStats.attack * 2;
            danyoEnemigo = 0;
        }
        StartCoroutine(AnimAtaque(danyoJugador,danyoEnemigo));
        
    }

    void cambiarKaijuEnemigo() 
    {
        
        kaijuEnemigoActual.SetActive(false);
        kaijuEnemigoActual = null;
        switch (ronda) {

            case 2:kaijuEnemigo2.SetActive(true); kaijuEnemigo2.GetComponent<ParticleSystem>().Stop(); kaijuEnemigoActual = kaijuEnemigo2;break;
            case 3: kaijuEnemigo3.SetActive(true); kaijuEnemigo3.GetComponent<ParticleSystem>().Stop(); kaijuEnemigoActual = kaijuEnemigo3;break;
            case 4: peleaGanada();break;
            default:break;
        }

        kaijuEnemigoStats = kaijuEnemigoActual.GetComponent<Stats>();
        animatorKaijuEnemigo = kaijuEnemigoActual.GetComponent<Animator>();
        vidaActualEnemigo = kaijuEnemigoStats.HP;

        rectTransformVidaMarcoEnemigo = GameObject.FindGameObjectWithTag("VidaMarcoEnemigo").GetComponent<RectTransform>();
        rectTransformVidaFondoEnemigo = GameObject.FindGameObjectWithTag("VidaFondoEnemigo").GetComponent<RectTransform>();

        rectTransformVidaMarcoEnemigo.sizeDelta = new Vector2(vidaActualEnemigo * 2, 25);
        rectTransformVidaFondoEnemigo.sizeDelta = new Vector2(vidaActualEnemigo * 2, 25);

    }
    void peleaPerdida() {
        Debug.Log("cambiando de escena");
        StartCoroutine(VolverACrianza());
    }

    void peleaGanada()
    {
        if(gameManager.GetComponent<GameManager>().nivelSeleccionado == gameManager.GetComponent<GameManager>().ultimoNivelCompletado + 1) 
        {
            gameManager.GetComponent<GameManager>().ultimoNivelCompletado++;
        }
        gameManager.GetComponent<GameManager>().nivelSeleccionado = 0;
        StartCoroutine(VolverACrianza());
    }

    public IEnumerator VolverACrianza() {
        yield return new WaitForSeconds(2);
        Destroy(kaijuEnemigo1);
        Destroy(kaijuEnemigo2);
        Destroy(kaijuEnemigo3);
        kaijuJugador.GetComponent<Movement>().enabled = false;
        GameObject.FindGameObjectWithTag("CareManager").GetComponent<CareManager>().enabled = true;
        kaijuJugador.transform.position = new Vector3(0, 0, -1);
        SceneManager.LoadScene("CareScene");

        Destroy(this.gameObject);
    }

    public IEnumerator AnimAtaque(double danyoJugador,double danyoEnemigo)
    {
        animatorKaijuJugador.Play("Atacar");
        yield return new WaitForSeconds(1);
        kaijuJugador.transform.position = kaijuJugador.transform.position +  new Vector3(2,0,0);
        yield return new WaitForSeconds(1);
        kaijuJugador.transform.position = kaijuJugador.transform.position + new Vector3(-2,0, 0);
        animatorKaijuEnemigo.Play("Atacar");
        yield return new WaitForSeconds(1);
        kaijuEnemigoActual.transform.position = kaijuEnemigoActual.transform.position + new Vector3(-2,0, 0);
        yield return new WaitForSeconds(1);
        kaijuEnemigoActual.transform.position = kaijuEnemigoActual.transform.position + new Vector3(2,0,0);
        Debug.Log("Daño jugador =" + danyoJugador);
        Debug.Log("Daño enemigo =" + danyoEnemigo);
        restarVida(danyoJugador, danyoEnemigo);
        Debug.Log("Vida Jugador = " + vidaActualJugador);
        Debug.Log("Vida Enemigo = " + vidaActualEnemigo);
    }
}

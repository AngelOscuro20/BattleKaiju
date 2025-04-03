using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject kaijuJugador;

    public GameObject kaijuEnemigoActual;
    public GameObject kaijuEnemigo1;
    public GameObject kaijuEnemigo2;
    public GameObject kaijuEnemigo3;

    public Stats kaijuJugadorStats;
    public Stats kaijuEnemigoStats;

    public Animator animatorKaijuJugador;
    public Animator animatorKaijuEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        
        animatorKaijuJugador = kaijuJugador.GetComponent<Animator>();
        kaijuJugadorStats = kaijuJugador.GetComponent<Stats>();
        vidaActualJugador =  kaijuJugadorStats.HP;

        kaijuEnemigoStats = kaijuEnemigoActual.GetComponent<Stats>();
        animatorKaijuEnemigo = kaijuEnemigoActual.GetComponent<Animator>();
        vidaActualEnemigo = kaijuEnemigoStats.HP;
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
        Debug.Log("Daño jugador =" + danyoJugador);
        Debug.Log("Daño enemigo =" + danyoEnemigo);
        restarVida(danyoJugador, danyoEnemigo);
        Debug.Log("Vida Jugador = " + vidaActualJugador);
        Debug.Log("Vida Enemigo = " + vidaActualEnemigo);
    }
}

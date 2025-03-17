using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float timer = 0;
    float callTime;
    int careMistakes = 0;
    int stage;
    int hungerMeter = 5;
    int trainingMeter = 5;
    bool callingHunger = false;
    bool callingTraining = false;
    float evoTime;
    int IDKaiju;
    bool triedEvolving = false; 
    public static GameManager instance;
    GameObject kaijuActual;
    public GameObject kaiju2;
    public GameObject kaiju3;
    public GameObject kaiju4;
    public GameObject kaiju5;
    public GameObject kaiju6;
    public GameObject kaiju7;
    public GameObject kaiju8;
    private void Awake()
    {
        // Configuración del Singleton para asegurar una única instancia
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persistir entre escenas
        }
        else
        {
            Destroy(gameObject); // Destruir duplicados
            return;
        }
    }
    void Start()
    {
        //Buscamos el kaiju actual, su id y su tiempo de evolución
        kaijuActual = GameObject.FindGameObjectWithTag("kaiju");
        IDKaiju = kaijuActual.GetComponent<Stats>().ID;
        evoTime = kaijuActual.GetComponent<Stats>().evolutiontime;
        Debug.Log("ID actual =" + IDKaiju);
        Debug.Log("Evolution timer = " + evoTime);
        Debug.Log("Hambre actual: " + hungerMeter);
        Debug.Log("Care Mistakes: " + careMistakes);

        //Iniciamos las rutina de hambre y entrenamiento
        InvokeRepeating("HungerDrop", 5, 5);
        InvokeRepeating("TrainingDrop", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) { careMistakes++; Debug.Log("Care Mistakes: " + careMistakes); }
        timer += Time.deltaTime;
        //Debug.Log(timer);

        //Si se está llamando a un care mistake, se comprueba el contador
        if (callingHunger || callingTraining) { CheckCareMistake(); }

        //Si el timer es mayor que el evolution timer,se llama al metodo de evolucion
        if (timer > evoTime && !triedEvolving) {evolution(); }
    }

    void HungerDrop()
    {
        if (!callingHunger)
        {
            //Si el hambre es mayor que cero, se reduce
            if (hungerMeter > 0)
            {
                hungerMeter--;
                Debug.Log("Hambre actual: " + hungerMeter);
            }
            //Si el hambre es cero, se realiza una call
            else
            {
                hungerMeter = 0;
                Call(0);
            }
        }
    }

    void TrainingDrop()
    {
        if (!callingTraining)
        {
            //Si el entrenamiento es mayor que cero, se reduce
            if (trainingMeter > 0)
            {
                trainingMeter--;
                Debug.Log("Training actual: " + trainingMeter);
            }
            //Si el entrenamiento es cero, se realiza una call
            else
            {
                trainingMeter = 0;
                Call(1);
            }
        }
    }
    //tipo hace referencia a el tipo de call, es un por si acaso a futuro.
    void Call(int tipo) {
        
        //Play sound
        switch (tipo)
        {
            //Hambre
            case 0:
                Debug.Log("Calling Hunger");
                callTime = timer;
                callingHunger = true;
            break;
            //Entrenamiento
            case 1: Debug.Log("Calling Training");
                callTime = timer;
                callingTraining = true;
                break;
            default: break;
        }
    
    }

    void CheckCareMistake() {

        //Si el han pasado X segundos desde que se registró la llamada, se suma uno o dos cares mistakes
        if (callTime + 30 < timer) {
            if (callingHunger && callingTraining) { careMistakes += 2; }
            else { careMistakes++; }
            Debug.Log("Care Mistakes: " + careMistakes);
            if (callingHunger) { callingHunger = false; }
            if (callingTraining) { callingTraining = false; }
        }
    }

    public void Eat() 
    {
        hungerMeter++;
        if (hungerMeter > 5) { hungerMeter = 5; }
        Debug.Log("Hambre actual: " + hungerMeter);
        if (callingHunger) { callingHunger = false; }
    }

    public void Train()
    {
        trainingMeter++;
        if (trainingMeter > 5) { trainingMeter = 5; }
        Debug.Log("Barra de entrenamiento: " + trainingMeter);
        if (callingTraining) { callingTraining = false; }
    }

    void evolution() {
        Debug.Log("Llamando a Evolucion");
        GameObject kaijuNuevo = null;
        //primero se comprueba la ID del kaiju
        switch (IDKaiju) {
            //borosu 
            case 1:
               
                if (careMistakes < 3) {
                    kaijuNuevo = Instantiate<GameObject>(kaiju2);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                    
                }
                else {
                    kaijuNuevo = Instantiate<GameObject>(kaiju3);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                }
                
            ;break;

            //hamuso
            case 2:
                if (careMistakes < 1)
                {
                    kaijuNuevo = Instantiate<GameObject>(kaiju4);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                }
                else if (careMistakes < 4)
                {
                    kaijuNuevo = Instantiate<GameObject>(kaiju5);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                }
                else 
                {
                    kaijuNuevo = Instantiate<GameObject>(kaiju6);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                }
            ;break;

            //lombriso
            case 3:
                if (careMistakes < 1)
                {
                    kaijuNuevo = Instantiate<GameObject>(kaiju8);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                }
                else if (careMistakes < 4)
                {
                    kaijuNuevo = Instantiate<GameObject>(kaiju7);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                }
                else
                {
                    kaijuNuevo = Instantiate<GameObject>(kaiju6);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                }
            ;break;
            //samuiso
            // Esto es para no tener que escribir las dos lineas siguientes en cada caso del switch.
            default:;break; 
        }
        if (kaijuNuevo != null)
        {
            Destroy(kaijuActual);
            kaijuActual = kaijuNuevo;
            IDKaiju = kaijuActual.GetComponent<Stats>().ID;
            evoTime = kaijuActual.GetComponent<Stats>().evolutiontime;
            careMistakes = 0;
        }
        else { triedEvolving = true; }

        Debug.Log("Care Mistakes: " + careMistakes);
        Debug.Log("ID actual =" + IDKaiju);
        Debug.Log("Evolution timer = " + evoTime);
    }
}

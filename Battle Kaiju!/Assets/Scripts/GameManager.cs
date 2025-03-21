using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    float timer = 0;
    float callTime;
    int careMistakes = 0;
    int stage;
    int hungerMeter = 5;
    int trainingMeter = 5;
    bool callingHunger = false;
    bool callingTraining = false;
    float evoTime =100000;
    int IDKaiju;
    bool triedEvolving = false; 
  
    GameObject kaijuActual;
    Animator animatorKaiju;
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
    GameObject callCircle;
    
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //Buscamos el kaiju actual, su id y su tiempo de evolución
        kaijuActual = GameObject.FindGameObjectWithTag("kaiju");
        callCircle = GameObject.Find("CircleCall");
        animatorKaiju = kaijuActual.GetComponentInChildren<Animator>();
        IDKaiju = kaijuActual.GetComponent<Stats>().ID;
        evoTime = kaijuActual.GetComponent<Stats>().evolutiontime;
        Debug.Log("ID actual =" + IDKaiju);
        Debug.Log("Evolution timer = " + evoTime);
        Debug.Log("Hambre actual: " + hungerMeter);
        Debug.Log("Care Mistakes: " + careMistakes);

        //Iniciamos las rutina de hambre y entrenamiento
        InvokeRepeating("HungerDrop", 5, 5);
        InvokeRepeating("TrainingDrop", 5, 5);

        callCircle.SetActive(false);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {

        //Buscamos el kaiju actual, su id y su tiempo de evolución
        kaijuActual = GameObject.FindGameObjectWithTag("kaiju");
        callCircle = GameObject.Find("CircleCall");
        animatorKaiju = kaijuActual.GetComponentInChildren<Animator>();
        IDKaiju = kaijuActual.GetComponent<Stats>().ID;
        evoTime = kaijuActual.GetComponent<Stats>().evolutiontime;
        Debug.Log("ID actual =" + IDKaiju);
        Debug.Log("Evolution timer = " + evoTime);
        Debug.Log("Hambre actual: " + hungerMeter);
        Debug.Log("Care Mistakes: " + careMistakes);

        //Iniciamos las rutina de hambre y entrenamiento
        InvokeRepeating("HungerDrop", 5, 5);
        InvokeRepeating("TrainingDrop", 5, 5);

        callCircle.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) { careMistakes++; Debug.Log("Care Mistakes: " + careMistakes); }
        if (Input.GetKeyDown(KeyCode.T)) { timer+= 10; Debug.Log("Timer: " + timer); }
        timer += Time.deltaTime;
        //Debug.Log(timer);

        //Si se está llamando a un care mistake, se comprueba el contador
        if (callingHunger || callingTraining) { CheckCareMistake();}

        //Si el timer es mayor que el evolution timer,se llama al metodo de evolucion
        if (timer > evoTime && !triedEvolving) { evolution(); } else { if(triedEvolving)Debug.Log("Ya ha intentado evolucionar"); }
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
                callCircle.SetActive(true);

                break;
            //Entrenamiento
            case 1: Debug.Log("Calling Training");
                callTime = timer;
                callingTraining = true;
                callCircle.SetActive(true);
                break;
            default: break;
        }
    
    }

    void CheckCareMistake() {

        //Si el han pasado X segundos desde que se registró la llamada, se suma uno o dos cares mistakes
        if (callTime + 30 < timer) {
            if (callingHunger && callingTraining) { careMistakes += 2; callCircle.SetActive(false); }
            else { careMistakes++; callCircle.SetActive(false); }
            Debug.Log("Care Mistakes: " + careMistakes);
            if (callingHunger) { callingHunger = false;  }
            if (callingTraining) { callingTraining = false; }
        }
    }

    public void Eat() 
    {
        animatorKaiju.Play("Comer");
        hungerMeter++;
        if (hungerMeter > 5) { hungerMeter = 5; }
        Debug.Log("Hambre actual: " + hungerMeter);
        if (callingHunger) { callingHunger = false; callCircle.SetActive(false); }
    }

    public void Train()
    {
        trainingMeter++;
        if (trainingMeter > 5) { trainingMeter = 5; }
        Debug.Log("Barra de entrenamiento: " + trainingMeter);
        if (callingTraining) { callingTraining = false; callCircle.SetActive(false); }
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

            //samuiso y castellaso
            case 4:
            case 5:
                if (careMistakes < 2)
                {
                    kaijuNuevo = Instantiate<GameObject>(kaiju9);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                }
                ;break;
            //oinchoso
            case 6:
                kaijuNuevo = Instantiate<GameObject>(kaiju10);
                kaijuNuevo.transform.position = kaijuActual.transform.position;
                ;break;

            //evaestruso y rainayaso 
            case 7:
            case 8:
                if (careMistakes < 2)
                {
                    kaijuNuevo = Instantiate<GameObject>(kaiju11);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                }
                ; break;

            //tarotugaso
            case 9:
                kaijuNuevo = Instantiate<GameObject>(kaiju12);
                kaijuNuevo.transform.position = kaijuActual.transform.position;
                ;break;

            //coppertauroso
            case 11:
                kaijuNuevo = Instantiate<GameObject>(kaiju13);
                kaijuNuevo.transform.position = kaijuActual.transform.position;
                ; break;
            // Esto es para no tener que escribir las dos lineas siguientes en cada caso del switch.
            default:;break; 
        }
        if (kaijuNuevo != null)
        {
            Destroy(kaijuActual);
            kaijuActual = kaijuNuevo;
            IDKaiju = kaijuActual.GetComponent<Stats>().ID;
            evoTime = kaijuActual.GetComponent<Stats>().evolutiontime;
            animatorKaiju = kaijuActual.GetComponentInChildren<Animator>();
            careMistakes = 0;
        }
        else { triedEvolving = true; }

        Debug.Log("Care Mistakes: " + careMistakes);
        Debug.Log("ID actual =" + IDKaiju);
        Debug.Log("Evolution timer = " + evoTime);
    }


    //Para pasar de una escena a otra 
    public float interLevelWaitTime = 3f;
    public void GoToNextScene(float waitTime = -1)
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("YOU WIN!");
        }
        else
        {
            Debug.Log("Prepare for next scene!");
            StartCoroutine(WaitAndLoadNextScene(waitTime));
        }
    }
    private IEnumerator WaitAndLoadNextScene(float waitSeconds)
    {
        if (waitSeconds < 0)
        {
            waitSeconds = interLevelWaitTime;
        }
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

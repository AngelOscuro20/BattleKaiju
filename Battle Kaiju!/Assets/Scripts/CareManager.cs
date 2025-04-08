using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareManager : Singleton<CareManager>
{
    float timer = 0;
    float callTime;
    int careMistakes = 0;
    int stage;
    int hungerMeter = 5;
    int trainingMeter = 5;
    bool callingHunger = false;
    bool callingTraining = false;
    float evoTime = 100000;
    int IDKaiju;
    bool triedEvolving = false;
    public GameObject kaijuActual;
    public Animator animatorKaiju;
    GameObject callCircle;
    // Start is called before the first frame update
    void Start()
    {

        //Buscamos el kaiju actual, su id y su tiempo de evolución
        kaijuActual = GameObject.FindGameObjectWithTag("kaiju");
        callCircle = GameObject.Find("CircleCall");
        animatorKaiju = kaijuActual.GetComponent<Animator>();
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
        if (Input.GetKeyDown(KeyCode.T)) { timer += 10; Debug.Log("Timer: " + timer); }
        if(enabled) timer += Time.deltaTime;
        //Debug.Log(timer);

        //Si se está llamando a un care mistake, se comprueba el contador
        if (callingHunger || callingTraining) { CheckCareMistake(); }

        //Si el timer es mayor que el evolution timer,se llama al metodo de evolucion
        if (timer > evoTime && !triedEvolving) 
        {
            kaijuActual = null;
            bool evobool = EvolutionManager.Instance.evolution(IDKaiju);
            if (evobool)
            {
                careMistakes = 0;
                if (kaijuActual = null) { 
                animatorKaiju = kaijuActual.GetComponent<Animator>();
                IDKaiju = kaijuActual.GetComponent<Stats>().ID;
                evoTime = kaijuActual.GetComponent<Stats>().evolutiontime;
                }
            } else { triedEvolving = true; }
            Debug.Log(evobool);
            Debug.Log("ID actual =" + IDKaiju);
            Debug.Log("Evolution timer = " + evoTime);
        } else { 
            if (triedEvolving) Debug.Log("Ya ha intentado evolucionar"); }
    }

    void HungerDrop()
    {
        if (!callingHunger && enabled)
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
        if (!callingTraining  && enabled)
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
    void Call(int tipo)
    {

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
            case 1:
                Debug.Log("Calling Training");
                callTime = timer;
                callingTraining = true;
                callCircle.SetActive(true);
                break;
            default: break;
        }

    }

    void CheckCareMistake()
    {

        //Si el han pasado X segundos desde que se registró la llamada, se suma uno o dos cares mistakes
        if (callTime + 30 < timer)
        {
            if (callingHunger && callingTraining) { careMistakes += 2; callCircle.SetActive(false); }
            else { careMistakes++; callCircle.SetActive(false); }
            Debug.Log("Care Mistakes: " + careMistakes);
            if (callingHunger) { callingHunger = false; }
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

    public int getCareMistakes() {
    return careMistakes;
    }

    public int getHunger()
    {
        return hungerMeter;
    }

    public int getTraining()
    {
        return trainingMeter;
    }


    public void setKaijuActual(GameObject kaijuNuevo) {
        Debug.Log("Seteando nuevo kaiju");
        kaijuActual = kaijuNuevo;
        IDKaiju = kaijuNuevo.GetComponent<Stats>().ID;
        animatorKaiju = kaijuNuevo.GetComponent<Animator>();
        evoTime = kaijuNuevo.GetComponent<Stats>().evolutiontime;


    }

    
}

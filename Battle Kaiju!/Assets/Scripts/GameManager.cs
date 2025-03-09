using System;
using System.Collections;
using System.Collections.Generic;
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

    public static GameManager instance;

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
        Debug.Log("Hambre actual: " + hungerMeter);
        Debug.Log("Care Mistakes: " + careMistakes);
        InvokeRepeating("HungerDrop", 5, 5);
        InvokeRepeating("TrainingDrop", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);

        if (callingHunger || callingTraining) { CheckCareMistake(); }
    }

    void HungerDrop()
    {
        if (!callingHunger)
        {
            if (hungerMeter > 0)
            {
                hungerMeter--;
                Debug.Log("Hambre actual: " + hungerMeter);
            }
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
            if (trainingMeter > 0)
            {
                trainingMeter--;
                Debug.Log("Training actual: " + trainingMeter);
            }
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
}

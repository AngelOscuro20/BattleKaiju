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
    bool callingHunger = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);

        if (callingHunger) { CheckCareMistake(); }
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
   //tipo hace referencia a el tipo de call, es un por si acaso a futuro.
    void Call(int tipo) {
        Debug.Log("Calling");
        //Play sound
        switch (tipo)
        {

            case 0:
                callTime = timer;
                callingHunger = true;
            break;
            default: break;
        }
    
    }

    void CheckCareMistake() {

        if (callTime + 30 < timer) { 
            careMistakes++; 
            Debug.Log("Care Mistakes: " + careMistakes);
            callingHunger = false;
        }
    }

    public void Eat() 
    {
        hungerMeter++;
        if (hungerMeter > 6) { hungerMeter = 6; }
        Debug.Log("Hambre actual: " + hungerMeter);
    }
}

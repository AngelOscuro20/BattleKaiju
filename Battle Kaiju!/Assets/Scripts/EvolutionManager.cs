using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvolutionManager : Singleton<EvolutionManager>
{
    public GameObject kaijuinicial;
    bool firstLoad = true;
    int careMistakes;
    public GameObject kaijuActual;
    public Animator animatorKaiju;
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
    // Start is called before the first frame update

    private void Start()
    {
        if(firstLoad == true)
        {
            Instantiate<GameObject>(kaijuinicial);
            firstLoad = false;
            kaijuinicial.transform.position = new Vector3(0, 0, -1);
        }
        kaijuActual = GameObject.FindGameObjectWithTag("kaiju");
        animatorKaiju = kaijuActual.GetComponent<Animator>();
    }
    public bool evolution(int IDKaiju)
    {
        careMistakes = CareManager.Instance.getCareMistakes();
        Debug.Log("Llamando a Evolucion");
        GameObject kaijuNuevo = null;
        //primero se comprueba la ID del kaiju
        switch (IDKaiju)
        {
            //borosu 
            case 1:

                if (careMistakes < 3)
                {
                    kaijuNuevo = Instantiate<GameObject>(kaiju2);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;

                }
                else
                {
                    kaijuNuevo = Instantiate<GameObject>(kaiju3);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                }

            ; break;

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
            ; break;

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
            ; break;

            //samuiso y castellaso
            case 4:
            case 5:
                if (careMistakes < 2)
                {
                    kaijuNuevo = Instantiate<GameObject>(kaiju9);
                    kaijuNuevo.transform.position = kaijuActual.transform.position;
                }
                ; break;
            //oinchoso
            case 6:
                kaijuNuevo = Instantiate<GameObject>(kaiju10);
                kaijuNuevo.transform.position = kaijuActual.transform.position;
                ; break;

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
                ; break;

            //coppertauroso
            case 11:
                kaijuNuevo = Instantiate<GameObject>(kaiju13);
                kaijuNuevo.transform.position = kaijuActual.transform.position;
                ; break;
            // Esto es para no tener que escribir las dos lineas siguientes en cada caso del switch.
            default:; break;
        }
        if (kaijuNuevo != null)
        {
            Destroy(kaijuActual);
            kaijuActual = kaijuNuevo;
            CareManager.Instance.setKaijuActual(kaijuActual);
            animatorKaiju = kaijuActual.GetComponent<Animator>();
            return true;

        }
        else { return false; }
        
    }

    public void setKaijuActual(GameObject kaijuNuevo)
    {
        Debug.Log("Seteando nuevo kaiju");
        kaijuActual = kaijuNuevo;
        animatorKaiju = kaijuNuevo.GetComponent<Animator>();
    }

}

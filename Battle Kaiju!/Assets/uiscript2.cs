using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiscript2 : MonoBehaviour
{
    int trainingMeter;

    public GameObject OrganizadorEntrenamiento;

    // Start is called before the first frame update
    void Start()
    {
        trainingMeter = CareManager.Instance.getTraining();
    }

    // Update is called once per frame
    void Update()
    {
        trainingMeter = CareManager.Instance.getTraining();
        if (trainingMeter == 5)
        {
            for (int i = 0; i < OrganizadorEntrenamiento.transform.childCount; i++)
            {
                var child = OrganizadorEntrenamiento.transform.GetChild(i).gameObject;
                if (child.activeSelf == false)
                    child.SetActive(true);
            }

        }

        if (trainingMeter == 4)
        {
            for (int i = 0; i < OrganizadorEntrenamiento.transform.childCount; i++)
            {
                var child = OrganizadorEntrenamiento.transform.GetChild(i).gameObject;
                if (i < 4)
                {
                    if (child.activeSelf == false)
                        child.SetActive(true);
                }

                else child.SetActive(false);
            }

        }

        if (trainingMeter == 3)
        {
            for (int i = 0; i < OrganizadorEntrenamiento.transform.childCount; i++)
            {
                var child = OrganizadorEntrenamiento.transform.GetChild(i).gameObject;
                if (i < 3)
                {
                    if (child.activeSelf == false)
                        child.SetActive(true);
                }
                else child.SetActive(false);
            }

        }

        if (trainingMeter == 2)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = OrganizadorEntrenamiento.transform.GetChild(i).gameObject;
                if (i < 2)
                {
                    if (child.activeSelf == false)
                        child.SetActive(true);
                }
                else child.SetActive(false);
            }

        }

        if (trainingMeter == 1)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = OrganizadorEntrenamiento.transform.GetChild(i).gameObject;
                if (i < 1)
                {
                    if (child.activeSelf == false)
                        child.SetActive(true);
                }
                else child.SetActive(false);
            }

        }

        if (trainingMeter == 0)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = OrganizadorEntrenamiento.transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(false);
            }

        }

        trainingMeter = 0;

    }
}

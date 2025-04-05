using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class uiscriptHambre  : MonoBehaviour
{
    int hungerMeter;
    


    // Start is called before the first frame update
    void Start()
    {
        hungerMeter = CareManager.Instance.getHunger();
        // hunger0 = this.transform.GetChild(1).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        hungerMeter = CareManager.Instance.getHunger();
        if (hungerMeter == 5)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = this.transform.GetChild(i).gameObject;
                if (child == null)
                    child.SetActive(true);
            }
        ;
        }

        if (hungerMeter == 4)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = this.transform.GetChild(i).gameObject;
                if(i < 4)
                {
                    if (child == null)
                    child.SetActive(true);
                    }

                    else child.SetActive(false);
            }
        ;
        }

        if (hungerMeter == 3)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = this.transform.GetChild(i).gameObject;
                if (i < 3) {
                    if (child == null)
                    child.SetActive(true);
                }
                else child.SetActive(false);
            }
      ;
        }

        if (hungerMeter == 2)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = this.transform.GetChild(i).gameObject;
                if (i < 2) { 
                    if (child == null)
                        child.SetActive(true);
                }
                else child.SetActive(false);
            }
      ;
        }

        if (hungerMeter == 1)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = this.transform.GetChild(i).gameObject;
                if (i < 1) { 
                    if (child == null)
                        child.SetActive(true);
                }
                else child.SetActive(false);
            }
      ;
        }

        if (hungerMeter == 0)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = this.transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(false);
            }
       ;
        }
    }
}




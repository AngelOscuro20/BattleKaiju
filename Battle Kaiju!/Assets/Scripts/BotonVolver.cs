using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BotonVolver : MonoBehaviour
{
    public void OnClick() 
    
    {
        GameObject.FindGameObjectWithTag("CareManager").GetComponent<CareManager>().enabled = true;
        SceneManager.LoadScene("CareScene");
    }
}

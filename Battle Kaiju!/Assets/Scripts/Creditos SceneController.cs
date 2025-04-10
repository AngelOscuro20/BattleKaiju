using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToMainMenu()  //cuando estamos en la escena de creditos y queremos volver al menu principal
    {
        SceneManager.LoadScene("MainMenu");
    }
}


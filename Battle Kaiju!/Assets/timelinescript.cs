using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timelinescript : MonoBehaviour
{
    // Start is called before the first frame update

    public void Trigger()
    {
        SceneManager.LoadScene("CareScene");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

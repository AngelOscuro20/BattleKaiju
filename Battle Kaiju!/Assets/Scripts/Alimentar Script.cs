using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentarScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("click");
        GameManager.instance.Eat();
    }
}

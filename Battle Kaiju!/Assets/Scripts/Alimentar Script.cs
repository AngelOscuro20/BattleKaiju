using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentarScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance.Eat();
    }
}

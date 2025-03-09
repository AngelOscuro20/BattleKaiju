using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrenarScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.instance.Train();
    }
}

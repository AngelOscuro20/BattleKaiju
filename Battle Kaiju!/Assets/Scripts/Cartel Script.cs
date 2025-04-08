using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartelScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance.GoToNextScene();
    }
}

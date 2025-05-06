using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Emitter : Singleton<Emitter>
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Kaiju").GetComponent<Movement>().injuryEmitter = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("kaiju").transform.position;
    }
}

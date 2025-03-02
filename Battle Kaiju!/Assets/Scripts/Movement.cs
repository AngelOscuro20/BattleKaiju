using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int Dir;
    Rigidbody2D rg2d;
    int speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("Wander", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Wander() {
        randomDirCall();
        switch (Dir)
        {
            case 0: break;
            case 1: rg2d.AddForce(transform.right * speed, ForceMode2D.Impulse); break;
            case 2: rg2d.AddForce(transform.right * -speed, ForceMode2D.Impulse); break;
            case 3: rg2d.AddForce(transform.up * speed, ForceMode2D.Impulse); break;
            case 4: rg2d.AddForce(transform.up * -speed, ForceMode2D.Impulse); break;
            case 5: rg2d.AddForce(transform.right * speed, ForceMode2D.Impulse); rg2d.AddForce(transform.up * speed, ForceMode2D.Impulse); break;
            case 6: rg2d.AddForce(transform.right * speed, ForceMode2D.Impulse); rg2d.AddForce(transform.up * -speed, ForceMode2D.Impulse); break;
            case 7: rg2d.AddForce(transform.right * -speed, ForceMode2D.Impulse); rg2d.AddForce(transform.up * speed, ForceMode2D.Impulse); break;
            case 8: rg2d.AddForce(transform.right * -speed, ForceMode2D.Impulse); rg2d.AddForce(transform.up * -speed, ForceMode2D.Impulse); break;
            default: break;
        }
        

    }

    void randomDirCall() 
    {
        Dir = Random.Range(0, 9);
    }
}

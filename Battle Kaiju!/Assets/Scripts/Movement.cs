using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class Movement : MonoBehaviour
{
    int Dir;
    Rigidbody2D rg2d;
    float speed;
    bool petting = false;
    Animator animator;
    float animspeed;
    SpriteRenderer spriteKaiju;
    ParticleSystem particulasPetting;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("Wander", 5, 5);
        speed = GetComponent<Stats>().speed * 0.1f;
        animator = this.GetComponent<Animator>();
        spriteKaiju = this.GetComponent<SpriteRenderer>();
        particulasPetting = this.GetComponent<ParticleSystem>();
        particulasPetting.Pause();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Wander() {
        
        if (!petting && enabled)
        {
            randomDirCall();
            switch (Dir)
            {
                case 0: break;
                case 1: spriteKaiju.flipX = true; rg2d.AddForce(transform.right * speed, ForceMode2D.Impulse);animator.Play("Mover"); break;
                case 2: spriteKaiju.flipX = false; rg2d.AddForce(transform.right * -speed, ForceMode2D.Impulse); animator.Play("Mover"); break;
                case 3: spriteKaiju.flipX = false; rg2d.AddForce(transform.up * speed, ForceMode2D.Impulse); animator.Play("Mover"); break;
                case 4: spriteKaiju.flipX = false; rg2d.AddForce(transform.up * -speed, ForceMode2D.Impulse); animator.Play("Mover"); break;
                case 5: spriteKaiju.flipX = true; rg2d.AddForce(transform.right * speed, ForceMode2D.Impulse);  rg2d.AddForce(transform.up * speed, ForceMode2D.Impulse); animator.Play("Mover"); break;
                case 6: spriteKaiju.flipX = true; rg2d.AddForce(transform.right * speed, ForceMode2D.Impulse);  rg2d.AddForce(transform.up * -speed, ForceMode2D.Impulse); animator.Play("Mover");break;
                case 7: spriteKaiju.flipX = false; rg2d.AddForce(transform.right * -speed, ForceMode2D.Impulse); rg2d.AddForce(transform.up * speed, ForceMode2D.Impulse); animator.Play("Mover"); break;
                case 8: spriteKaiju.flipX = false; rg2d.AddForce(transform.right * -speed, ForceMode2D.Impulse); rg2d.AddForce(transform.up * -speed, ForceMode2D.Impulse); animator.Play("Mover"); break;
                default: break;
            }
        }
    }

    void randomDirCall() 
    {
        Dir = Random.Range(0, 9);
    }

    private void OnMouseOver()
    {
        if(enabled) {
        petting = true;
        Debug.Log("Petting");
        rg2d.AddForce(transform.right * 0.4f);
        rg2d.AddForce(transform.right * -0.4f);
        particulasPetting.Play();
        }
    }

    private void OnMouseExit()
    {
        Debug.Log("Stopped petting");
        petting = false;
        particulasPetting.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
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
    ParticleSystem particulasInjury;
    GameObject injuryEmitter;
    bool injured = false;

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
        injuryEmitter = GameObject.Find("InjuryEmitter");
        particulasInjury = injuryEmitter.GetComponent<ParticleSystem>();
        particulasPetting.Pause();
        particulasInjury.Pause();
    }

    // Update is called once per frame
    void Update()
    {
     if(enabled)injuryEmitter.transform.position = this.transform.position - new Vector3(0,1,0);
    }

    private void Wander() {
        
        if (!petting && !injured && enabled)
        {
            randomDirCall();
            switch (Dir)
            {
                case 0: break;
                case 1: spriteKaiju.flipX = true; rg2d.AddForce(transform.right * speed*0.5f, ForceMode2D.Impulse);animator.Play("Mover"); break;
                case 2: spriteKaiju.flipX = false; rg2d.AddForce(transform.right * -speed * 0.5f, ForceMode2D.Impulse); animator.Play("Mover"); break;
                case 3: spriteKaiju.flipX = false; rg2d.AddForce(transform.up * speed * 0.5f, ForceMode2D.Impulse); animator.Play("Mover"); break;
                case 4: spriteKaiju.flipX = false; rg2d.AddForce(transform.up * -speed * 0.5f, ForceMode2D.Impulse); animator.Play("Mover"); break;
                case 5: spriteKaiju.flipX = true; rg2d.AddForce(transform.right * speed * 0.5f, ForceMode2D.Impulse);  rg2d.AddForce(transform.up * speed * 0.5f, ForceMode2D.Impulse); animator.Play("Mover"); break;
                case 6: spriteKaiju.flipX = true; rg2d.AddForce(transform.right * speed * 0.5f, ForceMode2D.Impulse);  rg2d.AddForce(transform.up * -speed * 0.5f, ForceMode2D.Impulse); animator.Play("Mover");break;
                case 7: spriteKaiju.flipX = false; rg2d.AddForce(transform.right * -speed * 0.5f, ForceMode2D.Impulse); rg2d.AddForce(transform.up * speed * 0.5f, ForceMode2D.Impulse); animator.Play("Mover"); break;
                case 8: spriteKaiju.flipX = false; rg2d.AddForce(transform.right * -speed * 0.5f, ForceMode2D.Impulse); rg2d.AddForce(transform.up * -speed * 0.5f, ForceMode2D.Impulse); animator.Play("Mover"); break;
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
        if(enabled && !injured) {
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

    public void moveTo(GameObject gameobject) 
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(gameobject.name);
            animator.Play("Mover");
            Vector2 hacia = Vector2.MoveTowards(this.transform.position, gameobject.transform.position, 10f);
            rg2d.MovePosition(hacia);
            if (hacia.x < 0) { spriteKaiju.flipX = false; } else { spriteKaiju.flipX = true; }
            StartCoroutine(Wait());
        }
    }

    public void Injured() 
    {
        particulasInjury.Play();
        particulasPetting.Stop();
        injured = true;
    }

    public void Healed()
    {
        particulasInjury.Stop();
        injured = false;
    }

    IEnumerator Wait() { yield return new WaitForSeconds(3); }
}

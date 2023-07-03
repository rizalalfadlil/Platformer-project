using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;
    public float health = 100f;
    public Slider HealthUI;
    private bool invicible;
    public Vector3 Startposition;
    private void Start()
    {
        Startposition = transform.position;
        health = 100f;
        HealthUI = GameObject.Find("Slider").GetComponent<Slider>();
        invicible = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
           if(!invicible)
           {
            health -=20f;
            StartCoroutine(Dmg());
           }
        }
    }
    IEnumerator Dmg()
    {
        invicible = true;
        yield return new WaitForSeconds(0.1f);
        invicible = false;
    }
    void Update()
    {
        HealthUI.value = health;
        if(health <=0f)StartCoroutine(Die());
    }
    private IEnumerator Die()
    {
        health = 100f;
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        yield return new WaitForSeconds(0.5f);
        RestartLevel();
        
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

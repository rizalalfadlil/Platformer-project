using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        infoText = GameObject.Find("info").GetComponent<Text>();
        infoText.text = "";
    }
    public GameObject[] Apples;
    public Text infoText;
    void Update()
    {
        Apples =  GameObject.FindGameObjectsWithTag("Collectibles");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            if(Apples.Length < 1)
            {
                finishSound.Play();
                levelCompleted = true;
                Invoke("CompleteLevel", 2f);
            }else
            {
                StartCoroutine(NotComplete());
            }
        }
    }
    IEnumerator NotComplete()
    {
        infoText.text =("Not Enough Apples");
        yield return new WaitForSeconds(2f);
        infoText.text = "";
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
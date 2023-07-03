using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Continue()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene("Start Screen");
    }
    void Start()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    
}

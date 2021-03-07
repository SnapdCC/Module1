using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Transform pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Module 1.1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseButton()
    {
        pausePanel.gameObject.SetActive(!pausePanel.gameObject.activeSelf);
    }
}

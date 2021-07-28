using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [SerializeField] private SceneManager manager;
    [SerializeField] private string scene;
    [SerializeField] private Image back;
    [SerializeField] private bool needDialog;
    private bool flag = true;

    void Awake()
    {
        StartCoroutine(IQuit());
    }

    public void OpenExitWindow()
    {
        back.gameObject.SetActive(true);
    }
    
    public void Exit() 
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Main Menu")
        {
            Application.Quit();
        }
        else
        {
            manager.SceneLoader(scene);
        }
    }

    public void Resume()
    {
        back.gameObject.SetActive(false);
    }

    private IEnumerator IQuit()
    {
        while(true)
        {
            if (Input.GetKeyDown(KeyCode.Return) && !flag)
            {
                Exit();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(!needDialog)
                {
                    if (flag)
                    {
                        back.gameObject.SetActive(true);
                        flag = false;
                    }
                    else
                    {
                        back.gameObject.SetActive(false);
                        flag = true;
                    }
                }
                else
                {
                    Exit();
                }
            }
            yield return null;
        }
    }
}

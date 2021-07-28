using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private string scene_back;
    [SerializeField] private string scene_next;
    [SerializeField] private EndLevel endLevel;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && endLevel.canNext) UnityEngine.SceneManagement.SceneManager.LoadScene(scene_back);
        if(Input.GetKeyDown(KeyCode.E)) UnityEngine.SceneManagement.SceneManager.LoadScene(scene_next);
        if (Input.GetKeyDown(KeyCode.R))
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}

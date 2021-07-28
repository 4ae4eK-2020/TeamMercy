using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void SceneLoader(string _scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_scene);
    }
}

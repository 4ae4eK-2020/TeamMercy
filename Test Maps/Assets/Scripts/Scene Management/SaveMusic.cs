using JSONManagement;
using UnityEngine;

public class SaveMusic : MonoBehaviour
{
    [SerializeField] private JsonManager jsonManager;
    [SerializeField] private AudioSource source;
    private SaveMusic[] musics;
    
    void Awake()
    {
        jsonManager.LoadJson("settings");
        musics = FindObjectsOfType<SaveMusic>();
        
        if (musics.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        jsonManager.LoadJson("settings");
        musics[0].source.volume = jsonManager.settings.volume * jsonManager.settings.music;
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level 1") Destroy(gameObject);
    }
}

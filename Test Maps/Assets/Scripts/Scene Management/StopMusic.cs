using System.Collections;
using JSONManagement;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    [SerializeField] private JsonManager jsonManager;
    [SerializeField] private AudioSource[] sounds;

    void Start()
    {
        jsonManager.LoadJson("settings");
        StartCoroutine(StopSounds());
        
    }
    
    private IEnumerator StopSounds()
    {
        while(true)
        {
            sounds = FindObjectsOfType<AudioSource>();
            foreach (AudioSource sound in sounds)
            {
                if (jsonManager.settings.isMute)
                {
                    sound.Stop();
                }
                else
                {
                   if(!sound.isPlaying && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Level 1") sound.Play();
                }
            }
            yield return null;
        }
    }
}

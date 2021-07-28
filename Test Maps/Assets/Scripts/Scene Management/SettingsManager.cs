using System.Collections;
using JSONManagement;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private JsonManager jsonManager;
    [SerializeField] private Slider slider;

    public enum TypeValue
    {
        sounds,
        music,
        volume
    }

    public TypeValue Value= TypeValue.volume;
    
    void Awake()
    {
        jsonManager.LoadJson("settings");
        StartCoroutine(ISetVolume());
    }
    
    private IEnumerator ISetVolume()
    {
        switch (Value)
        {
            case TypeValue.sounds: slider.value = jsonManager.settings.sounds;
                break;
            case TypeValue.music: slider.value = jsonManager.settings.music;
                break;
            case TypeValue.volume: slider.value = jsonManager.settings.volume;
                break;
        }
        yield break;
    }
    
    public void SaveVolume()
    {
        switch (Value)
        {
            case TypeValue.sounds: jsonManager.settings.sounds = slider.value;
                break;
            case TypeValue.music: jsonManager.settings.music = slider.value;
                break;
            case TypeValue.volume: jsonManager.settings.volume = slider.value;
                break;
        }
        jsonManager.SaveJson("settings");
    }
}


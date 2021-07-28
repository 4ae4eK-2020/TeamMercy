using JSONManagement;
using UnityEngine;

public class BattleVolume : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private JsonManager json;
    
    void Awake()
    {
        json.LoadJson("settings");

        source.volume = json.settings.volume * json.settings.music;
    }
}

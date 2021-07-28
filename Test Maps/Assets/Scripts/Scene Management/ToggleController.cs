using JSONManagement;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private JsonManager jsonManager;

    void Awake()
    {
        jsonManager.LoadJson("settings");
        toggle.isOn = jsonManager.settings.isMute;
    }
    
    public void SetBool(bool b)
    {
        jsonManager.settings.isMute = b;
        Save();
    }

    private void Save()
    {
        jsonManager.SaveJson("settings");
    }
}

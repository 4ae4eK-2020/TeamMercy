using JSONManagement;
using TMPro;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown lngVal;
    [SerializeField] private JsonManager json;

    void Start()
    {
        json.LoadJson("settings");
        lngVal.value = json.settings.languageInt;
    }
    
    public void SetLanguage()
    {
        Locale[] langs = FindObjectsOfType<Locale>();

        foreach (Locale lang in langs)
        {
            if (lngVal.value == 0)
            {
                lang.lng = Locale.Language.Ru;
            }
            else
            {
                lang.lng = Locale.Language.En;
            }
        }
        
        json.settings.languageInt = lngVal.value;
        
        json.SaveJson("settings");
    }
}

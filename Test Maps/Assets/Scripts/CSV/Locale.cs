using System.Collections;
using JSONManagement;
using TMPro;
using UnityEngine;

public class Locale : MonoBehaviour
{
    [SerializeField] private CSVManager csv;
    public int typeOfValue;
    [SerializeField] private TMP_Dropdown drop;
    [SerializeField] private JsonManager json;
    [SerializeField] private CoinMainer coinMainer;

    public TextMeshProUGUI value;
    
    [HideInInspector] public enum Modificators
    {
        isArrayValue,
        isHeroValue,
        isCoinValue,
        SimpleValue,
        PlayerSteelValue
    }

    public Modificators Modificator;
    
    [HideInInspector] public enum Language
    {
        Ru,
        En
    };

    public Language lng = Language.Ru;
    
    void Awake()
    {
        StartCoroutine(ISetLanguage());
    }

    private IEnumerator ISetLanguage()
    {
        while(true)
        {
            if (Modificator == Modificators.isHeroValue)
            {
                json.LoadJson("json");
            }

            json.LoadJson("settings");
            yield return null;
        }
    }

    void Start()
    {
        switch (json.settings.languageInt)
        {
            case 0: lng = Language.Ru;
                break;
            case 1: lng = Language.En;
                break;
        }
    }
    
    void Update()
    {
        switch (Modificator)
        {
            case Modificators.isArrayValue:
                switch (lng)
                {
                    case Language.Ru:
                    drop.captionText.text = csv.rows[typeOfValue + drop.value][1];
                    for (int i = 0; i < drop.options.Count; i++)
                    {
                        drop.options[i].text = csv.rows[typeOfValue + i][1];
                    }
                    break; 
                    
                case Language.En:
                    drop.captionText.text = csv.rows[typeOfValue + drop.value][2]; 
                    for (int i = 0; i < drop.options.Count; i++) 
                    { 
                        drop.options[i].text = csv.rows[typeOfValue + i][2];
                    } 
                    break;
                }
                break;
            
            case Modificators.isCoinValue:
                switch (lng)
                {
                    case Language.Ru:
                        value.text = csv.rows[typeOfValue][1] + coinMainer.coinCount;
                        break;
                    case Language.En:
                        value.text = csv.rows[typeOfValue][2] + coinMainer.coinCount;
                        break;
                }
                break;
            case Modificators.isHeroValue:
                switch (lng)
                {
                    case Language.Ru:
                        value.text = json.selectedHero.HeroID + " - " + csv.rows[typeOfValue][1] + " - " + json.selectedHero.cost;
                        break;
                    case Language.En:
                        value.text = json.selectedHero.HeroID + " - " + csv.rows[typeOfValue][2] + " - " +  json.selectedHero.cost;
                        break;
                }
                break;
            
            case Modificators.SimpleValue:
                switch (lng)
                {
                    case Language.Ru:
                        value.text = csv.rows[typeOfValue][1];
                        break;
                    case Language.En:
                        value.text = csv.rows[typeOfValue][2];
                        break;
                }
                break;
            
            case Modificators.PlayerSteelValue:
                switch (lng)
                {
                    case Language.Ru:
                        value.text = csv.rows[typeOfValue][1] + ": " + json.player.steel;
                        break;
                    case Language.En:
                        value.text = csv.rows[typeOfValue][2] + ": " + json.player.steel;
                        break;
                }
                break;
        }
    }
}

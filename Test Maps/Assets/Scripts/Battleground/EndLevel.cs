using System.Collections;
using TMPro;
using UnityEngine;
using Structs;
using JSONManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject leaveButton;
    [SerializeField] private GameObject info;
    [SerializeField] private EnemySpawner cd;
    [SerializeField] private TextMeshProUGUI result;
    [SerializeField] private BaseParams basePms;
    [SerializeField] private playerInfo player;
    [SerializeField] private JsonManager json;
    [SerializeField] private int steelPlus;
    [SerializeField] private CSVManager csv;
    [SerializeField] private Locale loc;
    [HideInInspector] public bool canNext;

    void Awake()
    {
        json.LoadJson("settings");
        json.LoadJson("mission");
    }
    
    void Start()
    {
        StartCoroutine(Iresult());
    }

    private IEnumerator Iresult()
    {
        if (cd.canResult)
        {
            Destroy(leaveButton);
            Destroy(info);
            result.gameObject.SetActive(true);
            if (basePms.health > 0)
            {
                button.SetActive(true);

                canNext = true;
                
                json.LoadJson("player");

                result.text = csv.rows[loc.typeOfValue][json.settings.languageInt + 1];

                json.mission.Stage = 2;
                
                json.SaveJson("mission");
                
                json.player.steel = steelPlus + json.player.steel;
                
                json.player.isDeafult = true;

                Save();
            }
            else
            {
                loc.typeOfValue += 1;
                result.text = csv.rows[loc.typeOfValue + 1][json.settings.languageInt + 1];
            }
        }
        
        yield return null;
    }

    private void Save()
    {
        json.SaveJson("player");
    }
}

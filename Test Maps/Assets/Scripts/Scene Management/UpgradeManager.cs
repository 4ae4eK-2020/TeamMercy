using UnityEngine;
using JSONManagement;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private int damadePlus;
    [SerializeField] private int needToUpgrade;

    [SerializeField] private GameObject vanguard;
    [SerializeField] private GameObject sniper;

    private JsonManager json;
    
    
    public void UpgradeHero()
    {
        if (vanguard.activeInHierarchy)
        {
            json = vanguard.GetComponent<JsonManager>();
        }
        else
        {
            json = sniper.GetComponent<JsonManager>();
        }
        json.LoadJson("json");    
        json.LoadJson("player");

        if (json.player.steel >= needToUpgrade)
        {
            json.selectedHero.damage += damadePlus;
            json.player.steel -= needToUpgrade;
            
            Invoke("Save", 0.01f);
        }
    }

    private void Save()
    {
        json.SaveJson("json");
        json.SaveJson("player");
    }
}

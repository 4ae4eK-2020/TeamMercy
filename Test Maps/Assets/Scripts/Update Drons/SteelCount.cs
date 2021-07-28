using System.Collections;
using JSONManagement;
using TMPro;
using UnityEngine;

public class SteelCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI steel;
    [SerializeField] private JsonManager jsonManager;
    
    void Start()
    {
        StartCoroutine(ISteel());
    }

    private IEnumerator ISteel()
    {
        while (true)
        {
            jsonManager.LoadJson("player");

            steel.text = "Steel: " + jsonManager.player.steel;

            yield return new WaitForFixedUpdate();
        }
    }
}

using JSONManagement;
using UnityEngine;

public class ChooseHero : MonoBehaviour
{
    [SerializeField] private GameObject vanguard;
    [SerializeField] private GameObject sniper;

    private Ray ray;
    private RaycastHit hit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            vanguard.SetActive(true);
            sniper.SetActive(true);
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            hit.transform.gameObject.GetComponent<JsonManager>().LoadJson("json");
            hit.transform.gameObject.GetComponent<JsonManager>().LoadJson("player");
            
            if (hit.collider.name == "Sniper")
            {
                vanguard.SetActive(false);
                sniper.SetActive(true);
            }

            if (hit.collider.name == "Vanguard")
            {
                vanguard.SetActive(true);
                sniper.SetActive(false);
            }
        }
    }
}

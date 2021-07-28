using System.Collections;
using JSONManagement;
using Structs;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ShowParams : MonoBehaviour
{
    [SerializeField] HeroParamsStruct paramS;
    [SerializeField] private JsonManager manager;
    [SerializeField] private TextMeshProUGUI paramsTextMesh;

    private UnityEvent eventClick;
    private string val = ""; 
    private Ray ray;
    
    [HideInInspector] public RaycastHit hit;

    private bool canStartCorutine = true;
    private int damage;
    private float dps;

    void Start()
    {
        eventClick = new UnityEvent();
        eventClick.AddListener(Characteristics);
    }

    void Characteristics()
    {
        paramsTextMesh.text = damage + "\n" + dps;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Input.GetKeyDown(KeyCode.Backspace)) canStartCorutine = false;
        if(canStartCorutine) StartCoroutine(IClick());

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.tag == "Player") canStartCorutine = true;
        }
        
        paramS = manager.selectedHero;
        
        damage = paramS.damage;
        dps = paramS.damageSpeed;
        
        val = "Damage: " + damage + "\nDPS: " + dps;
        
        if(paramsTextMesh.text != "" && canStartCorutine) if(val != paramsTextMesh.text) eventClick.Invoke();
    }

    private IEnumerator IClick()
    {
        while (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && canStartCorutine)
            {
                if (hit.collider.tag == "Player")
                {
                    Characteristics();
                }
            }
            yield return null;
        }
    }
}

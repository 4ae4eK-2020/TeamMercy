using System;
using System.Collections;
using UnityEngine;

public class HeroSetup : MonoBehaviour
{
    public float size;
    [SerializeField] private CSVManager csv;
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject heroSniper;
    [SerializeField] private GameObject heroStormtrooper;
    [SerializeField] private GameObject back;
    [SerializeField] private CoinMainer coin;
    [SerializeField] private int needToHero, needToHeroSniper;

    private bool sep;
    private bool canSet;
    private string heroClone;
    private GameObject clone;
    private Ray ray;
    private RaycastHit hit;
    private int heroCost, heroSniperCost, heroStormtrooperCost;

    private string[][] heroRows;

    [SerializeField] private HeroController.TypeHero typeHero;
    
    void Start()
    {
        StartCoroutine(SetupHero());
        StartCoroutine(SetCost());
    }
    
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (back.activeInHierarchy) canSet = true; else canSet = false;
        
        if (Physics.Raycast(ray, out hit))
        {
            heroClone = hit.transform.tag;
            if (hit.transform.gameObject.GetComponent<IsSetuped>() != null)
                sep = hit.transform.gameObject.GetComponent<IsSetuped>().setuped;
        }
    }

    private IEnumerator SetCost()
    {
        while (true)
        {
            heroRows = csv.rows;

            heroCost = Int32.Parse(heroRows[1][1]);
            heroStormtrooperCost = Int32.Parse(heroRows[2][1]);
            heroSniperCost = Int32.Parse(heroRows[3][1]);

            yield return null;
        }
    }
    
    private IEnumerator SetupHero()
    {
        while ((!Input.GetKey(KeyCode.Alpha1) || !Input.GetKey(KeyCode.Alpha2)) && !canSet)
        {
            if (coin.coinCount >= needToHero || coin.coinCount >= needToHeroSniper)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (heroClone != "Player" && sep == false)
                    {
                        if (hit.transform.gameObject.layer == 3)
                        {
                            if (Input.GetKeyDown(KeyCode.Alpha1) && coin.coinCount - heroCost >= 0)
                            {
                                typeHero = HeroController.TypeHero.Vanguard;
                                Cloning(hero);
                            }
                        
                            if (Input.GetKeyDown(KeyCode.Alpha2) && coin.coinCount - heroSniperCost >= 0)
                            {
                                typeHero = HeroController.TypeHero.Sniper;
                                Cloning(heroSniper);
                            }

                            if (Input.GetKeyDown(KeyCode.Alpha3) && coin.coinCount - heroStormtrooperCost >= 0)
                            {
                                typeHero = HeroController.TypeHero.Stormtrooper;
                                Cloning(heroStormtrooper);
                            }
                        }
                    }
                }
            }
            yield return null;
        }
    }

    void Cloning(GameObject _heroPref)
    {
        clone = Instantiate(_heroPref,
            new Vector3(hit.transform.position.x, hit.transform.position.y + (hit.transform.localScale.y + _heroPref.transform.localScale.y), hit.transform.position.z), _heroPref.transform.rotation, hit.transform);
        clone.transform.localScale *= size;
        Debug.Log(_heroPref.transform.rotation);

        switch (typeHero)
        {
            case HeroController.TypeHero.Vanguard:
                coin.coinCount -= heroCost;
                
                break;
            
            case HeroController.TypeHero.Stormtrooper:
                coin.coinCount -= heroStormtrooperCost;
                
                break;

            case HeroController.TypeHero.Sniper:
                coin.coinCount -= heroSniperCost;
                
                break;
        }
    }
}

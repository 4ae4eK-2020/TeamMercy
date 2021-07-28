using System;
using System.Collections;
using JSONManagement;
using UnityEngine;
using Random = UnityEngine.Random;


public class HeroController : MonoBehaviour
{
    [SerializeField] private CSVManager csv;
    [SerializeField] private Transform heroObj;
    [SerializeField] private int damage;
    [SerializeField] private float dps;
    [SerializeField] private float attackRange;
    [SerializeField] private LineRenderer ray;
    [SerializeField] private JsonManager jsonManager;
    [SerializeField] private AudioSource shot;
    [SerializeField] private HeroSetup setup;
    
    private GameObject clone;
    private float miliDps;
    private Ray attackRay;
    private RaycastHit hit;
    private Vector3 heading;
    [HideInInspector] public bool setUp;

    public enum TypeHero
    {
        Vanguard,
        Sniper,
        Stormtrooper
    }

    public TypeHero typeHero = TypeHero.Vanguard;

    void Start()
    {
        setup = Camera.main.GetComponent<HeroSetup>();
        attackRange *= 4.8f;
        if(jsonManager.player.isDeafult)
        {
            StartCoroutine(IDefaultJson());
        }
        else
        {
            StartCoroutine(IDefault());
        }
        StartCoroutine(IHeroCharact());
        setUp = true;
        ray = GetComponent<LineRenderer>();
        ray.startColor = Color.blue;
        ray.endColor = Color.blue;
        StartCoroutine(UpdateEnemyes());
    }

    void FixedUpdate()
    {
        if (clone != null && Mathf.Sqrt(heading.sqrMagnitude) <= attackRange)
        {
            transform.LookAt(clone.transform);
        }
        Debug.Log(heading.magnitude + " " + attackRange);
    }
    
    private IEnumerator UpdateEnemyes()
    {
        while(true)
        {
            GameObject[] enemyes = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemyes)
            {
                if (clone == null || Math.Sqrt(heading.sqrMagnitude) >= attackRange)
                {
                    clone = enemy;
                    if(clone != null) heading = heroObj.position - clone.transform.position;
                    yield return null;
                }
                else
                {
                    heading = heroObj.position - clone.transform.position;
                    attackRay = new Ray(heroObj.transform.position, transform.forward * attackRange);

                    if (Physics.Raycast(attackRay, out hit) && hit.collider.CompareTag("Enemy") &&
                        Math.Sqrt(heading.sqrMagnitude) <= attackRange)
                    {
                        Debug.DrawRay(heroObj.transform.position, transform.forward * attackRange, Color.yellow);
                        StartCoroutine(IRayDraw());

                        miliDps += Time.deltaTime;
                        if (miliDps >= dps)
                        {
                            CoolDown();
                            miliDps = 0;
                            yield return null;
                        }
                    }
                    else
                    {
                        StopCoroutine(IRayDraw());
                        ray.SetPosition(0, Vector3.zero);
                        ray.SetPosition(1, Vector3.zero);
                        miliDps = 0;
                        shot.loop = false;
                        yield return null;
                    }
                }
            }
            yield return null;
        }
    }

    private void CoolDown()
    {
        shot.Play();
        clone.GetComponent<EnemyController>().health -= damage;
        ray.material.color = new Color(Random.value, Random.value,Random.value);
    }
    
    private IEnumerator IDefaultJson()
    {
        
        damage = jsonManager.selectedHero.damage;
        dps = jsonManager.selectedHero.damageSpeed;
        attackRange = jsonManager.selectedHero.range;
        yield break;
    }

    private IEnumerator IDefault()
    {
        Debug.Log(csv.rows[jsonManager.selectedHero.HeroID][3]);
        damage = Int32.Parse(csv.rows[jsonManager.selectedHero.HeroID][2]);
        dps = float.Parse(csv.rows[jsonManager.selectedHero.HeroID][3], System.Globalization.CultureInfo.InvariantCulture);
        attackRange = float.Parse(csv.rows[jsonManager.selectedHero.HeroID][4]) * setup.size;
        yield return null;
    }

    private IEnumerator IRayDraw()
    {
        while (clone != null)
        {
            ray.positionCount = 2;
            ray.SetPosition(0, attackRay.origin);
            ray.SetPosition(1, hit.point);
            yield return null;
        }
    }

    private IEnumerator IHeroCharact()
    {
        while (true)
        {
            jsonManager.LoadJson("settings");
            jsonManager.LoadJson("json");
            GetComponent<AudioSource>().volume = jsonManager.settings.volume * 0.2f * jsonManager.settings.sounds;
            
            yield return null;
        }
    }
}

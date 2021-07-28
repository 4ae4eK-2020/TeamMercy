using System;
using System.Collections;
using  System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public GameObject clone;
    public UnityEvent canStart;

    [SerializeField] private int levelNumber;
    [SerializeField] private float size;
    [SerializeField] private CSVManager csv;
    [SerializeField] private Transform baseObj;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private GameObject back;
    [SerializeField] private GameObject cilinder;
    [SerializeField] private float wait;
    [SerializeField] private int checkValue;
    private int enemyNumber;
    private int _i;
    public List<int> needToSpawns;
    public float coolDown;
    [HideInInspector] public bool canResult;
    private bool isNull = true;

    private float timeCd;
    public int enemyN;

    void Awake()
    {
        canStart.AddListener(CorutineStart);
    }
    
    void CorutineStart()
    {
        StartCoroutine(ISpawn());
    }

    void Start()
    {
        for (int i =0; i< needToSpawns.Count; i++)
        {
            Debug.Log(csv.rows[levelNumber][i+1]);
            needToSpawns[i] = Int32.Parse(csv.rows[levelNumber][i+1]);
            checkValue += needToSpawns[i];
        }
    }

    void Update()
    {
        if(cilinder == null && isNull)
        {
            canStart.Invoke();
            isNull = false;
        }
        
        if (clone == null && enemyN == checkValue)
        { 
            canResult = true; 
            back.SetActive(true);
            StopCoroutine(ISpawn());
        }
    }
    
   private IEnumerator ISpawn()
    {
        while (enemyN < checkValue)
        {
            if(enemyNumber < needToSpawns[_i])
            {
                TimeTick();
                enemyNumber++;
                yield return new WaitForSeconds(coolDown);
            }
            else
            {
                if(_i < needToSpawns.Count)
                {
                    _i++;
                    enemyNumber = 0;
                    yield return new WaitForSeconds(wait);
                }
            }
        }
        yield return null;
    }

   private void TimeTick()
   {
       clone = Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
       enemyN++;
       clone.name = "Enemy_" + enemyN;
       clone.transform.localScale = new Vector3(size, size, size);
       clone.GetComponent<EnemyController>().target = baseObj;
       canResult = false;
   }
}

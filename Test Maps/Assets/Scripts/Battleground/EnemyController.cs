using System;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   public Transform target;
   public int health;
   [SerializeField] private GameObject enemyGameObject;
   [SerializeField] private int id;
   [SerializeField] private CSVManager hp;
   [SerializeField] private int enemyDamage = 25;
   private NavMeshAgent enemy;
   private bool canDestroy;
   

   void Start()
   {
       enemy = GetComponent<NavMeshAgent>();
       enemy.speed = Int32.Parse(hp.rows[id][2]);
       health = Int32.Parse(hp.rows[id][1]);
       StartCoroutine("IEnemyMovement");
   }

   void FixedUpdate()
   {
       StartCoroutine("IEnemyDamaging");

       if (health <= 0)
       {
           StopCoroutine("IEnemyDamaging");
           enemy.isStopped = true;
           canDestroy = true;
       }
   }

   void LateUpdate()
   {
       if(canDestroy) Destroy(enemyGameObject);
   }

   private IEnumerator IEnemyMovement()
   {
       enemy.destination = target.position;
       yield break;
   }

   private IEnumerator IEnemyDamaging()
   {
       Invoke("Damaging", Time.deltaTime);
       yield break;
   }

   private void Damaging()
   {
       if (enemy.remainingDistance == 0)
       {
           target.GetComponent<BaseParams>().health -= enemyDamage;
           StopCoroutine("IEnemyMovement");
           Destroy(enemyGameObject); 
       }
   }
}

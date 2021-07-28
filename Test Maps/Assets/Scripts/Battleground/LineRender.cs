using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class LineRender : MonoBehaviour
{
        public Transform target;
       [SerializeField] private GameObject enemyGameObject;
       [SerializeField] private EnemySpawner ev;
       private NavMeshAgent enemy;
       private bool canDestroy;
       
    
       void Start()
       {
           enemy = GetComponent<NavMeshAgent>();
           StartCoroutine("IEnemyMovement");
       }
    
       void FixedUpdate()
       {
           StartCoroutine("IEnemyDamaging");
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
               StopCoroutine("IEnemyMovement");
               Destroy(enemyGameObject); 
           }
       }
}

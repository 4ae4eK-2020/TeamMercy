using UnityEngine;
using UnityEngine.AI;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public GameObject[] enemyes;
    
    void FixedUpdate()
    {
        enemyes = GameObject.FindGameObjectsWithTag("Enemy");
    }
    
}

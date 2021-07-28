using UnityEngine;

public class BaseParams : MonoBehaviour
{
    public int health;
    [SerializeField] private int defaultHealth; 

    void Start()
    {
        health = defaultHealth;
    }
 }

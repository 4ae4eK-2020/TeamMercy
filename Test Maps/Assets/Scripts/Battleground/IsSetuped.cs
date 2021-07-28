using UnityEngine;

public class IsSetuped : MonoBehaviour
{
    public bool setuped;
    private HeroController hSet;
    
    void Update()
    {
        if (GetComponentInChildren<HeroController>() != null)
        {
            hSet = GetComponentInChildren<HeroController>();
            setuped = hSet.setUp;
        }
    }
}

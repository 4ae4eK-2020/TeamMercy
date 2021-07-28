using UnityEngine;

public class CoinMainer : MonoBehaviour
{
    public int coinCount = 10;
    [SerializeField] private float coolDown;
    [SerializeField] private GameObject background;
    
    
    private float timeCd;

    void FixedUpdate()
    {
        if(!background.activeSelf)
        {
            timeCd += Time.deltaTime;
            if (timeCd >= coolDown) 
            { 
                coinCount++;
                timeCd = 0;
            } 
        }
    }
}

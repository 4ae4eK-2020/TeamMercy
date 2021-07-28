using UnityEngine;

public class URLManager : MonoBehaviour
{
    public void OpenUrl(string url)
    {
        Application.OpenURL("https://" + url);
    }
}

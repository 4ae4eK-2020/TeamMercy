using UnityEngine;
using System.IO;
using System.Linq;

public class CSVManager : MonoBehaviour
{
    private string m_path;
    [SerializeField] private string fileName;
    [HideInInspector] public string[][] rows;

    void Awake()
     {
         m_path = Path.Combine(Application.dataPath, fileName);
         rows = File.ReadAllLines(m_path).Select(l => l.Split(',').ToArray()).ToArray();
     }
}

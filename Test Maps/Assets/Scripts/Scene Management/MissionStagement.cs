using System.Collections;
using JSONManagement;
using UnityEngine;
using UnityEngine.UI;

public class MissionStagement : MonoBehaviour
{
    [SerializeField] private Image mission;
    [SerializeField] private Button missionButton;
    [SerializeField] private JsonManager jsonManager;
    [SerializeField] private MissionStagement nextMission;
    void Awake()
    {
        jsonManager.LoadJson("mission");
    }

    void Start()
    {
        StartCoroutine(ISetStage());
    }

    void OnDestroy()
    {
        jsonManager.SaveJson("mission");
    }

    private IEnumerator ISetStage()
    {
        while (true)
        {
            if(jsonManager.mission.Stage == 2 && nextMission.jsonManager.mission.Stage != 2) nextMission.jsonManager.mission.Stage = 1;
            switch (jsonManager.mission.Stage)
            {
                case 0:
                    mission.material.color = Color.gray;
                    missionButton.interactable = false;
                    break;
                case 1:
                    mission.material.color = Color.blue;
                    missionButton.interactable = true;
                    break;
                case 2:
                    mission.material.color = Color.green;
                    break;
            }

            yield return null;
        }
    }
}

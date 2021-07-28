using UnityEngine;
using Structs;
using System.IO;

namespace JSONManagement
{
    public class JsonManager : MonoBehaviour
    {
        public playerInfo player;
        [SerializeField] private int HeroID;
        public HeroParamsStruct selectedHero;
        public SettingsStruct settings;
        public MissionStruct mission;

        public bool isSaved;
        
        [SerializeField] private string savePath;
        [SerializeField] private string saveFileNameJson;
        [SerializeField] private string saveFileNamePlayer;
        [SerializeField] private string saveFileNameSettings;
        [SerializeField] private string saveFileNameMission;
        
        public void SaveJson(string _param)
        {
            switch (_param)
            {
                case "json":
                    
                    JsonStruct jsonParams = new JsonStruct
                    {
                        HeroID = HeroID,
                        selectedHero = selectedHero
                    };
                
                    saveFileNameJson = "data_" + HeroID + ".json";
                    savePath = Path.Combine(Application.dataPath, saveFileNameJson);
                
                    string json = JsonUtility.ToJson(jsonParams, true);
            
                    File.WriteAllText(savePath, json);
                    break;
                
                case "player": 
                    
                    PlayerStruct playerParams = new PlayerStruct
                    {
                        player = player
                    };
                
                    saveFileNamePlayer = "player_info.json";
                    savePath = Path.Combine(Application.dataPath, saveFileNamePlayer);
                
                    string jsonPlayer = JsonUtility.ToJson(playerParams, true);
            
                    File.WriteAllText(savePath, jsonPlayer);
                    break;
                
                case "settings":

                    SettingsStruct settingsParams = new SettingsStruct
                    {
                        isMute = settings.isMute,
                        size = settings.size,
                        mode = settings.mode,
                        volume = settings.volume,
                        music = settings.music,
                        sounds = settings.sounds,
                        languageInt = settings.languageInt
                    };

                    saveFileNameSettings = "settings.json";
                    savePath = Path.Combine(Application.dataPath, saveFileNameSettings);

                    string jsonSettings = JsonUtility.ToJson(settingsParams, true);
                    
                    File.WriteAllText(savePath, jsonSettings);

                    isSaved = true;
                    break;
                
                case "mission":

                    MissionStruct missionStruct = new MissionStruct
                    {
                        Stage = mission.Stage,
                        missionNumber = mission.missionNumber
                    };
                    
                    savePath = Path.Combine(Application.dataPath, saveFileNameMission);

                    string jsonMission = JsonUtility.ToJson(missionStruct, true);
                    
                    File.WriteAllText(savePath,jsonMission);
                    break;
            }
        }

        public void LoadJson(string _param)
        {
            
            
            switch (_param)
            {
             case  "json": 
                 savePath = Path.Combine(Application.dataPath, saveFileNameJson);
                 string json = File.ReadAllText(savePath);
                 
                 JsonStruct paramsFromJson = JsonUtility.FromJson<JsonStruct>(json);
                 HeroID = paramsFromJson.HeroID;
                 selectedHero = paramsFromJson.selectedHero;
                 break;
             
             case "player":
                 savePath = Path.Combine(Application.dataPath, saveFileNamePlayer);
                 string jsonPlayer = File.ReadAllText(savePath);
                 
                 PlayerStruct paramsFromPlayerJson = JsonUtility.FromJson<PlayerStruct>(jsonPlayer);
                 player = paramsFromPlayerJson.player;
                 break;
             
             case "settings":
                 savePath = Path.Combine(Application.dataPath, saveFileNameSettings);
                 string jsonSettings = File.ReadAllText(savePath);
                 
                 SettingsStruct paramsFromSettingsJson = JsonUtility.FromJson<SettingsStruct>(jsonSettings);
                 settings.size = paramsFromSettingsJson.size;
                 settings.mode = paramsFromSettingsJson.mode;
                 settings.volume = paramsFromSettingsJson.volume;
                 settings.music = paramsFromSettingsJson.music;
                 settings.sounds = paramsFromSettingsJson.sounds;
                 settings.languageInt = paramsFromSettingsJson.languageInt;
                 settings.isMute = paramsFromSettingsJson.isMute;
                 break;
             
             case "mission":
                 savePath = Path.Combine(Application.dataPath, saveFileNameMission);
                 string jsonMission = File.ReadAllText(savePath);

                 MissionStruct paramsFromMissionJson = JsonUtility.FromJson<MissionStruct>(jsonMission);
                 mission = paramsFromMissionJson;
                 break;
            }
        }
    }
}
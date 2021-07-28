using JSONManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneScale : MonoBehaviour
{
   [SerializeField] private TMP_Dropdown size;
   [SerializeField] private TMP_Dropdown mode;
   [SerializeField] private RawImage back;
   [SerializeField] private JsonManager jsonManager;
   
   private int width = 1920;
   private int height = 1080;
   private FullScreenMode screenMode = FullScreenMode.FullScreenWindow;

   void Awake()
   { 
      if(size != null && mode != null)
      {
         jsonManager.LoadJson("settings");
         size.value = jsonManager.settings.size;
         mode.value = jsonManager.settings.mode;
      }
   }
   
   void Start()
   {
      back.rectTransform.sizeDelta = new Vector2(2560, 1440);
   }
   
   public void SetScreenResolution()
   {
      switch (size.value)
      {
         case 0:
            width = 1920;
            height = 1080;
            break;
         case 1:
            width = 1280;
            height = 720;
            break;
         case 2:
            width = 2560;
            height = 1440;
            break;
      }
      
      Screen.SetResolution(width, height, screenMode);
      back.rectTransform.sizeDelta = new Vector2(2560, 1440);
      jsonManager.settings.size = size.value;
      jsonManager.SaveJson("settings");
   }

   public void SetScreenMode()
   {
      switch (mode.value)
      {
         case 0: screenMode = FullScreenMode.ExclusiveFullScreen; 
            break;
         case 1: screenMode = FullScreenMode.Windowed; 
            break;
      }
      
      Screen.SetResolution(width, height, screenMode);
      back.rectTransform.sizeDelta = new Vector2(2560, 1440);
      jsonManager.settings.mode = mode.value;
      jsonManager.SaveJson("settings");
   }
}

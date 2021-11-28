using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuGameManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MenuGameManager Instance;

    public InputField nameInputField;
    public string nameText;
    private int m_Points;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    class SaveData
    {
        public InputField nameInputField;
        public string nameText;
        private int m_Points;
    }

    
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.nameText = nameInputField.text;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameInputField.text = data.nameText;
        }
    }
  

}

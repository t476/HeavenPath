using System.IO;
using UnityEngine;

public class Config : MonoBehaviour
{
    public ConfigFile BotConfig;
    public static Config instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        GetJson();
    }

    public void GetJson()
    {
        BotConfig = LoadJsonFromFile();
    }

    private static ConfigFile LoadJsonFromFile()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/config.json");
        if (sr == null)
        {
            return null;
        }
        string json = sr.ReadToEnd();
        sr.Close();
        if (json.Length > 0)
        {
            return JsonUtility.FromJson<ConfigFile>(json);
        }
        return null;
    }
}
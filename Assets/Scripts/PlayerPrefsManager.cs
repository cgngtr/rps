using UnityEngine;

public class PlayerPrefManager : MonoBehaviour
{
    private static PlayerPrefManager instance;

    public static PlayerPrefManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerPrefManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("PlayerPrefManager");
                    instance = singletonObject.AddComponent<PlayerPrefManager>();
                }
            }
            return instance;
        }
    }

    public void SaveValue(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }

    public void SaveValue(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public void SaveValue(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }


    public float GetValue(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }
}

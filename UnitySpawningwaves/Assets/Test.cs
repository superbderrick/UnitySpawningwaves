using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private AvatarData avatarData;
    private void Awake()
    {
        avatarData = LoadData();
    }
    private void Start()
    {
        if (avatarData)
        {
            for (int i = 0; i < avatarData.avatars.Count; i++)
            {
                Debug.Log("Avatar Name: " + avatarData.avatars[i].AvatarName);
                Debug.Log("Avatar Id: " + avatarData.avatars[i].AvatarId);
                Debug.Log("Avatar description: " + avatarData.avatars[i].Description);
            }    
        }
        
    }
    private void OnDisable()
    {
        SaveData();
    }
    void SaveData()
    {
        string json = JsonUtility.ToJson(avatarData);
        File.WriteAllText(Application.streamingAssetsPath + Path.DirectorySeparatorChar + "AvatarData.txt", json);
    }

    AvatarData LoadData()
    {
        AvatarData data = null;
        if (File.Exists(Application.streamingAssetsPath + Path.DirectorySeparatorChar + "AvatarData.txt"))
        {
            data = ScriptableObject.CreateInstance<AvatarData>();
            string json =
                File.ReadAllText(Application.streamingAssetsPath + Path.DirectorySeparatorChar + "AvatarData.txt");
            JsonUtility.FromJsonOverwrite(json, data);
        }
        else
        {
            data = Resources.Load<AvatarData>("Avatar Data");
        }

        return data;

    }
}

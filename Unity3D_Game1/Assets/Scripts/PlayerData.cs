using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<PlayerData>();
                if (instance == null)
                {
                    var a = new GameObject("PlayerData");
                    instance = a.AddComponent<PlayerData>();
                }
            }
            return instance;
        }
    }
    private static PlayerData instance;

    public List<bool> PlayerSkill = new List<bool>();
}

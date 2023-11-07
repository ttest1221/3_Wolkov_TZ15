using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    private string keyPlayer = "Nickname";
    private string keyScore = "Score";
    private string keyBestScore = "BestScore";
    public List<PlayerData> GetLeaders()
    {
        List<PlayerData> list = new List<PlayerData>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new PlayerData()
            {
                nickname = PlayerPrefs.GetString(keyPlayer + (i + 1), "None"),
                score = PlayerPrefs.GetInt(keyScore + (i + 1), 0),
            });
        }
        return list;
    }
    public PlayerData GetPlayer()
    {
        PlayerData data = new PlayerData();
        data.nickname = PlayerPrefs.GetString(keyPlayer, "None");
        data.score = PlayerPrefs.GetInt(keyScore, 0);
        data.bestScore = PlayerPrefs.GetInt(keyBestScore, 0);
        return data;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

[System.Serializable]
public struct leaderboardData {
    public string name;
    public string score;
}

[System.Serializable]
public struct wholeLeaderboard {
    public List<leaderboardData> entries;
}

public class SubmitLeaderboard : MonoBehaviour
{
    public static List<leaderboardData> leaderboardDataList;
    [SerializeField] GameObject toDisable;
    [SerializeField] TextMeshPro toEnable;

    private void Awake() {
        leaderboardDataList = new List<leaderboardData>();
    }

    [SerializeField] TextMeshProUGUI nameField;
    public void Submit() {
        double score = CoreStats.dollars;
        string name = nameField.text;
        StartCoroutine(Upload(score, name));
    }

    public void DisableSubmission() {
        toDisable.SetActive(false);
        toEnable.enabled = true;
    }

    IEnumerator Upload(double score, string name)
    {
        leaderboardData toSend = new leaderboardData();
        toSend.name = name.Split('\u200b')[0];
        toSend.score = score.ToString().Split('.')[0];
        string myData = JsonUtility.ToJson(toSend);
        Debug.Log(myData);
        using (UnityWebRequest www = UnityWebRequest.Put("https://gpu.bokaibi.com/api/dataupload", myData))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Upload complete!");
                GetLeaderboard();
            }
        }
    }

    public void GetLeaderboard() {
        StartCoroutine(GetLeaderboardRoutine());
    }

    IEnumerator GetLeaderboardRoutine() {
        
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://gpu.bokaibi.com/api/leaderboard"))
        {
            Debug.Log("Sending request");
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            //yield return new WaitForSeconds(2.0f);
            Debug.Log("Finished request");
            Debug.Log(webRequest.result);
            Debug.Log(webRequest.downloadHandler.text);
            wholeLeaderboard leaderboard = new wholeLeaderboard();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                break;
                case UnityWebRequest.Result.DataProcessingError:
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    break;
                case UnityWebRequest.Result.Success:
                    leaderboard = JsonUtility.FromJson<wholeLeaderboard>(webRequest.downloadHandler.text);
                    break;
            }
            foreach (leaderboardData data in leaderboard.entries) {
                Debug.Log(data.name);
                Debug.Log(data.score);
                LocalLeaderboard.AddEntry(data.name, double.Parse(data.score));
            }
            DisableSubmission();
            yield return null;
        }
    }


}

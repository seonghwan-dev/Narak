using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class OutboudTest : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Start WWW!";
        
        UnityWebRequest request = UnityWebRequest.Get("https://seonghwan-dev.github.io/api/autochessframework/registry.json");
        yield return request.SendWebRequest();
        
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError )
        {
            // Debug.LogError(request.error);
            GetComponent<TextMeshProUGUI>().text = request.error;
        }
        else
        {
            //다운로드 데이터를 파일로 저장
            string json = request.downloadHandler.text;
            GetComponent<TextMeshProUGUI>().text = json;
        }
    }
}

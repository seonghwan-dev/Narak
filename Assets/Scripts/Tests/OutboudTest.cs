using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class OutboudTest : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<Button>().onClick.AddListener(OnClick);
    }

    // Start is called before the first frame update
    IEnumerator Run()
    {
        var input = FindObjectOfType<TMP_InputField>();
        GetComponent<TextMeshProUGUI>().text = "Start WWW!";
        
        // UnityWebRequest request = UnityWebRequest.Get("https://seonghwan-dev.github.io/api/autochessframework/registry.json");
        UnityWebRequest request = UnityWebRequest.Get(input.text);
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
    
    private void FixedUpdate()
    {
    }

    public void OnClick()
    {
        StartCoroutine(Run());
    }
}

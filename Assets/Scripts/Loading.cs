using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
    public string SceneName;
    public Image LoadingImage;

	// Use this for initialization
    
	void Start () {
        CharacterControllerScript.previousScene = SceneManager.GetActiveScene().name;
        CharacterControllerScript.curentScene = SceneName;
        //CCSAndroid.previousScene = SceneManager.GetActiveScene().name; //Android
        //CCSAndroid.curentScene = SceneName; //Android
        StartCoroutine(Assync_Load());
        
    }
	
	// Update is called once per frame
	IEnumerator Assync_Load()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneName);
        while (!op.isDone)
        {
            float progress = op.progress / 0.9f;
            LoadingImage.fillAmount = progress;
            yield return null;
        }
    }
}

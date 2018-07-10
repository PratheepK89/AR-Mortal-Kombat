using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizePanel : MonoBehaviour {

    public GameObject qualityMeter;
    private string sceneName;
    
	// Use this for initialization
	void Start () {
        sceneName = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
        if (DefaultTrackableEventHandler.objectFound)
        {
            this.gameObject.SetActive(false);
            qualityMeter.SetActive(false);
        }
	}

    public void RefreshButton()
    {
        SceneManager.LoadScene(sceneName);
    }
}

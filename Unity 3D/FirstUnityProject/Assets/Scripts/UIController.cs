using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField] private Text scorelabel;
    [SerializeField] private SettingPopup settingPopup;

	// Use this for initialization
	void Start () {
        settingPopup.Close();
	}
	
	// Update is called once per frame
	void Update () {
        scorelabel.text = Time.realtimeSinceStartup.ToString();
	}

    public void OnOpenSetting()
    {
        settingPopup.Open();
    }

    public void OnPointerDown()
    {
        Debug.Log("Pointer down");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTimeOfDay : MonoBehaviour {
    [SerializeField] Light mainLight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeDay()
    {
        StartCoroutine(LightRotate());
    }

    private IEnumerator LightRotate()
    {
        
        for (int i = 1; i< 361; i++)
        {
            mainLight.transform.Rotate(mainLight.transform.position, i* Time.deltaTime);
            yield return new WaitForSeconds(0.3f);
            Debug.Log(i);
        }
    }
}

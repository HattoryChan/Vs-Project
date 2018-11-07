using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactiveTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if(behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        for (int i = 0; i < 30; i++)
        {
            this.transform.Rotate(Time.deltaTime*150, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}

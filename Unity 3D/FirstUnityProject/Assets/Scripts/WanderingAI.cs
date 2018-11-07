using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WanderingAI : MonoBehaviour {

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    public float speed = 3.0f;
    public float obstacleRange = 3.0f;

    private bool _alive;
	// Use this for initialization
	void Start () {
        _alive = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray Shootray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(Shootray, 1.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if(hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;

                        _fireball.transform.position =
                            transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if(hit.distance < obstacleRange)
                {
                    if (!hitObject.GetComponent<Fireball>())
                    {
                        float angle = Random.Range(-50, 50);
                        transform.Rotate(0, angle, 0);
                    }
                }
            }
        }
       
	}
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }        
}

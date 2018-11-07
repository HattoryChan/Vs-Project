using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(_enemy == null)
        {
            FPSInput PlayerPoint = GetComponent<FPSInput>();
            _enemy = Instantiate(enemyPrefab) as GameObject;
            //_enemy.transform.position = new Vector3(0, 1, 0);
            float enemySpawnX = GameObject.Find("Player").transform.position.x + Random.Range(5, 15);
            float enemySpawnZ = GameObject.Find("Player").transform.position.z + Random.Range(2, 12);

            _enemy.transform.position = new Vector3(
                enemySpawnX > 28 || enemySpawnX < -28 ? Random.Range(1, 25) : enemySpawnX,
                1,
                enemySpawnZ > 18 || enemySpawnZ < -28 ? Random.Range(1, 25) : enemySpawnZ);



            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }

	}
}

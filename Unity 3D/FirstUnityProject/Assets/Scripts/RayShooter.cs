﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour {

    Camera _camera;
	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();

       // Cursor.lockState = CursorLockMode.Locked;
      //  Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) &&
           !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 point = new Vector3(
              _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                reactiveTarget target = hitObject.GetComponent<reactiveTarget>();                
                if(target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }

            }
        }
        
	}


    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 4;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
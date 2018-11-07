using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class RayBlink : MonoBehaviour
{
    
    Camera _camera;
    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(
              _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
             //   Vector3 cameraMove = new Vector3();
             //   cameraMove = hit.point;
                //  cameraMove.y = -9.8f;
                //  cameraMove *= Time.deltaTime;
                //  cameraMove = transform.TransformDirection(cameraMove);
                this.transform.position = hit.point;
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
}

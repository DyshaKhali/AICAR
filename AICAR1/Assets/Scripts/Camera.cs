using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    public GameObject CamObj;
    public Camera cam;

    public int state = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float currentSensetivity = 1f;
    public float sensitivity = 10f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;
    private float yRot = 0f;


    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position;
        

        if (Input.GetKeyDown(KeyCode.F1))
            state = 1;
        if (Input.GetKeyDown(KeyCode.F2))
            state = 2;
        if (Input.GetKeyDown(KeyCode.F3))
            state = 3;

        switch (state)
        {
            case 1:
                CamObj.transform.LookAt(target.transform);
                break;
            case 2:
                currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
                currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
                currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
                currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
                CamObj.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
                break;
            case 3:
                Vector3 rot = new Vector3(20f, CamObj.transform.rotation.y + 1f);
                CamObj.transform.rotation = Quaternion.Euler(rot);
                break;
        }
    }
}

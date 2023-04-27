using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private Transform laserObject;

    private void Awake()
    {
        laserObject = gameObject.GetComponent<Transform>();
    }
    void Update()
    {

        Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(screenRay, out RaycastHit hit))
        {
            laserObject.LookAt(2 * transform.position - hit.point);
        }
    }
}

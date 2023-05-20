using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class RayCastGun : MonoBehaviour
{

    [Header("Atribuições de Objetos")]
    public Camera playerCamera;
    public Transform laserOrigin;
    public Transform laserObject;

    [Header("Seleção de Lasers e Camadas")]
    public LayerMask maskLayer;
    public LasersTypes currentLaser;

    public bool useLaserBlue = false;

    public UnityEvent OnClickLaser;


    private LineRenderer laserLine;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        laserObject = GetComponent<Transform>();
        currentLaser = LasersTypes.laserRed;
    }



    void Update()
    {
        changeLaser();
        LaserFire();
    }

    private void changeLaser()
    {

        if (Input.GetKeyDown("1"))
        {
            laserLine.startColor = Color.red;
            laserLine.endColor = Color.red;
            currentLaser = LasersTypes.laserRed;
        }
        else if(Input.GetKeyDown("2") && useLaserBlue)
        {
            laserLine.startColor = Color.blue;
            laserLine.endColor = Color.blue;
            currentLaser = LasersTypes.laserBlue;
        }
    }

    private void LaserFire()
    {

        if(Input.GetMouseButtonDown(0))
        {
            OnClickLaser?.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            
            laserLine.enabled = true;
            laserLine.SetPosition(0, laserOrigin.position);
            Ray rayCameraToMouse = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayCameraToMouse, out RaycastHit raycastHit, maskLayer))
            {
                laserLine.SetPosition(1, raycastHit.point);
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            laserLine.enabled = false;
        }
    }
}
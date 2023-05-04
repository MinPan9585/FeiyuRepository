using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public Camera mainCam;
    public LineRenderer lineRen;
    public DistanceJoint2D distanceJoi;
    void Start()
    {
        distanceJoi.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition);
            lineRen.SetPosition(0, mousePos);
            lineRen.SetPosition(1, transform.position);
            lineRen.enabled = true;
            distanceJoi.connectedAnchor = (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition);
            distanceJoi.enabled = true;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            distanceJoi.enabled = false;
            lineRen.enabled = false;
        }

        if (distanceJoi.enabled)
        {
            lineRen.SetPosition(1, transform.position);
        }
    }
}

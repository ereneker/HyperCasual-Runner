using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayWall : MonoBehaviour
{
    public Camera mainCam;
    public GameObject spray;
    public GameObject sprayWall;
    private LineRenderer lineRenderer;
    Vector3 lastPos;

    private void Update()
    {
        
        StartSpraying();
    }

    public void StartSpraying()
    {
        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit, 1f))
            {
                if (hit.collider.gameObject.tag == "Wall")
                {
                    InstantiateSpray();
                }
                

            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePos = sprayWall.transform.position;
            if (mousePos != this.lastPos)
            {
                if (Physics.Raycast(ray, out hit, 1f))
                {
                    if (hit.collider.gameObject.tag == "Wall")
                    {
                        AddPoint(mousePos);
                        this.lastPos = mousePos;
                    }
                }
                
                
            }
        }
        else
        {
            this.lineRenderer = null;
        }
    }
    public void InstantiateSpray()
    {
        GameObject sprayObject = Instantiate(spray);
        this.lineRenderer = sprayObject.GetComponent<LineRenderer>();
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos = sprayWall.transform.position;

        this.lineRenderer.SetPosition(0, mousePos);
        this.lineRenderer.SetPosition(1, mousePos);
    }
    public void AddPoint(Vector2 pointPos)
    {
        this.lineRenderer.positionCount++;
        int positionIndex = lineRenderer.positionCount - 1;
        this.lineRenderer.SetPosition(positionIndex, pointPos);
    }
}

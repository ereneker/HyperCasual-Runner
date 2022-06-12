using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpray : MonoBehaviour
{
    List<Vector3> linePoints;
    LineRenderer lineRenderer;
    GameObject newLine;
    float wallDist;
    public float lineWidth;
    float timer;
    public float timerDelay;
    private void Start()
    {
        linePoints = new List<Vector3>();
        timer = timerDelay;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1f))
            {
                if (hit.collider.gameObject.tag == "Wall")
                {
                    newLine = new GameObject();
                    lineRenderer = newLine.AddComponent<LineRenderer>();
                    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                    lineRenderer.startColor = Color.red;
                    lineRenderer.endColor = Color.red;
                    lineRenderer.startWidth = lineWidth;
                    lineRenderer.endWidth = lineWidth;
                }
                else
                {
                    linePoints.Clear();
                }
                    
                

            }
        }

        if (Input.GetMouseButton(0))
        {
            Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), GetMousePosition(), Color.red);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (Physics.Raycast(ray, out hit, 1f))
                {
                    if (hit.collider.gameObject.tag == "Wall")
                    {
                        linePoints.Add(GetMousePosition());
                        lineRenderer.positionCount = linePoints.Count;
                        lineRenderer.SetPositions(linePoints.ToArray());

                        timer = timerDelay;
                    }
                }
                
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit, 1f))
            {
                if (hit.collider.gameObject.tag == "Wall")
                {

                    linePoints.Clear();
                }

            }
            
        }
    }
    private Vector3 GetMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1f))
        {
            if (hit.collider.gameObject.tag == "Wall")
            {
                this.wallDist = hit.distance;
            }
            
        }
        return ray.origin + ray.direction * this.wallDist;
    }
}

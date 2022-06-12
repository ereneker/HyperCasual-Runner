using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlatformTouch : MonoBehaviour
{
    [SerializeField] private Rigidbody boyRb;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private Camera mainCamera;
    private bool isMoving;

    private void Update()
    {
        if (boyRb.transform.rotation.eulerAngles.z > 0 && boyRb.transform.parent != null)
        {
            boyRb.transform.Rotate(-Time.deltaTime*10f, 0f, 0f, Space.World);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag=="Player")
        {
            isMoving = true;
            collision.collider.transform.SetParent(transform);
            

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody.tag == "Player")
        {
            collision.collider.transform.SetParent(null);

        }
    }
}

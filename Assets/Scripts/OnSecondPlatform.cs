
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSecondPlatform : MonoBehaviour
{
    [SerializeField] private Rigidbody boyRb;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private Camera mainCamera;


    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody.tag == "Player")
        {
            
            other.collider.transform.SetParent(transform);


        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.rigidbody.tag == "Player")
        {
            other.collider.transform.SetParent(null);

        }
    }
}



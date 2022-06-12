using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] rotatingCylinder;

    private void Update()
    {
        for(int i=0; i < rotatingCylinder.Length; i++)
        {
            rotatingCylinder[i].transform.Rotate(Time.deltaTime * 10f, 0f, 0f, Space.World);

        }
    }
}

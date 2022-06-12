using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMechanic : MonoBehaviour
{
    private float cursorPosZ;
    private float movePosZ;
    public float MovePosZ => movePosZ;
    

    private void Update()
    {
        swerveMovement();
        
    }

    private void swerveMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursorPosZ = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            movePosZ = Input.mousePosition.x - cursorPosZ;
            cursorPosZ = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            movePosZ = 0;
        }
    }
    
}

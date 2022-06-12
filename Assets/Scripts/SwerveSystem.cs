using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveSystem : MonoBehaviour
{
    [SerializeField] private float changingPosSpeed = 2f;
    private SwerveMechanic swerveMechanic;

    private void Awake()
    {
        this.swerveMechanic = GetComponent<SwerveMechanic>();
    }
    private void Update()
    {
        SwerveLimit();
    }



    private void SwerveLimit()
    {
        float Swerving = changingPosSpeed * swerveMechanic.MovePosZ * Time.deltaTime;
        transform.Translate(Swerving, 0, 0);
    }
}

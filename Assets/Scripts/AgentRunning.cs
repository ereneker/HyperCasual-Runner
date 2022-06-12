using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentRunning : MonoBehaviour
{
    [SerializeField] private Transform movePosition;
    private NavMeshAgent navMesh;
    public Rigidbody[] aiModels;
    public Vector3[] startPos = new Vector3[10];
    private void Start()
    {
        for (int i = 0; i < this.aiModels.Length; i++)
        {
            this.startPos[i] = this.aiModels[i].transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < this.aiModels.Length; i++)
        {
            if (collision.collider.tag == "Obstacle")
            {
                this.aiModels[i].transform.position = this.startPos[i];
            }
        }
    }

}

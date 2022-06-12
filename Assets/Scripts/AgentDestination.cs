using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentDestination : MonoBehaviour
{
    [SerializeField] private Transform movePosition;
    private NavMeshAgent navMesh;
    Vector3 startPos;
    [SerializeField] private Rigidbody agentRB; 
    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        startPos = transform.position;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        navMesh.destination = movePosition.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
            if (collision.collider.tag == "Obstacle")
            {
                agentRB.transform.position = this.startPos;
            }
        
    }
}

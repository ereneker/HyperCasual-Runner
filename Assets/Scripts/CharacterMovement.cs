using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    
    public bool startRunning = false;
    public Rigidbody playerRb;

    private int startGame = 0;
    private int force = 10;
    private SwerveSystem swerveSystem;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Animator characterAnims;
    Vector3 startPos;
    private void Awake()
    {
        swerveSystem = GetComponent<SwerveSystem>();
    }
    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        if (this.startGame <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.startRunning = true;
                this.startGame++;
            }
        }
        
        CharacterRunning();

        playerRb.transform.Rotate(0f, 0f, 0f, Space.World);
    }
    

    public void CharacterRunning()
    {
        if (this.startRunning)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            characterAnims.SetBool("isMoving", true);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            playerRb.transform.position = startPos;
        }
        if (collision.collider.tag == "MovingObstacle")
        {
            Vector3 dir = new Vector3(100f, 0f, 0f);
            dir.Normalize();
            this.playerRb.AddForce(dir * 100);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            this.startRunning = false;
            characterAnims.SetBool("isMoving", false);
            characterAnims.SetBool("isFinished", true);
            swerveSystem.enabled = false;
        }
        

    }

    
}

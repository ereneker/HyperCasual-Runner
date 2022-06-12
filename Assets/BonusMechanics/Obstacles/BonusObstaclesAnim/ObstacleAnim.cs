using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnim : MonoBehaviour
{
    
    public Animator rotatorAnim;
    private float timer = 0f;

    private void Start()
    {
        this.timer = Random.Range(1f, 4f);
        Debug.Log(timer);
    }
    private void Update()
    {
        
        StartCoroutine(RotatorAnimTimer());
        

    }

    IEnumerator RotatorAnimTimer()
    {
       
        yield return new WaitForSeconds(timer);

        if (!this.rotatorAnim.GetBool("obsSet"))
            this.rotatorAnim.SetBool("obsSet", true);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutScript : MonoBehaviour
{
    public Animator donutAnim;
    

    private void Update()
    {
        InvokeRepeating("AnimPlay", 2f, 4f);
    }

    public void AnimPlay()
    {
        if (!this.donutAnim.GetBool("isMoving"))
        {
            this.donutAnim.SetBool("isMoving", true);
        }
        else
        {
            this.donutAnim.SetBool("isMoving", false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationUpdater : MonoBehaviour
{
    private List<GameObject> cacti;
    private const float distance = 0.25f;
    private Animator animator;
    private bool IsAttacking;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        cacti = GameObject.FindGameObjectsWithTag("Cactus").Where(gameObject => gameObject.activeSelf == true).ToList();

        cacti.Remove(this.gameObject);

        IsAttacking = false;

        foreach (GameObject cactus in cacti)
        {
            if (IsClose(cactus))
            {
                animator.SetBool("IsAttacking", true);
                IsAttacking = true;
            }
        }

        if(!IsAttacking)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private bool IsClose(GameObject cactus)
    {
        if(cactus.activeSelf == false) return false;

        return (Math.Abs(transform.parent.position.x - cactus.transform.parent.position.x) < distance && 
                Math.Abs(this.transform.parent.position.y - cactus.transform.parent.position.y) < distance && 
                Math.Abs(this.transform.parent.position.z - cactus.transform.parent.position.z) < distance);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    Animator animator;
    
    public float moveSpeed = 0.2f;
    
    Vector3 stopPosition;


    float walkTime;
    public float walkCounter;
    float waitTime;
    public float waitCounter;
    
    int walkDirection;

    public bool isWalking;
    private void Start()
    {
        animator = GetComponent<Animator>();
        walkTime = Random.Range(3, 6);
        waitTime = Random.Range(5, 7);

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();


    }
    private void Update()
    {
        if (isWalking)
        {
            animator.SetInteger("AnimIndex", 1);
            walkCounter -= Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, walkDirection, 0);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            if(walkCounter <= 0)
            {
                stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                isWalking = false;
                transform.position = stopPosition;
                animator.SetInteger("AnimIndex", 0);
                waitCounter = waitTime;
                
            }

        }
        else
        {
            waitCounter -= Time.deltaTime;
            if (waitCounter <= 0)
            {
                ChooseDirection();
            }
        }
    }










    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 360);
        isWalking = true;
        walkCounter = walkTime;
    }
}

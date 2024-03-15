using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
     [SerializeField] private Rigidbody2D rb;
     [SerializeField] private BoxCollider2D coll;
     [SerializeField] private GameObject pointA;
     [SerializeField] private GameObject pointB;
     private Transform currentPosition;
     private Animator anim;

    [SerializeField] private float loopTime;
    [SerializeField] private float moveSpeed;

    private void Start()
    {

        currentPosition = pointB.transform;
        anim = GetComponent<Animator>();
        //anim.SetBool("isFlying",true);
        
    }

    private void Update()
    {
        Vector2 point = currentPosition.position - transform.position;
        if (currentPosition == pointB.transform)
        {
            rb.velocity = new Vector2(0, moveSpeed);
            
        }
        else
        {
            rb.velocity = new Vector2(0,-moveSpeed);
        }

        if (Vector2.Distance(transform.position,currentPosition.position)< 0.5f && currentPosition == pointB.transform )
        {
            currentPosition = pointA.transform;
        }
        if (Vector2.Distance(transform.position,currentPosition.position)< 0.5f && currentPosition == pointA.transform )
        {
            currentPosition = pointB.transform;
        }
    }
}

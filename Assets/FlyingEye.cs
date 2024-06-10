using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyingEye : MonoBehaviour
{
    public float waypointReachedDistance = 0.5f;
    public float flightSpeed = 0.5f;
    public DetectionZone biteDetectionZone;
     public Collider2D deathCollider;
    public List<Transform> waypoints;
    Animator animator;
    Rigidbody2D rb;
    public Damagable damagable;



    Transform nextWaypoint;
    int waypointNum = 0;

    public bool _hasTarget = false;
    

    public bool HasTarget { get{
        return _hasTarget; 

    } private set{
        _hasTarget = value;
        animator.SetBool(AnimationStrings.hasTarget, value);
    } }

    private void Awake(){
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        damagable = GetComponent<Damagable>();
    }

    private void Start(){
        nextWaypoint = waypoints[waypointNum];
    }

    private void OnEnable(){
        damagable.damagableDeath.AddListener(OnDeath);
    }

    // Update is called once per frame
    void Update()
    {
        HasTarget = biteDetectionZone.detectedColliders.Count > 0;
        
    }

    private void FixedUpdate(){
        if(damagable.IsAlive)
        {
            if(CanMove)
            {
                Flight();
            }else{
                rb.velocity = Vector3.zero;
            }
        }
    }

        public bool CanMove{
        get{
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    private void Flight()
    {
        Vector2 directionToWaypoint = (nextWaypoint.position - transform.position).normalized;

        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        rb.velocity = directionToWaypoint * flightSpeed;
        UpdateDirection();

        if(distance <= waypointReachedDistance)
        {
            waypointNum++;

            if(waypointNum >= waypoints.Count)
            {
                waypointNum = 0;
            }

            nextWaypoint = waypoints[waypointNum];

        }

    }

    private void UpdateDirection()
    {
        Vector3 localScale = transform.localScale;
        if(transform.localScale.x > 0)
        {
            if(rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1 * localScale.x, localScale.y, localScale.z);
            }

        }
        else{
               if(rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1 * localScale.x, localScale.y, localScale.z);
            }

        }
    }

    public void OnDeath(){
            rb.gravityScale = 2f;
            rb.velocity = new Vector2(0, rb.velocity.y);
            deathCollider.enabled = true;
    }
}

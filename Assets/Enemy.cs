using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class Enemy : MonoBehaviour
{
    public float walkSpeed = 0.6f;
    public float walkStopRate = 0.8f;

    Rigidbody2D rb;
    TouchingDirections touchingDirections;
    public DetectionZone attackZone;
    public DetectionZone cliffDetectionZone;

    Animator animator;


    public enum WalkableDirection { Right, Left };
    private WalkableDirection _walkDirection = WalkableDirection.Right;
    private Vector2 walkDirectionVector = Vector2.right;

    public WalkableDirection WalkDirection {
        get { return _walkDirection; }
        set {
            if (_walkDirection != value) {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                walkDirectionVector = value == WalkableDirection.Right ? Vector2.right : Vector2.left;
            }
            _walkDirection = value;
        }
    }

    public bool _hasTarget = false;
    public bool HasTarget { get{
        return _hasTarget; 

    } private set{
        _hasTarget = value;
        animator.SetBool(AnimationStrings.hasTarget, value);
    } }

    public bool CanMove{
        get{
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
     
    }

    void Update(){
        HasTarget = attackZone.detectedColliders.Count > 0;
    }

    private void FixedUpdate() {
        if (touchingDirections.IsGrounded && touchingDirections.IsOnWall) {
            FlipDirection();
        }
        if(CanMove)
            rb.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rb.velocity.y);
        else
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, walkStopRate), rb.velocity.y);
    }

    private void FlipDirection() {
        WalkDirection = WalkDirection == WalkableDirection.Right ? WalkableDirection.Left : WalkableDirection.Right;
        
    }

        public bool LockVelocity { get {
        return animator.GetBool(AnimationStrings.lockVelocity);
    } 
    set{
        animator.SetBool(AnimationStrings.lockVelocity, value);
    }
     }

    
    public void OnAnimationEventExample()
    {
        Debug.Log("Animation event triggered");
    }

    public void OnHit(int damage, Vector2 knockback){
        LockVelocity = true;
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }

    public void OnCliffDetected(){
        if(touchingDirections.IsGrounded)
        {
            FlipDirection();
        }

    }



}

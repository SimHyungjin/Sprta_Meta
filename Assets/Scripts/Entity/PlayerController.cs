using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : BaseController
{
    [SerializeField][Range(0, 10)] protected float moveSpeed = 2f;
    [SerializeField][Range(0, 10)] protected float boostSpeed = 6f;

    private Vector2 inputKey;
    private float currentSpeed;
    private bool isBoosting;

    private Animator animator;
    private Rigidbody2D rb;

    protected override void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void FixedUpdate()
    {
        if (!isMoving && inputKey != Vector2.zero)
            StartMove();
        MoveToTarget();
        PlayerAnim(inputKey);
    }

    private void StartMove()
    {
        targetPosition = (Vector2)rb.position + inputKey * GridSize;
        if (IsColliding(targetPosition))
        {
            return;
        }
        isMoving = true;
        Boost();
    }

    private void MoveToTarget()
    {
        if (!isMoving) return;
        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, currentSpeed * Time.fixedDeltaTime));
        if (Vector2.Distance(rb.position, targetPosition) < 0.01f)
        {
            rb.position = targetPosition;
            isMoving = false;
        }
    }

    private bool IsColliding(Vector2 target)
    {
        int playerlayer = LayerMask.GetMask("Player");
        int triggerobj = LayerMask.GetMask("TriggerObj");
        int mask = ~(playerlayer | triggerobj);
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction, GridSize.x,mask);
        if (hit.collider != null)
        {
            return true; // 충돌 발생
        }
        return false; // 이동 가능
    }






    public void SetInput(Vector2 input)
    {
        if (!isMoving)
            inputKey = input;
    }

    public void SetBoost(bool boost)
    {
        isBoosting = boost;
    }

    private void Boost()
    {
        currentSpeed = isBoosting ? boostSpeed : moveSpeed;
        animator.speed = currentSpeed / 3;
    }

    private void PlayerAnim(Vector2 move)
    {
        animator.SetFloat("MoveX", move.x);
        animator.SetFloat("MoveY", move.y);
    }
}
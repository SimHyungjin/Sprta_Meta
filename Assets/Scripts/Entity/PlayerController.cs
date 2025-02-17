using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : BaseController
{
    [SerializeField][Range(0, 10)] protected float moveSpeed = 2f;
    [SerializeField][Range(0, 10)] protected float boostSpeed = 6f;

    private Vector2 inputKey;
    private float currentSpeed;
    private bool isBoosting;

    private Animator animator;

    protected override void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    protected override void Update()
    {
        PlayerMovment();
    }

    public void SetInput(Vector2 input)
    {
        //UnityEngine.Debug.Log(input);
        inputKey = input;
    }
    public void SetBoost(bool boost)
    {
        //UnityEngine.Debug.Log(boost);
        isBoosting = boost;
    }

    public void PlayerMovment()
    {
        if (!isMoving && inputKey != Vector2.zero)
        {
            targetPosition = (Vector2)transform.position + inputKey * GridSize; // 이동할 위치 계산
            
            if (!IsColliding(targetPosition))
            {
                isMoving = true; // 이동 시작
                Boost();
                StartCoroutine(TargetToMovement()); // 이동 실행
            }
            else
                isMoving = false; 
        }
        PlayerAnim(inputKey); // 애니메이션 실행
    }

    public IEnumerator TargetToMovement()
    {
        while (Vector2.Distance(transform.position, targetPosition) > 0.01f) // 목표 위치까지 이동
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition; // 정확한 위치 조정
        isMoving = false; // 이동 완료
    }

    //앞에 콜라이더가 있는지 확인
    private bool IsColliding(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized; // 방향 계산
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, GridSize.x);

        UnityEngine.Debug.DrawRay(transform.position, direction * GridSize.x, Color.red, 1f);
        UnityEngine.Debug.Log(hit.collider.name);

        if (hit.collider != null && !hit.collider.CompareTag("Player"))
            return true;

        return false;
    }

    //입력을 받으면 부스트
    private void Boost()
    {
        currentSpeed = isBoosting ? boostSpeed : moveSpeed;
        animator.speed = currentSpeed/3;
    }

    private void PlayerAnim(Vector2 move)
    {
        move *= 5;
        animator.SetFloat("MoveX", move.x);
        animator.SetFloat("MoveY", move.y);
    }
}


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
            targetPosition = (Vector2)transform.position + inputKey * GridSize; // �̵��� ��ġ ���
            
            if (!IsColliding(targetPosition))
            {
                isMoving = true; // �̵� ����
                Boost();
                StartCoroutine(TargetToMovement()); // �̵� ����
            }
            else
                isMoving = false; 
        }
        PlayerAnim(inputKey); // �ִϸ��̼� ����
    }

    public IEnumerator TargetToMovement()
    {
        while (Vector2.Distance(transform.position, targetPosition) > 0.01f) // ��ǥ ��ġ���� �̵�
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition; // ��Ȯ�� ��ġ ����
        isMoving = false; // �̵� �Ϸ�
    }

    //�տ� �ݶ��̴��� �ִ��� Ȯ��
    private bool IsColliding(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized; // ���� ���
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, GridSize.x);

        UnityEngine.Debug.DrawRay(transform.position, direction * GridSize.x, Color.red, 1f);
        UnityEngine.Debug.Log(hit.collider.name);

        if (hit.collider != null && !hit.collider.CompareTag("Player"))
            return true;

        return false;
    }

    //�Է��� ������ �ν�Ʈ
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


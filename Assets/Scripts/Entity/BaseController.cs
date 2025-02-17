using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected bool isMoving = false;
    public bool IsMoving => isMoving;

    protected Vector2 targetPosition;
    public Vector2 TargetPosition => targetPosition;

    private Vector2 gridSize = new Vector2(1, 1);
    public Vector2 GridSize => gridSize;

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        
    }

    protected virtual void FixedUpdate()
    {
    }

    protected virtual void HandleAction()
    {

    }

}



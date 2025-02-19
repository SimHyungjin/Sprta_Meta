using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GamePlayerController : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 10f;
    private float forwardSpeed = 3f;
    float onFlap = 0f;
    [SerializeField] private GameObject endPanel;
    public Transform ground;

    public bool godMode = false;

    private void Awake()
    {
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (godMode)
            onFlap = -1000;
        if (Input.GetKeyUp(KeyCode.A))
            godMode = !godMode;

        Vector3 velocity = _rigidbody.velocity;
        if (velocity.x < 10)
        {
            forwardSpeed += Time.deltaTime;
        }
        velocity.x = forwardSpeed;

        if (onFlap < 2 && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y += flapForce;
            onFlap += 1;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("InputZ");
            forwardSpeed = 3f;
            transform.position += new Vector3(-3f, 3f);
            ground.transform.position = new Vector3(ground.transform.position.x - 3, ground.transform.position.y, ground.transform.position.z);
            transform.rotation = Quaternion.identity;
        }
        _rigidbody.velocity = velocity;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            MiniGameManager.Instance.EndGame = true;
            endPanel.gameObject.SetActive(true);
            GameManager.Instance.PlayingCount++;
            Time.timeScale = 0;
        }
        if (collision.transform.CompareTag("Wall"))
        {
            onFlap = 0;
        }
    }
    public void OffAnime()
    {
        animator.SetInteger("State", 0);
    }
}
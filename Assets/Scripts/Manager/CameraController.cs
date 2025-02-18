using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private float lerpSpeed = 1.0f;
    private Camera _camera;
    private string currentScene;
    private Vector3 targetPos;

    private void Awake()
    {
        _camera = Camera.main;
        currentScene = SceneManager.GetActiveScene().name;
    }
    void Update()
    {
        CameraControl();
    }

    private void CameraControl()
    {
        float SceneScale = Input.GetAxis("Mouse ScrollWheel");

        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize - SceneScale, 5, 20);

        if (target != null)
        {
            if (currentScene == "MainScene")
            {
                targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z + SceneScale);
            }
            else if(currentScene == "JumpGameScene")
            {
                targetPos = new Vector3(target.transform.position.x +4.5f , transform.position.y, transform.position.z + SceneScale);
            }
                transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed);
            
        }
    }

}

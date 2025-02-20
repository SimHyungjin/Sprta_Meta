using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private float lerpSpeed = 0.1f;
    private Camera _camera;
    private string currentScene;
    private Vector3 targetPos;

    private void Awake()
    {
        _camera = Camera.main;
        currentScene = SceneManager.GetActiveScene().name;
    }
    private void FixedUpdate()
    {
        CameraControl();
    }
    private void CameraControl()
    {
        float SceneScale = Input.GetAxis("Mouse ScrollWheel")*5f;
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize - SceneScale, 5, 10);
        if (target != null)
        {
            if (currentScene == "MainScene")
            {
                float posX = Mathf.Clamp(target.transform.position.x, -21.5f + _camera.orthographicSize*1.8f, 15.5f - _camera.orthographicSize*1.8f);
                float posY = Mathf.Clamp(target.transform.position.y, -15.5f + _camera.orthographicSize, 15.5f - _camera.orthographicSize);
                targetPos = new Vector3(posX, posY, transform.position.z);
                
            }
            else if (currentScene == "JumpGameScene")
                targetPos = new Vector3(target.transform.position.x + 4.5f, target.transform.position.y+2f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed);
        }
    }
}

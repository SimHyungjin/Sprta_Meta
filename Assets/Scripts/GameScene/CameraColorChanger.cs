using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChanger : MonoBehaviour
{
    private Camera cam;
    private Color targetColor;
    private float changeDuration = 5f;
    private float timer = 0;

    void Start()
    {
        cam = Camera.main;
        targetColor = GetRandomColor();
    }

    void Update()
    {
        timer += Time.deltaTime;
        cam.backgroundColor = Color.Lerp(cam.backgroundColor, targetColor, Time.deltaTime/changeDuration);

        if (timer > 4f)
        {
            targetColor = GetRandomColor();
            timer = 0;
        }
    }

    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value); // ·£´ý »ö»ó
    }
}

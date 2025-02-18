using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    private float holeSizeMin = 2f;
    private float holeSizeMax = 2.5f;

    private float sizeMinX = 0.5f;
    private float sizeMaxX = 3f;

    public Transform bottomObject;

    public float widthMin = 4f;
    public float widthMax = 6f;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);

        bottomObject.localPosition = new Vector3(0, -holeSize);

        float size = Random.Range(sizeMinX, sizeMaxX);
        bottomObject.localScale = new Vector3(size, 1);
        float widthPadding = Random.Range(widthMin, widthMax);
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);

        transform.position = placePosition;

        return placePosition;
    }
}

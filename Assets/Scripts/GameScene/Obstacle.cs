using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    private float holeSizeMin = -0.5f;
    private float holeSizeMax = 0.5f;

    private float sizeMinX = 1f;
    private float sizeMaxX = 3f;

    private float sizeMinY = 1.5f;
    private float sizeMaxY = 3f;

    public Transform bottomObject;

    public float widthMin = 2f;
    public float widthMax = 4f;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        bottomObject.localPosition = new Vector3(0, holeSize);

        float sizeX = Random.Range(sizeMinX, sizeMaxX);
        float sizeY = Random.Range(sizeMinY, sizeMaxY);
        bottomObject.localScale = new Vector3(sizeX, sizeY);

        float widthPadding = Random.Range(widthMin, widthMax);
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);

        transform.position = placePosition;

        return placePosition;
    }
}

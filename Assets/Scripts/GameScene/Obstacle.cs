using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject player;

    public float highPosY = 1f;
    public float lowPosY = -1f;

    private float holeSizeMin = 2f;
    private float holeSizeMax = 3f;

    private float sizeMinX = 3f;
    private float sizeMaxX = 4f;

    private float sizeMinY = 1.5f;
    private float sizeMaxY = 3f;

    public Transform bottomObject;

    private float widthMin = 2f;
    private float widthMax = 3f;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = player.transform.position.y + Random.Range(holeSizeMin, holeSizeMax);
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

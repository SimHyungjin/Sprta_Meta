using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChanger : MonoBehaviour
{
    public GameObject obj;
    private int count = 10;

    private void Start()
    {
        SpawnObject();
    }
    public void SpawnObject()
    {
        HashSet<Vector2> list = new HashSet<Vector2>();
        Vector2 randPos;
        for (int i = 0; i < count; i++)
        {
            do
            {
                float x = Mathf.Floor(Random.Range(5.5f, 11.5f))+0.5f;
                float y = Mathf.Floor(Random.Range(-1.5f, 6.5f)) + 0.5f;
                randPos = new Vector2(x, y);
            }
            while (list.Contains(randPos));
            list.Add(randPos);
            Instantiate(obj, randPos, Quaternion.identity,transform);

        }
    }
}

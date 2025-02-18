using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private PlayerController playerController;
    private Vector2 inputKey;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        inputKey.x = Input.GetAxisRaw("Horizontal");
        inputKey.y = Input.GetAxisRaw("Vertical");

        if (inputKey.x != 0)
            inputKey.y = 0;

        playerController.SetInput(inputKey);

        if(Input.GetKey(KeyCode.Space))
            playerController.SetBoost(true);
        else
            playerController.SetBoost(false);
    }
}

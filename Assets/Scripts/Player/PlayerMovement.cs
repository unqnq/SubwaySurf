using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] float coef = 2;
    void Start()
    {
        playerTransform = transform;
    }
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MovePlayer();
        }
    }
    void MovePlayer()
    {
        float halfScreen = Screen.width / 2;
        float xPos = (Input.mousePosition.x - halfScreen)/halfScreen;
        float finalPosX = Mathf.Clamp(xPos*coef, -coef, coef);
        playerTransform.localPosition = new Vector3(finalPosX, playerTransform.position.y, playerTransform.position.z);
    }
}

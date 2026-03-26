using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float coef = 2;
    void Start()
    {
        playerTransform = transform.Find("PlayerModel");
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        float halfScreen = Screen.width / 2;
        float xPos = (Input.mousePosition.x - halfScreen) / halfScreen;
        float finalXPos = Mathf.Clamp(xPos*coef, -coef, coef);
        playerTransform.localPosition = new Vector3(finalXPos, playerTransform.transform.position.y, playerTransform.transform.position.z);
    }
}

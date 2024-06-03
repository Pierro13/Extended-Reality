using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform playerTransform;

    void Update()
    {
        if (cameraTransform != null)
        {
            transform.rotation = cameraTransform.rotation;

            playerTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, cameraTransform.position.z);
        }
    }
}

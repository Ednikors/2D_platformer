using UnityEngine;
public class GunAimAtMouse : MonoBehaviour
{
    private Camera mainCamera;
    private float minAngleZ = -60f;
    private float maxAngleZ = 60f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        AimAtMousePosition();
    }

    void AimAtMousePosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

        Vector3 aimDirection = (mouseWorldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        float playerDirection = Mathf.Sign(transform.root.localScale.x);

        if (playerDirection < 0f)
        {
            angle = 180f - angle;
            angle = -angle;
        }

        if (angle > 180f)
        {
            angle -= 360f;
        }

        if (angle < -180f)
        {
            angle += 360f;
        }
        

        angle = Mathf.Clamp(angle, minAngleZ, maxAngleZ);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
    

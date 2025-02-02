using UnityEngine;

public class RTSCameraController : MonoBehaviour
{
    public Transform Target;

    public float smoothSpeed = 8f;
    public Vector3 offset;

    void Update()
    {
        if(Target == null) return;

        Vector3 desiredPostition = new Vector3(Target.position.x+offset.x, Target.position.y+offset.y, Target.position.z+offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPostition , smoothSpeed* Time.deltaTime);
        transform.position = smoothedPosition;
    }
}

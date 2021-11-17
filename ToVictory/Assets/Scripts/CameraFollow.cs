using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Declaring variables, making a vector3 for positioning and a transform
    //Smoothfactor for a reference to in game for how smooth camera follow will be
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;

    //Activating the follow variable
    private void FixedUpdate()
    {
        Follow();
    }

    //Declaring the follow variable, getting the targets position and adding to its own vector3 potision
    //Also define a smooth transition using lerp which takes 3 values applying a linear motion
    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}

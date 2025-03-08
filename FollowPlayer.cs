
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Reference to the vehicle
    public Vector3 offset = new Vector3(0, 5, -10);  // Camera position relative to vehicle
    public float smoothSpeed = 5f;  // Controls how smoothly the camera follows

    void LateUpdate()
    {
        // Keep the camera behind the vehicle with a smooth transition
        Vector3 targetPosition = player.position + player.transform.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Make camera rotate slowly instead of snapping instantly
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }
}

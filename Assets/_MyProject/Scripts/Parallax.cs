using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    [Range(0f,1f)] float parallaxLagAmount = 0.1f;

    Vector3 previousCameraPosition;
    Vector3 targetPosition;
    Transform camera;

    public float debugAmount; 

    // 100% lag == no movement
    // 10% lag == 90% of camera movement
    private float ParallaxAmount => 1f - parallaxLagAmount;

    void Awake()
    {
        camera = Camera.main.transform;
        previousCameraPosition = camera.position;
    }

    void LateUpdate()
    {
        Vector3 camMovement = CameraMovement();
        // Early out if no movement;
        if (camMovement == Vector3.zero) return;

        //targetPosition = new Vector3(transform.position.x + camMovement.x * (1f - parallaxLagAmount), transform.position.y, transform.position.z);
        targetPosition = new Vector3(transform.position.x + camMovement.x * ParallaxAmount, transform.position.y, transform.position.z);
        transform.position = targetPosition;

        debugAmount = ParallaxAmount;
    }

    Vector3 CameraMovement()
    {
        // How far did the camera move since last update/frame?
        Vector3 camMovement = camera.position - previousCameraPosition;
        // update the previousCameraPosition
        previousCameraPosition = camera.position;

        return camMovement;
    }
}

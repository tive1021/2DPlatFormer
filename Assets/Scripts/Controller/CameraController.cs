using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    [SerializeField] float mapLeftEnd;
    [SerializeField] float mapRightEnd;
    Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float cameraPosX = Mathf.Lerp(transform.position.x, playerTransform.position.x, cameraSpeed * Time.deltaTime);
        if (cameraPosX <= mapLeftEnd)
            cameraPosX = mapLeftEnd;
        else if (cameraPosX >= mapRightEnd)
            cameraPosX = mapRightEnd;
        transform.position = new Vector3(cameraPosX, 0, -10);
    }
}

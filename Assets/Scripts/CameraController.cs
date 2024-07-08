using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // private Transform player;
    private GameObject playerObject;
    private float aheadDist = 5;
    private float cameraSpeed = 1f;
    private float lookAhead;

    private void Awake() {
        playerObject = GameObject.Find("Player");
        // player = playerObject.transform;
    }

    private void Update() {
        transform.position = new Vector3(playerObject.transform.position.x+lookAhead, playerObject.transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDist* playerObject.transform.localScale.x), Time.deltaTime*cameraSpeed);
    }
}

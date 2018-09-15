using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ShowOrthographicBoundsScript : MonoBehaviour {

    void OnDrawGizmos()
    {
        Camera camera = gameObject.GetComponent(typeof(Camera)) as Camera;
        float verticalHeightSeen = camera.orthographicSize * 2.0f;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3((verticalHeightSeen * camera.aspect), verticalHeightSeen, 0));
    }
}

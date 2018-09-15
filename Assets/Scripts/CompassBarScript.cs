using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Note: for this script to work it must be attached to the UI Image being used as the actual compass points

[RequireComponent(typeof(Image))]
public class CompassBarScript : MonoBehaviour {

    public float pixelsFromNorthToNorth;
    public GameObject controller;

    private Vector3 startPos;
    private float angleToPixels;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        angleToPixels = pixelsFromNorthToNorth / 360f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 perp = Vector3.Cross(Vector3.forward, controller.transform.forward);
        float dir = Vector3.Dot(perp, Vector3.up);
        transform.position = startPos + (new Vector3(Vector3.Angle(controller.transform.forward, Vector3.forward) * Mathf.Sign(dir) * angleToPixels, 0, 0));
    }
}

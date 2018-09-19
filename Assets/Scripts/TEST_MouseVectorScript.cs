using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ara;

[RequireComponent(typeof(AraTrail))]
public class TEST_MouseVectorScript : MonoBehaviour {

    [Range(90, 180)]
    public float angleThreshhold = 90;

    private Vector3[] mousePositions = new Vector3[3];

    private AraTrail trail;
	// Use this for initialization
	void Start () {
        trail = gameObject.GetComponent(typeof(AraTrail)) as AraTrail;
        trail.emit = false;
        //trail.emitting = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 lastVelocity;
        Vector3 thisVelocity;

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            || Input.GetMouseButton(0)) {

            if (Input.mousePosition != mousePositions[0])
            {
                mousePositions[2] = mousePositions[1];
                mousePositions[1] = mousePositions[0];
                mousePositions[0] = Input.mousePosition;

                lastVelocity = mousePositions[2] - mousePositions[1];
                thisVelocity = mousePositions[1] - mousePositions[0];

                Plane objPlane = new Plane(Camera.main.transform.forward * -1, Camera.main.transform.position + Camera.main.transform.forward * (5 + Random.Range(0.1f, 0.51f)));
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;
                if (objPlane.Raycast(mRay, out rayDistance))
                {
                    this.transform.position = mRay.GetPoint(rayDistance);
                    trail.emit = true;
                }
            }
            /*
                if (Vector3.Angle(lastVelocity, thisVelocity) <= angleThreshhold) {
                //Plane objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
                Plane objPlane = new Plane(Camera.main.transform.forward * -1, Camera.main.transform.position + Camera.main.transform.forward * (5 + Random.Range(0.1f, 0.51f)));
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;
                if (objPlane.Raycast(mRay, out rayDistance)) {
                    this.transform.position = mRay.GetPoint(rayDistance);
                    trail.emit = true;
                }
            } else {
                Debug.Log("Angle btw last frame and this is " + Vector3.Angle(lastVelocity, thisVelocity) + " degrees!");
                trail.emit = false;
            }
            */
        } else {
            trail.emit = false;
        }
            
	}

}

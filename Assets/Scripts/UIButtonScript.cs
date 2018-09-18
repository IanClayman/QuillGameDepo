using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIButtonScript : MonoBehaviour {
    public GameObject player;
    public float turnTime = 2;
    public GameObject moveRightButton;
    public GameObject moveLeftButton;
    public TextMeshProUGUI messageLog;

	// Use this for initialization
	void Start () {
        Globals.turnTime = turnTime;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveForwardButtonPress() {
        messageLog.text = "[Move forward button pressed!]";
    }

    public void MoveRightButtonPress() {
        messageLog.text = "[Move right button pressed!]";
        StartCoroutine(TurnRoutine(90));
        StartCoroutine(DisableBtnForTimeRoutine(moveLeftButton, Globals.turnTime));
        StartCoroutine(DisableBtnForTimeRoutine(moveRightButton, Globals.turnTime));
    }

    public void MoveLeftButtonPress() {
        messageLog.text = "[Move left button pressed!]";
        StartCoroutine(TurnRoutine(-90));
        StartCoroutine(DisableBtnForTimeRoutine(moveLeftButton, Globals.turnTime));
        StartCoroutine(DisableBtnForTimeRoutine(moveRightButton, Globals.turnTime));
    }

    public void OptionsButtonPress() {
        messageLog.text = "[Options button pressed!]";
    }

    public void MenuButtonPress() {
        messageLog.text = "[Menu button pressed!]";
    }

    public IEnumerator DisableBtnForTimeRoutine(GameObject button, float time) {
        button.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(time);
        button.GetComponent<Button>().interactable = true;
    }

    private IEnumerator TurnRoutine(float angle) {
        float t = 0;
        Vector3 playerAngle = player.transform.eulerAngles;
        Vector3 targetAngle = new Vector3(playerAngle.x, playerAngle.y + angle, playerAngle.z);
        while (t <= 1) {
            player.transform.eulerAngles = Vector3.LerpUnclamped(playerAngle, targetAngle, Mathf.SmoothStep(0, 1, t));
            t += Time.deltaTime / Globals.turnTime;
            yield return new WaitForEndOfFrame();
        }
        if (player.transform.eulerAngles.y != targetAngle.y) {
            player.transform.eulerAngles = targetAngle;
        }
    }

}

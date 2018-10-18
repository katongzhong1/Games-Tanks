/*!
 * Title:
 * Description:
 * Author: wusz
 * Date:
 * Modify recording:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventTest : MonoBehaviour {

    public void EventPointerDown() {
        Toggle tg = GetComponent<Toggle>();
        tg.interactable = false;
        tg.interactable = true;
        Debug.Log(tg.isOn);
    }

    public void OnPointerDown(int i) {
        print("OnPointerDown--int");
    }

    public void OnPointerDown(BaseEventData eventData) {
        print("OnPointerDown--BaseEventData");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

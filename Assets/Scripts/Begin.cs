using UnityEngine;
using System.Collections;

public class Begin: MonoBehaviour {
    // Use this for initialization
    void Start() {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        spr.sprite = Resources.LoadAll<Sprite>("Textures/Images/bonus")[1];
    }

    // Update is called once per frame
    void Update() {

    }
}

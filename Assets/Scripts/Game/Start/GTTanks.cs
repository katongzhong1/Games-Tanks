using UnityEngine;
using System.Collections;

public class GTTanks: MonoBehaviour {

    //==========================================================================
    // Private Properties
    //==========================================================================

    private Vector3[] enemyBorthPosition = new Vector3[3];

    //==========================================================================
    // Mono Life Cycle
    //==========================================================================

    private void Awake() {
        enemyBorthPosition[0] = new Vector3(-6f, 6f, 10f);
        enemyBorthPosition[1] = new Vector3(-0f, 6f, 10f);
        enemyBorthPosition[2] = new Vector3(6f, 6f, 10f);

    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    //==========================================================================
    // Private Functions
    //==========================================================================

    private void LoadEnemys() {

    }

    private void LoadPlayers() {

    }
}

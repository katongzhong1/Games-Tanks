using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GTTanks: MonoBehaviour {

    //==========================================================================
    // Private Properties
    //==========================================================================
    /// <summary>
    /// 敌人出现位置
    /// </summary>
    private Vector3[] enemyBorthPosition = new Vector3[3];
    /// <summary>
    /// The borth star.
    /// </summary>
    private GameObject borthStar;
    /// <summary>
    /// The player1.
    /// </summary>
    private GameObject player1;
    /// <summary>
    /// The enemys.
    /// </summary>
    private GameObject[] enemys = new GameObject[8];
    Vector3 playerOutPosition = new Vector3(-1.448073f, -6.029788f, 10f);

    //==========================================================================
    // Mono Life Cycle
    //==========================================================================

    private void Awake() {
        enemyBorthPosition[0] = new Vector3(-6f, 6f, 10f);
        enemyBorthPosition[1] = new Vector3(-0f, 6f, 10f);
        enemyBorthPosition[2] = new Vector3(6f, 6f, 10f);
        // ===> 加载 GameObject
        LoadPlayers();
        //LoadEnemys();
        // ===> player
        Instantiate(player1, playerOutPosition, Quaternion.identity);
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
        enemys[0] = (GameObject)Resources.Load("Prefabs/Element/Enemy/EnemyA1");
        enemys[1] = (GameObject)Resources.Load("Prefabs/Element/Enemy/EnemyA2");
        enemys[2] = (GameObject)Resources.Load("Prefabs/Element/Enemy/EnemyB1");
        enemys[3] = (GameObject)Resources.Load("Prefabs/Element/Enemy/EnemyB2");
        enemys[4] = (GameObject)Resources.Load("Prefabs/Element/Enemy/EnemyC1");
        enemys[5] = (GameObject)Resources.Load("Prefabs/Element/Enemy/EnemyC2");
        enemys[6] = (GameObject)Resources.Load("Prefabs/Element/Enemy/EnemyD1");
        enemys[7] = (GameObject)Resources.Load("Prefabs/Element/Enemy/EnemyD2");
    }

    private void LoadPlayers() {
        //borthStar = (GameObject)Resources.Load("Prefabs/Element/Borth/BorthStar");
        player1 = (GameObject)Resources.Load("Prefabs/Element/Player/Player1");
    }
}

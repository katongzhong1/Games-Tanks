using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borth : MonoBehaviour {

    //==========================================================================
    // Public Property
    //==========================================================================
    /// <summary>
    /// 类型 0 player; 1 enemy;
    /// </summary>
    public int type;

    //==========================================================================
    // Private Properties
    //==========================================================================
    /// <summary>
    /// The player1.
    /// </summary>
    private GameObject player1;
    /// <summary>
    /// The enemys.
    /// </summary>
    private GameObject[] enemys = new GameObject[8];

    //==========================================================================
    // Mono Life Cycle
    //==========================================================================

    private void Awake() {
        // ===> 加载 GameObject
        LoadPlayers();
        LoadEnemys();
    }

    //==========================================================================
    // Public Functions
    //==========================================================================

    public void OnAnimCompleted() {
        Destroy(this.gameObject);
        if (type == 0) {
            //==> Enemy
            int etype = DataManager.enemys[DataManager.stage, DataManager.dieEnemys + DataManager.curEnemys];
            Instantiate(enemys[etype], transform.position, Quaternion.identity);
        } else if (type == 1) {
            //==> Player1
            Instantiate(player1, transform.position, Quaternion.identity);
        }
    }

    //==========================================================================
    // Public Functions
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
        player1 = (GameObject)Resources.Load("Prefabs/Element/Player/Player1");
    }
}

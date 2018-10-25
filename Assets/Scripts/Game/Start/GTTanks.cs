using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTTanks : MonoBehaviour {

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
    private GameObject enemyBorth, playerBorth;
    /// <summary>
    /// The enemys.
    /// </summary>
    Vector3 playerOutPosition = new Vector3 (-1.75f, -6f, 0f);

    //==========================================================================
    // Mono Life Cycle
    //==========================================================================

    private void Awake () {
        enemyBorthPosition[0] = new Vector3 (-6f, 6f, 0f);
        enemyBorthPosition[1] = new Vector3 (-0f, 6f, 0f);
        enemyBorthPosition[2] = new Vector3 (6f, 6f, 0f);
        // ===> 加载 GameObject
        enemyBorth = (GameObject)Resources.Load("Prefabs/Element/Borth/EnemyBorth");
        playerBorth = (GameObject)Resources.Load("Prefabs/Element/Borth/PlayerBorth");
        // ===> player
        Instantiate(playerBorth, playerOutPosition, Quaternion.identity);
        // ===> 开启协程
        StartCoroutine(CreateEnemy());
        //TODO: 添加玩法更加智能的AI
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    //==========================================================================
    // Private Functions
    //==========================================================================

    IEnumerator CreateEnemy () {
        while (true) {
            if (DataManager.curEnemys < 20) {
                //坦克数量=>坦克类型=>取位置=>生坦克
                int l = DataManager.maxEnemys - DataManager.dieEnemys;
                int need = DataManager.curMaxEnemys - DataManager.curEnemys;
                int num = l < need ? l : need;
                num = num > 3 ? 3 : num;
                for (var i = 0; i < num; i++) {
                    Instantiate (enemyBorth, enemyBorthPosition[i], Quaternion.identity);
                }
                yield return new WaitForSeconds (3.0f);
            }
            yield return 0;
        }
    }
}
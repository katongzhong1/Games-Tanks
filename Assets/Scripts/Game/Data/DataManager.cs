using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager {
    //==========================================================================
    // Public Properties
    //==========================================================================
    /// <summary>
    /// 当前关卡.
    /// </summary>
    public static int stage = 1;
    /// <summary>
    /// 最大关卡.
    /// </summary>
    public static int maxStage = 2;

    /// <summary>
    /// 游戏是否结束.
    /// </summary>
    public static bool gameover;
    /// <summary>
    /// The new tanks count.
    /// </summary>
    public static int newTanksCount;

    /// <summary>
    /// 玩家数量.
    /// </summary>
    public static int players = 2;
    /// <summary>
    /// 玩家分数.
    /// </summary>
    public static List<int> scores = { 0, 0 };
    /// <summary>
    /// 玩家等级.
    /// </summary>
    public static List<int> levels = { 1, 1 };
    public static List<int> lifes = { 3, 3 };

    /// <summary>
    /// The enemy count a b c d.
    /// </summary>
    public static List<int> enemyCounts = {0,0,0,0};
    /// <summary>
    /// The max enemys.
    /// </summary>
    public static int maxEnemys = 20;
    public static List<int> enemyScores = { 100, 200, 300, 500 };
    /// <summary>
    /// The stop.
    /// </summary>
    public static bool stop;

    //==========================================================================
    // Public Functions
    //==========================================================================

    public static void NextLevel() {
        enemyCounts = {0, 0, 0, 0};

    }
}

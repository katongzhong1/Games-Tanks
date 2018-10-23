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
    public static List<int> scores = new List<int> { 0, 0 };
    /// <summary>
    /// 玩家等级.
    /// </summary>
    public static List<int> levels = new List<int> { 1, 1 };
    public static List<int> lifes = new List<int> { 3, 3 };

    /// <summary>
    /// The enemy count a b c d.
    /// </summary>
    public static List<int> enemyCounts = new List<int> { 0, 0, 0, 0 };
    /// <summary>
    /// The max enemys.
    /// </summary>
    public static int maxEnemys = 20;
    public static int dieEnemys = 0;
    /// <summary>
    /// The current enemys.
    /// </summary>
    public static int curEnemys = 0;
    public static int curMaxEnemys = 6;
    public static List<int> enemyScores = new List<int> { 100, 200, 300, 500 };
    /// <summary>
    /// The stop.
    /// </summary>
    public static bool stop;
    public static int[, ] enemys = { 
        { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 2 },
        { 6, 6, 2, 3, 2, 2, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0 }
    };
    /// <summary>
    /// The maps.
    /// </summary>
    public static int[, , ] maps = {
        { 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 }, 
            { 0, 1, 0, 1, 0, 1, 2, 1, 0, 1, 0, 1, 0 }, 
            { 0, 1, 0, 1, 0, 6, 0, 6, 0, 1, 0, 1, 0 }, 
            { 0, 6, 0, 6, 0, 5, 0, 5, 0, 6, 0, 6, 0 }, 
            { 5, 0, 5, 5, 0, 6, 0, 6, 0, 5, 5, 0, 5 }, 
            { 10, 0, 6, 6, 0, 5, 0, 5, 0, 6, 6, 0, 10 }, 
            { 0, 5, 0, 5, 0, 1, 1, 1, 0, 5, 0, 5, 0 },
            { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 }, 
            { 0, 1, 0, 1, 0, 6, 0, 6, 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 0, 14, 5, 13, 0, 1, 0, 1, 0 }, 
            { 0, 0, 0, 0, 0, 7, 15, 8, 0, 0, 0, 0, 0 }
        },
        { 
            { 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 2, 0, 0, 0, 1, 0, 1, 0, 1, 0 },
            { 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 2, 1, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 2, 0, 0, 0 },
            { 4, 0, 0, 1, 0, 0, 2, 0, 0, 1, 4, 1, 2 },
            { 4, 4, 0, 0, 0, 1, 0, 0, 2, 0, 4, 0, 0 },
            { 0, 1, 1, 1, 4, 4, 4, 2, 0, 0, 4, 1, 0 },
            { 0, 0, 0, 2, 4, 1, 0, 1, 0, 1, 0, 1, 0 },
            { 2, 1, 0, 2, 0, 1, 0, 1, 0, 0, 0, 1, 0 },
            { 0, 1, 0, 3, 0, 1, 1, 1, 0, 1, 2, 1, 0 },
            { 0, 1, 0, 3, 0, 6, 6, 6, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 14, 5, 13, 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 0, 7, 15, 8, 0, 1, 1, 1, 0 }
        }
    };

    //==========================================================================
    // Public Functions
    //==========================================================================

    public static void NextLevel () {
        enemyCounts = new List<int> { 0, 0, 0, 0 };

    }
}
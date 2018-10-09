﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 关卡初始化
/// </summary>
public class GTStart: MonoBehaviour {

    //==========================================================================
    // Private Properties
    //==========================================================================

    /// <summary>
    /// All.
    /// </summary>
    public GameObject all;

    //==========================================================================
    // Private Properties
    //==========================================================================

    private bool win;
    /// <summary>
    /// The background.
    /// </summary>
    private GameObject background;
    /// <summary>
    /// 元素 砖、草、格、水
    /// </summary>
    private GameObject brick, grass, grid, water;
    /// <summary>
    /// The brick t: 1100, b: 0011, l: 1010, r: 0101.
    /// 砖块和铁块是可以局部打穿
    /// </summary>
    private GameObject brick_t, brick_b, brick_l, brick_r;
    /// <summary>
    /// The brick 1l: 0010, 1r: 0001
    /// </summary>
    private GameObject brick_1l, brick_1r;
    /// <summary>
    /// The grid t: 1100, b: 0011, l: 1010, r: 0101.
    /// 砖块和铁块是可以局部打穿
    /// </summary>
    private GameObject grid_t, grid_b, grid_l, grid_r;
    /// <summary>
    /// 基地
    /// </summary>
    private GameObject home;
    /// <summary>
    /// 关卡地图
    /// </summary>
    private int[,,] map = {{
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0},
            {0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0},
            {0, 1, 0, 1, 0, 1, 2, 1, 0, 1, 0, 1, 0},
            {0, 1, 0, 1, 0, 6, 0, 6, 0, 1, 0, 1, 0},
            {0, 6, 0, 6, 0, 5, 0, 5, 0, 6, 0, 6, 0},
            {5, 0, 5, 5, 0, 6, 0, 6, 0, 5, 5, 0, 5},
            {10, 0, 6, 6, 0, 5, 0, 5, 0, 6, 6, 0, 10},
            {0, 5, 0, 5, 0, 1, 1, 1, 0, 5, 0, 5, 0},
            {0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0},
            {0, 1, 0, 1, 0, 6, 0, 6, 0, 1, 0, 1, 0},
            {0, 1, 0, 1, 0, 14, 5, 13, 0, 1, 0, 1, 0},
            {0, 0, 0, 0, 0, 7, 15, 8, 0, 0, 0, 0, 0}},
        {   
            {0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0},
            {0, 1, 0, 2, 0, 0, 0, 1, 0, 1, 0, 1, 0},
            {0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 2, 1, 0},
            {0, 0, 0, 1, 0, 0, 0, 0, 0, 2, 0, 0, 0},
            {4, 0, 0, 1, 0, 0, 2, 0, 0, 1, 4, 1, 2},
            {4, 4, 0, 0, 0, 1, 0, 0, 2, 0, 4, 0, 0},
            {0, 1, 1, 1, 4, 4, 4, 2, 0, 0, 4, 1, 0},
            {0, 0, 0, 2, 4, 1, 0, 1, 0, 1, 0, 1, 0},
            {2, 1, 0, 2, 0, 1, 0, 1, 0, 0, 0, 1, 0},
            {0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 2, 1, 0},
            {0, 1, 0, 1, 0, 6, 1, 6, 0, 0, 0, 0, 0},
            {0, 1, 0, 0, 0, 14, 5, 13, 0, 1, 0, 1, 0},
            {0, 1, 0, 1, 0, 7, 15, 8, 0, 1, 1, 1, 0}
         }};

    //==========================================================================
    // Mono Life Cycle
    //==========================================================================

    /// <summary>
    /// Awake this instance.
    /// </summary>
    private void Awake() {
        PropertiesInitial();
        CreateMap();
    }

    private void Start() {
        if (win) return;
        int total = 0;
        for (var i = 0; i < DataManager.enemyCounts.Count; i++) {
            total += DataManager.enemyCounts[i];
        }
        if (total == DataManager.maxEnemys) {
            win = true;
            SceneManager.LoadScene("Score");
        }
    }

    //==========================================================================
    // Private Functions
    //==========================================================================

    /// <summary>
    /// 根据二元数组生成地图
    /// </summary>
    private void CreateMap() {
        int level = 1;
        for (var i = 0; i < 13; i++) {
            for (var j = 0; j < 13; j++ ) {
                SetStyleElement(map[level, i, j], i, j);
            }
        }
    }

    private void SetStyleElement(int num, int i, int j) {
        switch (num) {
            case 1:  SetElement(brick, i, j);    break;
            case 2:  SetElement(grass, i, j);    break;
            case 3:  SetElement(grid , i, j);    break;
            case 4:  SetElement(water, i, j);    break;
            case 5:  SetElement(brick_t, i, j);  break;
            case 6:  SetElement(brick_b, i, j);  break;
            case 7:  SetElement(brick_l, i, j);  break;
            case 8:  SetElement(brick_r, i, j);  break;
            case 9:  SetElement(grid_t, i, j);   break;
            case 10: SetElement(grid_b, i, j);   break;
            case 11: SetElement(grid_l, i, j);   break;
            case 12: SetElement(grid_r, i, j);   break;
            case 13: SetElement(brick_1l, i, j); break;
            case 14: SetElement(brick_1r, i, j); break;
            case 15: SetElement(home, i, j);     break;
        }
    }

    private void SetElement(GameObject obj, int i, int j) {
        float tx = (-6f) + j;
        float ty = (6f) - i;
        Vector3 p = new Vector3(tx, ty, 0);
        GameObject element = Instantiate(obj, p, Quaternion.identity);
        element.transform.SetParent(all.transform);
    }

    //==========================================================================
    // Private Properties Initial
    //==========================================================================

    private void PropertiesInitial() {
        //
        home  = (GameObject)Resources.Load("Prefabs/Element/Home");
        // 
        brick = (GameObject)Resources.Load("Prefabs/Element/Brick");
        grass = (GameObject)Resources.Load("Prefabs/Element/Grass");
        grid  = (GameObject)Resources.Load("Prefabs/Element/Grid");
        water = (GameObject)Resources.Load("Prefabs/Element/Water");
        //
        brick_t = (GameObject)Resources.Load("Prefabs/Element/Brick_t");
        brick_b = (GameObject)Resources.Load("Prefabs/Element/Brick_b");
        brick_l = (GameObject)Resources.Load("Prefabs/Element/Brick_l");
        brick_r = (GameObject)Resources.Load("Prefabs/Element/Brick_r");
        // 
        grid_t = (GameObject)Resources.Load("Prefabs/Element/Grid_t");
        grid_b = (GameObject)Resources.Load("Prefabs/Element/Grid_b");
        grid_l = (GameObject)Resources.Load("Prefabs/Element/Grid_l");
        grid_r = (GameObject)Resources.Load("Prefabs/Element/Grid_r");
        //
        brick_1l = (GameObject)Resources.Load("Prefabs/Element/Brick_1l");
        brick_1r = (GameObject)Resources.Load("Prefabs/Element/Brick_1r");
    }
}

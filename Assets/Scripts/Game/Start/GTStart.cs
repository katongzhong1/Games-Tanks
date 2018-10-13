using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 关卡初始化
/// </summary>
public class GTStart : MonoBehaviour {

    //==========================================================================
    // Private Properties
    //==========================================================================

    /// <summary>
    /// 地图容器.
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
    /// The brick
    /// 砖块和铁块是可以局部打穿
    /// </summary>
    private GameObject brick_0011, brick_1100, brick_0101, brick_1010, brick_0010, brick_0001;
    /// <summary>
    /// The grid 
    /// 砖块和铁块是可以局部打穿
    /// </summary>
    private GameObject grid_0011, grid_1100, grid_0101, grid_1010;
    /// <summary>
    /// 基地
    /// </summary>
    private GameObject home;

    //==========================================================================
    // Mono Life Cycle
    //==========================================================================

    /// <summary>
    /// Awake this instance.
    /// </summary>
    private void Awake () {
        PropertiesInitial ();
        CreateMap ();
    }

    private void Start () {
        if (win) return;
        int total = 0;
        for (var i = 0; i < DataManager.enemyCounts.Count; i++) {
            total += DataManager.enemyCounts[i];
        }
        if (total == DataManager.maxEnemys) {
            win = true;
            SceneManager.LoadScene ("Score");
        }
    }

    //==========================================================================
    // Private Functions
    //==========================================================================

    /// <summary>
    /// 根据二元数组生成地图
    /// </summary>
    private void CreateMap () {
        for (var i = 0; i < 13; i++) {
            for (var j = 0; j < 13; j++) {
                SetStyleElement (DataManager.maps[DataManager.stage, i, j], i, j);
            }
        }
    }

    private void SetStyleElement (int num, int i, int j) {
        switch (num) {
            case 1:
                SetElement (brick, i, j, 0);
                break;
            case 2:
                SetElement (grid, i, j, 0);
                break;
            case 3:
                SetElement (water, i, j, 0);
                break;
            case 4:
                SetElement (grass, i, j, -3);
                break;
            case 5:
                SetElement (brick_0011, i, j, 0);
                break;
            case 6:
                SetElement (brick_1100, i, j, 0);
                break;
            case 7:
                SetElement (brick_0101, i, j, 0);
                break;
            case 8:
                SetElement (brick_1010, i, j, 0);
                break;
            case 9:
                SetElement (grid_0011, i, j, 0);
                break;
            case 10:
                SetElement (grid_1100, i, j, 0);
                break;
            case 11:
                SetElement (grid_0101, i, j, 0);
                break;
            case 12:
                SetElement (grid_1010, i, j, 0);
                break;
            case 13:
                SetElement (brick_0010, i, j, 0);
                break;
            case 14:
                SetElement (brick_0001, i, j, 0);
                break;
            case 15:
                SetElement (home, i, j, 0);
                break;
        }
    }

    private void SetElement (GameObject obj, int i, int j, int z) {
        float tx = (-6f) + j;
        float ty = (6f) - i;
        Vector3 p = new Vector3 (tx, ty, z);
        GameObject element = Instantiate (obj, p, Quaternion.identity);
        element.transform.SetParent (all.transform);
    }

    //==========================================================================
    // Private Properties Initial
    //==========================================================================

    private void PropertiesInitial () {
        //
        home = (GameObject) Resources.Load ("Prefabs/Element/Home");
        // 
        brick = (GameObject) Resources.Load ("Prefabs/Element/Brick/Brick");
        grass = (GameObject) Resources.Load ("Prefabs/Element/Grass");
        grid = (GameObject) Resources.Load ("Prefabs/Element/Grid/Grid");
        water = (GameObject) Resources.Load ("Prefabs/Element/Water");
        //
        brick_0011 = (GameObject) Resources.Load ("Prefabs/Element/Brick/Brick_0011");
        brick_1100 = (GameObject) Resources.Load ("Prefabs/Element/Brick/Brick_1100");
        brick_0101 = (GameObject) Resources.Load ("Prefabs/Element/Brick/Brick_0101");
        brick_1010 = (GameObject) Resources.Load ("Prefabs/Element/Brick/Brick_1010");
        brick_0001 = (GameObject) Resources.Load ("Prefabs/Element/Brick/Brick_0001");
        brick_0010 = (GameObject) Resources.Load ("Prefabs/Element/Brick/Brick_0010");
        // 
        grid_0011 = (GameObject) Resources.Load ("Prefabs/Element/Grid/Grid_0011");
        grid_1100 = (GameObject) Resources.Load ("Prefabs/Element/Grid/Grid_1100");
        grid_0101 = (GameObject) Resources.Load ("Prefabs/Element/Grid/Grid_0101");
        grid_1010 = (GameObject) Resources.Load ("Prefabs/Element/Grid/Grid_1010");
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Type: MonoBehaviour {

    //==========================================================================
    // Public Properties
    //==========================================================================

    /// <summary>
    /// The type of the brick.
    /// 0011 => 1; 1100 => 2; 0101 => 3; 1010 => 4
    /// 1000 => 5; 0100 => 6; 0010 => 7; 0001 => 8
    /// </summary>
    public int type;

    //==========================================================================
    // Life Cycle
    //==========================================================================

    private void Awake() {
        if (type == 0) return;
        List<List<int>> list = new List<List<int>>{ new List<int>{ 0, 1 },
               new List<int>{ 2, 3 }, new List<int>{0, 2}, new List<int>{1, 3},
               new List<int>{ 1, 2, 3 },new List<int>{ 0, 2, 3 }, new List<int>{ 0, 1, 3}, new List<int>{0, 1, 2}};
        List<int> typeList = list[type-1];
        for (var i = 0; i < typeList.Count; i++) {
            Destroy(this.gameObject.transform.GetChild(typeList[i]).gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        if (this.transform.childCount == 0) {
            Destroy(this.gameObject);
        }
    }

}

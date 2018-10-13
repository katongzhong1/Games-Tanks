using UnityEngine;
using System.Collections;

public class Explosion: MonoBehaviour {

    //==========================================================================
    // Public Functions
    //==========================================================================

    public void OnAnimCompleted() {
        Destroy(this.gameObject);
    }
}

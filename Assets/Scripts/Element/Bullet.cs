using UnityEngine;
using System.Collections;

public class Bullet: MonoBehaviour {

    //==========================================================================
    // Public Properties
    //==========================================================================
    /// <summary>
    /// The type 0=>player 1=>enemy.
    /// </summary>
    public int type;

    //==========================================================================
    // Private Properties
    //==========================================================================
    /// <summary>
    /// The speed.
    /// </summary>
    private float speed = 8f;
    /// <summary>
    /// The rb.
    /// </summary>
    private Rigidbody2D rb;
    /// <summary>
    /// The small explosion.
    /// </summary>
    private GameObject smallExplosion, bigExplosion;

    //==========================================================================
    // Private Properties
    //==========================================================================
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Vector3 v3 = transform.up.normalized;
        rb.velocity = v3 * speed;

        smallExplosion = (GameObject)Resources.Load("Prefabs/Elemet/Explosion/SmallExplosion");
        bigExplosion   = (GameObject)Resources.Load("Prefabs/Elemet/Explosion/BigExplosion");
    }

    // Update is called once per frame
    void Update() {

    }

    //==========================================================================
    // Collider Funtions
    //==========================================================================

    private void OnTriggerEnter2D(Collider2D collision) {
        // 销毁子弹
        Destroy(this.gameObject);
        // 更新子弹数
        switch (collision.tag) {
            case "brick":
                Destroy(collision.gameObject);
                // 触发子弹命中动画
                Instantiate(smallExplosion, this.transform.position, Quaternion.identity);
                break;
            case "grid":
                if (type == 0 && DataManager.levels[0] == 3) {
                    //TODO: 判断是否
                    Destroy(collision.gameObject);
                }
                break;
            case "home":
                break;
            case "bound":
                break;
            case "enemy":
                break;
            case "play":
                break;
        }
    }
}

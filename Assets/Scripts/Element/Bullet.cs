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
    private Rigidbody rb;
    /// <summary>
    /// 子弹发射的声音
    /// </summary>
    private AudioSource music;
    /// <summary>
    /// The small explosion.
    /// </summary>
    private GameObject smallExplosion, bigExplosion;

    //==========================================================================
    // Private Properties
    //==========================================================================
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        //music = GetComponent<AudioSource>();
        Vector3 v3 = transform.up.normalized;
        rb.velocity = v3 * speed;

        smallExplosion = (GameObject)Resources.Load("Prefabs/Element/Explosion/SmallExplosion");
        bigExplosion   = (GameObject)Resources.Load("Prefabs/Element/Explosion/BigExplosion");
        
        //music.Play();
    }

    // Update is called once per frame
    void Update() {

    }

    //==========================================================================
    // Collider Funtions
    //==========================================================================

    private void OnTriggerEnter(Collider other) {

        // 更新子弹数
        switch (other.tag) {
            case "brick":
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                // 触发子弹命中动画
                Instantiate(smallExplosion, this.transform.position, Quaternion.identity);
                break;
            case "grid":
                Destroy(this.gameObject);
                if (type == 1 && DataManager.levels[0] == 3) {
                    //TODO: 判断是否
                    Destroy(other.gameObject);
                }
                // 触发子弹命中动画
                Instantiate(smallExplosion, this.transform.position, Quaternion.identity);
                break;
            case "home":
                break;
            case "bound":
                Destroy(this.gameObject);
                Instantiate(smallExplosion, this.transform.position, Quaternion.identity);
                break;
            case "enemy":
                if (type == 0) {
                    Destroy(this.gameObject);
                    Instantiate(bigExplosion, other.transform.position, Quaternion.identity);
                }
                break;
            case "player":
                if (type == 1) {
                    Destroy(other.gameObject);
                    // 触发子弹命中动画
                    Instantiate(bigExplosion, other.transform.position, Quaternion.identity);
                    //TODO: 生成新坦克
                } else {

                }
                break;
        }
    }
}

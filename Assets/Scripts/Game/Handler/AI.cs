using System.Collections;
using UnityEngine;

public class AI : MonoBehaviour {

    //==========================================================================
    // Public Properties
    //==========================================================================

    /// <summary>
    /// The type of the enemy.
    /// </summary>
    public int enemyType;
    /// <summary>
    /// 是否是彩色坦克.
    /// </summary>
    //public bool color;

    //==========================================================================
    // Private Properties
    //==========================================================================

    /// <summary>
    /// The bullet.
    /// </summary>
    private GameObject bullet, boom;
    /// <summary>
    /// The current bullet count.
    /// </summary>
    private int curBulletCount;
    /// <summary>
    /// The life.
    /// </summary>
    private int life = 1;
    /// <summary>
    /// The speed.
    /// </summary>
    private float speed = 3f;
    /// <summary>
    /// The h.
    /// </summary>
    private float h;
    /// <summary>
    /// The v.
    /// </summary>
    private float v = -1;
    private float changeRotationTime;
    private float maxTime;
    private Animator ani;
    private Rigidbody2D rb;

    //==========================================================================
    // Life Cycle
    //==========================================================================

    // Use this for initialization
    private void Start () {
        InitialSpeedAndLife ();
        ani = GetComponent<Animator> ();
        rb = GetComponent<Rigidbody2D> ();
        this.transform.GetChild (0).gameObject.SetActive (false);
        bullet = (GameObject) Resources.Load ("Prefabs/Element/Bullet");
        maxTime = Random.Range (0.5f, 2f);
        InvokeRepeating ("Fire", 0f, 1f);
    }

    // Update is called once per Times
    private void FixedUpdate () {
        if (DataManager.stop) return;
        Move ();
    }

    // Update is called once per frame
    private void Update () {

    }

    private void OnCollisionEnter2D (Collision2D collision) {
        //Move();
        if (collision.gameObject.tag == "enemy") {
            Debug.Log ("===> Kinematic");
            //rb.bodyType = RigidbodyType2D.Kinematic;
            changeRotationTime = maxTime;
            //Move();
        } else if (collision.gameObject.tag == "player") {
            changeRotationTime = maxTime;
        }
    }

    private void OnCollisionExit2D (Collision2D collision) {
        if (collision.gameObject.tag == "enemy") {
            Debug.Log ("===> Dynamic");
            //rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    //==========================================================================
    // Private Functions
    //==========================================================================

    private void InitialSpeedAndLife () {
        switch (enemyType) {
            case 0:
                break;
            case 1:
                speed = 5f;
                break;
            case 2:
                life += 1;
                break;
            case 3:
                life += 2;
                break;
        }
    }

    private void Move () {
        if (changeRotationTime >= maxTime) {
            int num = Random.Range (0, 8);
            if (num > 5) {
                v = -1;
                h = 0;
            } else if (num == 0) {
                v = 1;
                h = 0;
            } else if (num == 1 || num == 2) {
                v = 0;
                h = -1;
            } else if (num == 3 || num == 4) {
                v = 0;
                h = 1;
            }
            changeRotationTime = 0;
            maxTime = Random.Range (0.5f, 2f);
        } else {
            changeRotationTime += Time.fixedDeltaTime;
        }
        UpdateState ();

        PlayRotation ();
        transform.Translate (transform.up.normalized * Mathf.Abs (v) * speed * Time.fixedDeltaTime, Space.World);
        // 判断是否为0的方式
        if (Mathf.Abs (v) > 0.00001) return;
        // 水平 
        PlayRotation ();
        transform.Translate (transform.up.normalized * Mathf.Abs (h) * speed * Time.fixedDeltaTime, Space.World);
    }

    private void UpdateState () {
        int bo = (Mathf.Abs (v) > 0.00001 || Mathf.Abs (h) > 0.00001) ? 1 : 0;
        //ani.SetInteger("IS_RUN", bo);
    }

    private void PlayRotation () {
        if (v > 0) {
            transform.rotation = Quaternion.identity;
        } else if (v < 0) {
            transform.rotation = Quaternion.Euler (0, 0, -180);
        } else if (h > 0) {
            transform.rotation = Quaternion.Euler (0, 0, -90);
        } else if (h < 0) {
            transform.rotation = Quaternion.Euler (0, 0, 90);
        }
    }

    private void Fire () {
        if (DataManager.stop) return;
        if (curBulletCount > 1) return;
        GameObject temp = (GameObject) Instantiate (bullet, transform.position, Quaternion.Euler (transform.eulerAngles));
    }

    private void Short () {
        life -= 1;
        if (life < 1) {
            DataManager.enemyCounts[enemyType] += 1;
            Destroy (this.gameObject);
        }
    }
}
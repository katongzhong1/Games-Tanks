using System.Collections.Generic;
using UnityEngine;
using GS;

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
    public int life = 1;
    /// <summary>
    /// The speed.
    /// </summary>
    private float speed = 2f;
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
    private CharacterController chart;

    //==========================================================================
    // Life Cycle
    //==========================================================================

    // Use this for initialization
    private void Start () {
        InitialSpeedAndLife ();
        ani = GetComponent<Animator> ();
        ani.SetInteger("life", life);
        chart = GetComponent<CharacterController> ();
        this.transform.GetChild (0).gameObject.SetActive (false);
        bullet = (GameObject) Resources.Load ("Prefabs/Element/Bullet/Bullet");
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

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        changeRotationTime = maxTime;
    }

    //==========================================================================
    // Private Functions
    //==========================================================================

    private void InitialSpeedAndLife () {
        switch (enemyType) {
            case 0:
                break;
            case 1:
                life += 1;
                break;
            case 2:
                speed = 5f;
                break;
            case 3:
                speed = 5f;
                life += 1;
                break;
            case 4:
                break;
            case 5:
                life += 1;
                break;
            case 6:
                life += 1;
                break;
            case 7:
                life += 2;
                break;
        }
    }

    private void intelligenceMove() {

    }

    private void Move () {
        int x = (int)(gameObject.transform.position.x + 6.5);
        int y = 12 - (int)(gameObject.transform.position.y + 6.5);
        Debug.Log("x==>"+ x + "y==>" + y);
        //TODO:定位当前位置
        if (changeRotationTime >= maxTime) {
            int[] l = {-1, 0}, r = {1, 0}, t = {0, -1}, b = {0, 1};
            Dictionary<int[], int> dic = new Dictionary<int[], int>();
            if (!(v == -1 && h == 0)) {
                dic.Add(l, 2);
            }
            if (!(v == 1 && h == 0)) {
                dic.Add(r, 2);
            }
            if (!(v == 0 && h == -1)) {
                dic.Add(t, 2);
            }
            if (!(v == 0 && h == 1)) {
                dic.Add(b, 2);
            }
            int[] value = dic.GetRandomWithPower();
            v = value[0];
            h = value[1];
            changeRotationTime = 0;
            maxTime = Random.Range (0.5f, 3f);
        } else {
            changeRotationTime += Time.fixedDeltaTime;
        }
        UpdateState ();

        PlayRotation ();
        chart.Move (transform.up.normalized * Mathf.Abs (v) * speed * Time.fixedDeltaTime);
        // 判断是否为0的方式
        if (Mathf.Abs (v) > 0.00001) return;
        // 水平 
        PlayRotation ();
        chart.Move(transform.up.normalized * Mathf.Abs (h) * speed * Time.fixedDeltaTime);
    }

    private void UpdateState () {
        int bo = (Mathf.Abs (v) > 0.00001 || Mathf.Abs (h) > 0.00001) ? 1 : 0;
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

    public void BeShorted () {
        life -= 1;
        if (life < 1) {
            DataManager.enemyCounts[enemyType] += 1;
            DataManager.curEnemys--;
            DataManager.dieEnemys++;
            Destroy (this.gameObject);
        } else {
            ani.SetInteger("life", life);
        }
    }
}
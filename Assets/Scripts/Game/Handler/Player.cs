using UnityEngine;
using System.Collections;

public class Player: MonoBehaviour {

    //==========================================================================
    // Private Properties
    //==========================================================================

    /// <summary>
    /// The speed.
    /// </summary>
    private float speed = 3f;
    /// <summary>
    /// The v.
    /// </summary>
    private float v = 0f;
    /// <summary>
    /// The h.
    /// </summary>
    private float h = 0f;
    /// <summary>
    /// The max buttlet.
    /// </summary>
    private int maxButtlet = 1;
    /// <summary>
    /// An.
    /// </summary>
    private Animator ani;
    /// <summary>
    /// The buttlet.
    /// </summary>
    private GameObject buttlet;
    /// <summary>
    /// The rb.
    /// </summary>
    private Rigidbody2D rb;

    //==========================================================================
    // Public Properties
    //==========================================================================

    /// <summary>
    /// The level.
    /// </summary>
    public int level = 1;
    /// <summary>
    /// The current buttlet.
    /// </summary>
    public int curButtlet;
    /// <summary>
    /// 玩家ID.
    /// </summary>
    public int id = 0;

    //==========================================================================
    // Public Properties
    //==========================================================================

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        buttlet = (GameObject)Resources.Load("bullet");
        level = DataManager.levels[id];
    }

    // Update is called once per Times
    private void FixedUpdate() {
        if (DataManager.gameover) return;
        Move();
        UpdateAniState();
    }

    // Update is called once per frame
    void Update() {
        if (DataManager.gameover) return;
        Fire();
    }

    //==========================================================================
    // Public Properties
    //==========================================================================

    private void Move() {
        // 竖直
        v = Input.GetAxisRaw("Vertical");
        PlayRotation();
        transform.Translate(transform.up.normalized * Mathf.Abs(v) * speed * Time.fixedDeltaTime, Space.World);
        // 判断是否为0的方式
        if (Mathf.Abs(v) > 0.00001) return;
        // 水平 
        h = Input.GetAxisRaw("Horizontal");
        PlayRotation();
        transform.Translate(transform.up.normalized * Mathf.Abs(h) * speed * Time.fixedDeltaTime, Space.World);
    }

    private void PlayRotation() {
        if (v > 0) {
            transform.rotation = Quaternion.identity;
        } else if (v < 0) {
            transform.rotation = Quaternion.Euler(0, 0, -180);
        } else if (h > 0) {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        } else if (h < 0) {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    /// <summary>
    /// Updates the state of the ani.
    /// </summary>
    private void UpdateAniState() {
        int bo = (Mathf.Abs(v) > 0.00001 || Mathf.Abs(h) > 0.00001) ? 1 : 0;
        ani.SetInteger("IS_RUN", bo);
    }

    /// <summary>
    /// 开火
    /// </summary>
    private void Fire() {
        if (curButtlet > maxButtlet) return;
        if (Input.GetKeyDown(KeyCode.Space)) {
            //TODO: 子弹与等级相关
            curButtlet += 1;
            Instantiate(buttlet, transform.position, Quaternion.Euler(transform.eulerAngles));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        switch (collision.gameObject.tag) {
            case "life":
                Destroy(collision.gameObject);
                DataManager.lifes[id] = DataManager.lifes[id] + 1;
                break;
            case "shield":
                Destroy(collision.gameObject);
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(0).gameObject.SendMessage("startTime");
                break;
            case "ship":
                Destroy(collision.gameObject);
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(0).gameObject.SendMessage("startTime");
                break;
            case "star":
                Destroy(collision.gameObject);
                if (level < 4) {
                    level += 1;
                    DataManager.levels[id] = level;
                }
                break;
            case "gun":
                Destroy(collision.gameObject);
                DataManager.levels[id] = 4;
                level = 4;
                break;
            case "bomb":
                Destroy(collision.gameObject);
                //TODO: 定时
                Invoke("BombAwake", 10f);
                break;
            case "explosion":
                Destroy(collision.gameObject);
                GameObject obj = GameObject.FindGameObjectWithTag("enemys");
                for (var i = 0; i < obj.transform.childCount; i++) {
                    obj.transform.GetChild(i).gameObject.SendMessage("die");
                    DataManager.newTanksCount += 1;
                }
                break;
        }
    }

    private void BombAwake() {
        DataManager.stop = false;
    }
}

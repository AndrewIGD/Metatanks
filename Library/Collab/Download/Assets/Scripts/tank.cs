using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class tank : MonoBehaviour
{
	List<GameObject> bullets = new List<GameObject>();
    //Serialized Data
    [SerializeField] int player = 1;

    [Space(2)]
    [Header("Tank Objects")]
    [SerializeField] GameObject foot1;
    [SerializeField] GameObject foot2;
    [SerializeField] GameObject leg1;
    [SerializeField] GameObject leg2;
    [SerializeField] GameObject ground;
    [SerializeField] GameObject hpBar;
    [SerializeField] GameObject hpBar2;
    [SerializeField] GameObject pistolObject;
    [SerializeField] GameObject bodyObject;
    [SerializeField] GameObject wheelsObject;
    [SerializeField] GameObject plane;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject cannonBall;
    [SerializeField] GameObject rocketVfx;
    [SerializeField] GameObject flame;
    [SerializeField] GameObject wholeHealthBar;
    [SerializeField] GameObject wholeManaBar;
    [SerializeField] GameObject manaBar;
    [SerializeField] GameObject deathVfx;
    [SerializeField] GameObject CeilingCollider;
    [SerializeField] GameObject floorCollider;
    [SerializeField] GameObject sideCollider;
    [Header("Audio")]
    [SerializeField] AudioClip death;
    [Space(2)]

    [Header("Positions")]
    [SerializeField] Vector3 holderpos;
    [SerializeField] Vector3 wheelsogpos;
    [SerializeField] Vector3 ogposs;
    [SerializeField] Vector3 bodyogpos;

    [Space(2)]
    [Header("Colors")]
    [SerializeField] Color32 endColor;
    [SerializeField] Color32 startCOlor;

    //Keyboard Keys
    KeyCode left;
    KeyCode right;
    KeyCode shoot;
    KeyCode transformRobot;
    KeyCode jump;
    KeyCode down;
    KeyCode transformTank;
    KeyCode mortarUp;
    KeyCode mortarDown;


    //Controller Varibles
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
 
    int face;
    int form = 1;
    float speed;
    float framerate;
    



    //Time trackers for animations
    float t1 = 0;
    float t2 = 0;
    float t3 = 0;
    float t4 = 0;
    float t5 = 0;
    float t6 = 0;
    float t7 = 0;
    float t8 = 0;
    float t9 = 0;
    float t11 = 0;
    float t12 = 0;
    float t13 = 0;
    float t10 = 0;
    float t14 = 0;
    float t15;
    float t16 = 0;
    float t17 = 0;

    //Leg and foot data
    Vector3 leg1pos;
    Vector3 leg2pos;
    Vector3 foot1pos;
    Vector3 foot2pos;
    Quaternion leg1rot;
    Quaternion leg2rot;
    Quaternion foot1rot;
    Quaternion foot2rot;

    
    
    //Flamer information
    GameObject burnVfx;
    GameObject flame1;
    GameObject flame2;
    GameObject flame3;
    GameObject flame4;
    GameObject flame5;
    int burn = 0;

    

    //Tank Information
    int facing;
    float inithp;
    float targethp;
    float damage;
    float maxhp;
    [SerializeField] float hp;
    GameObject pistol;
    GameObject actualWheels;
    GameObject wheels;
    GameObject body;
    GameObject holder;
    Vector3 mortarScale;
    Vector2 currentPos;
    [SerializeField] int jumps = 2;
    GameObject ground2;
    GameObject ground3;
    GameObject groundcol;
    [SerializeField] float damageMultiplier = 1f;
    bool tankPrepared = false;


    //Bools
	bool ableToJump = true;
    bool duckAnim;
    bool duckReverseAnim;
    bool rocketAnim = false;
    int ra = 0;
    int pb = 0;
    int rt = 0;
    int ableToTrans = 0;
    int ableToTakeDMG = 0;
    int rot1 = 0;
    int rot2 = 0;
    int runninganim = -1;
    bool input = false;
    bool ableToDoStuff = true;
    bool canShoot = true;
    int jumped1 = 0;
    int jumped2 = 0;
    int running = 0;
    bool activated = false;
    int ableToRun = 1;
    int gravity = 1;
    int leftmove = 1;
    int rightmove = 1;
    bool pistolBack = false;
    bool pistolAnim = false;
    bool mortarBack = false;
    bool mortarAnim = false;

    //Animation Startups
    private void RunningMM()
    {
        runninganim = -1;
        CancelInvoke("RunningMM");
        if (face == 0)
        {
            leg1.transform.localPosition = leg1.GetComponent<leg1>().ReturnIdle().transform.localPosition;
            leg2.transform.localPosition = leg2.GetComponent<leg2>().ReturnIdle().transform.localPosition;
            foot1.transform.localPosition = foot1.GetComponent<feet1>().ReturnIdle().transform.localPosition;
            foot2.transform.localPosition = foot2.GetComponent<feet2>().ReturnIdle().transform.localPosition;
            leg1.transform.localRotation = leg1.GetComponent<leg1>().ReturnIdle().transform.localRotation;
            leg2.transform.localRotation = leg2.GetComponent<leg2>().ReturnIdle().transform.localRotation;
            foot1.transform.localRotation = foot1.GetComponent<feet1>().ReturnIdle().transform.localRotation;
            foot2.transform.localRotation = foot2.GetComponent<feet2>().ReturnIdle().transform.localRotation;
        }
        else
        {
            leg1.transform.localPosition = leg1.GetComponent<leg1>().ReturnIdle2().transform.localPosition;
            leg2.transform.localPosition = leg2.GetComponent<leg2>().ReturnIdle2().transform.localPosition;
            foot1.transform.localPosition = foot1.GetComponent<feet1>().ReturnIdle2().transform.localPosition;
            foot2.transform.localPosition = foot2.GetComponent<feet2>().ReturnIdle2().transform.localPosition;
            leg1.transform.localRotation = leg1.GetComponent<leg1>().ReturnIdle2().transform.localRotation;
            leg2.transform.localRotation = leg2.GetComponent<leg2>().ReturnIdle2().transform.localRotation;
            foot1.transform.localRotation = foot1.GetComponent<feet1>().ReturnIdle2().transform.localRotation;
            foot2.transform.localRotation = foot2.GetComponent<feet2>().ReturnIdle2().transform.localRotation;
        }
    }
    public void TransformTankRobot()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 5);
        rot1 = 1;
        form = 2;
        Invoke("StopRot1", 0.3f);
    }
    private void PB()
    {
        if (pb == 1)
        {
            t4 += Time.deltaTime / 0.3f;
            plane.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(plane.GetComponent<SpriteRenderer>().color.r * 255), (byte)(plane.GetComponent<SpriteRenderer>().color.g * 255), (byte)(plane.GetComponent<SpriteRenderer>().color.b * 255), 0), endColor, t4);
            foot1.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(foot1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.b * 255), 255), startCOlor, t4);
            foot2.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(foot2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.b * 255), 255), startCOlor, t4);
            leg1.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 255), startCOlor, t4);
            leg2.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.b * 255), 255), startCOlor, t4);
            if (face == 2)
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnJump2().transform.localRotation, t4);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, leg1.GetComponent<leg1>().ReturnJump2().transform.localPosition, t4);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnJump2().transform.localRotation, t4);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, leg2.GetComponent<leg2>().ReturnJump2().transform.localPosition, t4);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnJump2().transform.localRotation, t4);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, foot2.GetComponent<feet2>().ReturnJump2().transform.localPosition, t4);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnJump2().transform.localRotation, t4);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, foot1.GetComponent<feet1>().ReturnJump2().transform.localPosition, t4);
            }
            else
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnJump2().transform.localRotation, t4);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, new Vector3(leg1.GetComponent<leg1>().ReturnJump2().transform.localPosition.x, leg1.GetComponent<leg1>().ReturnJump2().transform.localPosition.y, 5), t4);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnJump2().transform.localRotation, t4);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, new Vector3(leg2.GetComponent<leg2>().ReturnJump2().transform.localPosition.x, leg2.GetComponent<leg2>().ReturnJump2().transform.localPosition.y, 5), t4);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnJump2().transform.localRotation, t4);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, new Vector3(foot2.GetComponent<feet2>().ReturnJump2().transform.localPosition.x, foot2.GetComponent<feet2>().ReturnJump2().transform.localPosition.y, 3), t4);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnJump2().transform.localRotation, t4);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, new Vector3(foot1.GetComponent<feet1>().ReturnJump2().transform.localPosition.x, foot1.GetComponent<feet1>().ReturnJump2().transform.localPosition.y, 3), t4);
            }
        }
    }
    private void TransformPlaneRobot()
    {
        foot1pos = foot1.transform.localPosition;
        foot2pos = foot2.transform.localPosition;
        leg1pos = leg1.transform.localPosition;
        leg2pos = leg2.transform.localPosition;
        foot1rot = foot1.transform.localRotation;
        foot2rot = foot2.transform.localRotation;
        leg1rot = leg1.transform.localRotation;
        leg2rot = leg2.transform.localRotation;
        pb = 1;
        form = 2;
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.4f);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        foot1.SetActive(true);
        foot2.SetActive(true);
        leg1.SetActive(true);
        leg2.SetActive(true);
        foot1.GetComponent<SpriteRenderer>().color = new Color32((byte)(foot1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.b * 255), (byte)(0));
        foot2.GetComponent<SpriteRenderer>().color = new Color32((byte)(foot2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.b * 255), (byte)(0));
        leg1.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), (byte)(0));
        leg2.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.b * 255), (byte)(0));
        Invoke("StopPB", 0.3f);
    }
    private void TransformRobotPlane()
    {
        if (jumps <= 1)
        {
            foot1pos = foot1.transform.localPosition;
            foot2pos = foot2.transform.localPosition;
            leg1pos = leg1.transform.localPosition;
            leg2pos = leg2.transform.localPosition;
            foot1rot = foot1.transform.localRotation;
            foot2rot = foot2.transform.localRotation;
            leg1rot = leg1.transform.localRotation;
            leg2rot = leg2.transform.localRotation;
            ra = 1;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0f);
            form = 3;
            damageMultiplier = 2f;
            ableToTrans = 1;
            Invoke("AbleToTrans", 1f);
            plane.SetActive(true);
            Invoke("StopRP", 0.4f);
        }
    }
    private void RunningPP()
    {
        foot1pos = foot1.transform.localPosition;
        foot2pos = foot2.transform.localPosition;
        leg1pos = leg1.transform.localPosition;
        leg2pos = leg2.transform.localPosition;
        foot1rot = foot1.transform.localRotation;
        foot2rot = foot2.transform.localRotation;
        leg1rot = leg1.transform.localRotation;
        leg2rot = leg2.transform.localRotation;
        runninganim++;
        t6 = 0;
        t7 = 0;
        t8 = 0;
        t9 = 0;
        if (runninganim == 5)
        {
            runninganim = 1;
        }
        CancelInvoke("RunningPP");
    }
    private void RT()
    {
        if (rt == 1)
        {
            t5 += Time.deltaTime / 0.3f;
            foot1.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(foot1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.b * 255), 255), endColor, t5);
            foot2.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(foot2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.b * 255), 255), endColor, t5);
            leg1.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 255), endColor, t5);
            leg2.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.b * 255), 255), endColor, t5);
            actualWheels.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(actualWheels.GetComponent<SpriteRenderer>().color.r * 255), (byte)(actualWheels.GetComponent<SpriteRenderer>().color.g * 255), (byte)(actualWheels.GetComponent<SpriteRenderer>().color.b * 255), 0), startCOlor, t5);
        }
    }
    private void TransformRobotTank()
    {
        rt = 1;
        form = 1;
        wheels.SetActive(true);
        Invoke("StopRT", 0.3f);
    }

    //Animations

    private void DuckAnim()
    {
        if (duckAnim == true)
        {
            t16 += Time.deltaTime / 0.2f;
            if (t16 <= 0.5f)
            {
                leg1.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 255), new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 0), t16*2);
                leg2.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 255), new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 0), t16*2);
            }
            else
            {
                leg1.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 0);
                leg2.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.b * 255), 0);
            }
            body.transform.localPosition = Vector2.Lerp(new Vector2(0,0), new Vector2(0, -0.66f), t16);
            pistol.transform.localPosition = Vector2.Lerp(new Vector2(0, 0), new Vector2(0, -0.66f), t16);
        }
    }
    private void DuckReverseAnim()
    {
        if (duckReverseAnim == true)
        {
            t17 += Time.deltaTime / 0.2f;
            if (t17 >= 0.5f)
            {
                leg1.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 0), new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 255), t17);
                leg2.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 0), new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 255), t17);
            }
            body.transform.localPosition = Vector2.Lerp(new Vector2(0, -0.66f), new Vector2(0, 0), t17);
            pistol.transform.localPosition = Vector2.Lerp(new Vector2(0, -0.66f), new Vector2(0, 0), t17);
            leg1.SetActive(true);
            leg2.SetActive(true);
        }
    }
    
    private void BurnEffect()
    {
        if (burn == 1)
        {
            t14 += Time.deltaTime / 4.0f;
            if (10 - body.GetComponent<TankBody>().ReturnBody().GetComponent<body>().ReturnThermalArmor() < 1)
                hp = Mathf.Lerp(inithp, inithp - damageMultiplier, t14);
            else
                hp = Mathf.Lerp(inithp, inithp - (10 - body.GetComponent<TankBody>().ReturnBody().GetComponent<body>().ReturnThermalArmor()) * damageMultiplier, t14);
            hpBar.transform.localScale = new Vector3(100 * hp / maxhp / 100, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
            if (hp <= 0)
            { AudioSource.PlayClipAtPoint(death, Camera.main.transform.position); GameObject clone = Instantiate(deathVfx); clone.transform.position = transform.position; FindObjectOfType<SceneLoader>().LoadSelect(); Destroy(gameObject); }
        }
    }
    private void Rot1()
    {
        if (rot1 == 1)
        {
            t1 += Time.deltaTime / 0.3f;
            actualWheels.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(actualWheels.GetComponent<SpriteRenderer>().color.r * 255), (byte)(actualWheels.GetComponent<SpriteRenderer>().color.g * 255), (byte)(actualWheels.GetComponent<SpriteRenderer>().color.b * 255), 255), endColor, t1);
        }
    }
    private void Rot2()
    {
        if (rot2 == 1)
        {
            wheels.SetActive(false);
            t2 += Time.deltaTime / 0.6f;
            foot1.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(foot1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.b * 255), 0), startCOlor, t2);
            foot2.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(foot2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.b * 255), 0), startCOlor, t2);
            leg1.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 0), startCOlor, t2);
            leg2.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.b * 255), 0), startCOlor, t2);
        }
    }
    private void ManaBarAnim()
    {
        if (canShoot == false)
        {
            t15 += Time.deltaTime / pistol.GetComponent<TankPistol>().ReturnAtkSpeed();
            manaBar.transform.localScale = Vector2.Lerp(new Vector2(0, 1), new Vector2(1, 1), t15);
        }
    }

    private void SecondRocket()
    {
        if (pistol.GetComponent<TankPistol>().ReturnPistol().tag == "Rocket")
        {
            GameObject clone = Instantiate(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket2());
            if (face == 0)
            {
                clone.transform.position = pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket2().transform.position;
                clone.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                clone.GetComponent<Rigidbody2D>().velocity = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltSpeed() * (-1), 0f);
            }
            else if (face == 1)
            {
                clone.transform.position = pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket2().transform.position;
                clone.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                clone.GetComponent<Rigidbody2D>().velocity = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltSpeed(), 0f);
            }
            clone.GetComponent<bullet>().enabled = true;
            clone.GetComponent<bullet>().GetDamage(damage);
            clone.GetComponent<bullet>().GetTank(gameObject);
            clone.GetComponent<bullet>().GetEffect(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnEffect());
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot1.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg1.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
            AudioSource.PlayClipAtPoint(pistol.GetComponent<TankPistol>().ReturnShot(), Camera.main.transform.position);
            GameObject clone2 = Instantiate(rocketVfx);
            clone2.transform.position = pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket2().transform.position;
            Destroy(clone2, 1f);
            pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket2().transform.localScale = new Vector3(0, 0, 1);
            rocketAnim = true;
            t13 = 0;
            t15 = 0;
            Invoke("CanShoot", pistol.GetComponent<TankPistol>().ReturnAtkSpeed());
            Invoke("StopRocketAnim", pistol.GetComponent<TankPistol>().ReturnAtkSpeed());
        }
    }
    private void StopRocketAnim()
    {
        rocketAnim = false;
        pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket1().transform.localScale = new Vector3(1, 0.552f, 1);
        pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket2().transform.localScale = new Vector3(1, 0.552f, 1);
    }
    private void RocketAnim()
    {
        if (rocketAnim == true)
        {
            t13 += Time.deltaTime / pistol.GetComponent<TankPistol>().ReturnAtkSpeed();
            pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket1().transform.localScale = Vector3.Lerp(new Vector3(0, 0, 1), new Vector3(1, 0.552f, 1), t13);
            pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket2().transform.localScale = Vector3.Lerp(new Vector3(0, 0, 1), new Vector3(1, 0.552f, 1), t13);
        }
    }
    private void PistolAnimBack()
    {
        if (pistolBack == true)
        {
            if (face == 0)
            {
                pistol.GetComponent<TankPistol>().ReturnPistol().transform.position = new Vector3(pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.x + 0.8f / framerate / 0.1f / 6, pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.y, pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.z);
            }
            else if (face == 1)
            {
                pistol.GetComponent<TankPistol>().ReturnPistol().transform.position = new Vector3(pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.x - 0.8f / framerate / 0.1f / 6, pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.y, pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.z);
            }
        }
    }
    private void PistolAnim()
    {
        if (pistolAnim == true)
        {
            if (face == 0)
            {
                pistol.GetComponent<TankPistol>().ReturnPistol().transform.position = new Vector3(pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.x - 0.8f / framerate / 6 / pistol.GetComponent<TankPistol>().ReturnAtkSpeed(), pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.y, pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.z);
            }
            else if (face == 1)
            {
                pistol.GetComponent<TankPistol>().ReturnPistol().transform.position = new Vector3(pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.x + 0.8f / framerate / 6 / pistol.GetComponent<TankPistol>().ReturnAtkSpeed(), pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.y, pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.z);
            }
        }
    }
    private void MortarAnimBack()
    {
        if (mortarBack == true)
        {
            pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.localScale = new Vector3(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.localScale.x - 2f / framerate / 0.1f / 6, pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.localScale.y, pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.localScale.z);
        }
    }
    private void MortarAnim()
    {
        if (mortarAnim == true)
        {
            pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.localScale = new Vector3(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.localScale.x + 2f / framerate / 6 / pistol.GetComponent<TankPistol>().ReturnAtkSpeed(), pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.localScale.y, pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.localScale.z);
        }
    }
    
    private void Jump1()
    {
        if (t11 <= 1)
        {
            t11 += Time.deltaTime / 0.3f;
            if (face == 2)
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnJump1().transform.localRotation, t11);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, leg1.GetComponent<leg1>().ReturnJump1().transform.localPosition, t11);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnJump1().transform.localRotation, t11);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, leg2.GetComponent<leg2>().ReturnJump1().transform.localPosition, t11);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnJump1().transform.localRotation, t11);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, foot2.GetComponent<feet2>().ReturnJump1().transform.localPosition, t11);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnJump1().transform.localRotation, t11);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, foot1.GetComponent<feet1>().ReturnJump1().transform.localPosition, t11);
            }
            else
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnJump1().transform.localRotation, t11);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, new Vector3(leg1.GetComponent<leg1>().ReturnJump1().transform.localPosition.x, leg1.GetComponent<leg1>().ReturnJump1().transform.localPosition.y, 5), t11);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnJump1().transform.localRotation, t11);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, new Vector3(leg2.GetComponent<leg2>().ReturnJump1().transform.localPosition.x, leg2.GetComponent<leg2>().ReturnJump1().transform.localPosition.y, 5), t11);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnJump1().transform.localRotation, t11);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, new Vector3(foot2.GetComponent<feet2>().ReturnJump1().transform.localPosition.x, foot2.GetComponent<feet2>().ReturnJump1().transform.localPosition.y, 3), t11);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnJump1().transform.localRotation, t11);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, new Vector3(foot1.GetComponent<feet1>().ReturnJump1().transform.localPosition.x, foot1.GetComponent<feet1>().ReturnJump1().transform.localPosition.y, 3), t11);
            }
        }
    }
    private void Jump2()
    {
        if (t12 <= 1)
        {
            t12 += Time.deltaTime / 0.3f;
            if (face == 2)
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnJump2().transform.localRotation, t12);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, leg1.GetComponent<leg1>().ReturnJump2().transform.localPosition, t12);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnJump2().transform.localRotation, t12);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, leg2.GetComponent<leg2>().ReturnJump2().transform.localPosition, t12);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnJump2().transform.localRotation, t12);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, foot2.GetComponent<feet2>().ReturnJump2().transform.localPosition, t12);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnJump2().transform.localRotation, t12);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, foot1.GetComponent<feet1>().ReturnJump2().transform.localPosition, t12);
            }
            else
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnJump2().transform.localRotation, t12);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, new Vector3(leg1.GetComponent<leg1>().ReturnJump2().transform.localPosition.x, leg1.GetComponent<leg1>().ReturnJump2().transform.localPosition.y, 5), t12);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnJump2().transform.localRotation, t12);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, new Vector3(leg2.GetComponent<leg2>().ReturnJump2().transform.localPosition.x, leg2.GetComponent<leg2>().ReturnJump2().transform.localPosition.y, 5), t12);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnJump2().transform.localRotation, t12);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, new Vector3(foot2.GetComponent<feet2>().ReturnJump2().transform.localPosition.x, foot2.GetComponent<feet2>().ReturnJump2().transform.localPosition.y, 3), t12);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnJump2().transform.localRotation, t12);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, new Vector3(foot1.GetComponent<feet1>().ReturnJump2().transform.localPosition.x, foot1.GetComponent<feet1>().ReturnJump2().transform.localPosition.y, 3), t12);
            }
        }
    }
    private void RunningAnim1()
    {
        if (runninganim == 1 && ableToRun == 1)
        {
            running = 1;
            t6 += Time.deltaTime / 0.2f;
            if (face == 2)
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnRun1().transform.localRotation, t6);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, leg1.GetComponent<leg1>().ReturnRun1().transform.localPosition, t6);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnRun1().transform.localRotation, t6);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, leg2.GetComponent<leg2>().ReturnRun1().transform.localPosition, t6);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnRun1().transform.localRotation, t6);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, foot2.GetComponent<feet2>().ReturnRun1().transform.localPosition, t6);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnRun1().transform.localRotation, t6);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, foot1.GetComponent<feet1>().ReturnRun1().transform.localPosition, t6);
            }
            else
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnRun1().transform.localRotation, t6);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, new Vector3(leg1.GetComponent<leg1>().ReturnRun1().transform.localPosition.x, leg1.GetComponent<leg1>().ReturnRun1().transform.localPosition.y, 5), t6);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnRun1().transform.localRotation, t6);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, new Vector3(leg2.GetComponent<leg2>().ReturnRun1().transform.localPosition.x, leg2.GetComponent<leg2>().ReturnRun1().transform.localPosition.y, 5), t6);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnRun1().transform.localRotation, t6);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, new Vector3(foot2.GetComponent<feet2>().ReturnRun1().transform.localPosition.x, foot2.GetComponent<feet2>().ReturnRun1().transform.localPosition.y, 3), t6);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnRun1().transform.localRotation, t6);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, new Vector3(foot1.GetComponent<feet1>().ReturnRun1().transform.localPosition.x, foot1.GetComponent<feet1>().ReturnRun1().transform.localPosition.y, 3), t6);

            }
            if (t6 >= 1)
            {
                RunningPP();
            }
        }
    }
    private void RunningAnim2()
    {
        if (runninganim == 2 && ableToRun == 1)
        {
            running = 1;
            t7 += Time.deltaTime / 0.1f;
            if (face == 2)
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnRun2().transform.localRotation, t7);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, leg1.GetComponent<leg1>().ReturnRun2().transform.localPosition, t7);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnRun2().transform.localRotation, t7);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, leg2.GetComponent<leg2>().ReturnRun2().transform.localPosition, t7);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnRun2().transform.localRotation, t7);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, foot2.GetComponent<feet2>().ReturnRun2().transform.localPosition, t7);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnRun2().transform.localRotation, t7);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, foot1.GetComponent<feet1>().ReturnRun2().transform.localPosition, t7);
            }
            else
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnRun2().transform.localRotation, t7);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, new Vector3(leg1.GetComponent<leg1>().ReturnRun2().transform.localPosition.x, leg1.GetComponent<leg1>().ReturnRun2().transform.localPosition.y, 5), t7);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnRun2().transform.localRotation, t7);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, new Vector3(leg2.GetComponent<leg2>().ReturnRun2().transform.localPosition.x, leg2.GetComponent<leg2>().ReturnRun2().transform.localPosition.y, 5), t7);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnRun2().transform.localRotation, t7);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, new Vector3(foot2.GetComponent<feet2>().ReturnRun2().transform.localPosition.x, foot2.GetComponent<feet2>().ReturnRun2().transform.localPosition.y, 3), t7);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnRun2().transform.localRotation, t7);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, new Vector3(foot1.GetComponent<feet1>().ReturnRun2().transform.localPosition.x, foot1.GetComponent<feet1>().ReturnRun2().transform.localPosition.y, 3), t7);
            }
            if (t7 >= 1)
            {
                RunningPP();
            }
        }
    }
    private void RunningAnim3()
    {
        if (runninganim == 3 && ableToRun == 1)
        {
            running = 1;
            t8 += Time.deltaTime / 0.2f;
            if (face == 2)
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnRun3().transform.localRotation, t8);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, leg1.GetComponent<leg1>().ReturnRun3().transform.localPosition, t8);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnRun3().transform.localRotation, t8);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, leg2.GetComponent<leg2>().ReturnRun3().transform.localPosition, t8);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnRun3().transform.localRotation, t8);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, foot2.GetComponent<feet2>().ReturnRun3().transform.localPosition, t8);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnRun3().transform.localRotation, t8);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, foot1.GetComponent<feet1>().ReturnRun3().transform.localPosition, t8);
            }
            else
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnRun3().transform.localRotation, t8);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, new Vector3(leg1.GetComponent<leg1>().ReturnRun3().transform.localPosition.x, leg1.GetComponent<leg1>().ReturnRun3().transform.localPosition.y, 5), t8);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnRun3().transform.localRotation, t8);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, new Vector3(leg2.GetComponent<leg2>().ReturnRun3().transform.localPosition.x, leg2.GetComponent<leg2>().ReturnRun3().transform.localPosition.y, 5), t8);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnRun3().transform.localRotation, t8);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, new Vector3(foot2.GetComponent<feet2>().ReturnRun3().transform.localPosition.x, foot2.GetComponent<feet2>().ReturnRun3().transform.localPosition.y, 3), t8);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnRun3().transform.localRotation, t8);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, new Vector3(foot1.GetComponent<feet1>().ReturnRun3().transform.localPosition.x, foot1.GetComponent<feet1>().ReturnRun3().transform.localPosition.y, 3), t8);

            }
            if (t8 >= 1)
            {
                RunningPP();
            }
        }
    }
    private void RunningAnim4()
    {
        if (runninganim == 4 && ableToRun == 1)
        {
            running = 1;
            t9 += Time.deltaTime / 0.1f;
            if (face == 2)
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnRun4().transform.localRotation, t9);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, leg1.GetComponent<leg1>().ReturnRun4().transform.localPosition, t9);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnRun4().transform.localRotation, t9);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, leg2.GetComponent<leg2>().ReturnRun4().transform.localPosition, t9);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnRun4().transform.localRotation, t9);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, foot2.GetComponent<feet2>().ReturnRun4().transform.localPosition, t9);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnRun4().transform.localRotation, t9);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, foot1.GetComponent<feet1>().ReturnRun4().transform.localPosition, t9);

            }
            else
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1rot, leg1.GetComponent<leg1>().ReturnRun4().transform.localRotation, t9);
                leg1.transform.localPosition = Vector3.Lerp(leg1pos, new Vector3(leg1.GetComponent<leg1>().ReturnRun4().transform.localPosition.x, leg1.GetComponent<leg1>().ReturnRun4().transform.localPosition.y, 5), t9);
                leg2.transform.localRotation = Quaternion.Lerp(leg2rot, leg2.GetComponent<leg2>().ReturnRun4().transform.localRotation, t9);
                leg2.transform.localPosition = Vector3.Lerp(leg2pos, new Vector3(leg2.GetComponent<leg2>().ReturnRun4().transform.localPosition.x, leg2.GetComponent<leg2>().ReturnRun4().transform.localPosition.y, 5), t9);
                foot2.transform.localRotation = Quaternion.Lerp(foot2rot, foot2.GetComponent<feet2>().ReturnRun4().transform.localRotation, t9);
                foot2.transform.localPosition = Vector3.Lerp(foot2pos, new Vector3(foot2.GetComponent<feet2>().ReturnRun4().transform.localPosition.x, foot2.GetComponent<feet2>().ReturnRun4().transform.localPosition.y, 3), t9);
                foot1.transform.localRotation = Quaternion.Lerp(foot1rot, foot1.GetComponent<feet1>().ReturnRun4().transform.localRotation, t9);
                foot1.transform.localPosition = Vector3.Lerp(foot1pos, new Vector3(foot1.GetComponent<feet1>().ReturnRun4().transform.localPosition.x, foot1.GetComponent<feet1>().ReturnRun4().transform.localPosition.y, 3), t9);
            }
            if (t9 >= 0.9f)
            {
                RunningPP();
            }
        }
    }
    private void Idle()
    {
        if (runninganim == 0 && ableToRun == 1 && jumps == 2)
        {
            while (t10 < 1)
            {
                t10 += Time.deltaTime / 1f;
            }
            if (face == 0)
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1.transform.localRotation, leg1.GetComponent<leg1>().ReturnIdle().transform.localRotation, t10);
                leg1.transform.localPosition = Vector3.Lerp(leg1.transform.localPosition, leg1.GetComponent<leg1>().ReturnIdle().transform.localPosition, t10);
                leg2.transform.localRotation = Quaternion.Lerp(leg2.transform.localRotation, leg2.GetComponent<leg2>().ReturnIdle().transform.localRotation, t10);
                leg2.transform.localPosition = Vector3.Lerp(leg2.transform.localPosition, leg2.GetComponent<leg2>().ReturnIdle().transform.localPosition, t10);
                foot2.transform.localRotation = Quaternion.Lerp(foot2.transform.localRotation, foot2.GetComponent<feet2>().ReturnIdle().transform.localRotation, t10);
                foot2.transform.localPosition = Vector3.Lerp(foot2.transform.localPosition, foot2.GetComponent<feet2>().ReturnIdle().transform.localPosition, t10);
                foot1.transform.localRotation = Quaternion.Lerp(foot1.transform.localRotation, foot1.GetComponent<feet1>().ReturnIdle().transform.localRotation, t10);
                foot1.transform.localPosition = Vector3.Lerp(foot1.transform.localPosition, foot1.GetComponent<feet1>().ReturnIdle().transform.localPosition, t10);
            }
            else
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1.transform.localRotation, leg1.GetComponent<leg1>().ReturnIdle2().transform.localRotation, t10);
                leg1.transform.localPosition = Vector3.Lerp(leg1.transform.localPosition, leg1.GetComponent<leg1>().ReturnIdle2().transform.localPosition, t10);
                leg2.transform.localRotation = Quaternion.Lerp(leg2.transform.localRotation, leg2.GetComponent<leg2>().ReturnIdle2().transform.localRotation, t10);
                leg2.transform.localPosition = Vector3.Lerp(leg2.transform.localPosition, leg2.GetComponent<leg2>().ReturnIdle2().transform.localPosition, t10);
                foot2.transform.localRotation = Quaternion.Lerp(foot2.transform.localRotation, foot2.GetComponent<feet2>().ReturnIdle2().transform.localRotation, t10);
                foot2.transform.localPosition = Vector3.Lerp(foot2.transform.localPosition, foot2.GetComponent<feet2>().ReturnIdle2().transform.localPosition, t10);
                foot1.transform.localRotation = Quaternion.Lerp(foot1.transform.localRotation, foot1.GetComponent<feet1>().ReturnIdle2().transform.localRotation, t10);
                foot1.transform.localPosition = Vector3.Lerp(foot1.transform.localPosition, foot1.GetComponent<feet1>().ReturnIdle2().transform.localPosition, t10);
            }
            Invoke("RunningMM", 0.1f);
        }
    }
    private void PlaneTrans()
    {
        if (ra == 1)
        {
            t3 += Time.deltaTime / 0.4f;
            if (face == 0)
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1.transform.localRotation, leg1.GetComponent<leg1>().ReturnUntransformed().transform.localRotation, t3);
                leg1.transform.localPosition = Vector3.Lerp(leg1.transform.localPosition, new Vector3(0.73f, -0.39f, -10), t3);
                leg2.transform.localRotation = Quaternion.Lerp(leg2.transform.localRotation, leg2.GetComponent<leg2>().ReturnUntransformed().transform.localRotation, t3);
                leg2.transform.localPosition = Vector3.Lerp(leg2.transform.localPosition, new Vector3(0.73f, -0.39f, -10), t3);
                foot2.transform.localRotation = Quaternion.Lerp(foot2.transform.localRotation, foot2.GetComponent<feet2>().ReturnUntransformed().transform.localRotation, t3);
                foot2.transform.localPosition = Vector3.Lerp(foot2.transform.localPosition, foot2.GetComponent<feet2>().ReturnUntransformed().transform.localPosition, t3);
                foot1.transform.localRotation = Quaternion.Lerp(foot1.transform.localRotation, foot1.GetComponent<feet1>().ReturnUntransformed().transform.localRotation, t3);
                foot1.transform.localPosition = Vector3.Lerp(foot1.transform.localPosition, foot1.GetComponent<feet1>().ReturnUntransformed().transform.localPosition, t3);
            }
            else
            {
                leg1.transform.localRotation = Quaternion.Lerp(leg1.transform.localRotation, leg1.GetComponent<leg1>().ReturnUntransformed().transform.localRotation, t3);
                leg1.transform.localPosition = Vector3.Lerp(leg1.transform.localPosition, new Vector3(0.73f, -0.39f, 10), t3);
                leg2.transform.localRotation = Quaternion.Lerp(leg2.transform.localRotation, leg2.GetComponent<leg2>().ReturnUntransformed().transform.localRotation, t3);
                leg2.transform.localPosition = Vector3.Lerp(leg2.transform.localPosition, new Vector3(0.73f, -0.39f, 10), t3);
                foot2.transform.localRotation = Quaternion.Lerp(foot2.transform.localRotation, foot2.GetComponent<feet2>().ReturnUntransformed().transform.localRotation, t3);
                foot2.transform.localPosition = Vector3.Lerp(foot2.transform.localPosition, new Vector3(foot2.GetComponent<feet2>().ReturnUntransformed().transform.localPosition.x, foot2.GetComponent<feet2>().ReturnUntransformed().transform.localPosition.y, -foot2.GetComponent<feet2>().ReturnUntransformed().transform.localPosition.z), t3);
                foot1.transform.localRotation = Quaternion.Lerp(foot1.transform.localRotation, foot1.GetComponent<feet1>().ReturnUntransformed().transform.localRotation, t3);
                foot1.transform.localPosition = Vector3.Lerp(foot1.transform.localPosition, new Vector3(foot1.GetComponent<feet1>().ReturnUntransformed().transform.localPosition.x, foot1.GetComponent<feet1>().ReturnUntransformed().transform.localPosition.y, -foot1.GetComponent<feet1>().ReturnUntransformed().transform.localPosition.z), t3);
            }
            foot1.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(foot1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.b * 255), 255), endColor, t3);
            foot2.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(foot2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.b * 255), 255), endColor, t3);
            leg1.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 255), endColor, t3);
            leg2.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(leg2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.b * 255), 255), endColor, t3);
            plane.GetComponent<SpriteRenderer>().color = Color32.Lerp(new Color32((byte)(plane.GetComponent<SpriteRenderer>().color.r * 255), (byte)(plane.GetComponent<SpriteRenderer>().color.g * 255), (byte)(plane.GetComponent<SpriteRenderer>().color.b * 255), 0), startCOlor, t3);

        }
    }
    //Animation Stops
    private void StopMortarAnim()
    {
        mortarAnim = false;
        pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.localScale = new Vector3(1, 1, 1);

    }
    private void StopMortarBackAnim()
    {
        mortarBack = false;
        mortarAnim = true;
    }
    private void StopDuckAnim()
    {
        duckAnim = false;
        leg1.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 0);
        leg2.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.b * 255), 0);
        body.transform.localPosition = new Vector2(0, -0.66f);
        pistol.transform.localPosition = new Vector2(0, -0.66f);
        leg1.SetActive(false);
        leg2.SetActive(false);

    }
    private void StopDuckAnim2()
    {
        duckReverseAnim = false;
        leg1.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), 255);
        leg2.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.b * 255), 255);
        body.transform.localPosition = new Vector2(0, 0f);
        pistol.transform.localPosition = new Vector2(0, 0f);
        leg1.SetActive(true);
        leg2.SetActive(true);
        ableToDoStuff = true;
    }
    private void StopPistolAnim()
    {
        pistolAnim = false;
        if (face == 0)
        {
            pistol.GetComponent<TankPistol>().ReturnPistol().transform.position = pistol.GetComponent<TankPistol>().ReturnOgPos().transform.position;
        }
        else if (face == 1)
        {
            pistol.GetComponent<TankPistol>().ReturnPistol().transform.position = new Vector3(pistol.GetComponent<TankPistol>().ReturnOgPos().transform.position.x, pistol.GetComponent<TankPistol>().ReturnOgPos().transform.position.y, 2f);
        }

    }
    private void StopPistolBackAnim()
    {
        pistolBack = false;
        pistolAnim = true;
    }
    private void StopBurn()
    {
        burn = 0;
        Destroy(burnVfx);
    }
    private void StopRot2()
    {
        rot2 = 0;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        wheels.SetActive(false);
    }
    private void StopRot1()
    {
        rot1 = 0;
        rot2 = 1;
        foot1.SetActive(true);
        foot2.SetActive(true);
        leg1.SetActive(true);
        leg2.SetActive(true);
        Invoke("StopRot2", 0.6f);
    }
    private void StopRP()
    {
        ra = 0;
        foot1.SetActive(false);
        foot2.SetActive(false);
        leg1.SetActive(false);
        leg2.SetActive(false);
        ground2.GetComponent<BoxCollider2D>().size = new Vector2(ground2.GetComponent<BoxCollider2D>().size.x, 0.3243346f);
        ground2.GetComponent<BoxCollider2D>().offset = new Vector2(ground2.GetComponent<BoxCollider2D>().offset.x, 0.003757477f);
    }
    private void StopPB()
    {
        pb = 0;
        ground2.GetComponent<BoxCollider2D>().size = new Vector2(ground2.GetComponent<BoxCollider2D>().size.x, 0.947695F);
        ground2.GetComponent<BoxCollider2D>().offset = new Vector2(ground2.GetComponent<BoxCollider2D>().offset.x, -0.3079227F);
        foot1.GetComponent<SpriteRenderer>().color = new Color32((byte)(foot1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.b * 255), (byte)(255));
        foot2.GetComponent<SpriteRenderer>().color = new Color32((byte)(foot2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.b * 255), (byte)(255));
        leg1.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), (byte)(255));
        leg2.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.b * 255), (byte)(255));
        plane.GetComponent<SpriteRenderer>().color = new Color32((byte)(plane.GetComponent<SpriteRenderer>().color.r * 255), (byte)(plane.GetComponent<SpriteRenderer>().color.g * 255), (byte)(plane.GetComponent<SpriteRenderer>().color.b * 255), (byte)(0));
        plane.SetActive(false);
    }
    private void StopRT()
    {
        rt = 0;
        foot1.GetComponent<SpriteRenderer>().color = new Color32((byte)(foot1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot1.GetComponent<SpriteRenderer>().color.b * 255), (byte)(0));
        foot2.GetComponent<SpriteRenderer>().color = new Color32((byte)(foot2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(foot2.GetComponent<SpriteRenderer>().color.b * 255), (byte)(0));
        leg1.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg1.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg1.GetComponent<SpriteRenderer>().color.b * 255), (byte)(0));
        leg2.GetComponent<SpriteRenderer>().color = new Color32((byte)(leg2.GetComponent<SpriteRenderer>().color.r * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.g * 255), (byte)(leg2.GetComponent<SpriteRenderer>().color.b * 255), (byte)(0));
        foot1.SetActive(false);
        foot2.SetActive(false);
        leg1.SetActive(false);
        leg2.SetActive(false);
        ground2.GetComponent<BoxCollider2D>().size = new Vector2(ground2.GetComponent<BoxCollider2D>().size.x, 0.3243346f);
        ground2.GetComponent<BoxCollider2D>().offset = new Vector2(ground2.GetComponent<BoxCollider2D>().offset.x, 0.003757477f);
        actualWheels.transform.localPosition = wheelsogpos;
    }
    //Variable Setups

    private void AbleToTrans()
    {
        ableToTrans = 0;
    }
    public void SetBurn(GameObject burn)
    {
        burnVfx = burn;
    }
    public void LeftMove()
    {
        leftmove = 1;
    }
    public void RightMove()
    {
        rightmove = 1;
    }
    public void NotLeftMove()
    {
        leftmove = 0;
    }
    public void NotRightMove()
    {
        rightmove = 0;
    }
    public void ResetJumps()
    {
        gravity = 1;
        jumps = 2;
		ableToJump = true;
    }
    public void GravityZero()
    {
        gravity = 0;
    }
    private void ATTD()
    {
        ableToTakeDMG = 0;
    }
    private void CanShoot()
    {
        canShoot = true;
    }

    //Return Data

    public int ReturnBurn()
    {
        return burn;
    }
    public GameObject ReturnFoot1()
    {
        return foot1;
    }
    public GameObject ReturnFoot2()
    {
        return foot2;
    }
    public GameObject ReturnHolder()
    {
        return holder;
    }
    //Other

    public void Burn()
    {
        burn = 1;
        inithp = hp;
        targethp = inithp - 10;
        t14 = 0;
        CancelInvoke("StopBurn");
        Invoke("StopBurn", 4f);
    }
    public void DecreaseHp(float damag, bool takeDmg, string damageType, GameObject bulletz)
    {
        if (takeDmg == false)
        {
            if (ableToTakeDMG == 0)
            {
                if (damageType == "kinetic")
                {
                    if ((damag - body.GetComponent<TankBody>().ReturnBody().GetComponent<body>().ReturnKineticArmor()) < 1)
                        hp -= damageMultiplier;
                    else
                        hp = hp - (damag - body.GetComponent<TankBody>().ReturnBody().GetComponent<body>().ReturnKineticArmor()) * damageMultiplier;
                }
                else if (damageType == "thermal")
                {
                    if ((damag - body.GetComponent<TankBody>().ReturnBody().GetComponent<body>().ReturnThermalArmor()) < 1)
                        hp -= damageMultiplier;
                    else
                        hp = hp - (damag - body.GetComponent<TankBody>().ReturnBody().GetComponent<body>().ReturnThermalArmor()) * damageMultiplier;
                }

                hpBar.transform.localScale = new Vector3(100 * hp / maxhp / 100, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
                if (hp <= 0)
                { AudioSource.PlayClipAtPoint(death, Camera.main.transform.position); GameObject clone = Instantiate(deathVfx); clone.transform.position = transform.position; FindObjectOfType<SceneLoader>().LoadSelect(); Destroy(gameObject); }
            }
        }
        else
        {
            if (damageType == "kinetic")
            {
                if ((damag - body.GetComponent<TankBody>().ReturnBody().GetComponent<body>().ReturnKineticArmor()) < 1)
                    hp -= damageMultiplier;
                else
                    hp = hp - (damag - body.GetComponent<TankBody>().ReturnBody().GetComponent<body>().ReturnKineticArmor()) * damageMultiplier;
            }
            else if (damageType == "thermal")
            {
                if ((damag - body.GetComponent<TankBody>().ReturnBody().GetComponent<body>().ReturnThermalArmor()) < 1)
                    hp -= damageMultiplier;
                else
                    hp = hp - (damag - body.GetComponent<TankBody>().ReturnBody().GetComponent<body>().ReturnThermalArmor()) * damageMultiplier;
            }
            hpBar.transform.localScale = new Vector3(100 * hp / maxhp / 100, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
            if (hp <= 0)
            { AudioSource.PlayClipAtPoint(death, Camera.main.transform.position); GameObject clone = Instantiate(deathVfx); clone.transform.position = transform.position; FindObjectOfType<SceneLoader>().LoadSelect(); Destroy(gameObject); }
        }
        inithp = hp;
        targethp = inithp - 10;
        if (player == 3 || player == 4)
        {
            /*if (player == 3)
            {
                playerIndex = (PlayerIndex)0;
                GamePad.SetVibration(playerIndex, 0.5f, 0.5f);
            }
            else if (player == 4)
            {
                playerIndex = (PlayerIndex)1;
                GamePad.SetVibration(playerIndex, 0.5f, 0.5f);
            }
            Invoke("StopVibration", 0.15f); */
        }
    }
    private void StopVibration()
    {
        if (player == 3)
        {
            playerIndex = (PlayerIndex)0;
            GamePad.SetVibration(playerIndex, 0f, 0f);
        }
        else if (player == 4)
        {
            playerIndex = (PlayerIndex)1;
            GamePad.SetVibration(playerIndex, 0f, 0f);
        }
    }
    private void SetRotations()
    {
        if (facing == 1)
        {
            flame1.transform.eulerAngles = new Vector3(0f, 180f, -45f);
            flame2.transform.eulerAngles = new Vector3(0f, 180f, -22f);
            flame3.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            flame4.transform.eulerAngles = new Vector3(0f, 180f, 22f);
            flame5.transform.eulerAngles = new Vector3(0f, 180f, 45f);
        }
        else
        {
            flame1.transform.eulerAngles = new Vector3(0f, 0f, -45f);
            flame2.transform.eulerAngles = new Vector3(0f, 0f, -22f);
            flame3.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            flame4.transform.eulerAngles = new Vector3(0f, 0f, 22f);
            flame5.transform.eulerAngles = new Vector3(0f, 0f, 45f);
        }
    }
    public GameObject ReturnWheels()
    {
        return wheels;
    }
    public GameObject ReturnBody()
    {
        return body;
    }
    public GameObject ReturnPistol()
    {
        return holder;
    }
    public GameObject ReturnFoot11()
    {
        return foot1;
    }
    public GameObject ReturnFoot22()
    {
        return foot2;
    }
    public GameObject ReturnLeg1()
    {
        return leg1;
    }
    public GameObject ReturnLeg2()
    {
        return leg2;
    }






    // Update functions
    private void Executables()
    {
        if (wheels.GetComponent<TankWheels>().ReturnWheels().transform.localPosition != wheelsogpos)
        {
            wheels.GetComponent<TankWheels>().ReturnWheels().transform.localPosition = wheelsogpos;
        }
        if (flame1 != null)
            SetRotations();
        if (GetComponent<Rigidbody2D>().velocity.y >= 1.5f)
        {
            if (jumped1 == 0)
            {
                foot1pos = foot1.transform.localPosition;
                foot2pos = foot2.transform.localPosition;
                leg1pos = leg1.transform.localPosition;
                leg2pos = leg2.transform.localPosition;
                foot1rot = foot1.transform.localRotation;
                foot2rot = foot2.transform.localRotation;
                leg1rot = leg1.transform.localRotation;
                leg2rot = leg2.transform.localRotation;
                jumped1 = 1;
                t11 = 0;
                t9 = 0;
                t6 = 0;
                t7 = 0;
                t8 = 0;
            }
            ableToRun = 0;
            runninganim = 0;
            Jump1();
        }
        else if (GetComponent<Rigidbody2D>().velocity.y <= -1.5f && foot1.GetComponent<feet1>().GetColl() == 0 && foot2.GetComponent<feet2>().GetColl() == 0)
        {
            if (jumped2 == 0)
            {
                foot1pos = foot1.transform.localPosition;
                foot2pos = foot2.transform.localPosition;
                leg1pos = leg1.transform.localPosition;
                leg2pos = leg2.transform.localPosition;
                foot1rot = foot1.transform.localRotation;
                foot2rot = foot2.transform.localRotation;
                leg1rot = leg1.transform.localRotation;
                leg2rot = leg2.transform.localRotation;
                jumped1 = 0;
                jumped2 = 1;
                t12 = 0;
            }
            ableToRun = 0;
            runninganim = 0;
            if (gravity == 0 && ableToJump == true)
            { jumps = 1; ableToJump = false;}
            Jump2();
        }
        else
        {
            ableToRun = 1;
            jumped1 = 0;
            jumped2 = 0;
        }
        ManaBarAnim();
        RocketAnim();
        MortarAnim();
        MortarAnimBack();
        RunningAnim1();
        RunningAnim2();
        RunningAnim3();
        RunningAnim4();
        PlaneTrans();
        RT();
        PB();
        Idle();
        Rot1();
        Rot2();
        framerate = 1.0f / Time.deltaTime;
        PistolAnim();
        PistolAnimBack();
        BurnEffect();
        DuckAnim();
        DuckReverseAnim();
    }

    private void keyboardRun()
    {
        if (Input.GetKey(right) && ((face == 1 && rightmove == 1) || (face == 0 && leftmove == 1)))
        {
            RunRight();
        }
        else if (Input.GetKey(left) && ((face == 0 && rightmove == 1) || (face == 1 && leftmove == 1)))
        {
            RunLeft();
        }
        else
        {
            StopRunning();
        }
    }

    private void KeyboardJump()
    {
        if (Input.GetKeyDown(jump) && form == 2 && jumps >= 1 && ableToDoStuff == true)
        {
            Jump();

        }
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 5f);
        jumps--;
    }

    private void KeyboardFlyUp()
    {
        if (Input.GetKey(jump) && form == 3)
        {
            FlyUp();
        }
        else if (form == 3 && !Input.GetKey(down))
        {
            StopFlying();
        }
    }

    private void StopFlying()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0f);
    }

    private void FlyUp()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed);
    }

    private void KeyboardFlyDown()
    {
        if (Input.GetKey(down) && form == 3)
        {
            FlyDown();
        }
        else if (form == 3 && !Input.GetKey(jump))
        {
            StopFlying();
        }
    }

    private void FlyDown()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -speed);
    }

    private void KeyboardDuck()
    {
        if (Input.GetKeyDown(down) && form == 2)
        {
            Duck();
        }
        if (Input.GetKeyUp(down) && form == 2)
        {
            UnDuck();
        }
    }

    private void UnDuck()
    {
        if (activated == true)
            {
            CancelInvoke("StopDuckAnim");
            StopDuckAnim();
            duckReverseAnim = true;
                t17 = 0;
                activated = false;
                leg1.SetActive(true);
                leg2.SetActive(true);
                Invoke("StopDuckAnim2", 0.2f);
            }
    }

    private void Duck()
    {
        if (activated == false)
        {
            CancelInvoke("StopDuckAnim2");
            StopDuckAnim2();
            duckAnim = true;
            t16 = 0;
            ableToDoStuff = false;
            activated = true;
            Invoke("StopDuckAnim", 0.2f);
        }

    }

    private void KeyboardTransform()
    {
        if (Input.GetKeyDown(transformRobot) && ableToTrans == 0)
        {
            Tansform();
        }
    }

    private void Tansform()
    {
        if (form == 1 && CeilingCollider.GetComponent<ceiling>().ReturnColliding() == 0)
        {
            TransformTankRobot();
            ableToTrans = 1;
            Invoke("AbleToTrans", 1f);
            damageMultiplier = 1.5f;
            t1 = 0;
            t2 = 0;
            ground2.GetComponent<BoxCollider2D>().size = new Vector2(ground2.GetComponent<BoxCollider2D>().size.x, 0.947695F);
            ground2.GetComponent<BoxCollider2D>().offset = new Vector2(ground2.GetComponent<BoxCollider2D>().offset.x, -0.3079227F);
        }
        else if (form == 2 && ableToDoStuff == true)
        {
            TransformRobotPlane();
            t3 = 0;
            ground2.GetComponent<BoxCollider2D>().size = new Vector2(ground2.GetComponent<BoxCollider2D>().size.x, 0.3243346f);
            ground2.GetComponent<BoxCollider2D>().offset = new Vector2(ground2.GetComponent<BoxCollider2D>().offset.x, 0.003757477f);
        }
    }

    private void KeyboardDetransform()
    {
        if (Input.GetKeyDown(transformTank) && ableToTrans == 0)
        {
            Detransform();
        }
    }

    private void Detransform()
    {
        if (form == 3 && floorCollider.GetComponent<ceiling>().ReturnColliding() == 0)
        {
            TransformPlaneRobot();
            ableToTrans = 1;
            Invoke("AbleToTrans", 1f);
            damageMultiplier = 1.5f;
            t4 = 0;
            ground2.GetComponent<BoxCollider2D>().size = new Vector2(ground2.GetComponent<BoxCollider2D>().size.x, 0.947695F);
            ground2.GetComponent<BoxCollider2D>().offset = new Vector2(ground2.GetComponent<BoxCollider2D>().offset.x, -0.3079227F);
        }
        else if (form == 2 && ableToDoStuff == true)
        {
            TransformRobotTank();
            ableToTrans = 1;
            Invoke("AbleToTrans", 1f);
            damageMultiplier = 1f;
            t5 = 0;
            ground2.GetComponent<BoxCollider2D>().size = new Vector2(ground2.GetComponent<BoxCollider2D>().size.x, 0.3243346f);
            ground2.GetComponent<BoxCollider2D>().offset = new Vector2(ground2.GetComponent<BoxCollider2D>().offset.x, 0.003757477f);
        }
    }

    private void KeyboardMortarUp()
    {
        if (Input.GetKey(mortarUp))
        {
            MortarUp();
        }
    }

    private void MortarUp()
    {
        if (pistol.GetComponent<TankPistol>().ReturnPistol().tag == "Mortar" && pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.localEulerAngles.z <= 165)
        {
            if (face == 0)
                pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().RotateDreapta();
            else
                pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().RotateStanga();
        }
    }

    private void KeyboardMortarDown()
    {
        if (Input.GetKey(mortarDown))
        {
            MortarDown();
        }
    }

    private void MortarDown()
    {
        if (pistol.GetComponent<TankPistol>().ReturnPistol().tag == "Mortar" && pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.localEulerAngles.z >= 115)
        {
            if (face == 0)
                pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().RotateStanga();
            else
                pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().RotateDreapta();
        }
    }

    private void KeyboardShoot()
    {
        if (Input.GetKey(shoot) && canShoot == true)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (pistol.GetComponent<TankPistol>().ReturnPistol().tag == "Mortar")
        {
            MortarShoot();
        }
        else if (pistol.GetComponent<TankPistol>().ReturnPistol().tag == "Rocket")
        {
            RocketShoot();
        }
        else if (pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<flamer>() != null)
        {
            FlamerShoot();
        }
        else if (pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<tmg>() != null)
        {
            TmgShoot();
        }
        else
        {
            MachinegunShoot();
        }
    }
    private void TmgShoot()
    {
        GameObject clone = Instantiate(bullet);
        GameObject clone2 = Instantiate(bullet);
        if (face == 0)
        {
            clone.transform.position = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position.x, pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position.y);
            clone.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltSpeed() * (-1), 0f);
            clone2.transform.position = new Vector2(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnBltTwo().transform.position.x, pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnBltTwo().transform.position.y);
            clone2.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            clone2.GetComponent<Rigidbody2D>().velocity = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltSpeed() * (-1), 0f);
        }
        else if (face == 1)
        {
            clone.transform.position = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position.x, pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position.y);
            clone.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltSpeed(), 0f);
            clone2.transform.position = new Vector2(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnBltTwo().transform.position.x, pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnBltTwo().transform.position.y);
            clone2.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            clone2.GetComponent<Rigidbody2D>().velocity = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltSpeed(), 0f);
        }
        clone.GetComponent<bullet>().GetDamage(damage);
        clone.GetComponent<bullet>().GetTank(gameObject);
        clone.GetComponent<bullet>().GetEffect(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnEffect());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
        clone2.GetComponent<bullet>().GetDamage(damage);
        clone2.GetComponent<bullet>().GetTank(gameObject);
        clone2.GetComponent<bullet>().GetEffect(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnEffect());
        Physics2D.IgnoreCollision(clone2.GetComponent<Collider2D>(), foot1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone2.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone2.GetComponent<Collider2D>(), leg1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone2.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
        AudioSource.PlayClipAtPoint(pistol.GetComponent<TankPistol>().ReturnShot(), Camera.main.transform.position);
        pistolBack = true;
        canShoot = false;
        t15 = 0;
        manaBar.transform.localScale = new Vector2(0, 1);
        Invoke("CanShoot", pistol.GetComponent<TankPistol>().ReturnAtkSpeed());
        Invoke("StopPistolBackAnim", 0.1f);
        Invoke("PistolAnim", 0.1f);
        Invoke("StopPistolAnim", pistol.GetComponent<TankPistol>().ReturnAtkSpeed());
    }

    private void MachinegunShoot()
    {
        GameObject clone = Instantiate(bullet);
        if (face == 0)
        {
            clone.transform.position = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position.x, pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position.y);
            clone.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltSpeed() * (-1), 0f);
        }
        else if (face == 1)
        {
            clone.transform.position = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position.x, pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position.y);
            clone.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltSpeed(), 0f);
        }
        clone.GetComponent<bullet>().GetDamage(damage);
        clone.GetComponent<bullet>().GetTank(gameObject);
        clone.GetComponent<bullet>().GetEffect(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnEffect());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
        AudioSource.PlayClipAtPoint(pistol.GetComponent<TankPistol>().ReturnShot(), Camera.main.transform.position);
        pistolBack = true;
        canShoot = false;
        t15 = 0;
        manaBar.transform.localScale = new Vector2(0, 1);
        Invoke("CanShoot", pistol.GetComponent<TankPistol>().ReturnAtkSpeed());
        Invoke("StopPistolBackAnim", 0.1f);
        Invoke("PistolAnim", 0.1f);
        Invoke("StopPistolAnim", pistol.GetComponent<TankPistol>().ReturnAtkSpeed());
    }

    private void FlamerShoot()
    {
        GameObject clone = Instantiate(flame);
        GameObject clone2 = Instantiate(flame);
        GameObject clone3 = Instantiate(flame);
        GameObject clone4 = Instantiate(flame);
        GameObject clone5 = Instantiate(flame);
        if (face == 0)
        {
            clone.transform.position = pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position;
            clone2.transform.position = pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position;
            clone3.transform.position = pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position;
            clone4.transform.position = pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position;
            clone5.transform.position = pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position;
            clone.transform.eulerAngles = new Vector3(0f, 0f, -45f);
            clone2.transform.eulerAngles = new Vector3(0f, 0f, -22f);
            clone3.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            clone4.transform.eulerAngles = new Vector3(0f, 0f, 22f);
            clone5.transform.eulerAngles = new Vector3(0f, 0f, 45f);
            clone.GetComponent<Rigidbody2D>().velocity = pistol.GetComponent<TankPistol>().ReturnBltSpeed() * clone.transform.right * (-1);
            clone2.GetComponent<Rigidbody2D>().velocity = pistol.GetComponent<TankPistol>().ReturnBltSpeed() * clone2.transform.right * (-1);
            clone3.GetComponent<Rigidbody2D>().velocity = pistol.GetComponent<TankPistol>().ReturnBltSpeed() * clone3.transform.right * (-1);
            clone4.GetComponent<Rigidbody2D>().velocity = pistol.GetComponent<TankPistol>().ReturnBltSpeed() * clone4.transform.right * (-1);
            clone5.GetComponent<Rigidbody2D>().velocity = pistol.GetComponent<TankPistol>().ReturnBltSpeed() * clone5.transform.right * (-1);
        }
        else if (face == 1)
        {
            clone.transform.position = pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position;
            clone2.transform.position = pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position;
            clone3.transform.position = pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position;
            clone4.transform.position = pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position;
            clone5.transform.position = pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position;
            clone.transform.eulerAngles = new Vector3(0f, 180f, -45f);
            clone2.transform.eulerAngles = new Vector3(0f, 180f, -22f);
            clone3.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            clone4.transform.eulerAngles = new Vector3(0f, 180f, 22f);
            clone5.transform.eulerAngles = new Vector3(0f, 180f, 45f);
            clone.GetComponent<Rigidbody2D>().velocity = pistol.GetComponent<TankPistol>().ReturnBltSpeed() * clone.transform.right * (-1);
            clone2.GetComponent<Rigidbody2D>().velocity = pistol.GetComponent<TankPistol>().ReturnBltSpeed() * clone2.transform.right * (-1);
            clone3.GetComponent<Rigidbody2D>().velocity = pistol.GetComponent<TankPistol>().ReturnBltSpeed() * clone3.transform.right * (-1);
            clone4.GetComponent<Rigidbody2D>().velocity = pistol.GetComponent<TankPistol>().ReturnBltSpeed() * clone4.transform.right * (-1);
            clone5.GetComponent<Rigidbody2D>().velocity = pistol.GetComponent<TankPistol>().ReturnBltSpeed() * clone5.transform.right * (-1);
        }
        clone.GetComponent<bullet>().GetDamage(damage);
        clone.GetComponent<bullet>().GetTank(gameObject);
        clone.GetComponent<bullet>().GetEffect(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnEffect());
        clone2.GetComponent<bullet>().GetDamage(damage);
        clone2.GetComponent<bullet>().GetTank(gameObject);
        clone2.GetComponent<bullet>().GetEffect(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnEffect());
        clone3.GetComponent<bullet>().GetDamage(damage);
        clone3.GetComponent<bullet>().GetTank(gameObject);
        clone3.GetComponent<bullet>().GetEffect(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnEffect());
        clone4.GetComponent<bullet>().GetDamage(damage);
        clone4.GetComponent<bullet>().GetTank(gameObject);
        clone4.GetComponent<bullet>().GetEffect(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnEffect());
        clone5.GetComponent<bullet>().GetDamage(damage);
        clone5.GetComponent<bullet>().GetTank(gameObject);
        clone5.GetComponent<bullet>().GetEffect(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnEffect());
        Destroy(clone, 0.5f);
        Destroy(clone2, 0.5f);
        Destroy(clone3, 0.5f);
        Destroy(clone4, 0.5f);
        Destroy(clone5, 0.5f);
        AudioSource.PlayClipAtPoint(pistol.GetComponent<TankPistol>().ReturnShot(), Camera.main.transform.position);
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone2.GetComponent<Collider2D>(), foot1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone2.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone2.GetComponent<Collider2D>(), leg1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone2.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone3.GetComponent<Collider2D>(), foot1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone3.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone3.GetComponent<Collider2D>(), leg1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone3.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone4.GetComponent<Collider2D>(), foot1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone4.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone4.GetComponent<Collider2D>(), leg1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone4.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone5.GetComponent<Collider2D>(), foot1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone5.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone5.GetComponent<Collider2D>(), leg1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone5.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
        flame1 = clone;
        flame2 = clone;
        flame3 = clone;
        flame4 = clone;
        flame5 = clone;
        facing = face;
        Invoke("SetRotations", 0.3f);
        canShoot = false;
        pistolBack = true;
        t15 = 0;
        manaBar.transform.localScale = new Vector2(0, 1);
        Invoke("CanShoot", pistol.GetComponent<TankPistol>().ReturnAtkSpeed());
        Invoke("StopPistolBackAnim", 0.1f);
        Invoke("PistolAnim", 0.1f);
        Invoke("StopPistolAnim", pistol.GetComponent<TankPistol>().ReturnAtkSpeed());
    }

    private void RocketShoot()
    {
        GameObject clone = Instantiate(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket1());
        if (face == 0)
        {
            clone.transform.position = pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket1().transform.position;
            clone.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltSpeed() * (-1), 0f);
        }
        else if (face == 1)
        {
            clone.transform.position = pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket1().transform.position;
            clone.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltSpeed(), 0f);
        }
        clone.GetComponent<bullet>().enabled = true;
        clone.GetComponent<bullet>().GetDamage(damage);
        clone.GetComponent<bullet>().GetTank(gameObject);
        clone.GetComponent<bullet>().GetEffect(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnEffect());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
        GameObject clone2 = Instantiate(rocketVfx);
        clone2.transform.position = pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket2().transform.position;
        Destroy(clone2, 1f);
        AudioSource.PlayClipAtPoint(pistol.GetComponent<TankPistol>().ReturnShot(), Camera.main.transform.position);
        pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<rockets>().ReturnRocket1().transform.localScale = new Vector3(0, 0, 1);
        canShoot = false;
        manaBar.transform.localScale = new Vector2(0, 1);
        Invoke("SecondRocket", 0.3f);
    }

    private void MortarShoot()
    {
        GameObject clone = Instantiate(cannonBall);
        clone.transform.position = new Vector2(pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position.x, pistol.GetComponent<TankPistol>().ReturnBltPos().transform.position.y);
        clone.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        clone.GetComponent<Rigidbody2D>().velocity = pistol.GetComponent<TankPistol>().ReturnBltSpeed() * pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().ReturnMortarTexture().transform.right;
        clone.GetComponent<bullet>().GetDamage(damage);
        clone.GetComponent<bullet>().GetTank(gameObject);
        clone.GetComponent<bullet>().GetEffect(pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<pistol>().ReturnEffect());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
        AudioSource.PlayClipAtPoint(pistol.GetComponent<TankPistol>().ReturnShot(), Camera.main.transform.position);
        mortarBack = true;
        canShoot = false;
        t15 = 0;
        manaBar.transform.localScale = new Vector2(0, 1);
        Invoke("CanShoot", pistol.GetComponent<TankPistol>().ReturnAtkSpeed());
        Invoke("StopMortarBackAnim", 0.1f);
        Invoke("MortarAnim", 0.1f);
        Invoke("StopMortarAnim", pistol.GetComponent<TankPistol>().ReturnAtkSpeed());
    }

    private void ConsoleShoot()
    {
        if (state.Buttons.X == ButtonState.Pressed && canShoot == true)
        {
            Shoot();
        }
    }

    private void ConsoleMortarDown()
    {
        if (prevState.Triggers.Right > 0.5f)
        {
            MortarUp();
        }
    }

    private void ConsoleMortarUp()
    {
        if (prevState.Triggers.Left > 0.5f)
        {
            MortarDown();
        }
    }

    private void ConsoleDetransform()
    {
        if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && ableToTrans == 0)
        {
            Detransform();
        }
    }

    private void ConsoleTransform()
    {
        if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && ableToTrans == 0)
        {
            Tansform();

        }
    }

    private void ConsoleDuck()
    {
        if (prevState.ThumbSticks.Left.Y < -0.7 && form == 2)
        {
            Duck();
        }
        if (!(prevState.ThumbSticks.Left.Y < -0.7) && form == 2)
        {
            UnDuck();
        }
    }

    private void ConsoleFlyDown()
    {
        if (prevState.ThumbSticks.Left.Y < -0.5 && form == 3)
        {
            FlyDown();
        }
        else if (form == 3 && !(prevState.ThumbSticks.Left.Y > 0.5))
        {
            StopFlying();
        }
    }

    private void ConsoleFlyUp()
    {
        if (prevState.ThumbSticks.Left.Y > 0.5 && form == 3)
        {
            FlyUp();
        }
        else if (form == 3 && !(prevState.ThumbSticks.Left.Y < -0.5))
        {
            StopFlying();
        }
    }

    private void ConsoleJump()
    {
        if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && form == 2 && jumps >= 1 && ableToDoStuff == true)
        {
            Jump();

        }
    }

    private void ConsolePlayerDetection()
    {
        if (player == 3)
        {
            playerIndex = (PlayerIndex)0;
            prevState = state;
            state = GamePad.GetState(playerIndex);
        }
        else
        {
            playerIndex = (PlayerIndex)1;
            prevState = state;
            state = GamePad.GetState(playerIndex);
        }
    }

    private void ConsoleRun()
    {
        if (prevState.ThumbSticks.Left.X < -0.5 && ((face == 1 && rightmove == 1) || (face == 0 && leftmove == 1)))
        {
            RunRight();
        }
        else if (prevState.ThumbSticks.Left.X > 0.5 && ((face == 0 && rightmove == 1) || (face == 1 && leftmove == 1)))
        {
            RunLeft();
        }
        else
        {
            StopRunning();
        }
    }

    private void StopRunning()
    {
        running = 0;
        CancelInvoke("RunningAnim1");
        CancelInvoke("RunningAnim2");
        CancelInvoke("RunningAnim3");
        CancelInvoke("RunningAnim4");
        t6 = 0;
        t7 = 0;
        t8 = 0;
        t9 = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y);
        if (runninganim != -1)
        {
            runninganim = 0;
        }
        input = false;
    }

    private void RunLeft()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, transform.eulerAngles.z);
        hpBar2.transform.rotation = new Quaternion(hpBar2.transform.rotation.x, 0f, hpBar2.transform.rotation.z, hpBar2.transform.rotation.w);
        face = 1;
        pistol.GetComponent<TankPistol>().ReturnPistol().transform.position = new Vector3(pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.x, pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.y, 3f);

        body.GetComponent<TankBody>().ReturnBody().transform.position = new Vector3(body.GetComponent<TankBody>().ReturnBody().transform.position.x, body.GetComponent<TankBody>().ReturnBody().transform.position.y, 5f);

        wheels.GetComponent<TankWheels>().ReturnWheels().transform.position = new Vector3(wheels.GetComponent<TankWheels>().transform.position.x, wheels.GetComponent<TankWheels>().ReturnWheels().transform.position.y, -4f);
        foot1.transform.position = new Vector3(foot1.transform.position.x, foot1.transform.position.y, -20f);
        foot2.transform.position = new Vector3(foot2.transform.position.x, foot2.transform.position.y, -20f);
        leg1.transform.position = new Vector3(leg1.transform.position.x, leg1.transform.position.y, 20f);
        leg2.transform.position = new Vector3(leg2.transform.position.x, leg2.transform.position.y, 20f);
        plane.transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y, -4f);
        if (ableToDoStuff == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            if (input == false)
            {
                runninganim = 1;
                input = true;
            }
            if (runninganim < 0 && ableToRun == 1)
            {
                runninganim = 1;

            }
        }
        else
        {
            running = 0;
            CancelInvoke("RunningAnim1");
            CancelInvoke("RunningAnim2");
            CancelInvoke("RunningAnim3");
            CancelInvoke("RunningAnim4");
            t6 = 0;
            t7 = 0;
            t8 = 0;
            t9 = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y);
            if (runninganim != -1)
            {
                runninganim = 0;
            }
            input = false;
        }
    }

    private void RunRight()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0f, transform.eulerAngles.z);
        hpBar2.transform.rotation = new Quaternion(hpBar2.transform.rotation.x, 0f, hpBar2.transform.rotation.z, hpBar2.transform.rotation.w);
        face = 0;
        pistol.GetComponent<TankPistol>().ReturnPistol().transform.position = new Vector3(pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.x, pistol.GetComponent<TankPistol>().ReturnPistol().transform.position.y, 3f);

        body.GetComponent<TankBody>().ReturnBody().transform.position = new Vector3(body.GetComponent<TankBody>().ReturnBody().transform.position.x, body.GetComponent<TankBody>().ReturnBody().transform.position.y, -4f);

        wheels.GetComponent<TankWheels>().ReturnWheels().transform.position = new Vector3(wheels.GetComponent<TankWheels>().ReturnWheels().transform.position.x, wheels.GetComponent<TankWheels>().ReturnWheels().transform.position.y, -5f);
        foot1.transform.position = new Vector3(foot1.transform.position.x, foot1.transform.position.y, -20f);
        foot2.transform.position = new Vector3(foot2.transform.position.x, foot2.transform.position.y, -20f);
        leg1.transform.position = new Vector3(leg1.transform.position.x, leg1.transform.position.y, 20f);
        leg2.transform.position = new Vector3(leg2.transform.position.x, leg2.transform.position.y, 20f);
        plane.transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y, -5f);
        if (ableToDoStuff == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            if (input == false)
            {
                input = true;
                runninganim = 1;
            }
            if (runninganim < 0 && ableToRun == 1)
            {
                runninganim = 1;
            }
        }
        else
        {
            running = 0;
            CancelInvoke("RunningAnim1");
            CancelInvoke("RunningAnim2");
            CancelInvoke("RunningAnim3");
            CancelInvoke("RunningAnim4");
            t6 = 0;
            t7 = 0;
            t8 = 0;
            t9 = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y);
            if (runninganim != -1)
            {
                runninganim = 0;
            }
            input = false;
        }
    }
    void Start()
    {
        if (player == 1)
        {
            jump = KeyCode.W;
            left = KeyCode.D;
            right = KeyCode.A;
            shoot = KeyCode.F;
            transformRobot = KeyCode.G;
            down = KeyCode.S;
            transformTank = KeyCode.T;
            mortarUp = KeyCode.Z;
            mortarDown = KeyCode.C;
        }
        else if (player == 2)
        {
            left = KeyCode.RightArrow;
            right = KeyCode.LeftArrow;
            shoot = KeyCode.Keypad5;
            jump = KeyCode.UpArrow;
            transformRobot = KeyCode.Keypad8;
            down = KeyCode.DownArrow;
            transformTank = KeyCode.Keypad2;
            mortarUp = KeyCode.Keypad1;
            mortarDown = KeyCode.Keypad3;
        }
        selector[] tankuri = FindObjectsOfType<selector>();
        foreach (selector i in tankuri)
        {
            if (i.ReturnPlayer() == player && i.ReturnReady() == 1)
            {
                tankPrepared = true;
                GameObject clone = Instantiate(i.ReturnTankModel()[2].GetComponent<pistol>().ReturnHolder());
                clone.transform.parent = pistolObject.transform;
                clone.transform.localPosition = holderpos;
                holder = clone;
                GameObject clone2 = Instantiate(i.ReturnTankModel()[2]);
                clone2.transform.parent = clone.transform;
                clone2.transform.localPosition = ogposs;
                pistol = clone2;
                GameObject clone3 = Instantiate(i.ReturnTankModel()[1]);
                clone3.transform.parent = bodyObject.transform;
                clone3.transform.localPosition = bodyogpos;
                body = clone3;
                GameObject clone4 = Instantiate(i.ReturnTankModel()[0]);
                clone4.transform.parent = wheelsObject.transform;
                clone4.transform.localPosition = wheelsogpos;
                wheels = clone4;
                ground2 = clone3.GetComponent<body>().ReturnChestie();
                ground2.GetComponent<border1>().GetOgTank(gameObject);
                Destroy(clone2.GetComponent<pistol>().ReturnHolder());
                pistolObject.GetComponent<TankPistol>().GetPistol(clone2);
                pistolObject.GetComponent<TankPistol>().GetHolder(clone);
                bodyObject.GetComponent<TankBody>().GetBody(clone3);
                wheelsObject.GetComponent<TankWheels>().GetWheels(clone4);
                pistolObject.GetComponent<TankPistol>().GetHp(clone2.GetComponent<pistol>().ReturnHp());
                bodyObject.GetComponent<TankBody>().GetHp(clone3.GetComponent<body>().ReturnHp());
                wheelsObject.GetComponent<TankWheels>().GetHp(clone4.GetComponent<wheels>().ReturnHp());
                pistol = pistolObject;
                body = bodyObject;
                wheels = wheelsObject;
                ground3 = holder.GetComponent<holder>().ReturnGround();
                clone2.GetComponent<pistol>().ReturnOgPos().transform.parent = clone.transform;
                pistolObject.GetComponent<TankPistol>().GetOgPos(clone2.GetComponent<pistol>().ReturnOgPos());
                pistolObject.GetComponent<TankPistol>().GetBltPos(clone2.GetComponent<pistol>().ReturnBltPos());
                CeilingCollider.GetComponent<OgTank>().GetOgTank(gameObject);
                floorCollider.GetComponent<OgTank>().GetOgTank(gameObject);
                i.ReturnTankModel()[0].transform.position = new Vector2(10000f, 10000f);
                i.ReturnTankModel()[1].transform.position = new Vector2(10000f, 10000f);
                i.ReturnTankModel()[2].transform.position = new Vector2(10000f, 10000f);

                if (pistolObject.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>() != null)
                    pistolObject.GetComponent<TankPistol>().ReturnPistol().GetComponent<mortar>().GetHolder(holder);
            }
            else if (i.ReturnPlayer() == player && i.ReturnReady() == 0)
            {
                Destroy(gameObject);
            }
        }
        if (tankPrepared == false)
            Destroy(gameObject);
        Invoke("Start2", 0.1f);
    }

    private void Start2()
    {
        maxhp = pistolObject.GetComponent<TankPistol>().ReturnHp() + bodyObject.GetComponent<TankBody>().ReturnHp() + wheelsObject.GetComponent<TankWheels>().ReturnHp();
        hp = maxhp;
        damage = pistolObject.GetComponent<TankPistol>().ReturnDmg();
        speed = wheelsObject.GetComponent<TankWheels>().ReturnSpeed() - bodyObject.GetComponent<TankBody>().ReturnWeight() - pistolObject.GetComponent<TankPistol>().ReturnWeight();
        if (speed < 1)
        {
            speed = 1f;
        }
        holder.GetComponent<OgTank>().GetOgTank(gameObject);
        pistolObject.GetComponent<TankPistol>().ReturnPistol().GetComponent<OgTank>().GetOgTank(gameObject);
        wheelsObject.GetComponent<TankWheels>().ReturnWheels().GetComponent<OgTank>().GetOgTank(gameObject);
        bodyObject.GetComponent<TankBody>().ReturnBody().GetComponent<OgTank>().GetOgTank(gameObject);
        foot1.GetComponent<OgTank>().GetOgTank(gameObject);
        foot2.GetComponent<OgTank>().GetOgTank(gameObject);
        leg1.GetComponent<OgTank>().GetOgTank(gameObject);
        leg2.GetComponent<OgTank>().GetOgTank(gameObject);
        actualWheels = wheelsObject.GetComponent<TankWheels>().ReturnWheels();
        ground.transform.position = new Vector2(ground.transform.position.x, ground3.transform.position.y);
        ground.GetComponent<BoxCollider2D>().size = new Vector2(Mathf.Abs(body.transform.position.x - ground2.transform.position.x) * 2, ground.GetComponent<BoxCollider2D>().size.y);
        Physics2D.IgnoreCollision(foot1.GetComponent<Collider2D>(), foot2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(leg1.GetComponent<Collider2D>(), leg2.GetComponent<Collider2D>());
        startCOlor = actualWheels.GetComponent<SpriteRenderer>().color;
        endColor = new Color32((byte)(actualWheels.GetComponent<SpriteRenderer>().color.r * 255f), (byte)(actualWheels.GetComponent<SpriteRenderer>().color.g * 255f), (byte)(actualWheels.GetComponent<SpriteRenderer>().color.b * 255f), 0);
        pistol.GetComponent<TankPistol>().ReturnPistol().transform.position = pistol.GetComponent<TankPistol>().ReturnOgPos().transform.position;
		if (pistol.GetComponent<TankPistol>().ReturnPistol().GetComponent<tmg>() != null)
		{pistol.GetComponent<TankPistol>().ReturnOgPos().transform.localPosition = new Vector2(-0.2476383f, -0.02f);
		pistol.GetComponent<TankPistol>().ReturnPistol().transform.localPosition = pistol.GetComponent<TankPistol>().ReturnOgPos().transform.localPosition;
		}
    }
















    // Update is called once per frame
    void Update()
    {
        Executables();
        if (player == 1 || player == 2)
        {
            keyboardRun();
            KeyboardJump();
            KeyboardFlyUp();
            KeyboardFlyDown();
            KeyboardDuck();
            KeyboardTransform();
            KeyboardDetransform();
            KeyboardMortarUp();
            KeyboardMortarDown();
            KeyboardShoot();
        }
        else if (player == 3 || player == 4)
        {
            ConsolePlayerDetection();
            ConsoleRun();
            ConsoleJump();
            ConsoleFlyUp();
            ConsoleFlyDown();
            ConsoleDuck();
            ConsoleTransform();
            ConsoleDetransform();
            ConsoleMortarUp();
            ConsoleMortarDown();
            ConsoleShoot();
        }
    }




}

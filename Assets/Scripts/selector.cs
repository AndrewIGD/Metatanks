using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;

public class selector : MonoBehaviour
{
    [SerializeField] GameObject[] pistol;
    [SerializeField] GameObject[] body;
    [SerializeField] GameObject[] wheels;
    [SerializeField] GameObject[] pos1;
    [SerializeField] GameObject[] options1;
    [SerializeField] Text stat1;
    [SerializeField] Text stat2;
    [SerializeField] Text stat3;
    [SerializeField] Text stat4;
    [SerializeField] Text stat5;
    [SerializeField] Text stat1rez;
    [SerializeField] Text stat2rez;
    [SerializeField] Text stat3rez;
    [SerializeField] Text stat4rez;
    [SerializeField] Text stat5rez;
    [SerializeField] Text waiting;
    [SerializeField] int[] option1;
    int form1 = 0;
    int lerp1 = 0;
    float t1 = 0;
    bool ableToSelect1 = true;
    [SerializeField] GameObject[] tank1;
    [SerializeField] int player;
    KeyCode left;
    KeyCode right;
    KeyCode accept;
    KeyCode back;
    [SerializeField] int ready = -1;
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    public int ReturnReady()
    {
        return ready;
    }
    private void Lerp1()
    {
        if (lerp1 == 1)
        {
            t1 += Time.deltaTime / 0.3f;
                if (options1[1] != null)
                { options1[1].transform.position = Vector3.Lerp(pos1[4].transform.position, pos1[3].transform.position, t1);
                    options1[1].transform.localScale = Vector3.Lerp(pos1[4].transform.localScale, pos1[3].transform.localScale, t1);
                }
            if (form1 == 0)
            {
                if (options1[2] != null)
                {
                    options1[2].transform.position = Vector3.Lerp(pos1[0].transform.position, pos1[4].transform.position, t1);
                    options1[2].transform.localScale = Vector3.Lerp(pos1[0].transform.localScale, pos1[4].transform.localScale, t1);
                }
                if (options1[3] != null)
                {
                    options1[3].transform.position = Vector3.Lerp(pos1[5].transform.position, pos1[0].transform.position, t1);
                    options1[3].transform.localScale = Vector3.Lerp(pos1[5].transform.localScale, pos1[0].transform.localScale, t1);
                }
            }
            else if (form1 == 1)
            {
                if (options1[2] != null)
                {
                    options1[2].transform.position = Vector3.Lerp(pos1[1].transform.position, pos1[4].transform.position, t1);
                    options1[2].transform.localScale = Vector3.Lerp(pos1[1].transform.localScale, pos1[4].transform.localScale, t1);
                }
                if (options1[3] != null)
                {
                    options1[3].transform.position = Vector3.Lerp(pos1[5].transform.position, pos1[1].transform.position, t1);
                    options1[3].transform.localScale = Vector3.Lerp(pos1[5].transform.localScale, pos1[1].transform.localScale, t1);
                }
            }
            else if (form1 == 2)
            {
                if (options1[2] != null)
                {
                    options1[2].transform.position = Vector3.Lerp(pos1[2].transform.position, pos1[4].transform.position, t1);
                    options1[2].transform.localScale = Vector3.Lerp(pos1[2].transform.localScale, pos1[4].transform.localScale, t1);
                }
                if (options1[3] != null)
                {
                    options1[3].transform.position = Vector3.Lerp(pos1[5].transform.position, pos1[2].transform.position, t1);
                    options1[3].transform.localScale = Vector3.Lerp(pos1[5].transform.localScale, pos1[2].transform.localScale, t1);
                }
            }
            if (options1[4] != null)
                {
                    options1[4].transform.position = Vector3.Lerp(pos1[6].transform.position, pos1[5].transform.position, t1);
                    options1[4].transform.localScale = Vector3.Lerp(pos1[6].transform.localScale, pos1[5].transform.localScale, t1);
                }
            
        }
        else if (lerp1 == 2)
        {
            t1 += Time.deltaTime / 0.3f;
                if (options1[0] != null)
                {
                    options1[0].transform.position = Vector3.Lerp(pos1[3].transform.position, pos1[4].transform.position, t1);
                    options1[0].transform.localScale = Vector3.Lerp(pos1[3].transform.localScale, pos1[4].transform.localScale, t1);
                }
            if (form1 == 0)
            {
                if (options1[1] != null)
                {
                    options1[1].transform.position = Vector3.Lerp(pos1[4].transform.position, pos1[0].transform.position, t1);
                    options1[1].transform.localScale = Vector3.Lerp(pos1[4].transform.localScale, pos1[0].transform.localScale, t1);
                }
                if (options1[2] != null)
                {
                    options1[2].transform.position = Vector3.Lerp(pos1[0].transform.position, pos1[5].transform.position, t1);
                    options1[2].transform.localScale = Vector3.Lerp(pos1[0].transform.localScale, pos1[5].transform.localScale, t1);
                }
            }
            else if (form1 == 1)
            {
                if (options1[1] != null)
                {
                    options1[1].transform.position = Vector3.Lerp(pos1[4].transform.position, pos1[1].transform.position, t1);
                    options1[1].transform.localScale = Vector3.Lerp(pos1[4].transform.localScale, pos1[1].transform.localScale, t1);
                }
                if (options1[2] != null)
                {
                    options1[2].transform.position = Vector3.Lerp(pos1[1].transform.position, pos1[5].transform.position, t1);
                    options1[2].transform.localScale = Vector3.Lerp(pos1[1].transform.localScale, pos1[5].transform.localScale, t1);
                }
            }
            else if (form1 == 2)
            {
                if (options1[1] != null)
                {
                    options1[1].transform.position = Vector3.Lerp(pos1[4].transform.position, pos1[2].transform.position, t1);
                    options1[1].transform.localScale = Vector3.Lerp(pos1[4].transform.localScale, pos1[2].transform.localScale, t1);
                }
                if (options1[2] != null)
                {
                    options1[2].transform.position = Vector3.Lerp(pos1[2].transform.position, pos1[5].transform.position, t1);
                    options1[2].transform.localScale = Vector3.Lerp(pos1[2].transform.localScale, pos1[5].transform.localScale, t1);
                }
            }
            if (options1[3] != null)
                {
                    options1[3].transform.position = Vector3.Lerp(pos1[5].transform.position, pos1[6].transform.position, t1);
                    options1[3].transform.localScale = Vector3.Lerp(pos1[5].transform.localScale, pos1[6].transform.localScale, t1);
                }
            
        }
    }
    private void StopLerp1()
    {
        if (lerp1 == 1)
        {
            lerp1 = 0;
            if (options1[0] != null)
                Destroy(options1[0]);
            if (options1[1] != null)
            { options1[0] = options1[1]; options1[1] = null; }
            if (options1[2] != null)
            { options1[1] = options1[2]; options1[2] = null; }
            if (options1[3] != null)
            { options1[2] = options1[3]; options1[3] = null; }
            if (options1[4] != null)
            { options1[3] = options1[4]; options1[4] = null; }
            if (form1 == 0)
            {
                if (option1[0] + 2 < wheels.Length)
                {
                    GameObject clone = Instantiate(wheels[option1[0] + 2]);
                    clone.transform.position = pos1[6].transform.position;
                    clone.transform.localScale = pos1[6].transform.localScale;
                    options1[4] = clone;
                }
                options1[2].transform.position = pos1[0].transform.position;
            }
            else if (form1 == 1)
            {
                if (option1[1] + 2 < body.Length)
                {
                    GameObject clone = Instantiate(body[option1[1] + 2]);
                    clone.transform.position = pos1[6].transform.position;
                    clone.transform.localScale = pos1[6].transform.localScale;
                    options1[4] = clone;
                }
                options1[2].transform.position = pos1[1].transform.position;
            }
            else if (form1 == 2)
            {
                if (option1[2] + 2 < pistol.Length)
                {
                    GameObject clone = Instantiate(pistol[option1[2] + 2]);
                    clone.transform.position = pos1[6].transform.position;
                    clone.transform.localScale = pos1[6].transform.localScale;
                    options1[4] = clone;
                }
                options1[2].transform.position = pos1[2].transform.position;
            }
            if (options1[1] != null)
            {
                options1[1].transform.position = pos1[4].transform.position;
                options1[1].transform.localScale = pos1[4].transform.localScale;
            }
            if (form1 == 0)
            {
                if (options1[2] != null)
                {
                    options1[2].transform.position = pos1[0].transform.position;
                    options1[2].transform.localScale = pos1[0].transform.localScale;
                }
                if (options1[3] != null)
                {
                    options1[3].transform.position = pos1[5].transform.position;
                    options1[3].transform.localScale = pos1[5].transform.localScale;
                }
            }
            else if (form1 == 1)
            {
                if (options1[2] != null)
                {
                    options1[2].transform.position = pos1[1].transform.position;
                    options1[2].transform.localScale = pos1[1].transform.localScale;
                }
                if (options1[3] != null)
                {
                    options1[3].transform.position = pos1[5].transform.position;
                    options1[3].transform.localScale = pos1[5].transform.localScale;
                }
            }
            else if (form1 == 2)
            {
                if (options1[2] != null)
                {
                    options1[2].transform.position = pos1[2].transform.position;
                    options1[2].transform.localScale = pos1[2].transform.localScale;
                }
                if (options1[3] != null)
                {
                    options1[3].transform.position = pos1[5].transform.position;
                    options1[3].transform.localScale = pos1[5].transform.localScale;
                }
            }
            if (options1[4] != null)
            {
                options1[4].transform.position = pos1[6].transform.position;
                options1[4].transform.localScale = pos1[6].transform.localScale;
            }
        }
        else if (lerp1 == 2)
        {
            lerp1 = 0;
            if (options1[4] != null)
                Destroy(options1[4]);
            if (options1[3] != null)
            { options1[4] = options1[3]; options1[3] = null; }
            if (options1[2] != null)
            { options1[3] = options1[2]; options1[2] = null; }
            if (options1[1] != null)
            { options1[2] = options1[1]; options1[1] = null; }
            if (options1[0] != null)
            { options1[1] = options1[0]; options1[0] = null; }
            if (option1[0] - 2 >= 0 && form1 == 0)
            {
                GameObject clone = Instantiate(wheels[option1[0] - 2]);
                clone.transform.position = pos1[3].transform.position;
                clone.transform.localScale = pos1[3].transform.localScale;
                options1[0] = clone;
            }
            if (option1[1] - 2 >= 0 && form1 == 1)
            {
                GameObject clone = Instantiate(body[option1[1] - 2]);
                clone.transform.position = pos1[3].transform.position;
                clone.transform.localScale = pos1[3].transform.localScale;
                options1[0] = clone;
            }
            if (option1[2] - 2 >= 0 && form1 == 2)
            {
                GameObject clone = Instantiate(pistol[option1[2] - 2]);
                clone.transform.position = pos1[3].transform.position;
                clone.transform.localScale = pos1[3].transform.localScale;
                options1[0] = clone;
            }
            if (options1[0] != null)
            {
                options1[0].transform.position = pos1[3].transform.position;
                options1[0].transform.localScale = pos1[3].transform.localScale;
            }
            if (form1 == 0)
            {
                if (options1[1] != null)
                {
                    options1[1].transform.position = pos1[4].transform.position;
                    options1[1].transform.localScale = pos1[4].transform.localScale;
                }
                if (options1[2] != null)
                {
                    options1[2].transform.position = pos1[0].transform.position;
                    options1[2].transform.localScale = pos1[0].transform.localScale;
                }
            }
            else if (form1 == 1)
            {
                if (options1[1] != null)
                {
                    options1[1].transform.position = pos1[4].transform.position;
                    options1[1].transform.localScale = pos1[4].transform.localScale;
                }
                if (options1[2] != null)
                {
                    options1[2].transform.position = pos1[1].transform.position;
                    options1[2].transform.localScale = pos1[1].transform.localScale;
                }
            }
            else if (form1 == 2)
            {
                if (options1[1] != null)
                {
                    options1[1].transform.position = pos1[4].transform.position;
                    options1[1].transform.localScale = pos1[4].transform.localScale;
                }
                if (options1[2] != null)
                {
                    options1[2].transform.position = pos1[2].transform.position;
                    options1[2].transform.localScale = pos1[2].transform.localScale;
                }
            }
            if (options1[3] != null)
            {
                options1[3].transform.position = pos1[5].transform.position;
                options1[3].transform.localScale = pos1[5].transform.localScale;
            }
        }
        ableToSelect1 = true;

        if (form1 == 0)
        {
            stat1rez.text = options1[2].GetComponent<wheels>().ReturnHp().ToString();
            stat2rez.text = options1[2].GetComponent<wheels>().ReturnSpeed().ToString();
        }
        else if (form1 == 1)
        {
            stat1rez.text = options1[2].GetComponent<body>().ReturnHp().ToString();
            stat2rez.text = options1[2].GetComponent<body>().ReturnWeight().ToString();
            stat3rez.text = options1[2].GetComponent<body>().ReturnKineticArmor().ToString();
            stat4rez.text = options1[2].GetComponent<body>().ReturnThermalArmor().ToString();
        }
        else if (form1 == 2)
        {
            stat4rez.text = options1[2].GetComponent<pistol>().ReturnHp().ToString();
            stat5rez.text = options1[2].GetComponent<pistol>().ReturnWeight().ToString();
            stat1rez.text = options1[2].GetComponent<pistol>().ReturnDmg().ToString();
            stat2rez.text = options1[2].GetComponent<pistol>().ReturnAtkSpeed().ToString();
            stat3rez.text = options1[2].GetComponent<pistol>().ReturnBltSpeed().ToString();
        }
    }
    private void Start()
    {
		DontDestroyOnLoad(gameObject);
        
        if (player == 1)
        {
            left = KeyCode.A;
            right = KeyCode.D;
            accept = KeyCode.F;
            back = KeyCode.Q;
        }
        else if (player == 2)
        {
            left = KeyCode.LeftArrow;
            right = KeyCode.RightArrow;
            accept = KeyCode.UpArrow;
            back = KeyCode.DownArrow;
        }
    }
	public int ReturnPlayer()
	{
		return player;
	}
	public GameObject[] ReturnTankModel()
	{
		return tank1;
	}
    private void Update()
    {
        Lerp1();
        if (player == 1 || player == 2)
        {
            
            if (Input.GetKey(KeyCode.T) && SceneManager.GetActiveScene().name == "SelectScene" && ready == 1)
            {
                selector[] tancuri = FindObjectsOfType<selector>();
                foreach(selector i in tancuri)
                {
                    if (i.ReturnReady() == 0)
                        return;
                }
                if (FindObjectOfType<counter>().ReturnPlayers() >= 2)
                    SceneManager.LoadScene("Area 1");
            }
            if (Input.GetKey(right) && SceneManager.GetActiveScene().name == "SelectScene" && ready == 0)
            {
                if (form1 == 0 && option1[0] + 1 < wheels.Length && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[0]++;
                    lerp1 = 1;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
                else if (form1 == 1 && option1[1] + 1 < body.Length && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[1]++;
                    lerp1 = 1;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
                else if (form1 == 2 && option1[2] + 1 < pistol.Length && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[2]++;
                    lerp1 = 1;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
            }
            if (Input.GetKey(left) && SceneManager.GetActiveScene().name == "SelectScene" && ready == 0)
            {
                if (form1 == 0 && option1[0] - 1 >= 0 && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[0]--;
                    lerp1 = 2;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
                else if (form1 == 1 && option1[1] - 1 >= 0 && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[1]--;
                    lerp1 = 2;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
                else if (form1 == 2 && option1[2] - 1 >= 0 && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[2]--;
                    lerp1 = 2;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
            }
            if (Input.GetKeyDown(accept) && ableToSelect1 == true && SceneManager.GetActiveScene().name == "SelectScene")
            {
                if (ready != -1)
                {
                    if (form1 == 0)
                    {
                        tank1[0] = options1[2];
                        form1 = 1;
                        Destroy(options1[0]);
                        Destroy(options1[1]);
                        Destroy(options1[3]);
                        Destroy(options1[4]);
                        options1[2] = null;
                        if (body[0] != null)
                        {
                            GameObject clone = Instantiate(body[0]);
                            clone.transform.position = pos1[1].transform.position;
                            options1[2] = clone;
                        }
                        if (body[1] != null)
                        {
                            GameObject clone2 = Instantiate(body[1]);
                            clone2.transform.position = pos1[5].transform.position;
                            clone2.transform.localScale = pos1[5].transform.localScale;
                            options1[3] = clone2;
                        }
                        if (body[2] != null)
                        {
                            GameObject clone3 = Instantiate(body[2]);
                            clone3.transform.position = pos1[6].transform.position;
                            clone3.transform.localScale = pos1[6].transform.localScale;
                            options1[4] = clone3;
                        }
                        DontDestroyOnLoad(tank1[0]);
                        stat1.text = "Hp";
                        stat2.text = "Weight";
                        stat3.text = "Kinetic Armor:";
                        stat4.text = "Thermal Armor:";
                        stat5.text = "";
                        stat1rez.text = options1[2].GetComponent<body>().ReturnHp().ToString();
                        stat2rez.text = options1[2].GetComponent<body>().ReturnWeight().ToString();
                        stat3rez.text = options1[2].GetComponent<body>().ReturnKineticArmor().ToString();
                        stat4rez.text = options1[2].GetComponent<body>().ReturnThermalArmor().ToString();
                        stat5rez.text = "";
                    }
                    else if (form1 == 1)
                    {
                        tank1[1] = options1[2];
                        form1 = 2;
                        Destroy(options1[0]);
                        Destroy(options1[1]);
                        Destroy(options1[3]);
                        Destroy(options1[4]);
                        options1[2] = null;
                        if (pistol[0] != null)
                        {
                            GameObject clone = Instantiate(pistol[0]);
                            clone.transform.position = pos1[2].transform.position;
                            options1[2] = clone;
                        }
                        if (pistol[1] != null)
                        {
                            GameObject clone2 = Instantiate(pistol[1]);
                            clone2.transform.position = pos1[5].transform.position;
                            clone2.transform.localScale = pos1[5].transform.localScale;
                            options1[3] = clone2;
                        }
                        if (pistol[2] != null)
                        {
                            GameObject clone3 = Instantiate(pistol[2]);
                            clone3.transform.position = pos1[6].transform.position;
                            clone3.transform.localScale = pos1[6].transform.localScale;
                            options1[4] = clone3;
                        }
                        DontDestroyOnLoad(tank1[1]);
                        stat1.text = "Dmg";
                        stat2.text = "Attack Speed";
                        stat3.text = "Bullet Speed";
                        stat4.text = "Hp";
                        stat5.text = "Weight";
                        stat4rez.text = options1[2].GetComponent<pistol>().ReturnHp().ToString();
                        stat5rez.text = options1[2].GetComponent<pistol>().ReturnWeight().ToString();
                        stat1rez.text = options1[2].GetComponent<pistol>().ReturnDmg().ToString();
                        stat2rez.text = options1[2].GetComponent<pistol>().ReturnAtkSpeed().ToString();
                        stat3rez.text = options1[2].GetComponent<pistol>().ReturnBltSpeed().ToString();

                    }
                    else if (form1 == 2)
                    {
                        tank1[2] = options1[2];
                        form1 = 3;
                        Destroy(options1[0]);
                        Destroy(options1[1]);
                        Destroy(options1[3]);
                        Destroy(options1[4]);
                        options1[2] = null;
                        DontDestroyOnLoad(tank1[2]);
                        stat1.text = "";
                        stat2.text = "";
                        stat3.text = "";
                        stat4.text = "";
                        stat5.text = "";
                        stat1rez.text = "";
                        stat2rez.text = "";
                        stat3rez.text = "";
                        stat4rez.text = "";
                        stat5rez.text = "";
                        FindObjectOfType<counter>().PlayerPP();
                        ready = 1;
                    }
                }
                else
                {
                    GameObject clone = Instantiate(wheels[0]);
                    clone.transform.position = pos1[0].transform.position;
                    options1[2] = clone;
                    GameObject clone2 = Instantiate(wheels[1]);
                    clone2.transform.position = pos1[5].transform.position;
                    clone2.transform.localScale = pos1[5].transform.localScale;
                    options1[3] = clone2;
                    GameObject clone3 = Instantiate(wheels[2]);
                    clone3.transform.position = pos1[6].transform.position;
                    clone3.transform.localScale = pos1[6].transform.localScale;
                    options1[4] = clone3;
                    stat1.text = "Hp: ";
                    stat2.text = "Speed: ";
                    stat1rez.text = options1[2].GetComponent<wheels>().ReturnHp().ToString();
                    stat2rez.text = options1[2].GetComponent<wheels>().ReturnSpeed().ToString();
                    waiting.text = "";
                    ready = 0;
                }
            }
            if (Input.GetKeyDown(back) && ableToSelect1 == true && SceneManager.GetActiveScene().name == "SelectScene")
            {
                if (form1 == 0)
                {
                    option1[0] = 0;
                    Destroy(options1[0]);
                    Destroy(options1[1]);
                    Destroy(options1[2]);
                    Destroy(options1[3]);
                    Destroy(options1[4]);
                    stat1.text = "";
                    stat2.text = "";
                    stat1rez.text = "";
                    stat2rez.text = "";
                    waiting.text = "Press " + accept.ToString() + " to join";
                    ready = -1;
                }
                else if (form1 == 1)
                {
                    Destroy(options1[2]);
                    options1[2] = tank1[0];
                    tank1[0] = null;
                    form1 = 0;
                    option1[1] = 0;
                    Destroy(options1[0]);
                    Destroy(options1[1]);
                    Destroy(options1[3]);
                    Destroy(options1[4]);
                    if (option1[0] - 2 >= 0)
                    {
                        GameObject clone4 = Instantiate(wheels[option1[0] - 2]);
                        clone4.transform.position = pos1[3].transform.position;
                        clone4.transform.localScale = pos1[3].transform.localScale;
                        options1[0] = clone4;
                    }
                    if (option1[0] - 1 >= 0)
                    {
                        GameObject clone = Instantiate(wheels[option1[0] - 1]);
                        clone.transform.position = pos1[4].transform.position;
                        clone.transform.localScale = pos1[4].transform.localScale;
                        options1[1] = clone;
                    }
                    if (option1[0] + 1 < wheels.Length)
                    {
                        GameObject clone2 = Instantiate(wheels[option1[0] + 1]);
                        clone2.transform.position = pos1[5].transform.position;
                        clone2.transform.localScale = pos1[5].transform.localScale;
                        options1[3] = clone2;
                    }
                    if (option1[0] + 2 < wheels.Length)
                    {
                        GameObject clone3 = Instantiate(wheels[option1[0] + 2]);
                        clone3.transform.position = pos1[6].transform.position;
                        clone3.transform.localScale = pos1[6].transform.localScale;
                        options1[4] = clone3;
                    }
                    stat1.text = "Hp";
                    stat2.text = "Speed";
                    stat3.text = "";
                    stat4.text = "";
                    stat5.text = "";
                    stat1rez.text = options1[2].GetComponent<wheels>().ReturnHp().ToString();
                    stat2rez.text = options1[2].GetComponent<wheels>().ReturnSpeed().ToString();
                    stat3rez.text = "";
                    stat4rez.text = "";
                    stat5rez.text = "";
                }
                else if (form1 == 2)
                {
                    Destroy(options1[2]);
                    options1[2] = tank1[1];
                    tank1[1] = null;
                    form1 = 1;
                    option1[2] = 0;
                    Destroy(options1[0]);
                    Destroy(options1[1]);
                    Destroy(options1[3]);
                    Destroy(options1[4]);
                    if (option1[1] - 2 >= 0)
                    {
                        GameObject clone4 = Instantiate(body[option1[1] - 2]);
                        clone4.transform.position = pos1[3].transform.position;
                        clone4.transform.localScale = pos1[3].transform.localScale;
                        options1[0] = clone4;
                    }
                    if (option1[1] - 1 >= 0)
                    {
                        GameObject clone = Instantiate(body[option1[1] - 1]);
                        clone.transform.position = pos1[4].transform.position;
                        clone.transform.localScale = pos1[4].transform.localScale;
                        options1[1] = clone;
                    }
                    if (option1[1] + 1 < body.Length)
                    {
                        GameObject clone2 = Instantiate(body[option1[1] + 1]);
                        clone2.transform.position = pos1[5].transform.position;
                        clone2.transform.localScale = pos1[5].transform.localScale;
                        options1[3] = clone2;
                    }
                    if (option1[1] + 2 < body.Length)
                    {
                        GameObject clone3 = Instantiate(body[option1[1] + 2]);
                        clone3.transform.position = pos1[6].transform.position;
                        clone3.transform.localScale = pos1[6].transform.localScale;
                        options1[4] = clone3;
                    }
                    stat1.text = "Hp";
                    stat2.text = "Weight";
                    stat3.text = "Kinetic Armor:";
                    stat4.text = "Thermal Armor:";
                    stat5.text = "";
                    stat1rez.text = options1[2].GetComponent<body>().ReturnHp().ToString();
                    stat2rez.text = options1[2].GetComponent<body>().ReturnWeight().ToString();
                    stat3rez.text = options1[2].GetComponent<body>().ReturnKineticArmor().ToString();
                    stat4rez.text = options1[2].GetComponent<body>().ReturnThermalArmor().ToString();
                    stat5rez.text = "";
                }
                else if (form1 == 3)
                {
                    ready = 0;
                    options1[2] = tank1[2];
                    tank1[2] = null;
                    form1 = 2;
                    if (option1[2] - 2 >= 0)
                    {
                        GameObject clone4 = Instantiate(pistol[option1[2] - 2]);
                        clone4.transform.position = pos1[3].transform.position;
                        clone4.transform.localScale = pos1[3].transform.localScale;
                        options1[0] = clone4;
                    }
                    if (option1[2] - 1 >= 0)
                    {
                        GameObject clone = Instantiate(pistol[option1[2] - 1]);
                        clone.transform.position = pos1[4].transform.position;
                        clone.transform.localScale = pos1[4].transform.localScale;
                        options1[1] = clone;
                    }
                    if (option1[2] + 1 < pistol.Length)
                    {
                        GameObject clone2 = Instantiate(pistol[option1[2] + 1]);
                        clone2.transform.position = pos1[5].transform.position;
                        clone2.transform.localScale = pos1[5].transform.localScale;
                        options1[3] = clone2;
                    }
                    if (option1[2] + 2 < pistol.Length)
                    {
                        GameObject clone3 = Instantiate(pistol[option1[2] + 2]);
                        clone3.transform.position = pos1[6].transform.position;
                        clone3.transform.localScale = pos1[6].transform.localScale;
                        options1[4] = clone3;
                    }
                    stat1.text = "Dmg";
                    stat2.text = "Attack Speed";
                    stat3.text = "Bullet Speed";
                    stat4.text = "Hp";
                    stat5.text = "Weight";
                    stat4rez.text = options1[2].GetComponent<pistol>().ReturnHp().ToString();
                    stat5rez.text = options1[2].GetComponent<pistol>().ReturnWeight().ToString();
                    stat1rez.text = options1[2].GetComponent<pistol>().ReturnDmg().ToString();
                    stat2rez.text = options1[2].GetComponent<pistol>().ReturnAtkSpeed().ToString();
                    stat3rez.text = options1[2].GetComponent<pistol>().ReturnBltSpeed().ToString();
                    FindObjectOfType<counter>().PlayerMM();
                }
            }
        }
        else if (player == 3 || player == 4)
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
            
            if (prevState.Buttons.Y == ButtonState.Released && state.Buttons.Y == ButtonState.Pressed && SceneManager.GetActiveScene().name == "SelectScene" && ready == 1)
            {
                selector[] tancuri = FindObjectsOfType<selector>();
                foreach (selector i in tancuri)
                {
                    if (i.ReturnReady() == 0)
                        return;
                }
                if (FindObjectOfType<counter>().ReturnPlayers() >= 2)
                    SceneManager.LoadScene("Area 1");
            }
            if (prevState.ThumbSticks.Left.X > 0.5 && SceneManager.GetActiveScene().name == "SelectScene" && ready == 0)
            {
                if (form1 == 0 && option1[0] + 1 < wheels.Length && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[0]++;
                    lerp1 = 1;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
                else if (form1 == 1 && option1[1] + 1 < body.Length && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[1]++;
                    lerp1 = 1;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
                else if (form1 == 2 && option1[2] + 1 < pistol.Length && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[2]++;
                    lerp1 = 1;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
            }
            if (prevState.ThumbSticks.Left.X < -0.5 && SceneManager.GetActiveScene().name == "SelectScene" && ready == 0)
            {
                if (form1 == 0 && option1[0] - 1 >= 0 && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[0]--;
                    lerp1 = 2;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
                else if (form1 == 1 && option1[1] - 1 >= 0 && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[1]--;
                    lerp1 = 2;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
                else if (form1 == 2 && option1[2] - 1 >= 0 && ableToSelect1 == true)
                {
                    t1 = 0;
                    option1[2]--;
                    lerp1 = 2;
                    ableToSelect1 = false;
                    Invoke("StopLerp1", 0.3f);
                }
            }
            if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && ableToSelect1 == true && SceneManager.GetActiveScene().name == "SelectScene")
            {
                if (ready != -1)
                {
                    if (form1 == 0)
                    {
                        tank1[0] = options1[2];
                        form1 = 1;
                        Destroy(options1[0]);
                        Destroy(options1[1]);
                        Destroy(options1[3]);
                        Destroy(options1[4]);
                        options1[2] = null;
                        if (body[0] != null)
                        {
                            GameObject clone = Instantiate(body[0]);
                            clone.transform.position = pos1[1].transform.position;
                            options1[2] = clone;
                        }
                        if (body[1] != null)
                        {
                            GameObject clone2 = Instantiate(body[1]);
                            clone2.transform.position = pos1[5].transform.position;
                            clone2.transform.localScale = pos1[5].transform.localScale;
                            options1[3] = clone2;
                        }
                        if (body[2] != null)
                        {
                            GameObject clone3 = Instantiate(body[2]);
                            clone3.transform.position = pos1[6].transform.position;
                            clone3.transform.localScale = pos1[6].transform.localScale;
                            options1[4] = clone3;
                        }
                        DontDestroyOnLoad(tank1[0]);
                        stat1.text = "Hp";
                        stat2.text = "Weight";
                        stat3.text = "Kinetic Armor:";
                        stat4.text = "Thermal Armor:";
                        stat5.text = "";
                        stat1rez.text = options1[2].GetComponent<body>().ReturnHp().ToString();
                        stat2rez.text = options1[2].GetComponent<body>().ReturnWeight().ToString();
                        stat3rez.text = options1[2].GetComponent<body>().ReturnKineticArmor().ToString();
                        stat4rez.text = options1[2].GetComponent<body>().ReturnThermalArmor().ToString();
                        stat5rez.text = "";
                    }
                    else if (form1 == 1)
                    {
                        tank1[1] = options1[2];
                        form1 = 2;
                        Destroy(options1[0]);
                        Destroy(options1[1]);
                        Destroy(options1[3]);
                        Destroy(options1[4]);
                        options1[2] = null;
                        if (pistol[0] != null)
                        {
                            GameObject clone = Instantiate(pistol[0]);
                            clone.transform.position = pos1[2].transform.position;
                            options1[2] = clone;
                        }
                        if (pistol[1] != null)
                        {
                            GameObject clone2 = Instantiate(pistol[1]);
                            clone2.transform.position = pos1[5].transform.position;
                            clone2.transform.localScale = pos1[5].transform.localScale;
                            options1[3] = clone2;
                        }
                        if (pistol[2] != null)
                        {
                            GameObject clone3 = Instantiate(pistol[2]);
                            clone3.transform.position = pos1[6].transform.position;
                            clone3.transform.localScale = pos1[6].transform.localScale;
                            options1[4] = clone3;
                        }
                        DontDestroyOnLoad(tank1[1]);
                        stat1.text = "Dmg";
                        stat2.text = "Attack Speed";
                        stat3.text = "Bullet Speed";
                        stat4.text = "Hp";
                        stat5.text = "Weight";
                        stat4rez.text = options1[2].GetComponent<pistol>().ReturnHp().ToString();
                        stat5rez.text = options1[2].GetComponent<pistol>().ReturnWeight().ToString();
                        stat1rez.text = options1[2].GetComponent<pistol>().ReturnDmg().ToString();
                        stat2rez.text = options1[2].GetComponent<pistol>().ReturnAtkSpeed().ToString();
                        stat3rez.text = options1[2].GetComponent<pistol>().ReturnBltSpeed().ToString();

                    }
                    else if (form1 == 2)
                    {
                        tank1[2] = options1[2];
                        form1 = 3;
                        Destroy(options1[0]);
                        Destroy(options1[1]);
                        Destroy(options1[3]);
                        Destroy(options1[4]);
                        options1[2] = null;
                        DontDestroyOnLoad(tank1[2]);
                        stat1.text = "";
                        stat2.text = "";
                        stat3.text = "";
                        stat4.text = "";
                        stat5.text = "";
                        stat1rez.text = "";
                        stat2rez.text = "";
                        stat3rez.text = "";
                        stat4rez.text = "";
                        stat5rez.text = "";
                        FindObjectOfType<counter>().PlayerPP();
                        ready = 1;
                    }
                }
                else
                {
                    GameObject clone = Instantiate(wheels[0]);
                    clone.transform.position = pos1[0].transform.position;
                    options1[2] = clone;
                    GameObject clone2 = Instantiate(wheels[1]);
                    clone2.transform.position = pos1[5].transform.position;
                    clone2.transform.localScale = pos1[5].transform.localScale;
                    options1[3] = clone2;
                    GameObject clone3 = Instantiate(wheels[2]);
                    clone3.transform.position = pos1[6].transform.position;
                    clone3.transform.localScale = pos1[6].transform.localScale;
                    options1[4] = clone3;
                    stat1.text = "Hp: ";
                    stat2.text = "Speed: ";
                    stat1rez.text = options1[2].GetComponent<wheels>().ReturnHp().ToString();
                    stat2rez.text = options1[2].GetComponent<wheels>().ReturnSpeed().ToString();
                    waiting.text = "";
                    ready = 0;
                }
            }
            if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed && ableToSelect1 == true && SceneManager.GetActiveScene().name == "SelectScene")
            {
                if (form1 == 0)
                {
                    option1[0] = 0;
                    Destroy(options1[0]);
                    Destroy(options1[1]);
                    Destroy(options1[2]);
                    Destroy(options1[3]);
                    Destroy(options1[4]);
                    stat1.text = "";
                    stat2.text = "";
                    stat1rez.text = "";
                    stat2rez.text = "";
                    waiting.text = "Press A to join";
                    ready = -1;
                }
                if (form1 == 1)
                {
                    Destroy(options1[2]);
                    options1[2] = tank1[0];
                    tank1[0] = null;
                    form1 = 0;
                    option1[1] = 0;
                    Destroy(options1[0]);
                    Destroy(options1[1]);
                    Destroy(options1[3]);
                    Destroy(options1[4]);
                    if (option1[0] - 2 >= 0)
                    {
                        GameObject clone4 = Instantiate(wheels[option1[0] - 2]);
                        clone4.transform.position = pos1[3].transform.position;
                        clone4.transform.localScale = pos1[3].transform.localScale;
                        options1[0] = clone4;
                    }
                    if (option1[0] - 1 >= 0)
                    {
                        GameObject clone = Instantiate(wheels[option1[0] - 1]);
                        clone.transform.position = pos1[4].transform.position;
                        clone.transform.localScale = pos1[4].transform.localScale;
                        options1[1] = clone;
                    }
                    if (option1[0] + 1 < wheels.Length)
                    {
                        GameObject clone2 = Instantiate(wheels[option1[0] + 1]);
                        clone2.transform.position = pos1[5].transform.position;
                        clone2.transform.localScale = pos1[5].transform.localScale;
                        options1[3] = clone2;
                    }
                    if (option1[0] + 2 < wheels.Length)
                    {
                        GameObject clone3 = Instantiate(wheels[option1[0] + 2]);
                        clone3.transform.position = pos1[6].transform.position;
                        clone3.transform.localScale = pos1[6].transform.localScale;
                        options1[4] = clone3;
                    }
                    stat1.text = "Hp";
                    stat2.text = "Speed";
                    stat3.text = "";
                    stat4.text = "";
                    stat5.text = "";
                    stat1rez.text = options1[2].GetComponent<wheels>().ReturnHp().ToString();
                    stat2rez.text = options1[2].GetComponent<wheels>().ReturnSpeed().ToString();
                    stat3rez.text = "";
                    stat4rez.text = "";
                    stat5rez.text = "";
                }
                else if (form1 == 2)
                {
                    Destroy(options1[2]);
                    options1[2] = tank1[1];
                    tank1[1] = null;
                    form1 = 1;
                    option1[2] = 0;
                    Destroy(options1[0]);
                    Destroy(options1[1]);
                    Destroy(options1[3]);
                    Destroy(options1[4]);
                    if (option1[1] - 2 >= 0)
                    {
                        GameObject clone4 = Instantiate(body[option1[1] - 2]);
                        clone4.transform.position = pos1[3].transform.position;
                        clone4.transform.localScale = pos1[3].transform.localScale;
                        options1[0] = clone4;
                    }
                    if (option1[1] - 1 >= 0)
                    {
                        GameObject clone = Instantiate(body[option1[1] - 1]);
                        clone.transform.position = pos1[4].transform.position;
                        clone.transform.localScale = pos1[4].transform.localScale;
                        options1[1] = clone;
                    }
                    if (option1[1] + 1 < body.Length)
                    {
                        GameObject clone2 = Instantiate(body[option1[1] + 1]);
                        clone2.transform.position = pos1[5].transform.position;
                        clone2.transform.localScale = pos1[5].transform.localScale;
                        options1[3] = clone2;
                    }
                    if (option1[1] + 2 < body.Length)
                    {
                        GameObject clone3 = Instantiate(body[option1[1] + 2]);
                        clone3.transform.position = pos1[6].transform.position;
                        clone3.transform.localScale = pos1[6].transform.localScale;
                        options1[4] = clone3;
                    }
                    stat1.text = "Hp";
                    stat2.text = "Weight";
                    stat3.text = "Kinetic Armor:";
                    stat4.text = "Thermal Armor:";
                    stat5.text = "";
                    stat1rez.text = options1[2].GetComponent<body>().ReturnHp().ToString();
                    stat2rez.text = options1[2].GetComponent<body>().ReturnWeight().ToString();
                    stat3rez.text = options1[2].GetComponent<body>().ReturnKineticArmor().ToString();
                    stat4rez.text = options1[2].GetComponent<body>().ReturnThermalArmor().ToString();
                    stat5rez.text = "";
                }
                else if (form1 == 3)
                {
                    options1[2] = tank1[2];
                    tank1[2] = null;
                    form1 = 2;
                    if (option1[2] - 2 >= 0)
                    {
                        GameObject clone4 = Instantiate(pistol[option1[2] - 2]);
                        clone4.transform.position = pos1[3].transform.position;
                        clone4.transform.localScale = pos1[3].transform.localScale;
                        options1[0] = clone4;
                    }
                    if (option1[2] - 1 >= 0)
                    {
                        GameObject clone = Instantiate(pistol[option1[2] - 1]);
                        clone.transform.position = pos1[4].transform.position;
                        clone.transform.localScale = pos1[4].transform.localScale;
                        options1[1] = clone;
                    }
                    if (option1[2] + 1 < pistol.Length)
                    {
                        GameObject clone2 = Instantiate(pistol[option1[2] + 1]);
                        clone2.transform.position = pos1[5].transform.position;
                        clone2.transform.localScale = pos1[5].transform.localScale;
                        options1[3] = clone2;
                    }
                    if (option1[2] + 2 < pistol.Length)
                    {
                        GameObject clone3 = Instantiate(pistol[option1[2] + 2]);
                        clone3.transform.position = pos1[6].transform.position;
                        clone3.transform.localScale = pos1[6].transform.localScale;
                        options1[4] = clone3;
                    }
                    stat1.text = "Dmg";
                    stat2.text = "Attack Speed";
                    stat3.text = "Bullet Speed";
                    stat4.text = "Hp";
                    stat5.text = "Weight";
                    stat4rez.text = options1[2].GetComponent<pistol>().ReturnHp().ToString();
                    stat5rez.text = options1[2].GetComponent<pistol>().ReturnWeight().ToString();
                    stat1rez.text = options1[2].GetComponent<pistol>().ReturnDmg().ToString();
                    stat2rez.text = options1[2].GetComponent<pistol>().ReturnAtkSpeed().ToString();
                    stat3rez.text = options1[2].GetComponent<pistol>().ReturnBltSpeed().ToString();
                    FindObjectOfType<counter>().PlayerMM();
                    ready = 0;
                }
            }
        }
        
    }
}


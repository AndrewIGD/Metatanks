using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPistol : MonoBehaviour
{
    float damage;
    float atkSpeed;
    float bulletSpeed;
    [SerializeField] GameObject bulletPos;
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject ogggPos;
    AudioClip shot;
    float weight;
    GameObject holder;
    float hp;

    //Functions
	
	public void GetOgPos(GameObject ogpos)
	{
		ogggPos = ogpos;
	}
    public void GetHp(float hpp)
    {
        hp = hpp;
    }
    public float ReturnHp()
    {
        return hp;
    }
    public void GetHolder(GameObject hold)
    {
        holder = hold;
    }
    public GameObject ReturnHolder()
    {
        return holder;
    }
    public void GetWeight(float w)
    {
        weight = w;
    }
    public void GetPistol(GameObject pis)
    {
        pistol = pis;
    }
    public void GetShot(AudioClip gunshot)
    {
        shot = gunshot;
    }
    public void GetDamage(float dmg)
    {
        damage = dmg;
    }
    public void GetAtkSpeed(float attackSpeed)
    {
        atkSpeed = attackSpeed;
    }
    public void GetBltSpeed(float bltSpeed)
    {
        bulletSpeed = bltSpeed;
    }

    public void GetBltPos(GameObject bltPos)
    {
        bulletPos = bltPos;
    }
    public float ReturnBltSpeed()
    {
        return bulletSpeed;
    }
    public float ReturnDmg()
    {
        return damage;
    }
    public float ReturnAtkSpeed()
    {
        return atkSpeed;
    }
    public GameObject ReturnBltPos()
    {
        return bulletPos;
    }
    public GameObject ReturnPistol()
    {
        return pistol;
    }
    public GameObject ReturnOgPos()
    {
        return ogggPos;
    }
    public AudioClip ReturnShot()
    {
        return shot;
    }
    public float ReturnWeight()
    {
        return weight;
    }
    // Start is called before the first frame update
    void Start()
    {
        ogpos[] pos = FindObjectsOfType<ogpos>();
        foreach(ogpos i in pos)
        {
            if (i.gameObject.transform.IsChildOf(gameObject.transform))
            {
                ogggPos = i.gameObject;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int players = 0;
    public void LoadSelect()
    {
        players--;
        if (players <= 1)
        {
            Invoke("LoadScene", 3f);
        }
    }
    public void LoadScene()
    {

        if (FindObjectOfType<MapSelector>().ReturnCount() < FindObjectOfType<MapSelector>().ReturnMaps().Length)
            SceneManager.LoadScene(FindObjectOfType<MapSelector>().ReturnMaps()[FindObjectOfType<MapSelector>().ReturnCount()]);
        else
        {
            GameObject[] tancuri = FindObjectsOfType<GameObject>();
            foreach (GameObject i in tancuri)
            {
                if (i != gameObject)
                    Destroy(i);
            }
            FindObjectOfType<MapSelector>().ResetCount();  SceneManager.LoadScene("SelectScene");}
    }
    // Start is called before the first frame update
    void Start()
    {
        selector[] tancuri = FindObjectsOfType<selector>();
        foreach (selector i in tancuri)
        {
            if (i.ReturnReady() == 0)
            {
                Destroy(i.ReturnTankModel()[0]);
                Destroy(i.ReturnTankModel()[1]);
                Destroy(i.ReturnTankModel()[2]);
                Destroy(i.gameObject);
            }
        }   
        Invoke("Start2", 0.5f);
    }
    void Start2()
    {
        tank[] tancuri = FindObjectsOfType<tank>();
        foreach (tank i in tancuri)
        {
            players++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

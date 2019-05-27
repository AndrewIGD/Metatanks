using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buton : MonoBehaviour
{
    public void Select()
    {
        
        SceneManager.LoadScene("SelectScene");
    }
    public void Select2()
    {
        selector[] tancuri = FindObjectsOfType<selector>();
        foreach(selector i in tancuri)
        {
            Destroy(i.gameObject);
        }
        SceneManager.LoadScene("SelectScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

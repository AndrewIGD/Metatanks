using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelector : MonoBehaviour
{
    [SerializeField] string[] maps;
    int count = 1;

    public string[] ReturnMaps()
    {
        return maps;
    }
    public int ReturnCount()
    {
        return count;
    }
    public void ResetCount()
    {
        count = 0;
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        MapSelector[] mape = FindObjectsOfType<MapSelector>();
        if (mape.Length > 1)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Area 1")
        {
            count = 1;
        }
        else if (SceneManager.GetActiveScene().name == "Area 2")
        {
            count = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Area 3")
        {
            count = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Area 4")
        {
            count = 4;
        }
        else if (SceneManager.GetActiveScene().name == "Area 5")
        {
            count = 5;
        }
    }
}

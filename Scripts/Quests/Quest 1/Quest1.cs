using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : MonoBehaviour {
    public int indexquest;
    CalenderManager c_manager;
	// Use this for initialization
	void Start ()
    {
        c_manager = FindObjectOfType<CalenderManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (indexquest != c_manager.globalIndex)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}

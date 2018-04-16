using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class BloodUIController : MonoBehaviour {

    public GameObject[] bloods;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InstantiateBlood ()
    {
        Instantiate(bloods[Mathf.RoundToInt(Random.Range(0, bloods.Length))], this.gameObject.transform);
    }
}

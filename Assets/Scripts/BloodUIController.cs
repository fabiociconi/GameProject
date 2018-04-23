using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class BloodUIController : MonoBehaviour {
    public GameObject[] bloods;
    public UnityEngine.UI.Slider healthUI;

    // Use this for initialization
    void Start () {
        var scoreValue = GameObject.FindGameObjectsWithTag("Score")[0].GetComponent<Text>();
        var score = GameManager.instance.score;
        scoreValue.text = score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        healthUI.value = (GameManager.instance.health / 100f);
	}

    public void InstantiateBlood ()
    {
        Instantiate(bloods[Mathf.RoundToInt(Random.Range(0, bloods.Length))], this.gameObject.transform);
    }
}

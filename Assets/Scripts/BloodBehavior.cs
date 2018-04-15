using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodBehavior : MonoBehaviour {
    public float FadeRate = 1;

    private Image image;
    private float targetAlpha = 0.0f;

    // Use this for initialization
    void Start () {
        this.image = this.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        Color curColor = this.image.color;
        float alphaDiff = Mathf.Abs(curColor.a - this.targetAlpha);
        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, this.FadeRate * Time.deltaTime);
            this.image.color = curColor;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

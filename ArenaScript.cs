using UnityEngine;
using System.Collections;

public class ArenaScript : MonoBehaviour {


	void Start () {//edit
        //resize the arena so it fits the whole screen no matter the device
        float factor = Camera.main.orthographicSize;

        float factorX = (Screen.width * factor * 2) / Screen.height;
        float factorY = factor * 2;

        Vector2 tmpSize = transform.localScale;
        tmpSize.x = factorX;
        tmpSize.y = factorY;
        transform.localScale = tmpSize;
	}
	
	void Update () {
	
	}
}


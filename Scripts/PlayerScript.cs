using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private float speedX = 10.0f;
    private float speedY = 10.0f; //***gameplay idea, testing***

	void Start () {
        //put the player in the upper-corner of the arena
        float camSize = Camera.main.orthographicSize;

        float posX = -((Screen.width * camSize) / Screen.height - transform.localScale.x/2);
        float posY = camSize - transform.localScale.y / 2;

        Vector2 pos = new Vector2(posX, posY);

        transform.position = pos;

        speedY = (Screen.width * speedX) / Screen.height; //gameplay idea: move the same amount of area in time on both axes ***testing***
	}

    void Update() {
        keepPlayerInsideCamera(); //do not let the player get out of camera bounds
    }

	void FixedUpdate () {
        handlePlayerInput(); //move the player
	}

    void handlePlayerInput() {
        //move the player across the screen
        if (Input.GetKey(KeyCode.W)) {
            Vector2 tmp = transform.position;
            tmp.y += speedX * Time.deltaTime;
            transform.position = tmp;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            Vector2 tmp = transform.position;
            tmp.y -= speedX * Time.deltaTime;
            transform.position = tmp;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            Vector2 tmp = transform.position;
            tmp.x -= speedY * Time.deltaTime;
            transform.position = tmp;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            Vector2 tmp = transform.position;
            tmp.x += speedY * Time.deltaTime;
            transform.position = tmp;
        }
    }

    void keepPlayerInsideCamera() {
        //do not let the player get out of camera bounds
        float camSize = Camera.main.orthographicSize;

        float posX = -((Screen.width * camSize) / Screen.height - transform.localScale.x/2);
        float posY = camSize - transform.localScale.y / 2;

        if (transform.position.x < posX) {
            Vector2 tmp = transform.position;
            tmp.x = posX;
            transform.position = tmp;
        }

        if (transform.position.x > -posX) {
            Vector2 tmp = transform.position;
            tmp.x = -posX;
            transform.position = tmp;
        }

        if (transform.position.y > posY) {
            Vector2 tmp = transform.position;
            tmp.y = posY;
            transform.position = tmp;
        }

        if (transform.position.y < -posY) {
            Vector2 tmp = transform.position;
            tmp.y = -posY;
            transform.position = tmp;
        }
    }
}

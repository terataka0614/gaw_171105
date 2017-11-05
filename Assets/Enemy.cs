using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
	Rigidbody2D rb2d;
	GameObject border;
	int fallspeed;
	bool is_moved;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
		border = GameObject.Find("BorderLine");
		this.transform.position = new Vector2(Random.Range(-2.35f, 2.35f), 5.5f);
		fallspeed = Random.Range(1, 5) * -1;
		if ("ChildEnemy" == this.name) {
			is_moved = true;
		} else {
			is_moved = false;
		}
	}

	void Update ()
	{
		overForBorderLine();
		enemyDestroy();
		if (true == is_moved) {
			autoDownMoved();
		}
	}

	// 等速で下方向に移動させる
	void autoDownMoved()
	{
		rb2d.velocity = new Vector2(rb2d.velocity.x, fallspeed);
	}

	// タップされたら消す
	void enemyDestroy()
	{
		if (0 < Input.touchCount) {
			Touch touch = Input.GetTouch(0);
			Vector2 touch_point = Camera.main.ScreenToWorldPoint(
				new Vector2(touch.position.x, touch.position.y)
			);
			Collider2D col = Physics2D.OverlapPoint(touch_point);
			if (col && touch.phase == TouchPhase.Began) {
				GameObject obj = col.gameObject;
				FindObjectOfType<ScoreManager>().addScore(10);
				Destroy(obj);
			}
		}
	}

	// 途中でゴールに達したらシーンを移動する
	void overForBorderLine()
	{
		if (border.transform.position.y > this.transform.position.y) {
			SceneManager.LoadScene("TitleScene");
		}
	}
}
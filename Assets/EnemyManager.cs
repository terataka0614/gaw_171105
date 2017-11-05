using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	GameObject parent_enemy;
	int clone_count;

	void Start ()
	{
		parent_enemy = GameObject.Find("ParentEnemy");
		clone_count = 100;
	}
	
	void Update ()
	{
		if (100 == clone_count) {
			CloneEnemy();
			clone_count = 0;
		} else {
			clone_count++;
		}
	}

	// ParentObjectsにあるEnemyを複製する
	void CloneEnemy()
	{
		GameObject parent = Object.Instantiate(parent_enemy) as GameObject;
		Enemy clone = parent.GetComponent<Enemy>();
		clone.name = "ChildEnemy";
	}
}

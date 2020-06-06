﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour {
	public BodyPartType type;
	[Space]
	public BodyPartType[] connectionParts;
	public Transform[] connectionPoints;
	[Space]
	public StatValue[] stats;
	[Space]
	[SerializeField] Rigidbody2D rigidbody;
	[SerializeField] SpriteRenderer sr;

	private void Awake() {
		rigidbody.simulated = false;

		Color c = sr.color;
		c.a = 0.0f;
		sr.color = c;
		LeanTween.value(gameObject, 0.0f, 1.0f, 0.33f)
			.setOnUpdate((float t) => {
				c = sr.color;
				c.a = t;
				sr.color = c;
			});
	}

	public void OnDie() {
		rigidbody.simulated = true;

		rigidbody.AddForce(new Vector2(Random.Range(-500, 500), Random.Range(0, 750)), ForceMode2D.Impulse);
		rigidbody.AddTorque(Random.Range(-5, 5), ForceMode2D.Impulse);
		LeanTween.value(gameObject, 1.0f, 0.0f, 1.5f)
			.setOnUpdate((float t) => {
				Color c = sr.color;
				c.a = t;
				sr.color = c;
			});
	}
}

[System.Serializable]
public class StatValue {
	public StatType type;
	public float value;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
	[SerializeField] float speedX = default;
	[SerializeField] float posX = default;

	void Update()
	{
		transform.Translate(speedX, 0, 0);
		if (transform.position.x < -posX)
		{
			transform.position = new Vector3(posX, 0, 0);
		}
	}
}
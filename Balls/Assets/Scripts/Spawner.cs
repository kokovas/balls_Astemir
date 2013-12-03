/* Создаем заданное количество шариков и задаем им начальные параметры. */

using UnityEngine;
using System.Collections;

public class Spawner:MonoBehaviour {
	public Rigidbody2D ball;
	public static int ballCount=0;

	void Start() {
		InvokeRepeating("Spawn", 0.1f, 1f);	// вызываем функцию создания шариков каждую секунду
	}

	void Spawn() {
		ballCount++;						// счетчик количества шариков

		// создаем объект-шарик из префаба
		Rigidbody2D Balls = Instantiate(ball, new Vector2(Random.Range(-5.0F, 5.0F), Random.Range(-3.0F, 3.0F)), transform.rotation) as Rigidbody2D;	
		Balls.rigidbody2D.velocity = new Vector2(Random.Range(-3F, 3F), Random.Range(-3F, 3F));		// задаем начальную скорость шарика


		if (ballCount>=MainMenu.ballAmt) {		// если шариков уже хватает
			CancelInvoke("Spawn");			// то перестаем создавать новые
		}
	}
}
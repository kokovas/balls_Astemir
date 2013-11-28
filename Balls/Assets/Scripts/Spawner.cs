/* Создаем заданное количество шариков и задаем им начальные параметры. */

using UnityEngine;
using System.Collections;

public class Spawner:MonoBehaviour {
	//public Rigidbody2D ball;
	public GameObject ball;
	//public GameObject number;

	private int ballCount=0;

	void Start() {
		InvokeRepeating("Spawn", 0.1f, 1f);	// вызываем функцию создания шариков каждую секунду
	}

	void Spawn() {
		ballCount++;						// счетчик количества шариков

		//ball.tag=ballCount.ToString();
		Rigidbody2D Balls = Instantiate(ball, new Vector2(Random.Range(-5.0F, 5.0F), Random.Range(-3.0F, 3.0F)), transform.rotation) as Rigidbody2D;	// создаем объект-шарик из префаба
		Balls.rigidbody2D.velocity = new Vector2(Main_menu.speed+Random.Range(-7F, 7F), Main_menu.speed+Random.Range(-7F, 7F));																	// задаем начальную скорость шарика


		if (ballCount>=Main_menu.amt) {		// если шариков уже хватает
			CancelInvoke("Spawn");			// то перестаем создавать новые
		}
	}
}
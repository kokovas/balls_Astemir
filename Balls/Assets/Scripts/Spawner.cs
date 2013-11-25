using UnityEngine;
using System.Collections;

public class Spawner: MonoBehaviour {
	public Rigidbody2D ball;
	int i=0;

	void Start() {
		InvokeRepeating("Spawn", 0.1f, 1f);	// вызываем функцию создания шариков каждую секунду
	}

	void Spawn() {
		Rigidbody2D Balls = Instantiate(ball, new Vector2(Random.Range(-5.0F, 5.0F), Random.Range(-3.0F, 3.0F)), transform.rotation) as Rigidbody2D;	// создаем объект-шарик из префаба
		Balls.rigidbody2D.velocity = new Vector2(Random.Range(-10F, 10F), Random.Range(-10F, 10F));														// задаем начальную скорость шарика

		i++;								// счетчик количества шариков

		if (i>=20) {						// если шариков больше 20
			CancelInvoke("Spawn");			// то перестаем создавать новые
		}
	}
}
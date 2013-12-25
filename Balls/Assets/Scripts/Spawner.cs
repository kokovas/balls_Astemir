/* Создаем заданное количество шариков и задаем им начальные параметры. */

using UnityEngine;
using System.Collections;

public class Spawner: MonoBehaviour {
	public Rigidbody2D ball;						// инициализируем объект ball(из префаба)
	public static int ballCount = 0;				// счётчик созданных шариков

	void Start() {
		InvokeRepeating("Spawn", 0.1f, 0.7f);		// вызываем функцию создания шариков каждую секунду
	}

	void Spawn() {
		ballCount++;								// номер создаваемого шарика

		// создаем объект-шарик из префаба
		Rigidbody2D Balls = Instantiate(ball, 
		                                new Vector2(Random.Range(-GameWindow.sizeX, GameWindow.sizeX), 
		                                            Random.Range(-GameWindow.sizeY, GameWindow.sizeY)), 
		                                transform.rotation) as Rigidbody2D;

		Balls.rigidbody2D.velocity = new Vector2(Random.Range(-3F, 3F), Random.Range(-3F, 3F));			// задаем начальную скорость шарика
		Balls.transform.FindChild("number").gameObject.GetComponent<TextMesh>().text = "" + ballCount;	// задаём номер шарика

		if (ballCount >= MainMenu.ballAmt) {		// если шариков уже хватает
			CancelInvoke("Spawn");					// то перестаем создавать новые
		}
	}
}
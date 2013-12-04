/* Обрабатываем клик на шарик. */

using UnityEngine;
using System.Collections;

public class ClickOnTheBall: MonoBehaviour {
	public Camera cam1;									// задаем камеру
	public static int ballDestroy=0;					// счетчик тапнутых шариков

	void Update() {
		if (ballDestroy>=MainMenu.ballAmt) {			// если шарики закончились то
			Application.LoadLevel("EndLevel");			// переходим в меню выйгрыша
		}

		if (Input.GetMouseButtonDown(0)) {				// обрабатываем клик мыши
			RaycastHit2D aHit = new RaycastHit2D();		// инициализируем луч

			// проводим луч от камеры до места клика мышью
			aHit = Physics2D.Raycast(cam1.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			try {
				if(Input.GetMouseButtonDown(0)&&(aHit.transform.tag=="enemy")) {	// если луч пресекает объект тег которого enemy то
					Destroy(aHit.collider.gameObject);								// удаляем этот объект
					ballDestroy++;													// счетчик удалённых объектов
					Score.score+=10;												// добавляем 100 очков за тапнутый шарик
				}
			} catch {
				// добавляем в исключение ошибку при клике в пустое пространство
			}
		}
	}
}
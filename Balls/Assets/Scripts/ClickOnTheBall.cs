/* Обрабатываем клик на шарик. */

using UnityEngine;
using System.Collections;

public class ClickOnTheBall: MonoBehaviour {
	public Camera cam1;													// задаем камеру
	public static int ballDestroy = 0;									// счетчик тапнутых шариков
	public AudioClip ding;
	public AudioClip play;

	void Update() {
		if (ballDestroy >= MainMenu.ballAmt) {							// если шарики закончились то
			if (MainMenu.levelNum == 30) {								// если этот уровень последний то
				Application.LoadLevel("MainMenu");						// возвращаемся в гланое меню
			}

			Application.LoadLevel("EndLevel");							// переходим в меню выйгрыша
		}

		if (Input.GetMouseButtonDown(0)) {								// обрабатываем клик мыши
			RaycastHit2D aHit = new RaycastHit2D();						// инициализируем луч
			
			// проводим луч от камеры до места клика мышью
			aHit = Physics2D.Raycast(cam1.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			try {
				// если луч пресекает объект тег которого ball то
				if(Input.GetMouseButtonDown(0) && (aHit.transform.tag == "ball")) {
					// если номер тапнутого шарика на один больше чем номур удаленного то
					if (int.Parse(aHit.collider.gameObject.transform.FindChild("number").gameObject.GetComponent<TextMesh>().text) == ballDestroy + 1) {
						// проигрываем звук для тапнутого шарика
 						AudioSource.PlayClipAtPoint (ding, transform.position);
						Destroy(aHit.collider.gameObject);				// удаляем этот объект
						ballDestroy++;									// счетчик удалённых объектов
						Score.score += 10;								// добавляем 10 очков за тапнутый шарик
					}
				}
			} catch {
				// добавляем в исключение ошибку при клике в пустое пространство
				AudioSource.PlayClipAtPoint (play, transform.position); // звук для промаха
			}
		}
	}
}
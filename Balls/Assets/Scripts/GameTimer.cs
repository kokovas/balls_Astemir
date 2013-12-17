/* Получаем занчение таймера и отсчитываем время до конца игры */

using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {
	void Update() {
		if (MainMenu.gameTimer <= 0) {
			Application.LoadLevel("GameOver");							// если время истекло, то переходим в сцену GameOver
		}

		MainMenu.gameTimer -= 1.0f * Time.deltaTime;					// каждую секунду отнимаем от заданного значения таймера 1
		guiText.text = "ВРЕМЯ: " + MainMenu.gameTimer.ToString("f1");	// отображение значения таймера на экране
	}
}
/* Меню проигрыша */

using UnityEngine;
using System.Collections;

public class GameOver: MonoBehaviour {
	void Start() {
		Spawner.ballCount = 0;								// обнуляем счётчик созданных шариков 
		ClickOnTheBall.ballDestroy = 0;						// обнуляем счётчик тапнутых шариков
		Score.score = 0;									// обнуляем счетчик очков
	}
	
	void OnGUI() {
		// создаем окно главного меню игрыv
		GUI.Box(new Rect(Screen.width / 2 - 350, Screen.height / 2 - 250, 700, 500), "(((_ПОРАЖКЕНИЕ_(((");
		
		// создаём кнопу "Пройти заново уровень" и обрабатываем её нажатие
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 40), "Пройти заново уровень " + MainMenu.levelNum)) { 
			MainMenu.ballSpeed = MainMenu.levelNum / 5;		// получаем скорость шариков на уровне
			MainMenu.gameTimer = MainMenu.ballAmt;			// получаем значение с которого начинается отсчет таймера
			Application.LoadLevel("Game");					// проходим заново тот же уровень 
		}

		// создаём кнопку "Выйти в главное меню" и обрабатываем её нажатие
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 40), "Выйти в главное меню")) { 
			Application.LoadLevel("MainMenu");				// выходим в главное меню 
		}
	}
}
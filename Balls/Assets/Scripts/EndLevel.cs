/* Меню окончания уровня включающее в себя переход на следующий уровень, перезапуск текущего и выход в главное меню */

using UnityEngine;
using System.Collections;

public class EndLevel: MonoBehaviour {
	int _scoreLevel = 0;										// очки набранные на уровне

	void Start() {
		_scoreLevel = (int)(Score.score * MainMenu.gameTimer);	// количество очков набранных при прохождении уровня

		// если мы набрали больше очков чем в прошлый раз, то перезаписываем рекорд
		if (_scoreLevel > MainMenu.scores[MainMenu.levelNum - 1]) {
			MainMenu.scores[MainMenu.levelNum - 1] = _scoreLevel;
			DataBase.getInstance().query("UPDATE rating SET score = " + _scoreLevel.ToString() + " WHERE level = " + MainMenu.levelNum);
		}

		Spawner.ballCount = 0;									// обнуляем счётчик созданных шариков
		ClickOnTheBall.ballDestroy = 0;							// обнуляем счётчик тапнутых шариков
		Score.score = 0;										// обнуляем счетчик очков
	}

	void OnGUI() {
		// создаем окно главного меню игры
		GUI.Box(new Rect(Screen.width / 2 - 350, Screen.height / 2 - 250, 700, 500), ")))_ПОБЕДА_)))");

		// выводим количество очков заработанных на уровне
		GUI.Label(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 170, 100, 20), "** " + _scoreLevel.ToString() + " **");

		// создаём кнопку "Следующий уровень" и обрабатываем её нажатие
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 40), "Следующий уровень " + (MainMenu.levelNum + 1))) {
			MainMenu.levelNum++;								// увеличиваем уровень на 1					
			MainMenu.ballAmt = 10 + MainMenu.levelNum;			// получаем количество шариков на уровне
			MainMenu.ballSpeed = MainMenu.levelNum / 5;			// получаем скорость шариков на уровне
			MainMenu.gameTimer = MainMenu.ballAmt;				// получаем значение с которого начинается отсчёт таймера
			Application.LoadLevel("Game");						// переход на следующий уровень
		}

		// создаём кнопу "Пройти заново уровень" и обрабатываем её нажатие
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 40), "Пройти заново уровень " + MainMenu.levelNum)) {
			MainMenu.ballSpeed = MainMenu.levelNum / 5;			// получаем скорость шариков на уровне
			MainMenu.gameTimer = MainMenu.ballAmt;				// получаем значение с которого начинается отсчёт таймера
			Application.LoadLevel("Game");						// проходим заново тот же уровень 
		}

		// создаём кнопку "Выйти в главное меню" и обрабатываем её нажатие
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 40), "Выйти в главное меню")) {
			Application.LoadLevel("MainMenu");					// выходим в главное меню 
		}
	}
}
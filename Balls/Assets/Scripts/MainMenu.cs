using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MainMenu: MonoBehaviour {
	public static int levelNum;								// номер выбранного уровня
	public static int ballAmt;								// количество шариков на уровне
	public static float ballSpeed;							// скорость шариков на уровне
	public static float gameTimer;							// время до конца игры
	public static int[] scores = new int[30];				// массив рекордов

	int _levelAmt = 30;				     					// количество уровней в игре
	
	void Start() {
		int i = 0;											// итераторы для циклов

		// призапуске игры и выходе в главное меню обновляем список рекордов
        try {
            // получаем выборку из таблицы
            QueryResult res = DataBase.getInstance().query("SELECT score FROM rating ORDER BY level");

            for (i = 0; i < res.numRows(); i++) {
                scores[i] = res[i].getAsInt("score");
            }
        } catch (DatabaseException e) {
            Debug.Log(e.Message);
        }
	}

	void OnGUI() {
		int i = 0, j = 0;									// итераторы для циклов

		// создаем окно главного меню игры
		GUI.Box(new Rect(Screen.width/2 - 350, Screen.height/2 - 250, 700, 500), "МЕНЮ");

		// создаем кнопки перехода на доступные уровни
		for (i = 0; i < _levelAmt / 5; i++) {
			for (j = 0; j < 5; j++) {
				// создаём кнопку перехода на уровень и обрабатываем её нажатие
				if (GUI.Button(new Rect(Screen.width/2 - 315 + j * 130, Screen.height/2 - 200 + i * 65, 100, 40), "Уровень_"+(i * 5 + j + 1))) { 
					levelNum = i * 5 + j + 1;				// определяем какой уровень был выбр					
					ballAmt = 10 + levelNum;				// определяем количество шариков на уровне levelNum
					ballSpeed = levelNum/5;				// определяем скорость шариков на уровне levelNum
					gameTimer = ballAmt;					// определяем время до конца игры для уровня levelNum
					Application.LoadLevel("Game");			// загружаем сцену "Game"
				}

				// создаём окошки с рекордави под каждым уровнем
				GUI.Box(new Rect(Screen.width/2 - 300 + j * 130, Screen.height/2 - 170 + i * 65, 70, 20), "" + scores[i * 5 + j].ToString());
			}
		}

		// выход из игры
		if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 + 195, 200, 40), "ВЫХОД")) { 
			//DataBase.getInstance().closeConnection();		// закрываем соединение с базой данных
			Application.Quit();								// выходим из игры
		}
	}
}
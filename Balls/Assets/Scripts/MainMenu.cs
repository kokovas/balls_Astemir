/* Создаём главное меню игры включающее в себя кнопки перехода на доступные уровни и кнопку выхода из игры. */

using UnityEngine;
using System.Collections;

public class MainMenu: MonoBehaviour {
	public static int levelNum;						// номер выбранного уровня
	public static int ballAmt;						// количество шариков на уровне
	public static float ballSpeed;					// скорость шариков на уровне
	public static float gameTimer;					// время до конца игры

	int _levelAmt=30;								// количество уровней в игре
	public static float[] scores = new float[30];	// массив рекордов

	void Start() {
		/*int i=0, j=0;								// итераторы для циклов

		for (i=0; i<6; i++) {
			for (j=0; j<5; j++) {
				scores[i*5+j]=0;					// обнуление массива рекордов
			}
		}*/
	}

	void OnGUI() {
		int i=0, j=0;								// итераторы для циклов

		// создаем окно главного меню игры
		GUI.Box(new Rect(Screen.width/2-350, Screen.height/2-250, 700, 500), "МЕНЮ");

		// создаем кнопки перехода на доступные уровни
		for (i=0; i<6; i++) {
			for (j=0; j<5; j++) {
				if (GUI.Button(new Rect(Screen.width/2-315+j*130, Screen.height/2-200+i*65, 100, 40), "Уровень_"+(i*5+j+1))) { 
					levelNum=i*5+j+1;				// определяем какой уровень был выбр					
					ballAmt=10+levelNum;			// определяем количество шариков на уровне levelNum
					ballSpeed=levelNum/5;			// определяем скорость шариков на уровне levelNum
					gameTimer=ballAmt;				// определяем время до конца игры для уровня levelNum
					Application.LoadLevel("Game");	// загружаем сцену "Game"
				}

				GUI.Box(new Rect(Screen.width/2-300+j*130, Screen.height/2-170+i*65, 70, 20), ""+scores[i*5+j].ToString("f0"));
			}
		}
			
		// выход из игры
		if (GUI.Button(new Rect(Screen.width/2-100, Screen.height/2+195, 200, 40), "ВЫХОД")) { 
			Application.Quit();						// выходим из игры 
		}
	}
}
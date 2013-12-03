/* Создаём главное меню игры включающее в себя кнопки перехода на доступные уровни и кнопку выхода из игры. */

using UnityEngine;
using System.Collections;

public class MainMenu:MonoBehaviour {
	public static int levlelNum;	// номер выбранного уровня
	public static int ballAmt;		// количество шариков на уровне
	public static float ballSpeed;	// скорость шариков на уровне

	int i=0, j=0;					// итераторы для циклов
	int levelAmt=29;				// количество уровней в игре

	void OnGUI() {
		// создаем окно главного меню игры
		GUI.Box(new Rect(Screen.width/2-350, Screen.height/2-250, 700, 500), "МЕНЮ");

		// создаем кнопки перехода на доступные уровни
		for (i=0; i<=levelAmt/5; i++) {
			for (j=0; j<=4; j++) {
				if (GUI.Button(new Rect(Screen.width/2-315+j*130, Screen.height/2-170+i*50, 100, 40), "Уровень_"+(i*5+j+1))) { 
					levlelNum=i*5+j+1;				// определяем какой уровень был выбр					
					ballAmt=3+levlelNum;
					ballSpeed=levlelNum/5;
					Application.LoadLevel("Game");	// загружаем сцену "Game"
				}
			}
		}
			
		// выход из игры
		if (GUI.Button(new Rect(Screen.width/2-100, Screen.height/2+195, 200, 40), "ВЫХОД")) { 
			Application.Quit();						// выходим из игры 
		}
	}
}
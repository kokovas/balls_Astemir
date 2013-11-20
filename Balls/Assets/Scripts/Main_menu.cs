using UnityEngine;
using System.Collections;

public class Main_menu : MonoBehaviour {
	int i=0, j=0;		// итераторы для циклов
	int numb=29;		// количество уровней в игре

	void OnGUI() {
		// создаем окно главного меню игры
		GUI.Box(new Rect(Screen.width/2-350, Screen.height/2-250, 700, 500), "МЕНЮ");

		// создаем кнопки-уровни
		for (i=0; i<=numb/5; i++) {
			for (j=0; j<=4; j++) {
				if (GUI.Button(new Rect(Screen.width/2-315+j*130, Screen.height/2-170+i*50, 100, 40), "Уровень_"+(i*5+j+1))) { 
					Application.LoadLevel("Game");	
				}
			}
		}

		// выход из игры
		if (GUI.Button(new Rect(Screen.width/2-100, Screen.height/2+195, 200, 40), "ВЫХОД")) { 
			// выходим из игры 
			Application.Quit();
		}
	}
}
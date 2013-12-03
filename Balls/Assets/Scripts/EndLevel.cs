using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {
	void Start() {
		Spawner.ballCount=0;
		ClickOnTheBall.ballDestroy=0;
	}

	void OnGUI() {
		// создаем окно главного меню игры
		GUI.Box(new Rect(Screen.width/2-350, Screen.height/2-250, 700, 500), "УРА_ПОБЕДА!!! )))");

		if (GUI.Button(new Rect(Screen.width/2-100, Screen.height/2-150, 200, 40), "Следующий уровень - "+(MainMenu.levlelNum+1))) { 
			MainMenu.levlelNum+=1;						// увеличиваем уровень на 1					
			MainMenu.ballAmt=3+MainMenu.levlelNum;		// получаем количество шариков на уровне
			MainMenu.ballSpeed=MainMenu.levlelNum/5;	// получаем скорость шариков на уровне
			Application.LoadLevel("Game");				// переход на следующий уровень
		}
		if (GUI.Button(new Rect(Screen.width/2-100, Screen.height/2, 200, 40), "Пройти заново уровень "+MainMenu.levlelNum)) { 
			Application.LoadLevel("Game");				// проходим заново тот же уровень 
		}
		if (GUI.Button(new Rect(Screen.width/2-100, Screen.height/2+150, 200, 40), "Выйти в главное меню")) { 
			Application.LoadLevel("MainMenu");			// выходим в главное меню 
		}
	}
}

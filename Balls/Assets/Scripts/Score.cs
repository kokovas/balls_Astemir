/* Обновляем счёт игры который изменяется в классе ClickOnTheBall */

using UnityEngine;
using System.Collections;

public class Score: MonoBehaviour {
	public static int score = 0;			// обнуляем счёт

	void Update() {
		guiText.text = "СЧЁТ: " + score;	// обновляем счёт (счёт изменяется в классе ClickOnTheBall)
	}
}
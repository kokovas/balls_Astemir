/* Обрабатываем клик на шарик. */

using UnityEngine;
using System.Collections;

public class Ray_C : MonoBehaviour {
	public Camera cam1;

	void Update () {
		if (Input.GetMouseButtonDown(0)){
			RaycastHit2D aHit = new RaycastHit2D();
			if (cam1.orthographic){
				aHit = Physics2D.Raycast(cam1.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);   
			}
			
			if(Input.GetMouseButtonDown(0)&&(aHit.transform.tag!="STANLE")){
				Destroy(aHit.collider.gameObject);
			}
		}
	}
}
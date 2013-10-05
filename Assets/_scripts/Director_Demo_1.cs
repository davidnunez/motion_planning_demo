using UnityEngine;
using System.Collections;
using Vectrosity;
public class Director_Demo_1 : MonoBehaviour {
	
	VectorLine myLine;
	VectorPoints indicator;
	public GameObject indicator2;
	public Vector2 angles;
	public GameObject shoulder;
	public GameObject elbow;
	// Use this for initialization
	void Start () {
		//myLine = VectorLine.SetLine (Color.green, new Vector2(0, 0), new Vector2(Screen.width,
//Screen.height));
		myLine = new VectorLine ("Square", new Vector2[8], null, 1.0f);
		myLine.MakeRect (new Rect(50, 300, 200, 200));
		myLine.Draw();
		
		indicator = new VectorPoints("Indicator", new Vector2[1], null, 5.0f);
		indicator.points2[0] = new Vector2(100, 200);
		indicator.Draw();
		
		angles = new Vector2();
		setAngles(new Vector2(100,200));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
 			//Debug.Log("Position" + Input.mousePosition);
			
			if (Input.mousePosition.x > 50 && Input.mousePosition.x < 250 && Input.mousePosition.y > 100 && Input.mousePosition.y < 300) {
			//	Debug.Log("IN BOX!");
				indicator.points2[0] = Input.mousePosition;
			
				setAngles(Input.mousePosition);
				indicator.Draw();
				
			}
		}
	
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (Input.mousePosition.x > 50 && Input.mousePosition.x < 250 && Input.mousePosition.y > 100 && Input.mousePosition.y < 300) {
		//		iTween.ValueTo(this, iTween.Hash("x", Input.mousePosition.x, "y", Input.mousePosition.y, "time", 2.0f));
			}			
			
			myLine.points2[0] = new Vector2(0, Screen.height); 
			myLine.points2[1] = new Vector2(Screen.width, 0); 
			myLine.Draw();
		}
		shoulder.transform.eulerAngles = new Vector3(0,0,angles.x);
		elbow.transform.eulerAngles = new Vector3(0,0,angles.y);

	}
	
	
	void setAngles(Vector2 position) {
		angles.x = map (position.x, 50.0f, 250.0f, 0f, 360.0f);
		angles.y = map (position.y, 100.0f, 300.0f, 0f, 360.0f);
		
	}
	

	float map(float s, float a1, float a2, float b1, float b2) {

	    return b1 + (s-a1)*(b2-b1)/(a2-a1);

	}
	
	void onupdate(Vector2 p) {
		indicator.points2[0] = p;
	}	
}

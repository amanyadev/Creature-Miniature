using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{   
    Transform[] points; 
    [Range(10,100)] public int resolution = 10;
    
    public Transform pointPrefab;

    void Start(){
        float step = 3.0f / resolution;
       	Vector3 scale = Vector3.one *step;
		Vector3 position;
        position.x = 0;
        position.y = 0;
        position.z = 0;
        points = new Transform[resolution];
		for (int i = 0; i < resolution; i++) {
			Transform point = Instantiate(pointPrefab);
            points[i] = point;
			position.x = (i + 0.5f) * step - 1f;//not working
          position.y = (position.x)*position.x*position.x;
			point.localPosition = position;
			point.localScale = scale;
            point.SetParent(transform);
            transform.translate(quaternion);
	    
		}
    }

    // Update is called once per frame
  /*  void Update()
    {
        for (int i = 0; i < points.Length; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;

            
			position.y = Mathf.Tan(Mathf.PI * (position.x + Time.time));

			point.localPosition = position;
            	
		}

    }*/
}

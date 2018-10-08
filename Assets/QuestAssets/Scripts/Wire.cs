using UnityEngine;

public class Wire : MonoBehaviour {

    private LineRenderer lr = null;
    private Vector3[] children;

    [ContextMenu("BuildWire")]
	void Build () {
        children = new Vector3[transform.childCount];
        lr = GetComponent<LineRenderer>();
        lr.positionCount = children.Length;
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i).position;
            lr.SetPosition(i, children[i]);
        }
        lr.SetPositions(children);
    }
}

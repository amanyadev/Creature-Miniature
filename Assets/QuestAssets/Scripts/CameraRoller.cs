using System.Collections;
using UnityEngine;

public class CameraRoller : MonoBehaviour {

    public float speed = 6f;

    public void MoveTo(Transform pos)
    {
        StartCoroutine(Move(pos));
    }

    private IEnumerator Move(Transform posToMove)
    {
        while (Vector3.Distance(transform.position, posToMove.position) > .3f)
        {
            transform.position += (posToMove.position - transform.position).normalized * speed * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}

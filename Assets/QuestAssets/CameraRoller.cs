using System.Collections;
using UnityEngine;

public class CameraRoller : MonoBehaviour {

    public float speed = 6f;
    public Vector3[] positions;
    public int current = 0;

    public void MoveToNext()
    {
        if (positions.Length > current + 1)
        {
            current++;
            StartCoroutine(Move(positions[current]));
        }
    }

    public void MoveToPrevious()
    {
        if (current > 0)
        {
            current--;
            StartCoroutine(Move(positions[current]));
        }
    }

    private IEnumerator Move(Vector3 posToMove)
    {
        while (Vector3.Distance(transform.position, posToMove) > .1f)
        {
            transform.position += (transform.position + posToMove).normalized * speed * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}

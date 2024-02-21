using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(CollectedAnimation());
    }

    public IEnumerator CollectedAnimation()
    {
        float timePassed = 0f;
        float duration = 0.4f;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z);
        do
        {
            timePassed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, endPos, timePassed);
            yield return null;
        } while(timePassed < duration);
        Destroy(gameObject);
    }
}

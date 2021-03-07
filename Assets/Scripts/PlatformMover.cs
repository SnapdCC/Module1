using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public Transform start;
    public Transform target;
    float speed = .1f;
    float elapsedTime = 0f;
    const float tripTime = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float weight = Mathf.Cos(elapsedTime * speed * 2 * Mathf.PI) *0.5f + 0.5f;
        // transform.position = start.position * weight + target.position * (1-weight);
        // elapsedTime += Time.deltaTime;
        if (gameObject.transform.position == target.position)
        {
            Transform temp = target;
            target=start;
            start=temp;
            elapsedTime=0;
        }
        transform.position = Vector3.Lerp(start.position, target.position, speed * elapsedTime%tripTime);
        elapsedTime += Time.deltaTime;
    }
}

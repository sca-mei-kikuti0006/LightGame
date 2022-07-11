using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExplosionControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayCoroutine(2, () =>
        {
            Destroy(gameObject);


        }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

    public GameObject Object;
    private IEnumerator coroutine;
    private float ObjectPosition;
    private float ObjectStartPosition;
    // Use this for initialization

    void Start ()
    {
        ObjectStartPosition = Object.transform.position.y; //get starting y value
        coroutine = WaitAndPrint(2.0f);
        StartCoroutine(coroutine);

    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {

            Vector3 temp = new Vector3(-50.0f, 0, 0);
            Object.transform.position += temp;
            ObjectPosition = Object.transform.position.y; //get current y value
            if (ObjectPosition < ObjectStartPosition - 200) //one current value goes X below starting value turn around
            {
                Vector3 temp1 = new Vector3(+50.0f, 0, 0);
                Object.transform.position += temp1;
            }
        }
    }
}

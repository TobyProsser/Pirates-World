using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {

    public Vector3 Destination;

    public float TimeBetween = 5;

    public float speedOfBoat = 10;
    public GameObject boat;

    public Rigidbody controller;
    public float heading;
    public float heading1;

    private float xValMin;
    private float xValMax;
    private float zValMin;
    private float zValMax;

    // Use this for initialization
    void Awake()
    {
        heading = boat.transform.position.x;
        heading1 = boat.transform.position.z;

        controller = GetComponent<Rigidbody>();

        StartCoroutine(NewHeading());
    }

    void Update()
    {
        boat.transform.LookAt(Destination);
        //transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.time * speed);
        float step = speedOfBoat * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Destination, step);
    }

    IEnumerator NewHeading()
    {
        while (true)
        {
            NewHeadingRoutine();
            print("Distination: " + Destination);
            yield return new WaitForSeconds(TimeBetween);
        }
    }

    void NewHeadingRoutine()
    {
        xValMin = .2f;
        xValMax = 112f;
        heading = Random.Range(xValMin, xValMax);

        zValMin = .2f;
        zValMax = 112f;
        heading1 = Random.Range(zValMin, zValMax);

        float yVal = boat.transform.position.y;
        Destination = new Vector3(heading, yVal, heading1);
    }
}

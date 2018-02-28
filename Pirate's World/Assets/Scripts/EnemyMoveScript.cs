using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveScript : MonoBehaviour {

    public Vector3 Destination;

    public float TimeBetween = 5;

    public float speedOfBoat = 10;
    public GameObject boat;

    public float heading;
    public float heading1;

    private float xValMin;
    private float xValMax;
    private float zValMin;
    private float zValMax;

    public float damping = 2;
    private Quaternion targetRotation;

    private NavMeshAgent navComponent;

    // Use this for initialization
    void Awake()
    {
        heading = boat.transform.position.x;
        heading1 = boat.transform.position.z;

        StartCoroutine(NewHeading());

        navComponent = boat.gameObject.GetComponent<NavMeshAgent>();

        Destination = new Vector3(-13.5f, 63.08f, -76.97f);
        navComponent.Warp(Destination);
    }

    void Update()
    {
        //Vector3 minus = new Vector3(0, -90, 0);
        Vector3 looking = boat.transform.position - Destination;
        targetRotation = Quaternion.LookRotation(looking, Vector3.up);
        boat.transform.rotation = Quaternion.Slerp(boat.transform.rotation, targetRotation, 0);

        navComponent.SetDestination(Destination);

       //boat.transform.eulerAngles = new Vector3(0, -90, 0);

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
        xValMin = -74f;
        xValMax = 36f;
        heading = Random.Range(xValMin, xValMax);

        zValMin = -84f;
        zValMax = 22;
        heading1 = Random.Range(zValMin, zValMax);

        float yVal = boat.transform.position.y;
        Destination = new Vector3(heading, yVal, heading1);
    }
}

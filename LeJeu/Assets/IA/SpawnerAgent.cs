using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class SpawnerAgent : Agent
{
    public GameObject tictac;
    public Degat degat;
    public bool spawned;
    private Vector3 postictac;
    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

    public override void OnEpisodeBegin()
    {
        degat.hit = false;
        spawned = false;
        Destroy(GameObject.Find("Capsule(Clone)"));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(degat.hit);
        sensor.AddObservation(postictac);
    }


    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = 25 * actionBuffers.ContinuousActions[0];
        controlSignal.z = 25 * actionBuffers.ContinuousActions[1];
        controlSignal.y = 1.0f;
        if (spawned == false)
        {
            Instantiate(tictac, controlSignal, Quaternion.identity);
            postictac = controlSignal;
            spawned = true;
        }


        // Rewards

        // Reached target
        if (degat.hit == true)
        {
            AddReward(1.0f);
            EndEpisode();
        }

        // Fell off platform
        else if (GameObject.Find("Capsule(Clone)").transform.position.y < 0)
        {
            EndEpisode();
        }
    }


}

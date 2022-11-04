using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public FloatVariable currentPhaseTime, currentPhaseLength, currentSpawnTime, spawnDelay, spawnPhaseLength, waitPhaseLength;
    public IntVariable roundNumber;
    public GameObject enemy;

    private bool spawning = true;

    private float spawnRange = 20;

    // Start is called before the first frame update
    void Start()
    {
        currentPhaseLength.v = spawnPhaseLength.v;
        currentPhaseTime.v = Time.time + spawnPhaseLength.v;
    }


    // Update is called once per frame
    void Update()
    {

        if (spawning && Time.time > currentSpawnTime.v)
        {
            currentSpawnTime.v = Time.time + spawnDelay.v;

            var vector2 = Random.insideUnitCircle.normalized * spawnRange;
            Instantiate(enemy, vector2, Quaternion.identity);
        }


        if (Time.time > currentPhaseTime.v)
        {
            if (spawning)
            {   //If done spawning, set the wait time
                currentPhaseLength.v = waitPhaseLength.v;
                currentPhaseTime.v = Time.time + waitPhaseLength.v;
            }
            else
            {   //If done waiting, set the spawn time and start a new round!
                currentPhaseLength.v = spawnPhaseLength.v;
                currentPhaseTime.v = Time.time + spawnPhaseLength.v;

                roundNumber.RuntimeValue++;
                spawnDelay.v *= 0.9f;
            }
            //Change spawning state
            spawning = !spawning;
        }
    }
}

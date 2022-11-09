using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameMaster : MonoBehaviour
{
    [System.Serializable]
    public class RoundVariables
    {
        [Header("Phase lengths")]
        public FloatVariable currentPhaseLength;
        public FloatVariable spawnPhaseLength;
        public FloatVariable waitPhaseLength;
        [Header("Runtime pointers")]
        public FloatVariable currentPhaseTime;
        public IntVariable roundNumber;
    }
    [System.Serializable]
    public class EnemyVariables
    {
        public GameObject enemy;
        public Upgrader baseAttackDamage;
        public Upgrader baseHealthMax;
        public Upgrader baseCoinDrop;
    }
    [System.Serializable]
    public class SpawningVariables
    {
        public FloatVariable spawnDelay;
        public FloatVariable currentSpawnTime;
        public float spawnRange;
        [System.NonSerialized]
        public bool spawning;
    }


    public RoundVariables round;
    public EnemyVariables enemy;
    public SpawningVariables spawning;


    // Start is called before the first frame update
    void Start()
    {
        round.currentPhaseLength.v = round.spawnPhaseLength.v;
        round.currentPhaseTime.v = Time.time + round.spawnPhaseLength.v;
        spawning.spawning = true;
    }


    // Update is called once per frame
    void Update()
    {

        if (spawning.spawning && Time.time > spawning.currentSpawnTime.v)
        {
            spawning.currentSpawnTime.v = Time.time + spawning.spawnDelay.v;

            var vector2 = Random.insideUnitCircle.normalized * spawning.spawnRange;
            Instantiate(enemy.enemy, vector2, Quaternion.identity);
        }


        if (Time.time > round.currentPhaseTime.v)
        {
            if (spawning.spawning)
            {   //If done spawning, set the wait time
                round.currentPhaseLength.v = round.waitPhaseLength.v;
                round.currentPhaseTime.v = Time.time + round.waitPhaseLength.v;
            }
            else
            {   //If done waiting, set the spawn time and start a new round!
                round.currentPhaseLength.v = round.spawnPhaseLength.v;
                round.currentPhaseTime.v = Time.time + round.spawnPhaseLength.v;

                NewRound();
            }
            //Change spawning state
            spawning.spawning = !spawning.spawning;
        }
    }


    private void NewRound()
    {
        round.roundNumber.RuntimeValue++;
        spawning.spawnDelay.v *= 0.9f;
        float output;
        enemy.baseHealthMax.Upgrade(out output, out output);
        enemy.baseAttackDamage.Upgrade(out output, out output);
        enemy.baseCoinDrop.Upgrade(out output, out output);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSwipe : Attack
{
    [SerializeField] private float speed;
    private float endAngle;
    private int layer;

    public void Initialize(float angleStart, float turnAmount, bool clockWise)
    {
        transform.eulerAngles = new Vector3(0, 0, angleStart);
        endAngle = angleStart + turnAmount;
        layer = LayerMask.NameToLayer("Enemy");
    }


    protected override void UpdateAttackStatus()
    {
        transform.Rotate(0, 0, speed);
        if (transform.rotation.eulerAngles.z >= endAngle)
        {
            Finished();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision between tentacle and " + collision.gameObject.name);
        if (collision.gameObject.layer == layer)
        {
            Combatant combatant = collision.transform.GetComponent<Combatant>();
            DealDamage(combatant);
        }
    }

}

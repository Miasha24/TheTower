using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSwipe : Attack
{
    [SerializeField] private float speed;
    [SerializeField] private float turnAmount;
    private float angleStart;
    private float angleEnd;
    private int layer;
    private bool negativeEnd = false;

    public void Initialize()
    {
        angleStart = Random.value * 359;
        transform.eulerAngles = new Vector3(0, 0, angleStart);
        angleEnd = angleStart + turnAmount;
        if (angleEnd >= 360)
        {
            angleEnd = angleEnd % 360;
            negativeEnd = true;
        }
        layer = LayerMask.NameToLayer("Enemy");
    }

    protected override void UpdateAttackStatus()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
        if (transform.rotation.eulerAngles.z >= angleEnd && !negativeEnd ||
            transform.rotation.eulerAngles.z <= angleEnd && negativeEnd)
        {
            Finished();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layer)
        {
            Combatant combatant = collision.transform.GetComponent<Combatant>();
            DealDamage(combatant);
        }
    }
}

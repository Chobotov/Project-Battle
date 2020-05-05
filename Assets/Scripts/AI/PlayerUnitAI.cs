using UnityEngine;

public class PlayerUnitAI : MonoBehaviour
{
    [SerializeField]
    private float volumeScale = 0.5f;

    private RaycastHit2D hit;
    private int damage, speed;
    private float nextAttackTime;
    private float attackDelay, maxDistance;
    private UnitData unitData;
    public Transform startRay;
    

    private void Start()
    {
        unitData = GetComponent<UnitData>();
        damage = unitData.unitProperties.Damage;
        speed = unitData.unitProperties.Speed;
        attackDelay = unitData.unitProperties.AttackDelay;
        maxDistance = unitData.unitProperties.Distance;
    }

    private void FixedUpdate()
    {
        if (unitData.unitProperties.state != State.Dead)
            hit = Physics2D.Raycast(startRay.position,startRay.right);
    }

    private void Update()
    {
        if (hit && unitData.unitProperties.state != State.Dead)
        {
            EnemyUnit enemy = hit.collider.gameObject.GetComponent<EnemyUnit>();
            if (hit.distance > maxDistance)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
                unitData.unitProperties.state = State.Running;
            }
            if (enemy != null && hit.distance < maxDistance)
            {
                Attack(enemy);
            }
            else if (enemy == null && hit.distance <= maxDistance)
            {
                unitData.unitProperties.state = State.Idle;
            }
        }
    }

    private void Attack(EnemyUnit enemy)
    {
        if (nextAttackTime < Time.time)
        {
            unitData.unitProperties.state = State.Attack;
            enemy.TakeDamage(damage);
            nextAttackTime = Time.time + attackDelay;
        }
    }
    //Вызов через анимацию смерти
    private void GetAudio()
    {
        switch(unitData.unitProperties.unitClass)
        {
            case UnitClass.Low:
                AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.Punch, volumeScale);
                break;
            case UnitClass.Middle:
                AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.SwordsFigth, volumeScale);
                break;
            case UnitClass.Heavy:
                AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.SwordsFigth, volumeScale);
                break;
        }
    }
}

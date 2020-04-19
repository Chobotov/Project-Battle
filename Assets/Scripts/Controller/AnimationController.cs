using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private UnitData unitData;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        unitData = GetComponent<UnitData>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (unitData.unitProperties.state)
        {
            case State.Idle:
                anim.SetBool("isAttack", false);
                anim.SetBool("isRunning", false);
                break;
            case State.Attack:
                anim.SetBool("isAttack", true);
                anim.SetBool("isRunning", false);
                break;
            case State.Dead:
                anim.SetBool("isDead", true);
                break;
            case State.Running:
                anim.SetBool("isRunning", true);
                break;
        }
    }
}

using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private UnitData unitData;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        unitData = GetComponent<UnitData>();
    }

    void Update()
    {
        if (anim.gameObject.activeSelf)
        {
            switch (unitData.unitProperties.state)
            {
                case State.Idle:
                    anim.SetBool("isIdle", true);
                    anim.SetBool("isAttack", false);
                    anim.SetBool("isRunning", false);
                    break;
                case State.Attack:
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isAttack", true);
                    anim.SetBool("isRunning", false);
                    break;
                case State.Running:
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isAttack", false);
                    anim.SetBool("isRunning", true);
                    break;
                case State.Dead:
                    anim.SetBool("isDead", true);
                    break;
            }
        }        
    }
}

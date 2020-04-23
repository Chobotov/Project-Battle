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
                    anim.SetBool("isAttack", false);
                    anim.SetBool("isRunning", false);
                    break;
                case State.Attack:
                    anim.SetBool("isAttack", true);
                    break;
                case State.Running:
                    anim.SetBool("isRunning", true);
                    break;
                case State.Dead:
                    anim.SetBool("isDead", true);
                    break;
            }
        }        
    }
}

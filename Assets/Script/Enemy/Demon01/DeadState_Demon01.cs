using INab.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState_Demon01 : EnemyState
{
    [SerializeField] private Material burnMatrial;

    [SerializeField] private SkinnedMeshRenderer meshRenderer;

    [SerializeField] private ScaleOscillate scaleOscillate;

    [SerializeField] private ParticleSystem[] smokes;

    // 사망 상태 시작(진입) 처리(상태 초기화)
    public override void EnterState(int state)
    {
        // 이동 중지
        navMeshAgent.isStopped = true;

        // 사망 애니메이션 재생
        animator.SetBool("Dead", true);

        // 몬스터가 소멸됨
        Invoke("objectDestroyEvent", 3);
    }

    // 사망 상태 기능 동작 처리 (상태 실행)
    public override void UpdateState()
    {
    }

    // 사망 상태 종료(다른상태로 전이) 동작 처리(상태 정리)
    public override void ExitState()
    {

    }

    public void objectDestroyEvent()
    {
        foreach (ParticleSystem smoke in smokes)
        {
            smoke.Stop();
        }

        meshRenderer.material = burnMatrial;
        scaleOscillate.enabled = true;
        Destroy(gameObject, 10);
    }
}

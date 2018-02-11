using UnityEngine;
using System.Collections;
using System;

public class SkillBase : CCBehaviour,IHandFeedback
{
    public SkillState skillState;
    /// <summary>
    /// 玩家开启大招
    /// </summary>
    public bool playerAllowOpen;
    /// <summary>
    /// 可以开启大招：时间减速
    /// </summary>
    public bool canOpenSkill_Timer;
    /// <summary>
    /// 大招过程中
    /// </summary>
    public bool keepingSkill;
    /// <summary>
    /// 大招持续时间
    /// </summary>
    public float initSkillTime = 10f;
    /// <summary>
    /// 当前大招时间
    /// </summary>
    public float skillCurrentTime = 0;

    public static GameObject skillBody;

    void Start()
    {
        skillBody = gameObject;
        base.CcAddUpdate();
    }

    protected override void COnFixedUpdate()
    {
        
    }

    protected override void COnUpdate()
    {
        OpenSkill();
    }

    public virtual void OpenSkill()
    {

    }

    public virtual void OverSkil()
    {

    }

    public virtual void ConstraintOver()
    {

    }
#region
    public void TakeMy(HandType handType)
    {
      
    }

    public void CcDownSideKey()
    {
      
    }

    public void CcDownDiskKey()
    {
        playerAllowOpen = true;
    }

    public void CcDownTriggerKey()
    {

    }

    public void CcUpSideKey()
    {
        
    }

    public void CcUpDiskKey()
    {
        playerAllowOpen = false;
    }

    public void CcUpTriggerKey()
    {
      
    }

    public float CcRange(GameObject go)
    {
        return 0;
    }

    public bool CcOrPickUp()
    {
        throw new NotImplementedException();
    }

    public void CcClearHand()
    {
       
    }

    public int CcTakeGunAni()
    {
        throw new NotImplementedException();
    }

    public GameObject CcTakeGunPar(HandType la)
    {
        throw new NotImplementedException();
    }

    public void CcPos(GameObject go, HandType handType)
    {
        throw new NotImplementedException();
    }
#endregion
}

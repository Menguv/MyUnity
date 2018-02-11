using UnityEngine;
using System.Collections;

public class TriggerSkill_Timer : SkillBase
{
    /// <summary>
    /// 当前技能时间
    /// </summary>
    bool tmpBool = true;
    public override void OpenSkill()
    {
        base.OpenSkill();
        if (!canOpenSkill_Timer)
            return;
        if (playerAllowOpen)
        {
            Time.timeScale = 0.1f;
            skillCurrentTime = Time.realtimeSinceStartup;
            keepingSkill = true;
        }
        else if (keepingSkill == true)
        {
            if (Time.realtimeSinceStartup - skillCurrentTime >= initSkillTime)
            {
                skillState = SkillState.closeSkill;
                Time.timeScale = 1f;
                skillCurrentTime = 0;
                GameData.Ins.GetMapUi(1).GetComponent<SkillEnergyBase>().currentEnergy = 0;
                canOpenSkill_Timer = false;
                playerAllowOpen = false;
                keepingSkill = false;
            }
        }            
    }

    public override void ConstraintOver()
    {
        base.ConstraintOver();
        skillState = SkillState.closeSkill;
        Time.timeScale = 1f;
        skillCurrentTime = 0;
        GameData.Ins.GetMapUi(1).GetComponent<SkillEnergyBase>().currentEnergy = 0;
        canOpenSkill_Timer = false;
        playerAllowOpen = false;
        keepingSkill = false;
    }
}

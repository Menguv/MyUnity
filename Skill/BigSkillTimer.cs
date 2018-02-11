using UnityEngine;
using System.Collections;

public class BigSkillTimer : SkillEnergyBase
{
    /// <summary>
    /// 临时连击时间
    /// </summary>
    float tmpAttackTime = 0;
    public override void SkillTimer()
    {
        if (beginTimer)//杀死一个敌人之后开始计时
        {
            tmpAttackTime += Time.deltaTime;//开始计时，时间自增长
            if (tmpAttackTime > midTime)
            {
                GameData.Ins.Head_.GetComponentInChildren<GameMsg_Combo>().tmpBool = false;
            }
        }
        if (canCombo)//杀死第二个敌人时打开连击开关
        {
            if (tmpAttackTime <= perfectTime)//时间如果在完美连击时间内，则视为完美连击
            {
                GameData.Ins.Head_.GetComponentInChildren<GameMsg_Combo>().tmpBool = true;
                canAddEnergy = true;
                currentEnergy += 20;
                perfectNum++;
                tmpAttackTime = 0;
                canCombo = false;
                addSorce += 2;
                HitCombo++;
            }
            else if (tmpAttackTime > perfectTime && tmpAttackTime <= midTime)//时间如果在中等连击时间内，则视为中等连击
            {
                GameData.Ins.Head_.GetComponentInChildren<GameMsg_Combo>().tmpBool = true;
                canAddEnergy = true;
                currentEnergy += 10;
                midNum++;
                tmpAttackTime = 0;
                canCombo = false;
                addSorce++;
                HitCombo++;
            }
            else if (tmpAttackTime > midTime)//时间超过了中等连击时间，连击失败
            {
                tmpAttackTime = 0;
                perfectNum = 0;
                midNum = 0;
                HitCombo = 0;
                GameData.Ins.Head_.GetComponentInChildren<GameMsg_Combo>().tmpBool = false;
                canCombo = false;
                beginTimer = false;//只需判断不满足中等连击数即视为连击结束                      
            }
            //beginTimer = false;

        }
        base.SkillTimer();
    }
    public override void GetEnergy()
    {
        //base.GetEnergy();
        if (currentEnergy >= 100)//能量蓄满
        {
            GameData.Ins.Head_.GetComponentInChildren<SkillBase>().canOpenSkill_Timer = true;
            if (GameData.Ins.Head_.GetComponentInChildren<GameMsg_Image>().gameObject != null)
                GameData.Ins.Head.GetComponentInChildren<GameMsg_Image>().gameObject.SendMessage("ShowImg", null);
        }

        else if (currentEnergy < 100)//释放发招或正在释放
        {
            GameData.Ins.Head_.GetComponentInChildren<SkillBase>().canOpenSkill_Timer = false;
            if (GameData.Ins.Head.GetComponentInChildren<GameMsg_Image>().gameObject != null)
                GameData.Ins.Head.GetComponentInChildren<GameMsg_Image>().gameObject.SendMessage("DelImg", null);

            //currentEnergy = (float)HitCombo / 100;
            //energySlider.value = currentEnergy;
            //if (energySlider.value >= 1)
            //    canOpenSkill = true;
            //else if (energySlider.value <= 0)
            //    canOpenSkill = false;
        }
    }
}

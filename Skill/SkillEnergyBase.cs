using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEnergyBase : CCBehaviour
{
    /// <summary>
    /// 低分连击下限
    /// </summary>
    public float midTime = 5;
    /// <summary>
    /// 完美连击下限
    /// </summary>
    public float perfectTime = 2;
    /// <summary>
    /// 开始计时
    /// </summary>
    public bool beginTimer;
    /// <summary>
    /// 是否可以计时
    /// </summary>
    public bool addTime = true;
    /// <summary>
    /// 可以连击
    /// </summary>
    public bool canCombo;
    /// <summary>
    /// 是否为完美连击
    /// </summary>
    public bool isPerfectCombo;
    /// <summary>
    /// 是否为中等连击
    /// </summary>
    public bool isMidCombo;
    /// <summary>
    /// 可以积攒能量
    /// </summary>
    public bool canAddEnergy;
    /// <summary>
    /// 当前能量
    /// </summary>
    public float currentEnergy;  
    /// <summary>
    /// 当前连击数
    /// </summary>
    public int HitCombo = 0;
    /// <summary>
    /// 加分
    /// </summary>
    public float addSorce;
    /// <summary>
    /// 完美连击数
    /// </summary>
    public float perfectNum = 0;
    /// <summary>
    /// 中等连击数
    /// </summary>
    public float midNum = 0;
    public static int tmpNum = 0;
    void Start()
    {
        base.CcAddUpdate();
    }

    protected override void COnFixedUpdate()
    {

    }

    protected override void COnUpdate()
    {
        SkillTimer();
    }

    public virtual void GetEnergy()
    {
        //Debug.Log("当前剩余能量："+currentEnergy);
    }  

    public virtual void SkillTimer()
    {
        GetEnergy();
    }
}

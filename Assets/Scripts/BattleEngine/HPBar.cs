using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject hpBar;

    public void SetHP(float hpNormalised)
    {
        hpBar.transform.localScale = new Vector3(hpNormalised, 1.0f);
    }

    public IEnumerator SetHPSmooth(float newHP)
    {
        float currentHP = hpBar.transform.localScale.x;
        float changeHP = currentHP - newHP;

        while (currentHP - newHP > Mathf.Epsilon)
        {
            currentHP -= changeHP * Time.deltaTime;
            if(currentHP > 0)
            {
                hpBar.transform.localScale = new Vector3(currentHP, 1f);
            }
            else
            {
                hpBar.transform.localScale = new Vector3(0f, 1f);
            }
            yield return null;
        }

        if(currentHP == 0)
            hpBar.transform.localScale = new Vector3(newHP, 1.0f);
    }
}

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPBar : MonoBehaviour
{
    [SerializeField] GameObject spBar;

    public void SetSP(float spNormalised)
    {
        spBar.transform.localScale = new Vector3(spNormalised, 1.0f);
    }

    public IEnumerator SetSPSmooth(float newSP)
    {
        float currentSP = spBar.transform.localScale.x;
        float changeSP = currentSP - newSP;

        while (currentSP - newSP > Mathf.Epsilon)
        {
            currentSP -= changeSP * Time.deltaTime;
            if(currentSP > 0)
            {
                spBar.transform.localScale = new Vector3(currentSP, 1f);
            }
            else
            {
                spBar.transform.localScale = new Vector3(0f, 1f);
            }
            yield return null;
        }

        if(currentSP == 0)
            spBar.transform.localScale = new Vector3(newSP, 1.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI spirimonName;
    [SerializeField] TMPro.TextMeshProUGUI spirimonLevel;
    [SerializeField] HPBar hpBar;
    [SerializeField] SPBar spBar;

    Spirimon _spirimon;

    public void SetData(Spirimon spirimon)
    {
        _spirimon = spirimon;
        spirimonName.text = spirimon.Base.Name;
        spirimonLevel.text = "Lv " + spirimon.Level;
        hpBar.SetHP((float)spirimon.HP / spirimon.MaxHP);
        spBar.SetSP((float)spirimon.SP / spirimon.MaxSP);
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)_spirimon.HP / _spirimon.MaxHP);
    }

    public IEnumerator UpdateSP()
    {
        yield return spBar.SetSPSmooth((float)_spirimon.SP / _spirimon.MaxSP);
    }

}

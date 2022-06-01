using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI spirimonName;
    [SerializeField] TMPro.TextMeshProUGUI spirimonLevel;
    [SerializeField] HPBar hpBar;

    Spirimon _spirimon;

    public void SetData(Spirimon spirimon)
    {
        _spirimon = spirimon;
        spirimonName.text = spirimon.Base.Name;
        spirimonLevel.text = "Lv " + spirimon.Level;
        hpBar.SetHP((float)spirimon.HP / spirimon.MaxHP);
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)_spirimon.HP / _spirimon.MaxHP);
    }

}

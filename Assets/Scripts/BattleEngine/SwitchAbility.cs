using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAbility : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] UnityEngine.UI.Button ability1Btn;
    [SerializeField] UnityEngine.UI.Button ability2Btn;
    [SerializeField] Sprite activeImg;
    [SerializeField] Sprite inactiveImg;
    [SerializeField] TMPro.TextMeshProUGUI ab1Text;
    [SerializeField] TMPro.TextMeshProUGUI ab2Text;
    [SerializeField] TMPro.TextMeshProUGUI ab1StatusText;
    [SerializeField] TMPro.TextMeshProUGUI ab2StatusText;

    public void SwitchAbilityBtn()
    {
        if(playerUnit.Spirimon.ActiveAbility == 0)
        {
            playerUnit.Spirimon.ActiveAbility = 1;
            ability1Btn.image.sprite = inactiveImg;
            ability2Btn.image.sprite = activeImg;
            ab1StatusText.text = "Inactive";
            ab2StatusText.text = "Active";
        } 
        else if(playerUnit.Spirimon.ActiveAbility == 1)
        {
            playerUnit.Spirimon.ActiveAbility = 0;
            ability1Btn.image.sprite = activeImg;
            ability2Btn.image.sprite = inactiveImg;
            ab1StatusText.text = "Active";
            ab2StatusText.text = "Inactive";
        }
    }

    private void Start()
    {
        ab1Text.text = playerUnit.Spirimon.Base.UseableAbilities[playerUnit.Spirimon.ActiveAbility].Name;
        ab2Text.text = playerUnit.Spirimon.Base.UseableAbilities[playerUnit.Spirimon.ActiveAbility + 1].Name;
    }
}

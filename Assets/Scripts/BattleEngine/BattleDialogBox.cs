using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI dialogText;
    [SerializeField] int lettersPerSecond;

    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;

    [SerializeField] List<TMPro.TextMeshProUGUI> moveTexts;
    [SerializeField] List<TMPro.TextMeshProUGUI> spTexts;


    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }

    public void EnableDialogText(bool isEnabled)
    {
        dialogText.enabled = isEnabled;
    }

    public void EnableActionSelector(bool isEnabled)
    {
        actionSelector.SetActive(isEnabled);
    }

    public void EnableMoveSelector(bool isEnabled)
    {
        actionSelector.SetActive(isEnabled);
    }
}

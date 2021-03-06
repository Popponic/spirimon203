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

        yield return new WaitForSeconds(1f);
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
        moveSelector.SetActive(isEnabled);
    }

    public void SetMoveNames(List<Move> moves)
    {
        for(int i = 0; i < moveTexts.Count; ++i)
        {
            if(i < moves.Count)
            {
                moveTexts[i].text = moves[i].Base.Name;
                spTexts[i].text = $"{moves[i].Base.SpCost}\nSP";
            } else // FIGURE OUT A WAY TO DISABLE THE MOVE BOX IF EMPTY, and assign a different colour move box for the move type
            {
                moveTexts[i].text = "-- EMPTY --";
                spTexts[i].text = $"0\nSP";
            }
        }
    }
}

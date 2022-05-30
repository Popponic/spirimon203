using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] SpirimonBase sBase;
    [SerializeField] int level;
    [SerializeField] bool isPlayerMon;

    public Spirimon Spirimon { get; set; }

    public void Setup()
    {
        Spirimon = new Spirimon(sBase, level);
        if(isPlayerMon)
        {
            GetComponent<Image>().sprite = Spirimon.Base.BackSprite;
        }
        else
        {
            GetComponent<Image>().sprite = Spirimon.Base.FrontSprite;
        }
    }
}

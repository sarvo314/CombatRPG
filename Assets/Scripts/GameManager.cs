using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject castSpell;

    private void OnEnable()
    {
        PlayerControls.OnCastSpell += CastSpell;
    }
    void CastSpell()
    {
        Instantiate(castSpell, PlayerPosition.Instance.Position, Quaternion.identity);
        Debug.Log("Spell cast");
    }
    private void OnDisable()
    {
        PlayerControls.OnCastSpell -= CastSpell;
    }
}

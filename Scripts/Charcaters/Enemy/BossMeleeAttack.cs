using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAttack : MonoBehaviour
{
    public Collider2D attack1Collider;
    public Collider2D attack2Collider;
    public Collider2D attack3Collider;
    private void onAttack1Start()
    {
        attack1Collider.enabled = true;
    }
    private void onAttack1End()
    {
        attack1Collider.enabled = false;
    }
    private void onAttack2Start()
    {
        attack2Collider.enabled = true;
    }
    private void onAttack2End()
    {
        attack2Collider.enabled = false;
    }
    private void onAttack3Start()
    {
        attack3Collider.enabled = true;
    }
    private void onAttack3End()
    {
        attack3Collider.enabled = false;
    }
}

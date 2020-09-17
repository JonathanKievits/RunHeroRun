using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAnimations : MonoBehaviour
{
    [SerializeField]private Animator _enemyAnimator;

    public void EnemyAnimaton(string s, bool b)
    {
        _enemyAnimator.SetBool(s, b);
    }
}

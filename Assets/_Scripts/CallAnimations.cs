using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAnimations : MonoBehaviour
{
    [SerializeField]private Animator _enemyAnimator;
    //[SerializeField]private Animator _playerAnimator; If I want to add player animations I could uncomment these

    public void EnemyAnimaton(string s, bool b)
    {
        _enemyAnimator.SetBool(s, b);
    }
    /*public void PlayerAnimaton(string s, bool b)
    {
        _playerAnimator.SetBool(s, b);
    }*/
}

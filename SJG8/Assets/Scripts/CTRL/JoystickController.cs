using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
public enum MoveState
{
    Left,
    Left1,
    Mid,
    Right1,
    Right
}
public class JoystickController : MonoBehaviour
{
    private Transform m_playerTrans;
    private Vector3 m_position;
    private static Vector3 m_offset = Vector3.right * 6f;

    private MoveState m_state;

    private bool m_isMove = true;
    private bool m_isRecovery = false;

    [SerializeField]
    private ETCJoystick m_joystick;//虚拟摇杆

    private void Start()
    {
        m_playerTrans = GameObject.Find("Player").transform;
        m_position = m_playerTrans.position;
        m_state = MoveState.Mid; 
        m_joystick.OnPressLeft.AddListener(MoveLeft);
        m_joystick.OnPressRight.AddListener(MoveRight);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }
    public void MoveLeft()
    {
        if (m_state == MoveState.Left) { return; }
        if (m_isMove)
        {
            m_state -= 1; 
            m_position -= m_offset;
            m_playerTrans.position = m_position;
            m_isMove = false;
        }
        if (!m_isRecovery && !m_isMove)
        {
            StartCoroutine(AutoRecovery());
            m_isRecovery = true;
        }
    }
    public void MoveRight()
    {
        if (m_state == MoveState.Right) { return; }
        if (m_isMove)
        {
            m_state += 1; 
            m_position += m_offset;
            m_playerTrans.position = m_position;
            m_isMove = false;
        }
        if (!m_isRecovery && !m_isMove)
        {
            StartCoroutine(AutoRecovery());
            m_isRecovery = true;
        }
    }

    IEnumerator AutoRecovery()
    {
        yield return new WaitForSeconds(0.2f);
        m_isMove = true;
        m_isRecovery = false;
    }

}

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
    public Player playerObject;
    [SerializeField]
    private ETCJoystick m_joystick;//虚拟摇杆
    private KeyCode mykey;
    private void Start()
    {
        m_playerTrans = GameObject.Find("Player").transform;
        m_position = m_playerTrans.position;
        m_state = MoveState.Mid; 
        m_joystick.OnPressLeft.AddListener(MoveLeft);
        m_joystick.OnPressRight.AddListener(MoveRight);
    }

    
    public void MoveFormNum(int num)
    {
        var step = num - m_state;
        if (num < 0 || (int)num > 4)
        { return; }
        m_state = (MoveState)num;
        print(m_state + "M_state");
        print(step + "Step");
        m_position += m_offset * ((int)step % 5);
        m_playerTrans.position = m_position;
        playerObject.Shoot();
    }
    public void MoveToTarget(MoveState state)
    {
        //abs?
        var step =state-m_state;
        if (state < 0 || (int)state > 4)
        { return; }
        m_state = state;
        print(m_state+"M_state");
        print(step + "Step");
        m_position += m_offset * (step % 5);
        m_playerTrans.position = m_position;
        playerObject.Shoot();
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
        InputNumToMove();



    }
    public void InputNumToMove()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            MoveFormNum(0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            MoveFormNum(1);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            MoveFormNum(2);
        }
    
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            MoveFormNum(3);
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            MoveFormNum(4);
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

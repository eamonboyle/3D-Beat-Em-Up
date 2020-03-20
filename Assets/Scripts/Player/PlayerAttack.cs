using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation playerAnim;

    private bool activateTimerToReset;

    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;

    private ComboState currentComboState;

    private void Awake()
    {
        playerAnim = GetComponentInChildren<CharacterAnimation>();
    }

    private void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.NONE;
    }

    private void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    private void ComboAttacks()
    {
        // punch
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentComboState == ComboState.PUNCH_3 || currentComboState == ComboState.KICK_1 || currentComboState == ComboState.KICK_2)
            {
                return;
            }

            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.PUNCH_1)
            {
                playerAnim.Punch_1();
            }
            if (currentComboState == ComboState.PUNCH_2)
            {
                playerAnim.Punch_2();
            }
            if (currentComboState == ComboState.PUNCH_3)
            {
                playerAnim.Punch_3();
            }
        }

        // kick
        if (Input.GetKeyDown(KeyCode.X))
        {
            // if the current combo is punch 3 or kick 2
            // exit the kick
            if (currentComboState == ComboState.KICK_2 || currentComboState == ComboState.PUNCH_3)
            {
                return;
            }

            // if the current combo state is NONE, punch1 or punch2
            // then we set the current combo state to kick1 to chain the combo
            if (currentComboState == ComboState.NONE || currentComboState == ComboState.PUNCH_1 || currentComboState == ComboState.PUNCH_2)
            {
                currentComboState = ComboState.KICK_1;
            }
            else if (currentComboState == ComboState.KICK_1)
            {
                currentComboState++;
            }

            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.KICK_1)
            {
                playerAnim.Kick_1();
            }

            if (currentComboState == ComboState.KICK_2)
            {
                playerAnim.Kick_2();
            }
        }
    }

    private void ResetComboState()
    {
        if (activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime;

            if (currentComboTimer <= 0.0f)
            {
                // run out of time to perform the combo
                currentComboState = ComboState.NONE;
                activateTimerToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }
}
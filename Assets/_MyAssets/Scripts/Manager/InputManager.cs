using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header ("Scriptable")]
    [SerializeField] private InputData inputData;
    [SerializeField] private PlayerData playerData;

    [Header ("Components")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject touchControls;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        SetToDefaultSetting();
    }

    private void Start()
    {
        StartSettings();
    }

    private void SetToDefaultSetting()
    {
        // player action
        inputData.isCrouching = false;
        inputData.isSprinting = false;

        // player inputs
        inputData.mouseX = 0;
        inputData.mouseY = 0;

        // player inputs
        inputData.rawKeyboardX = 0;
        inputData.rawKeyboardY = 0;
        inputData.lerpKeyboardX = 0;
        inputData.lerpKeyboardY = 0;
    }

    private void Update()
    {
        if (playerData.playerCaught)
        {
            SetToDefaultSetting();
            return;
        }

        ReadMouseInputs();
        ReadKeyboardInputs();
        SetMovingParameter();
    }

    private void ReadMouseInputs()
    {
        switch (inputData.inputType)
        {
            case InputType.KEYBOARD:
                inputData.mouseX = Input.GetAxisRaw("Mouse X");
                inputData.mouseY = Input.GetAxisRaw("Mouse Y");
                break;
        }
    }

    private void ReadKeyboardInputs()
    {
        switch (inputData.inputType)
        {
            case InputType.KEYBOARD:
                inputData.rawKeyboardX = Input.GetAxisRaw("Horizontal");
                inputData.rawKeyboardY = Input.GetAxisRaw("Vertical");
                break;
            case InputType.TOUCH:
                inputData.rawKeyboardX = joystick.Horizontal;
                inputData.rawKeyboardY = joystick.Vertical;
                break;
        }

        inputData.lerpKeyboardX = Mathf.MoveTowards(inputData.lerpKeyboardX, inputData.rawKeyboardX, inputData.lerpValue * Time.deltaTime);
        inputData.lerpKeyboardY = Mathf.MoveTowards(inputData.lerpKeyboardY, inputData.rawKeyboardY, inputData.lerpValue * Time.deltaTime);

        switch (inputData.inputType)
        {
            case InputType.KEYBOARD:
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (inputData.isSprinting)
                    {
                        inputData.isSprinting = false;
                    }
                    else
                    {
                        inputData.isCrouching = false;
                        inputData.isSprinting = true;
                    }
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    if (inputData.isCrouching)
                    {
                        inputData.isCrouching = false;
                    }
                    else
                    {
                        inputData.isSprinting = false;
                        inputData.isCrouching = true;
                    }
                }
            break;
        }
    }

    private void SetMovingParameter()
    {
        if (inputData.rawKeyboardY == 0 && inputData.rawKeyboardX == 0) inputData.isMoving = false;
        else inputData.isMoving = true;
    }


    //#region TOUCH  BUTTONS
    public void B_SprintControls()
    {
        if (inputData.inputType == InputType.KEYBOARD) return;

        if (inputData.isSprinting)
        {
            inputData.isSprinting = false;
        }
        else
        {
            inputData.isCrouching = false;
            inputData.isSprinting = true;
        }
    }

    public void B_CrouchControls()
    {
        if (inputData.inputType == InputType.KEYBOARD) return;

        if (inputData.isCrouching)
        {
            inputData.isCrouching = false;
        }
        else
        {
            inputData.isSprinting = false;
            inputData.isCrouching = true;
        }
    }

    private void StartSettings()
    {
        switch (inputData.inputType)
        {
            case InputType.KEYBOARD:
                UI.ToolKit.ActionHandler.ClosePopup(UI.ToolKit.PopUpNames.CONTROL_POPUP);
                touchControls.SetActive(false);
                break;
            case InputType.TOUCH:
                UI.ToolKit.ActionHandler.OpenPopup(UI.ToolKit.PopUpNames.CONTROL_POPUP);                
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursolstageselect : MonoBehaviour
{
    // �X�e�[�W�u�b�N�̈ʒu���X�g
    public List<Vector3> destinationPositions;
    // �J�����̈ʒu���X�g
    public List<Vector3> cameraPositions;
    // ���݂̖ړI�n�̃C���f�b�N�X
    private int currentDestinationIndex;

    // �e�X�e�[�W�u�b�N��GameObject
    public GameObject stage1book;
    public GameObject stage2book;
    public GameObject stage3book;
    public GameObject stage4book;
    public GameObject stage5book;

    // �e�X�e�[�W�u�b�N�ɃA�^�b�`����Ă���StageBookAnimatorController�X�N���v�g
    private StageBookAnimatorController stage1bookScript;
    private StageBookAnimatorController stage2bookScript;
    private StageBookAnimatorController stage3bookScript;
    private StageBookAnimatorController stage4bookScript;
    private StageBookAnimatorController stage5bookScript;

    // ���C���J����
    public Camera mainCamera;

    void Start()
    {
        // �X�e�[�W�u�b�N�̈ʒu�ƃJ�����̈ʒu�����X�g�ɒǉ�
        destinationPositions = new List<Vector3>
        {
            new Vector3(-56f, 14.3f,186f),  // stage1book�̈ʒu
            new Vector3(-30.9f, -13.4f, 186f),   // stage2book�̈ʒu
            new Vector3(-1.4f, 14.3f, 186f), // stage3book�̈ʒu
            new Vector3(27.8f, -13.4f, 186f),  // stage4book�̈ʒu
            new Vector3(52.9f, 14.3f, 186f)   // stage5book�̈ʒu
        };

        cameraPositions = new List<Vector3>
        {
            new Vector3(-57.11f, 31.94f, 101.22f),  // stage1book�̃J�����ʒu
            new Vector3(-32.2f, 5.7f, 97.6f),   // stage2book�̃J�����ʒu
            new Vector3(-1.4f, 31.94f, 101.22f), // stage3book�̃J�����ʒu
            new Vector3(28f, 5.7f, 97.6f),  // stage4book�̃J�����ʒu
            new Vector3(53.4f, 31.94f, 101.22f)   // stage5book�̃J�����ʒu
        };

        // �e�X�e�[�W�u�b�N����X�N���v�g���擾
        stage1bookScript = stage1book.GetComponent<StageBookAnimatorController>();
        stage2bookScript = stage2book.GetComponent<StageBookAnimatorController>();
        stage3bookScript = stage3book.GetComponent<StageBookAnimatorController>();
        stage4bookScript = stage4book.GetComponent<StageBookAnimatorController>();
        stage5bookScript = stage5book.GetComponent<StageBookAnimatorController>();

        // �ŏ��ɂ��ׂẴX�N���v�g�𖳌���
        DisableAllScripts();
    }

    void Update()
    {
        // ���͂�����
        HandleInput();
    }

    void HandleInput()
    {
        // �E��D-pad�������ꂽ��A���̖ړI�n�Ɉړ�
        if (Gamepad.current.dpad.right.wasPressedThisFrame)
        {
            currentDestinationIndex = (currentDestinationIndex + 1) % destinationPositions.Count;
            this.gameObject.transform.position = destinationPositions[currentDestinationIndex];
        }

        // ����D-pad�������ꂽ��A�O�̖ړI�n�Ɉړ�
        if (Gamepad.current.dpad.left.wasPressedThisFrame)
        {
            currentDestinationIndex--;
            if (currentDestinationIndex < 0)
            {
                currentDestinationIndex = destinationPositions.Count - 1;
            }
            this.gameObject.transform.position = destinationPositions[currentDestinationIndex];
        }

        // A�̃{�^���������ꂽ��A�Ή�����X�N���v�g��L����
        if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            EnableCorrectScript();
        }
    }

    // ���ׂẴX�N���v�g�𖳌���
    void DisableAllScripts()
    {
        stage1bookScript.enabled = false;
        stage2bookScript.enabled = false;
        stage3bookScript.enabled = false;
        stage4bookScript.enabled = false;
        stage5bookScript.enabled = false;
    }

    // �������X�N���v�g��L����
    void EnableCorrectScript()
    {
        DisableAllScripts();

        switch (currentDestinationIndex)
        {
            case 0:
                stage1bookScript.enabled = true;
                break;
            case 1:
                stage2bookScript.enabled = true;
                break;
            case 2:
                stage3bookScript.enabled = true;
                break;
            case 3:
                stage4bookScript.enabled = true;
                break;
            case 4:
                stage5bookScript.enabled = true;
                break;
        }

        // �X�N���v�g��L����������ACursolstageselect�𖳌���
        this.enabled = false;

        // �J������V�����ʒu�Ɉړ�
        StartCoroutine(MoveCameraToPosition(cameraPositions[currentDestinationIndex], 1f));
    }

    // �J������V�����ʒu�Ɉړ�����R���[�`��
    IEnumerator MoveCameraToPosition(Vector3 newPosition, float time)
    {
        float elapsedTime = 0;
        Vector3 startingPos = mainCamera.transform.position;
        while (elapsedTime < time)
        {
            mainCamera.transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.position = newPosition;
    }
}



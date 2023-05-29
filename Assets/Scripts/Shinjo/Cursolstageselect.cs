using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursolstageselect : MonoBehaviour
{
    // ステージブックの位置リスト
    public List<Vector3> destinationPositions;
    // カメラの位置リスト
    public List<Vector3> cameraPositions;
    // 現在の目的地のインデックス
    private int currentDestinationIndex;

    // 各ステージブックのGameObject
    public GameObject stage1book;
    public GameObject stage2book;
    public GameObject stage3book;
    public GameObject stage4book;
    public GameObject stage5book;

    // 各ステージブックにアタッチされているStageBookAnimatorControllerスクリプト
    private StageBookAnimatorController stage1bookScript;
    private StageBookAnimatorController stage2bookScript;
    private StageBookAnimatorController stage3bookScript;
    private StageBookAnimatorController stage4bookScript;
    private StageBookAnimatorController stage5bookScript;

    // メインカメラ
    public Camera mainCamera;

    void Start()
    {
        // ステージブックの位置とカメラの位置をリストに追加
        destinationPositions = new List<Vector3>
        {
            new Vector3(-56f, 14.3f,186f),  // stage1bookの位置
            new Vector3(-30.9f, -13.4f, 186f),   // stage2bookの位置
            new Vector3(-1.4f, 14.3f, 186f), // stage3bookの位置
            new Vector3(27.8f, -13.4f, 186f),  // stage4bookの位置
            new Vector3(52.9f, 14.3f, 186f)   // stage5bookの位置
        };

        cameraPositions = new List<Vector3>
        {
            new Vector3(-57.11f, 31.94f, 101.22f),  // stage1bookのカメラ位置
            new Vector3(-32.2f, 5.7f, 97.6f),   // stage2bookのカメラ位置
            new Vector3(-1.4f, 31.94f, 101.22f), // stage3bookのカメラ位置
            new Vector3(28f, 5.7f, 97.6f),  // stage4bookのカメラ位置
            new Vector3(53.4f, 31.94f, 101.22f)   // stage5bookのカメラ位置
        };

        // 各ステージブックからスクリプトを取得
        stage1bookScript = stage1book.GetComponent<StageBookAnimatorController>();
        stage2bookScript = stage2book.GetComponent<StageBookAnimatorController>();
        stage3bookScript = stage3book.GetComponent<StageBookAnimatorController>();
        stage4bookScript = stage4book.GetComponent<StageBookAnimatorController>();
        stage5bookScript = stage5book.GetComponent<StageBookAnimatorController>();

        // 最初にすべてのスクリプトを無効化
        DisableAllScripts();
    }

    void Update()
    {
        // 入力を処理
        HandleInput();
    }

    void HandleInput()
    {
        // 右のD-padが押されたら、次の目的地に移動
        if (Gamepad.current.dpad.right.wasPressedThisFrame)
        {
            currentDestinationIndex = (currentDestinationIndex + 1) % destinationPositions.Count;
            this.gameObject.transform.position = destinationPositions[currentDestinationIndex];
        }

        // 左のD-padが押されたら、前の目的地に移動
        if (Gamepad.current.dpad.left.wasPressedThisFrame)
        {
            currentDestinationIndex--;
            if (currentDestinationIndex < 0)
            {
                currentDestinationIndex = destinationPositions.Count - 1;
            }
            this.gameObject.transform.position = destinationPositions[currentDestinationIndex];
        }

        // Aのボタンが押されたら、対応するスクリプトを有効化
        if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            EnableCorrectScript();
        }
    }

    // すべてのスクリプトを無効化
    void DisableAllScripts()
    {
        stage1bookScript.enabled = false;
        stage2bookScript.enabled = false;
        stage3bookScript.enabled = false;
        stage4bookScript.enabled = false;
        stage5bookScript.enabled = false;
    }

    // 正しいスクリプトを有効化
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

        // スクリプトを有効化した後、Cursolstageselectを無効化
        this.enabled = false;

        // カメラを新しい位置に移動
        StartCoroutine(MoveCameraToPosition(cameraPositions[currentDestinationIndex], 1f));
    }

    // カメラを新しい位置に移動するコルーチン
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



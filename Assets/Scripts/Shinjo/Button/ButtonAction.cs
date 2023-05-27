//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class ButtonAction : MonoBehaviour
//{
//    public GameObject leftObject;
//    public GameObject rightObject;
//    public GameObject leftObjectBack;
//    public GameObject rightObjectBack;
//    public GameObject objectToInitialize;

//    public void OptionButtonClicked()
//    {
//        ToggleComponent(leftObject, typeof(MoveObject), true, true);
//        ToggleComponent(rightObject, typeof(MoveObject), true, true);
//    }

//    public void GameBackButtonClicked()
//    {
//        ToggleComponent(leftObjectBack, typeof(MoveObject), true, false);
//        ToggleComponent(rightObjectBack, typeof(MoveObject), true, false);
//        ToggleComponent(objectToInitialize, typeof(InitializeFirstSelected), true);
//    }

//    private void ToggleComponent(GameObject target, System.Type componentType, bool isEnabled, bool moveLeft = false)
//    {
//        Component targetComponent = target.GetComponent(componentType);

//        if (targetComponent != null)
//        {
//            if (componentType == typeof(MoveObject))
//            {
//                MoveObject moveObject = targetComponent as MoveObject;
//                if (moveObject != null)
//                {
//                    moveObject.enabled = isEnabled;
//                    moveObject.SetMoveLeft(moveLeft);
//                }
//            }
//            else if (componentType == typeof(InitializeFirstSelected))
//            {
//                Behaviour behaviourComponent = targetComponent as Behaviour;
//                if (behaviourComponent != null)
//                {
//                    behaviourComponent.enabled = isEnabled;
//                }
//            }
//        }
//    }
//}


//public class MoveObject : MonoBehaviour
//{
//    [SerializeField] private GameObject objectToActivate;
//    [SerializeField] private float targetPosition;
//    [SerializeField] private float duration = 1f;

//    private Vector3 startPosition;
//    private float startTime;
//    private bool hasReachedTarget = false;
//    private bool moveLeft;

//    private void Awake()
//    {
//        if (objectToActivate != null) objectToActivate.SetActive(false);
//    }

//    private void Start()
//    {
//        startPosition = transform.position;
//        startTime = Time.time;
//    }

//    private void Update()
//    {
//        if (hasReachedTarget) return;

//        float elapsedTime = Time.time - startTime;
//        float progress = elapsedTime / duration;

//        if (progress >= 1f)
//        {
//            progress = 1f;
//            hasReachedTarget = true;
//            Activate();
//            this.enabled = false; // スクリプトを無効化
//        }

//        Vector3 targetVector = moveLeft ? new Vector3(startPosition.x - targetPosition, startPosition.y, startPosition.z) : new Vector3(startPosition.x + targetPosition, startPosition.y, startPosition.z);
//        Vector3 newPosition = Vector3.Lerp(startPosition, targetVector, progress);
//        transform.position = newPosition;
//    }

//    private void Activate()
//    {
//        if (objectToActivate != null) objectToActivate.SetActive(true);
//    }

//    public void SetMoveLeft(bool moveLeft)
//    {
//        this.moveLeft = moveLeft;
//    }
//}

//public class InitializeFirstSelected : MonoBehaviour
//{
//    [SerializeField] private GameObject firstSelectedObject;    // 最初にSelectされるボタン
//    private EventSystem eventSystem;

//    private void Awake()
//    {
//        eventSystem = EventSystem.current;
//    }

//    private void OnEnable()
//    {
//        SetFirstSelected();
//    }

//    public void SetFirstSelected()
//    {
//        if (firstSelectedObject != null)    //EventSystem FirstSelectedの初期化
//        {
//            eventSystem.SetSelectedGameObject(firstSelectedObject);
//            this.enabled = false; // スクリプトを無効化
//        }
//    }
//}

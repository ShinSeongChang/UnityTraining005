using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerMoveHandler
{
    private bool isDrag = false;
    private Canvas Ui = default;
    public RectTransform rectObject = default;


    //private GameObject sdPlayer = default;

    private delegate void MyLogFunc(object message);
    
    private System.Action<object, int, int> myAction;
    private delegate void MyAction001(object message, int number1, int number2);



    private void Awake()
    {       
        rectObject = GetComponent<RectTransform>();

        //Ui = GetComponentInParent<Canvas>();
        Ui = GFunc.GetRootobj("Ui").GetComponent<Canvas>();

        //sdPlayer = GFunc.GetRootobj("Set Costume_02 SD Yuko");
        //GameObject yukoLeftEye = sdPlayer.FindChildObj("Eye_L");
        //Debug.LogFormat("Yuko is Null {0}, Yuko's left eye is null : {1}",
        //    sdPlayer == null, yukoLeftEye == null);

        isDrag = false;

        MyLogFunc myLogFunc = Debug.Log;

        myLogFunc("이제부터 이 로그 함수는 제 껍니다.");

    }
    // Start is called before the first frame update
    void Start()
    {
        rectObject.anchoredPosition += new Vector2(100f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrag = true;
        Debug.Log("클릭하는 바로 그 순간");

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDrag= false;
        Debug.Log("떼는 바로 그 순간");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isDrag)
        {
            // 앵커드 포지션에 변화량을 더하여 움직이는 것
            // Update -> UI Canvas의 스케일 팩터로 변화량을 나누면 드래그에 오차가 없어짐

            rectObject.anchoredPosition += (eventData.delta / Ui.scaleFactor);
            Debug.LogFormat("드래그 할 준비 완료 -> {0}", eventData.delta); // 마우스 변화량 측정
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        
    }
}

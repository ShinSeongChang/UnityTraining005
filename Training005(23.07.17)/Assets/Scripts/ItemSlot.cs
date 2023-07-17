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

        myLogFunc("�������� �� �α� �Լ��� �� ���ϴ�.");

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
        Debug.Log("Ŭ���ϴ� �ٷ� �� ����");

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDrag= false;
        Debug.Log("���� �ٷ� �� ����");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isDrag)
        {
            // ��Ŀ�� �����ǿ� ��ȭ���� ���Ͽ� �����̴� ��
            // Update -> UI Canvas�� ������ ���ͷ� ��ȭ���� ������ �巡�׿� ������ ������

            rectObject.anchoredPosition += (eventData.delta / Ui.scaleFactor);
            Debug.LogFormat("�巡�� �� �غ� �Ϸ� -> {0}", eventData.delta); // ���콺 ��ȭ�� ����
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        
    }
}

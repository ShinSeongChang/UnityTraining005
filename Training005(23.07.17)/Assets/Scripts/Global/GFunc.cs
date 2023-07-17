using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static partial class GFunc
{
    //                              ������ �ɺ�
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object mesaage)
    {
#if DEBUUG_MODE
        Debug.Log(mesaage);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject �޾Ƽ� Text ������Ʈ ã�Ƽ� text �ʵ� �� �����ϴ� �Լ�
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if (textComponent == null || textComponent == default) { return; }

        textComponent.text = text;
    }

    public static Vector2 AddVector(this Vector3 origin, Vector2 addVector)
    {
        Vector2 result = new Vector2(origin.x, origin. y);
        result += addVector;
        return result;
    }

    public static bool IsValid<T>(this T target) where T : Component
    {
        if(target == null || target == default) {  return false; }
        else { return true; }
    }

    public static bool IsValid<T>(this List<T> target) where T : Component
    {
        bool isInvalid = (target == null || target == default);
        isInvalid = isInvalid || target.Count == 0;

        if (isInvalid == true) { return false; }
        else { return true; }
    }

    //! Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ������Ʈ�� ã���ִ� �Լ�
    public static T FindChildComponent<T>(this GameObject targetObj_, string objName_)
    {
        T searchResultComponent = default(T);
        GameObject searchResultObj = default(GameObject);
        searchResultObj = targetObj_.FindChildObj(objName_);
        if(searchResultObj != null || searchResultObj != default)
        {
            searchResultComponent = searchResultObj.GetComponent<T>();
        }

        return searchResultComponent;
    }

    //! Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
    public static GameObject FindChildObj(this GameObject targetobj_, string objName)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;

        for(int i = 0; i < targetobj_.transform.childCount; i++)
        {
            searchTarget = targetobj_.transform.GetChild(i).gameObject;
            if(searchTarget.name.Equals(objName))
            {
                searchResult = searchTarget;
                return searchResult;
            }   // if : ���� ã�� ���� ������Ʈ�� ã�� ���
            else
            {
                // �ڽ��� �Լ��� ȣ���ϴ� �� => ����Լ�
                searchResult = FindChildObj(searchTarget, objName);
                
                if(searchResult == null || searchResult == default)
                {
                    /* Pass */
                }
                else
                {
                    return searchResult;
                }   // else : ���� ã�� ���� ������Ʈ�� ���� ��ã�� ���
            }       // loop : Ž�� Ÿ�� ������Ʈ�� �ڽ� ������Ʈ ������ŭ ��ȸ�ϴ� ����
        }

        return searchResult;
    }


    //! Ȱ��ȭ �� ���� ���� ��Ʈ ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
    public static GameObject GetRootobj(string objName_)
    {
        Scene activeScene = SceneManager.GetActiveScene();
        GameObject[] rootObjs_ = activeScene.GetRootGameObjects();

        GameObject targetObj_ = default;

        foreach(GameObject rootObj_ in rootObjs_)
        {
            if(rootObj_.name.Equals(objName_))
            {
                targetObj_ = rootObj_;
                return targetObj_;

            }
            else
            {
                continue;
            }
            
        }

        return targetObj_;
    }

}

using UnityEngine;
using System.Collections;

public class HideGUI : MonoBehaviour
{
    #if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
    void Start ()
    {
        Destroy(this.gameObject);
	}
    #endif
}

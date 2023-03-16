using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailWindowBehavior : MonoBehaviour
{
    [SerializeField] GameObject detailWindow;
    public void onBackgroundPress()
    {
        Destroy(detailWindow);
    }
}

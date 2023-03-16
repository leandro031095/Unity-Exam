using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailsWindows : MonoBehaviour
{
    [SerializeField] GameObject detailWindowPrefab;
    public void OnButtonPress()
    {
        Instantiate(detailWindowPrefab,transform.parent.transform.parent);
    }
}

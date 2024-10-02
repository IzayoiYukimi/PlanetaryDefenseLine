using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour
{
    [SerializeField] Image mask;
    [SerializeField] Image bg;


    public float fillamount;
    public bool ishighlight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mask.fillAmount = fillamount;
        bg.color = ishighlight ? Color.yellow : Color.white;
    }
}

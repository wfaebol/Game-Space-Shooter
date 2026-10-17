using UnityEngine;
using UnityEngine.UI;

public class SliderHp : MonoBehaviour
{
    [SerializeField] Slider simpleHp;
    [SerializeField] HpPlayer hpPlayer;


    void Start()
    {
        simpleHp.maxValue = hpPlayer.GetHp();
    }

 
    void Update()
    {
        simpleHp.value = hpPlayer.GetHp();
    }
}

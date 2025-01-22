using UnityEngine;
using UnityEngine.UI;

public class HPBAR : MonoBehaviour
{
    [SerializeField] private Health playerHP;
    [SerializeField] private Image TOTALHP;
    [SerializeField] private Image CURRENTHP;

    private void Start()
    {
        TOTALHP.fillAmount = playerHP.HEALTHRN / 10;
    }
    
    private void Update()
    {
        CURRENTHP.fillAmount = playerHP.HEALTHRN / 10;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Cannon cannon;

    //power related
    [Header("Power Related")]
    [SerializeField] Slider PowerSlide;
    [SerializeField] Text PowerSliderText;
    [Header("Angle Related")]
    [SerializeField] Slider AngleSlider;
    [SerializeField] Text AngleSliderText;
    [Header("Height Related")]
    [SerializeField] Slider HeightSlider;
    [SerializeField] Text HeightSliderText;
    [Header("Toggle Related")]
    [SerializeField] Toggle RBToggle;
    [SerializeField] Toggle CalcuToggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {

        }
    }


    public void ToggleRB()
    {
        cannon.isShootingRigidBody = RBToggle.isOn;
    }
    public void ToggleCalculated()
    {
        cannon.isShootingCalculated = CalcuToggle.isOn;
    }

    public void DestroyTrails()
    {
        TrailRenderer[] Trails = FindObjectsOfType<TrailRenderer>();

        for (int i = 0; i < Trails.Length; i++)
        {
            Destroy(Trails[i].gameObject);
        }
    }

    public void OnChangeValuePowerSlider()
    {
        cannon.CannonPower = Mathf.RoundToInt(PowerSlide.value);
        PowerSliderText.text = "Cannon Power: " + cannon.CannonPower;
    }



    public void OnChangeValueAngleSlider()
    {
        cannon.CannonRotation = Mathf.RoundToInt(AngleSlider.value);
        AngleSliderText.text = "Cannon Angle: " + cannon.CannonRotation;
    }


    public void OnChangeValueHeightSlider()
    {
        cannon.cannonHeight = Mathf.RoundToInt(HeightSlider.value);
        HeightSliderText.text = "Cannon Angle: " + cannon.cannonHeight;
    }







}

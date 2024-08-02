using UnityEngine;
using UnityEngine.UI;

public class Pump : MonoBehaviour
{
    public Slider pumpSlider;  // Tham chiếu đến slider
    public float maxScale = 2.5f;  // Kích thước lớn nhất của quả bóng bay
    public float minScale = 1.0f;  // Kích thước nhỏ nhất của quả bóng bay
    private float valBef;
    private Vector3 initialScale;
    [SerializeField] private GameObject balloon;
    void Start()
    {
        valBef = 0;
        initialScale =balloon. transform.localScale;  // Lưu lại kích thước ban đầu của quả bóng bay

        //Gán hàm OnSliderValueChanged để lắng nghe sự thay đổi giá trị của slider
        pumpSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        if (value < valBef)
        {
           
            float scale = Mathf.Lerp(minScale, minScale+ 0.05f, 1-value);
           balloon.transform.localScale = initialScale * scale;
           minScale = scale;
           
          // balloon.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
           if (balloon.transform.localScale.x>= maxScale)
           {
               //Debug.Log("WIn");
               pumpSlider.gameObject.GetComponent<Slider>().enabled = false;
               GameManager.instance.WinGame();
           }
        }
        // Tính toán kích thước mới của quả bóng bay dựa trên giá trị của slider
        
       
        valBef = value;
    }
}
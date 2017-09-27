using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Colors : MonoBehaviour
{
    [SerializeField] Image m_rgb = null;
    [SerializeField] Image m_red = null;
    [SerializeField] Image m_green = null;
    [SerializeField] Image m_blue = null;

    [SerializeField] TMPro.TextMeshProUGUI m_redText = null;
    [SerializeField] TMPro.TextMeshProUGUI m_greenText = null;
    [SerializeField] TMPro.TextMeshProUGUI m_blueText = null;
    [SerializeField] TMPro.TextMeshProUGUI m_alphaText = null;

    [SerializeField] TMPro.TextMeshProUGUI m_descriptionText = null;

    public struct colorDefinition
    {
        public int r;
        public int g;
        public int b;
        public int a;
        public int colors;

        public string channels;
        
        public colorDefinition(int r, int g, int b, int a, int colors, string channels)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
            this.colors = colors;
            this.channels = channels;
        }
    }

    string[] bitDepth = { "8-Bit", "16-Bit(4)", "16-Bit(1)", "32-Bit" };
    int bitDepthIndex = 0;
    Dictionary<string, colorDefinition> m_colorDefinitions = new Dictionary<string, colorDefinition>();
    colorDefinition m_colorDefinition;

    private void Start()
    {
        m_colorDefinitions["8-Bit"] = new colorDefinition(3, 3, 2, 0, 256, "3|3|2|0");
        m_colorDefinitions["16-Bit(4)"] = new colorDefinition(4, 4, 4, 4, 4096, "4|4|4|4");
        m_colorDefinitions["16-Bit(1)"] = new colorDefinition(5, 5, 5, 1, 32768, "5|5|5|1");
        m_colorDefinitions["32-Bit"] = new colorDefinition(8, 8, 8, 8, 16777216, "8|8|8|8");

        m_colorDefinition = m_colorDefinitions[bitDepth[bitDepthIndex]];
    }

    void Update()
    {
        Color color = m_rgb.color;

        color.r = m_red.color.r;
        color.g = m_green.color.g;
        color.b = m_blue.color.b;

        m_rgb.color = color;

        m_descriptionText.text = "RGB - " + bitDepth[bitDepthIndex]  + " (" + m_colorDefinition.channels + ") - " + m_colorDefinition.colors.ToString();
    }

    public void RedSlider(Slider slider)
    {
        float steps = Mathf.Pow(2, m_colorDefinition.r) - 1;
        int integer = Mathf.RoundToInt(steps * slider.value);
        float scalar = integer / steps;

        Color color = m_red.color;
        color.r = scalar;
        m_red.color = color;

        string scalarString = scalar.ToString("F2");
        string integerString = integer.ToString();
        m_redText.text = "RED: " + scalarString + "/" + integerString;
    }

    public void GreenSlider(Slider slider)
    {
        float steps = Mathf.Pow(2, m_colorDefinition.g) - 1;
        int integer = Mathf.RoundToInt(steps * slider.value);
        float scalar = integer / steps;

        Color color = m_green.color;
        color.g = scalar;
        m_green.color = color;

        string scalarString = scalar.ToString("F2");
        string integerString = integer.ToString();
        m_greenText.text = "GREEN: " + scalarString + "/" + integerString;
    }

    public void BlueSlider(Slider slider)
    {
        float steps = Mathf.Pow(2, m_colorDefinition.b) - 1;
        int integer = Mathf.RoundToInt(steps * slider.value);
        float scalar = integer / steps;

        Color color = m_blue.color;
        color.b = scalar;
        m_blue.color = color;

        string scalarString = scalar.ToString("F2");
        string integerString = integer.ToString();
        m_blueText.text = "BLUE: " + scalarString + "/" + integerString;
    }

    public void AlphaSlider(Slider slider)
    {
        float steps = Mathf.Pow(2, m_colorDefinition.a) - 1;
        int integer = (steps == 0) ? 1 : Mathf.RoundToInt(steps * slider.value);
        float scalar = (steps == 0) ? 1.0f : integer / steps;

        Color color = m_rgb.color;
        color.a = scalar;
        m_rgb.color = color;

        string scalarString = scalar.ToString("F2");
        string integerString = integer.ToString();
        m_alphaText.text = "ALPHA: " + scalarString + "/" + integerString;
    }
}

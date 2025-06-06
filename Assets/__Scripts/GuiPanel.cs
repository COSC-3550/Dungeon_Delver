using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiPanel : MonoBehaviour
{
    [Header("Inscribed")] 
    public Sprite healthEmpty;
    public Sprite healthHalf;
    public Sprite healthFull;

    private Text keyCountText;
    private List<Image> healthImages;

    void Start()
    {
        Transform trans = transform.Find("Key Count");
        keyCountText = trans.GetComponent<Text>();
        
        Transform healthPanel = transform.Find("Health Panel");
        healthImages = new List<Image>();
        if (healthPanel != null)
        {
            for (int i = 0; i < 20; i++)
            {
                trans = healthPanel.Find("H_" + i);
                if (trans == null) break;
                healthImages.Add(trans.GetComponent<Image>());
            }
        }
    }

    void Update()
    {
        keyCountText.text = Dray.NUM_KEYS.ToString();

        int healthDisp = Dray.HEALTH;
        for (int i = 0; i < healthImages.Count; i++)
        {
            if (healthDisp > 1)
            {
                healthImages[i].sprite = healthFull;
            } else if (healthDisp == 1)
            {
                healthImages[i].sprite = healthHalf;
            }
            else
            {
                healthImages[i].sprite = healthEmpty;
            }

            healthDisp -= 2;
        }
    }
}

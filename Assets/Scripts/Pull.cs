using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class Pull : MonoBehaviour
{
    public CatsGachaManager gm;

    public Button button;

    public FrameManager fm;

    public CollectionCheck colCheck;

    private DataManager data_Manager;

    public GameObject gacha_anim;

    public GameObject alreadyHaveDetector;

    public GameObject NotReceivedDetector;

    void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();
        button.onClick.AddListener(OnClick);
        gm.testGoldCount = data_Manager.player_money;
        
    }

    void OnClick()
    {
        
        if (!(gm.testGoldCount < 100))
        {
            gacha_anim.GetComponent<Animator>().Play("Pull");
            Destroy(gm.catGacha);
            Destroy(fm.frame);
            gm.Gacha();
            fm.ShowFrame();



            if (data_Manager.cat_collection[gm.catName]) 
            {
                Debug.Log($"{gm.catName} is already in your collection!");
                NotReceivedDetector.SetActive(false);
                alreadyHaveDetector.SetActive(true);

            }
            else
            {
                alreadyHaveDetector.SetActive(false);
                NotReceivedDetector.SetActive(true);
                data_Manager.cat_collection[gm.catName] = true;
            }
                

            gm.testGoldCount -= 100;
            data_Manager.player_money -= 100;
        }
        else
        {
            Debug.Log("Out of gold.");
        }
    }
}

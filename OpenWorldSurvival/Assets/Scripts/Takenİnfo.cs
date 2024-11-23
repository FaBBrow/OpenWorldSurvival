
using System;
using System.Collections;

using UnityEngine;
using TMPro;
using Image = UnityEngine.UI.Image;

namespace DefaultNamespace
{

    public class Takenİnfo : MonoBehaviour
    {
        public static Takenİnfo instance;
        [SerializeField] private GameObject _infoimage;
        [SerializeField] private TextMeshProUGUI _infotext;
        [SerializeField] private GameObject infoUI;

        private void Start()
        {
            instance = this;
        }

        private void OnEnable()
        {
            InventorySystem.OnItemAdded += onitemTaken;
        }

        public void onitemTaken(GameObject a, string b)
        {
            infoUI.SetActive(true);
            _infoimage.GetComponent<Image>().sprite = a.GetComponent<Image>().sprite;
            _infotext.text = $"{b} added to inventory";
            StartCoroutine(infotexttime());
        }
        public void onitemConsumed(GameObject a, string b)
        {
            infoUI.SetActive(true);
            _infoimage.GetComponent<Image>().sprite = a.GetComponent<Image>().sprite;
            _infotext.text = $"{b} Consumed";
            StartCoroutine(infotexttime());
        }
        public void onitemDeleted(GameObject a, string b)
        {
            infoUI.SetActive(true);
            _infoimage.GetComponent<Image>().sprite = a.GetComponent<Image>().sprite;
            _infotext.text = $"{b} Deleted";
            StartCoroutine(infotexttime());
        }
        IEnumerator infotexttime()
        {
            yield return new WaitForSeconds(3f);
            infoUI.SetActive(false);
            _infoimage.GetComponent<Image>().sprite = null;
            _infotext.text = "";
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] private GameObject _levelUpCanvas;
    [SerializeField] private GameObject _panel;
    [SerializeField] private int _maxCards;
    [SerializeField] private Vector2 _firstElementPosition;
    [SerializeField] private int _distanceBetweenCards;
    [SerializeField] private List<GameObject> _cards;
    private List<GameObject> _spawnedObj = new List<GameObject>();
    private Level _playerLevel;

    void Start()
    {
        _playerLevel = GameObject.Find("Player").GetComponent<Level>();        
    }

    void Update()
    {
        ShowPanel();
    }

    private void ShowPanel()
    {
        if (_playerLevel.LevelUp())
        {
            _levelUpCanvas.SetActive(true);

            List<GameObject> tempList = new List<GameObject>(_cards);

            //Instantiate random object from temp list then remove from list
            int count = tempList.Count;
            int elements = _maxCards;
            Vector2 position = _firstElementPosition;

            for (int i = count; i > 0; i--)
            {
                if(elements == 0)
                {
                    break;
                }
                int randomElement = Random.Range(0, i);
                GameObject card = Instantiate(tempList[randomElement], position, _panel.transform.rotation, _panel.transform);
                position.x += _distanceBetweenCards;

                tempList.RemoveAt(randomElement);
                _spawnedObj.Add(card);

                elements--;
                count--;
            }

            Time.timeScale = 0;
        }
    }

    public void ContinueGame()
    {
        _levelUpCanvas.SetActive(false);

        //delete all instantiated objects
        for (int i = _spawnedObj.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedObj[i]);
            _spawnedObj.RemoveAt(i);
        }
        Time.timeScale = 1;
    }
}

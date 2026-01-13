/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private GameObject[] heartContainers;
    private Image[] heartFills;

    public Transform heartsParent; // Контейнер для сердец
    public GameObject heartContainerPrefab; // Префаб сердца

    private void Start()
    {
        // Инициализация массивов для сердец
        heartContainers = new GameObject[3]; // Три сердца
        heartFills = new Image[3];

        InstantiateHeartContainers(); // Создаём сердца
        UpdateHeartsHUD(3); // Устанавливаем начальное здоровье (3 жизни)
    }

    public void UpdateHeartsHUD(int currentHealth)
    {
        for (int i = heartFills.Length - 1; i >= 0; i--)
        {
            // Заполняем сердце, если его индекс меньше текущего здоровья
            heartFills[i].fillAmount = i < currentHealth ? 1 : 0;
        }
    }

    void InstantiateHeartContainers()
    {
        for (int i = 0; i < 3; i++) // Создаём три сердца
        {
            GameObject temp = Instantiate(heartContainerPrefab, heartsParent);
            heartContainers[i] = temp;

            Image heartImage = temp.GetComponent<Image>();
            if (heartImage == null)
            {
                Debug.LogError($"HeartContainerPrefab не содержит компонент Image! Проверьте префаб.");
                return;
            }

            heartFills[i] = heartImage;
        }
    }
}

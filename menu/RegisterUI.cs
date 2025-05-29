using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class MenuUI : MonoBehaviour
{
    [Header("Create User")]
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private Button createButton;

    [Header("Update Level Time")]
    [SerializeField] private TMP_InputField userIdInput;
    [SerializeField] private TMP_InputField levelInput;
    [SerializeField] private TMP_InputField timeInput;
    [SerializeField] private Button updateButton;

    private UIFUN userFun;

    private void Start()
    {
        userFun = new UIFUN();

        createButton.onClick.AddListener(OnCreateUserClicked);

    }

    private void OnCreateUserClicked()
    {
        string name = nameInput.text;
        string password = passwordInput.text;

        StartCoroutine(userFun.CreateUser(name, password));
        NextScene();
    }

    public void NextScene()
    {
        SceneManager.LoadScene("menu"); // set name of scene
    }

}

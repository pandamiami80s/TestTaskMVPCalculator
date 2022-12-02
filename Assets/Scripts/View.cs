using UnityEngine;
using TMPro;

public class View : MonoBehaviour, IView
{
    public TMP_InputField inputField;
    IPresenter presenter;
   
    public GameObject dialogError;

    void Start()
    {
        dialogError.SetActive(false);

        presenter = new Presenter(this);

        inputField.text = presenter.LoadState();
    }

    public void OnResult()
    {
        if(presenter.IsFormatError(inputField.text))
        {
            ShowErrorDialog();   
        }
    }

    public void ShowValue(string value)
    {
        inputField.text = value;

        presenter.SaveState(value);
    }

    public void OnValueChange()
    {
        presenter.SaveState(inputField.text);
    }

    public void ShowErrorDialog()
    {
        dialogError.SetActive(true);
    }

    public void OnQuit()
    {
        presenter.ClearState();
        Application.Quit();
    }

    public void OnNewEquation()
    {
        dialogError.SetActive(false);
        inputField.text = null;
    }
}
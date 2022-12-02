using UnityEngine;

public class Presenter : IPresenter
{
    Model model;
    IView View;

    public string stateName = "InputState";

    public Presenter(IView view)
    {
        model = new Model();
        View = view;
    }

    public bool IsFormatError(string value)
    {
        if (string.IsNullOrEmpty(value) || !value.Contains("/"))
        {
            View.ShowValue("Error");

            return true;
        }

        string checkNumber = value.Replace("/", string.Empty);
        if(!int.TryParse(checkNumber, out int result))
        {
            View.ShowValue("Error");

            return true;
        }

        model.Calculate(value);
        View.ShowValue(model.result);

        return false;
    }

    public void SaveState(string value)
    {
        PlayerPrefs.SetString(stateName, value);
    }

    public string LoadState()
    {
        return PlayerPrefs.GetString(stateName, "");
    }
    public void ClearState()
    {
        PlayerPrefs.DeleteAll();
    }
}
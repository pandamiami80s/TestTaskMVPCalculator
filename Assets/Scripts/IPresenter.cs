public interface IPresenter
{
    public bool IsFormatError(string value);
    public void SaveState(string value);
    public string LoadState();
    public void ClearState();
}
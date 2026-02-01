using B_Extensions;

public class ButtonPlayAudio : BaseButtonAttendant 
{

    private void Start()
    {
        buttonComponent.onClick.AddListener(Play);
    }
    public void Play() 
    {
        ManagerAudio.Instance.PlayMenu();
    }
}
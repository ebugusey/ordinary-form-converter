namespace OFP.ObjectModel.Forms
{
    public enum FormEvent
    {
        BeforeOpen = 70000,
        OnOpen = 70001,
        BeforeClose = 70002,
        OnClose = 70003,
        ChoiceProcessing = 70004,
        ObjectActivationProcessing = 70005,
        NewObjectWriteProcessing = 70006,
        NotificationProcessing = 70007,
        OnReopen = 70008,
        RefreshDisplay = 70009,
        ExternalEvent = 70010,
        FillCheckProcessing = 70011,
    }
}

namespace RaNotification.Data
{
    public interface INotifyData
    {
        NotifyType Type { get; }

        object Data { get; }

        string Serialize();

        void Deserialize(string data);
    }
}

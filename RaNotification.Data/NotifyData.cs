using Newtonsoft.Json;

namespace RaNotification.Data
{
    public class NotifyData : INotifyData
    {
        public NotifyType Type { get; set; }

        public object Data { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void Deserialize(string data)
        {
            var notifyData = JsonConvert.DeserializeObject<NotifyData>(data);
            Type = notifyData.Type;
            Data = notifyData.Data;
        }
    }
}

# RA Nofitication

## Nofitication Data Transfter

* The caller project should reference the **RaNotification.Data** project and create the transfer data instance by themselves.
* Before send the data to the RaNotification Web API, caller should call the `INotifyData.Serialize()` to construct data into _string_.
* After get the HTTP Post request, web server will call `INotifyData.Deserialize()` to reconstruct the transfer data.

Please see more details on `RaNotification.Sample` code.

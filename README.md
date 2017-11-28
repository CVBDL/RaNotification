# RA Notification

## Nonification Data Transfter

* The caller project should reference the **RaNotification.Data** project and create the transfer data instance by themselves.
* Before send the data to the RaNotification Web API, caller should call the `INotifyData.Serialize()` to construct data into _string_.
* After get the HTTP Post request, web server will call `INotifyData.Deserialize()` to reconstruct the transfer data.

Please see more details on `RaNotification.Sample` code.

## Notification Web API

* Send a Email notification

  ```text
  POST /ranotification/api/mailnotification
  ```
  #### Example
  ```text
  {
	  "From":"testSender@ralibrary",
	  "To":["receiver@ra.rockwell.com"],
	  "Cc":[],
	  "Bcc":[],
	  "Subject":"于老师，你真牛逼",
	  "Body":"This is test body",
	  "Attachments":[]
  }
  ```

  #### Sample Code in C# to Generate Attachment
  ```text
  var entity = new MailEntity();
  entity.From = "tester@*.com";
  entity.To.Add("tester2@*.com");
  entity.Subject = "This is test subject";
  entity.Body = "This is test body";
  entity.Attachments.Add(MailAttachment.FromString("1.txt", "this is attachment data"));
  ```



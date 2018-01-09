# RA Notification

<!--
## Nonification Data Transfter

* The caller project should reference the **RaNotification.Data** project and create the transfer data instance by themselves.
* Before send the data to the RaNotification Web API, caller should call the `INotifyData.Serialize()` to construct data into _string_.
* After get the HTTP Post request, web server will call `INotifyData.Deserialize()` to reconstruct the transfer data.

Please see more details on `RaNotification.Sample` code.
-->

## Notification REST API

### Email Notification

```text
POST /api/mailnotification
```

#### Input

| Name        | Type   | Description                                                       |
| ----------- | ------ | ----------------------------------------------------------------- |
| From        | string | Sender's email address.                                           |
| To          | string | Receiver's email address.                                         |
| Cc          | Array  | Carbon copy to secondary recipients.                              |
| Bcc         | Array  | blind carbon copy to tertiary recipients who receive the message. |
| Subject     | string | Email subject.                                                    |
| Body        | string | Email message body.                                               |
| IsHtml      | bool   | Send message body with html format.                                 |
| Attachments | Array  | Attachments.                                                      |

##### Attachment Format

| Name     | Type   | Description                               |
| -------- | ------ | ----------------------------------------- |
| Name     | string | Attachment file name.                     |
| Data     | string | Base64 encoded file content.              |

#### Example

```json
{
  "From":"no-reply@example.com",
  "To":["example@example.com"],
  "Cc":[],
  "Bcc":[],
  "Subject":"RaNotification Released!",
  "Body":"Hi all, we're pleased to announce that RaNotification is released.",
  "IsHtml": false,
  "Attachments":
  [
    {
      "Name":"readme.txt",
      "Data":"dGhpcyBpcyBhdHRhY2htZW50IGRhdGE="
    }
  ]
}
```

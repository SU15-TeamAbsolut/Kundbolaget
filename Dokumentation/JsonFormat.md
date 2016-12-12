# Formattering för JSON-filer

## Order från kund
Endast giltig, korrekt formatterad JSON accepteras för mottagning av orderfiler från kund. Ett [JSON Schema för formatet](https://github.com/SU15-TeamAbsolut/Kundbolaget/blob/develop/Dokumentation/json/orderSchema.json)
finns tillgängligt för validering på kundens sida innan orderfilen skickas.

### Filformat

Filen skall innehålla:
 - `CustomerId` (integer) -- kundens id
 - `DeliveryDate` (date-time) -- önskat leveransdatum, i [kombinerat UTC-format][utc-time], enligt [ISO 8601][iso8601].
 - `DeliveryAddressID` (integer) -- leveransadressens id
 - `OrderRows` (array av orderrader) -- JSON-objekt med orderrader

`OrderRows` innehåller objekt som skall innehålla:
 - `ArticleId` (integer) -- artikel-id
 - `Amount` (integer) -- antal som skall beställas

[utc-time]:https://en.wikipedia.org/wiki/ISO_8601#Combined_date_and_time_representations
[iso8601]:https://en.wikipedia.org/wiki/ISO_8601

### Exempel på orderfil

``` json
{
  "CustomerId":1,
  "DeliveryDate":"2016-12-13T22:31:21.7282317+01:00",
  "DeliveryAddressId":147,
  "OrderRows":[
    {
      "ArticleId":15626,
      "Amount":28
    },
    {
      "ArticleId":25626,
      "Amount":10
    },
    {
      "ArticleId":23577,
      "Amount":150
    }
  ]
}
```

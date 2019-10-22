- WCF service does not have default support for CORS. There is always additional code needs to be written in server side to support this.
- Basically, for CORS, the server side app needs to allow certain headers in response.
- On the server side, the logic is in [Application_BeginRequest](https://github.com/PurnaChandraPanda/CORSinWCFRest/blob/master/src/server/WcfService1/Global.asax.cs#L23) API.

```
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS") {
                HttpContext.Current.Response.End();
            }
        }
```

- The client side logic is in [testpage.html](https://github.com/PurnaChandraPanda/CORSinWCFRest/blob/master/src/client/WebApplication1/wwwroot/testpage.html#L18) page.

```
    var valuesAddress = "http://localhost:1797/Service1.svc";

    $("#post").click(function () {
        var customer = {
            "FirstName": "Purna",
            "Id": "2123",
            "LastName": "Panda",
            "SSN": "SSN12109"
        };
        $.ajax({
            url: valuesAddress + "/add",
            type: "POST",
            contentType: "application/json",
            dataType: 'json',
            data: JSON.stringify(customer),
            success: function (result) {
                $("#result").text(JSON.stringify(result));
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $("#result").text(textStatus);
            }
        });
    });
```

- Regarding running the projct:
 - WcfService1 project can be run without debug mode
 - Make sure /help page is accessible
 - Update the URL in testpage.html with new value [here](https://github.com/PurnaChandraPanda/CORSinWCFRest/blob/master/src/client/WebApplication1/wwwroot/testpage.html#L16)
 - Run the WebApplication1 page in debug mode
 - You would find POST request for the service completing without issues



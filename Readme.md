# GridView - How to programmatically Save/Load the last ClientLayout within the Session


This example is based on the <a href="https://www.devexpress.com/Support/Center/p/T146962">T146962: GridView - How to track ClientLayout with a separate ListBox</a> one. It illustrates how to programmatically Save/Load the last ClientLayout within the Session. In real scenarios, it is possible to use a real database (for example, with a client profile data) instead:<br /><br />


```cs
@Html.DevExpress().GridView(settings => {
    ...
    settings.ClientLayout = (s, e) => {
        switch (e.LayoutMode) {
            case ClientLayoutMode.Loading:
                //Load Last ClientLayout Via First Load
                if (Session["Layout"] != null) {
                    e.LayoutData = Session["Layout"].ToString();
                }
                break;
            case ClientLayoutMode.Saving:
                //Save Last ClientLayout Automatically
                Session["Layout"] = e.LayoutData;
                break;
        }
    };
}).Bind(Model).GetHtml()
```


<br />


```vb
@Html.DevExpress().GridView( _
    Sub(settings)
            ...
            settings.ClientLayout = _
                Sub(s, e)
                        Select Case e.LayoutMode
                            Case ClientLayoutMode.Loading
                                'Load Last ClientLayout Via First Load
                                If Session("Layout") IsNot Nothing Then
                                    e.LayoutData = Session("Layout").ToString()
                                End If
                            Case ClientLayoutMode.Saving
                                'Save Last ClientLayout Automatically
                                Session("Layout") = e.LayoutData
                        End Select
                End Sub
    End Sub).Bind(Model).GetHtml()
```


<br />Note that the same behavior can be mimic via the GridView's SettingsCookies:<br /><br />


```cs
@Html.DevExpress().GridView(settings => {
    ...
    settings.SettingsCookies.Enabled = true;
}).Bind(Model).GetHtml()
```


<br />


```vb
@Html.DevExpress().GridView( _
    Sub(settings)
        ...
        settings.SettingsCookies.Enabled = True
    End Sub).Bind(Model).GetHtml()
```


<br />However, in this case, the last ClientLayout is stored within an end-user's browser (i.e., on the client side).<br /><br /><strong>See Also:</strong><br /><a href="https://www.devexpress.com/Support/Center/p/T146962">T146962: GridView - How to track ClientLayout with a separate ListBox</a>

<br/>



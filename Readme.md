<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128550462/14.1.9%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T205817)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/DXWebApplication1/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DXWebApplication1/Controllers/HomeController.vb))
* **[GridViewPartial.cshtml](./CS/DXWebApplication1/Views/Home/GridViewPartial.cshtml)**
* [Index.cshtml](./CS/DXWebApplication1/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - How to programmatically Save/Load the last ClientLayout within the Session
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t205817/)**
<!-- run online end -->


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



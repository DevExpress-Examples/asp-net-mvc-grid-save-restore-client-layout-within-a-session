@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "gv"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

            settings.Settings.ShowFilterBar = GridViewStatusBarMode.Visible
            settings.Settings.ShowFilterRow = True
            settings.Settings.ShowGroupPanel = True
            settings.SettingsBehavior.EnableCustomizationWindow = True
            settings.SettingsContextMenu.Enabled = True

            settings.KeyFieldName = "ID"
    
            settings.Columns.Add("ID")
            settings.Columns.Add("Text")

            settings.CustomJSProperties = _
                Sub(s, e)
                        Dim gridView As MVCxGridView = CType(s, MVCxGridView)
                        e.Properties("cpClientLayout") = gridView.SaveClientLayout()
                End Sub

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
    
            settings.ClientSideEvents.Init = "OnInit"
            settings.ClientSideEvents.EndCallback = "OnEndCallback"
    
    End Sub).Bind(Model).GetHtml()
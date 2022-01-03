Imports System
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices.COMException
Imports System.Runtime.Remoting.Contexts.Context
Imports System.Net
Imports System.Net.Mail
Imports System.Text
Imports Microsoft.Win32
Imports System.Diagnostics
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser

Partial Class subsystem2_form_sales_order_dept
    Inherits System.Web.UI.Page

    Dim TodayDate, SystemDate As Date
    Dim NextNo As Integer

    Dim StockCheckJR, StockCheckFR, StockCheckGlue, StockCheckRibbon, StockCheckWL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        TodayDate = System.DateTime.Now
        SystemDate = System.DateTime.Now
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim con_Check_Security_Access As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim cmd_Check_Security_Access As New SqlCommand
        Try
            cmd_Check_Security_Access.CommandText = "Select * from tbl_authentication where email ='" & User.Identity.Name.ToUpper() & "' and department <> 'SAL' and [type]='A'"
            cmd_Check_Security_Access.Connection = con_Check_Security_Access
            con_Check_Security_Access.Open()
            Dim rd_Check_Security_Access As System.Data.SqlClient.SqlDataReader = cmd_Check_Security_Access.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If rd_Check_Security_Access.HasRows Then
                If rd_Check_Security_Access.Read Then
                    Dim Dummy As String
                    Dummy = Nothing
                End If
            Else
                Response.Redirect("main_menu.aspx")
            End If
        Catch ex As Exception
            con_Check_Security_Access.Close()
            Response.Redirect("main_menu.aspx")
        Finally
            con_Check_Security_Access.Close()
        End Try
        con_Check_Security_Access.Dispose()
        cmd_Check_Security_Access.Dispose()
        con_Check_Security_Access = Nothing
        cmd_Check_Security_Access = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim con_SP1 As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim cmd_SP1 As System.Data.SqlClient.SqlCommand = New SqlCommand
        Try
            cmd_SP1.Connection = con_SP1
            cmd_SP1.CommandText = "SP_SAPS_SO_UPDATE_STATUS"
            cmd_SP1.CommandType = CommandType.StoredProcedure
            cmd_SP1.CommandTimeout = 9000
            con_SP1.Open()
            cmd_SP1.ExecuteNonQuery()
        Catch ex As Exception
            con_SP1.Close()
            Lbl_Message.Text = "Error SP SO Update! " & ex.ToString
            Exit Sub
        Finally
            con_SP1.Close()
        End Try
        con_SP1.Dispose()
        con_SP1 = Nothing
        cmd_SP1 = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Lbl_SystemUsername.Text = Request.ServerVariables("REMOTE_ADDR")
        Lbl_ReportDate.Text = System.DateTime.Now
        Lbl_RefNo.Text = User.Identity.Name.ToUpper() & "-" & Format(TodayDate, "yyyy") & Format(TodayDate, "MM") & (Format(TodayDate, "dd"))
        TxtBx_SOUser.Text = User.Identity.Name.ToUpper()
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        BindData()
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    End Sub

    Sub ClearVariable()
        TxtBx_SODate.Text = Nothing
        TxtBx_Customer.Text = Nothing
        TxtBx_CustomerType.Text = Nothing
        TxtBx_CustomerCode.Text = Nothing
        TxtBx_SOPO.Text = Nothing
        TxtBx_SOQTY.Text = Nothing
        'TxtBx_SOUser.Text = Nothing
        Txtbx_SOETD.Text = Nothing
        Txtbx_Info1.Text = Nothing
        Txtbx_Info2.Text = Nothing
        TxtBx_Info3.Text = Nothing
    End Sub


    Sub BindData()
        Dim ds As DataSet
        ds = CreateDataSet()
        DG_DATA.DataSource = ds.Tables(0).DefaultView
        DG_DATA.DataBind()
    End Sub

    Function CreateDataSet() As DataSet
        '***************************************************************************************************************************************************************************
        Dim objConn As New System.Data.SqlClient.SqlConnection
        Dim objCmd As New System.Data.SqlClient.SqlCommand
        Dim dtAdapter As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString, strSQL, Today_Data As String
        Dim TodayData As Date
        '***************************************************************************************************************************************************************************
        strConnString = ConfigurationSettings.AppSettings("ConnectionString")
        '***************************************************************************************************************************************************************************
        TodayData = Nothing
        Today_Data = Nothing
        TodayData = DateTime.Now
        TodayData = TodayDate.AddDays(-40)
        Today_Data = Format(TodayData, "yyyy") & "-" & Format(TodayData, "MM") & "-" & Format(TodayData, "dd")
        '***************************************************************************************************************************************************************************
        'If User.Identity.Name.ToLower = "itteam.sbgroup@gmail.com" Then
        'strSQL = "select * from VIEW_SALES_STORE_PO_REGISTRATION where ReportDateTime >= '" & Today_Data & "'  order by SODateTime desc"
        'Else
        'strSQL = "select * from VIEW_SALES_STORE_PO_REGISTRATION where UserName = '" & User.Identity.Name.ToUpper() & "'  order by ReportDateTime desc"
        strSQL = "select * from VIEW_SAPS_SO_CONVERTING2 where ReportDateTime >= '" & Today_Data & "'  order by flag5, SODateTime desc"
        'End If
        'strSQL = "select * from VIEW_SALES_STORE_PO_REGISTRATION_FILE"
        '***************************************************************************************************************************************************************************
        objConn.ConnectionString = strConnString
        With objCmd
            .Connection = objConn
            .CommandText = strSQL
            .CommandType = CommandType.Text
        End With
        dtAdapter.SelectCommand = objCmd
        dtAdapter.Fill(ds)
        dtAdapter = Nothing
        objConn.Close()
        objConn = Nothing
        Return ds   '*** Return DataSet ***'  
    End Function

    Public Sub Button_Click(ByVal Sender As System.Object, ByVal E As System.Web.UI.WebControls.DataGridCommandEventArgs)
        Dim strTNO, strTLine, StrSql, StrSalesOrderNo As String

        strTNO = Nothing
        strTLine = Nothing
        StrSql = Nothing
        StrSalesOrderNo = Nothing

        strTLine = E.Item.Cells(2).Text
        strTNO = E.Item.Cells(1).Text
        StrSalesOrderNo = E.Item.Cells(2).Text
        '************************************************************************************************************************
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim SP_CheckSO_SqlCon As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim SP_CheckSO_QueryStr As String = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" & StrSalesOrderNo & "'"
        Dim SP_CheckSO_SqlCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(SP_CheckSO_QueryStr, SP_CheckSO_SqlCon)
        Try
            SP_CheckSO_SqlCon.Open()
            Dim dbr_CheckSO_LIST As System.Data.SqlClient.SqlDataReader = SP_CheckSO_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If dbr_CheckSO_LIST.HasRows Then
                Do While dbr_CheckSO_LIST.Read()
                    Try
                        '###################################################################################################################################################################
                        TxtBx_SO.Text = dbr_CheckSO_LIST("SalesOrderNo")
                        TxtBx_SODate.Text = dbr_CheckSO_LIST("SODateTime")
                        TxtBx_Customer.Text = dbr_CheckSO_LIST("Customer")
                        TxtBx_CustomerCode.Text = " "

                        If dbr_CheckSO_LIST("CustomerType").ToString = Nothing Then
                            TxtBx_CustomerType.Text = " "
                        Else
                            TxtBx_CustomerType.Text = dbr_CheckSO_LIST("CustomerType")
                        End If

                        If dbr_CheckSO_LIST("CustomerPO").ToString = Nothing Then
                            TxtBx_SOPO.Text = " "
                        Else
                            TxtBx_SOPO.Text = dbr_CheckSO_LIST("CustomerPO")
                        End If

                        TxtBx_SOQTY.Text = dbr_CheckSO_LIST("SalesOrder")
                        Txtbx_SOETD.Text = dbr_CheckSO_LIST("ETDDateTime")

                        If dbr_CheckSO_LIST("SalesOrderInfo1").ToString = Nothing Then
                            Txtbx_Info1.Text = " "
                        Else
                            Txtbx_Info1.Text = dbr_CheckSO_LIST("SalesOrderInfo1")
                        End If

                        If dbr_CheckSO_LIST("SalesOrderInfo2").ToString = Nothing Then
                            Txtbx_Info2.Text = " "
                        Else
                            Txtbx_Info2.Text = dbr_CheckSO_LIST("SalesOrderInfo2")
                        End If

                        If dbr_CheckSO_LIST("SalesOrderInfo3").ToString = Nothing Then
                            TxtBx_Info3.Text = " "
                        Else
                            TxtBx_Info3.Text = dbr_CheckSO_LIST("SalesOrderInfo3")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload").ToString = Nothing Then
                            LstFiles.Text = " "
                        Else
                            LstFiles.Text = dbr_CheckSO_LIST("FlagFileUpload")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload2").ToString = Nothing Then
                            LstFiles2.Text = " "
                        Else
                            LstFiles2.Text = dbr_CheckSO_LIST("FlagFileUpload2")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload3").ToString = Nothing Then
                            LSTFILES3.Text = " "
                        Else
                            LSTFILES3.Text = dbr_CheckSO_LIST("FlagFileUpload3")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload4").ToString = Nothing Then
                            LSTFILES4.Text = " "
                        Else
                            LSTFILES4.Text = dbr_CheckSO_LIST("FlagFileUpload4")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload5").ToString = Nothing Then
                            LSTFILES5.Text = " "
                        Else
                            LSTFILES5.Text = dbr_CheckSO_LIST("FlagFileUpload5")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload6").ToString = Nothing Then
                            LSTFILES6.Text = " "
                        Else
                            LSTFILES6.Text = dbr_CheckSO_LIST("FlagFileUpload6")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload7").ToString = Nothing Then
                            LSTFILES7.Text = " "
                        Else
                            LSTFILES7.Text = dbr_CheckSO_LIST("FlagFileUpload7")
                        End If
                        '###################################################################################################################################################################
                    Catch CheckSO_ex1 As Exception
                        Lbl_Message.Text = CheckSO_ex1.ToString
                        Exit Sub
                    End Try
                Loop
            End If
            dbr_CheckSO_LIST = Nothing
        Catch CheckSO_ex2 As Exception
            Lbl_Message.Text = CheckSO_ex2.ToString
            Exit Sub
        Finally
            SP_CheckSO_SqlCon.Close()
            SP_CheckSO_SqlCon.Dispose()
        End Try
        SP_CheckSO_SqlCon = Nothing
        SP_CheckSO_QueryStr = Nothing
        SP_CheckSO_SqlCmd = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        '************************************************************************************************************************
        BindData()
        '************************************************************************************************************************
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    End Sub

    Protected Sub Btn_SearchSO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_SearchSO.Click
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        If TxtBx_SO.Text = Nothing Or TxtBx_SO.Text = String.Empty Then
            Lbl_Message.Text = "Error! Please enter sales order number."
            Exit Sub
        End If
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim SP_CheckSO_SqlCon As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim SP_CheckSO_QueryStr As String = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" & TxtBx_SO.Text & "'"
        Dim SP_CheckSO_SqlCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(SP_CheckSO_QueryStr, SP_CheckSO_SqlCon)
        Try
            SP_CheckSO_SqlCon.Open()
            Dim dbr_CheckSO_LIST As System.Data.SqlClient.SqlDataReader = SP_CheckSO_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If dbr_CheckSO_LIST.HasRows Then
                Do While dbr_CheckSO_LIST.Read()
                    Try
                        '###################################################################################################################################################################
                        TxtBx_SO.Text = dbr_CheckSO_LIST("SalesOrderNo")
                        TxtBx_SODate.Text = dbr_CheckSO_LIST("SODateTime")
                        TxtBx_Customer.Text = dbr_CheckSO_LIST("Customer")
                        TxtBx_CustomerCode.Text = " "

                        If dbr_CheckSO_LIST("CustomerType").ToString = Nothing Then
                            TxtBx_CustomerType.Text = " "
                        Else
                            TxtBx_CustomerType.Text = dbr_CheckSO_LIST("CustomerType")
                        End If

                        If dbr_CheckSO_LIST("CustomerPO").ToString = Nothing Then
                            TxtBx_SOPO.Text = " "
                        Else
                            TxtBx_SOPO.Text = dbr_CheckSO_LIST("CustomerPO")
                        End If

                        TxtBx_SOQTY.Text = dbr_CheckSO_LIST("SalesOrder")
                        Txtbx_SOETD.Text = dbr_CheckSO_LIST("ETDDateTime")

                        If dbr_CheckSO_LIST("SalesOrderInfo1").ToString = Nothing Then
                            Txtbx_Info1.Text = " "
                        Else
                            Txtbx_Info1.Text = dbr_CheckSO_LIST("SalesOrderInfo1")
                        End If

                        If dbr_CheckSO_LIST("SalesOrderInfo2").ToString = Nothing Then
                            Txtbx_Info2.Text = " "
                        Else
                            Txtbx_Info2.Text = dbr_CheckSO_LIST("SalesOrderInfo2")
                        End If

                        If dbr_CheckSO_LIST("SalesOrderInfo3").ToString = Nothing Then
                            TxtBx_Info3.Text = " "
                        Else
                            TxtBx_Info3.Text = dbr_CheckSO_LIST("SalesOrderInfo3")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload").ToString = Nothing Then
                            LstFiles.Text = " "
                        Else
                            LstFiles.Text = dbr_CheckSO_LIST("FlagFileUpload")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload2").ToString = Nothing Then
                            LstFiles2.Text = " "
                        Else
                            LstFiles2.Text = dbr_CheckSO_LIST("FlagFileUpload2")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload3").ToString = Nothing Then
                            LSTFILES3.Text = " "
                        Else
                            LSTFILES3.Text = dbr_CheckSO_LIST("FlagFileUpload3")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload4").ToString = Nothing Then
                            LSTFILES4.Text = " "
                        Else
                            LSTFILES4.Text = dbr_CheckSO_LIST("FlagFileUpload4")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload5").ToString = Nothing Then
                            LSTFILES5.Text = " "
                        Else
                            LSTFILES5.Text = dbr_CheckSO_LIST("FlagFileUpload5")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload6").ToString = Nothing Then
                            LSTFILES6.Text = " "
                        Else
                            LSTFILES6.Text = dbr_CheckSO_LIST("FlagFileUpload6")
                        End If

                        If dbr_CheckSO_LIST("FlagFileUpload7").ToString = Nothing Then
                            LSTFILES7.Text = " "
                        Else
                            LSTFILES7.Text = dbr_CheckSO_LIST("FlagFileUpload7")
                        End If
                        '###################################################################################################################################################################
                    Catch CheckSO_ex1 As Exception
                        Lbl_Message.Text = CheckSO_ex1.ToString
                        Exit Sub
                    End Try
                Loop
            End If
            dbr_CheckSO_LIST = Nothing
        Catch CheckSO_ex2 As Exception
            Lbl_Message.Text = CheckSO_ex2.ToString
            Exit Sub
        Finally
            SP_CheckSO_SqlCon.Close()
            SP_CheckSO_SqlCon.Dispose()
        End Try
        SP_CheckSO_SqlCon = Nothing
        SP_CheckSO_QueryStr = Nothing
        SP_CheckSO_SqlCmd = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        BindData()
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    End Sub

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim CmdDownloadFile As String
        CmdDownloadFile = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim con_GetSO_FIle As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim cmd_GetSO_FIle As New SqlCommand
        Try
            cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" & TxtBx_SO.Text & "'"
            cmd_GetSO_FIle.Connection = con_GetSO_FIle
            con_GetSO_FIle.Open()
            Dim rd_GetSO_FIle As System.Data.SqlClient.SqlDataReader = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If rd_GetSO_FIle.Read Then
                LstFiles.Text = rd_GetSO_FIle("FlagFileUpload")
                CmdDownloadFile = rd_GetSO_FIle("FlagFileUpload")
            Else
                con_GetSO_FIle.Close()
                Exit Sub
            End If
        Catch ex As Exception
            con_GetSO_FIle.Close()
            Lbl_Message.Text = "Error Download File :" & ex.ToString
            Exit Sub
        Finally
            con_GetSO_FIle.Close()
        End Try
        con_GetSO_FIle.Dispose()
        cmd_GetSO_FIle.Dispose()
        con_GetSO_FIle = Nothing
        cmd_GetSO_FIle = Nothing
        '**********************************************************************************************************************        
        Dim value1 As String = LstFiles.Text
        Dim value2 As String = value1.Replace("http://192.168.1.210/SAPS/", "D:\SAPS\")
        'Dim value3 As String = value1.Replace("http://192.168.1.210/SAPS/", "DocNo")
        '**********************************************************************************************************************        
        'LstFiles.Text
        'Dim filename As System.String = LstFiles.Text
        Dim filename As System.String = value2 'value3

        ' set the http content type to "APPLICATION/OCTET-STREAM
        Response.ContentType = "APPLICATION/OCTET-STREAM"

        ' initialize the http content-disposition header to
        ' indicate a file attachment with the default filename
        Dim disHeader As System.String = "Attachment; Filename=""" & filename & """"
        Response.AppendHeader("Content-Disposition", disHeader)

        ' transfer the file byte-by-byte to the response object
        Dim fileToDownload As New System.IO.FileInfo(value2)
        Response.Flush()
        Response.WriteFile(fileToDownload.FullName)
        '**********************************************************************************************************************
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim conUpdate_Acknowledgement As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim cmdUpdate_Acknowledgement As System.Data.SqlClient.SqlCommand = New SqlCommand
        Try
            cmdUpdate_Acknowledgement.CommandText = "update TBL_FORM_SALES_STORE_PO_REGISTRATION_USER set flag1 = 'Y', userdate = '" & System.DateTime.Now & "' where username = '" & User.Identity.Name.ToUpper() & "' and SalesOrderNo = '" & TxtBx_SO.Text & "'"
            cmdUpdate_Acknowledgement.Connection = conUpdate_Acknowledgement
            conUpdate_Acknowledgement.Open()
            cmdUpdate_Acknowledgement.ExecuteNonQuery()
        Catch ex As Exception
            conUpdate_Acknowledgement.Close()
            Lbl_Message.Text = "Error User Acknowledgement! " & ex.ToString
            Exit Sub
        Finally
            conUpdate_Acknowledgement.Close()
        End Try
        conUpdate_Acknowledgement.Dispose()
        conUpdate_Acknowledgement = Nothing
        cmdUpdate_Acknowledgement = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        StockCheckJR = Nothing
        StockCheckFR = Nothing
        StockCheckGlue = Nothing
        StockCheckRibbon = Nothing
        StockCheckWL = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        StockCheckJR = "N"
        StockCheckFR = "N"
        StockCheckGlue = "N"
        StockCheckRibbon = "N"
        StockCheckWL = "N"
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        '###################################################################################################################################################################
        Dim SP_CheckStockType_Glue_SqlCon As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim SP_CheckStockType_Glue_QueryStr As String = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION_DETAIL where tno = '" & TxtBx_SO.Text.ToUpper & "' and tstk like 'EX%' or tno = '" & TxtBx_SO.Text.ToUpper & "' and tstk like 'WG%'"
        Dim SP_CheckStockType_Glue_SqlCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(SP_CheckStockType_Glue_QueryStr, SP_CheckStockType_Glue_SqlCon)
        Try
            SP_CheckStockType_Glue_SqlCon.Open()
            Dim dbr_CheckStockType_Glue_LIST As System.Data.SqlClient.SqlDataReader = SP_CheckStockType_Glue_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If dbr_CheckStockType_Glue_LIST.HasRows Then
                Do While dbr_CheckStockType_Glue_LIST.Read()
                    Try
                        '###################################################################################################################################################################
                        StockCheckGlue = "Y"
                        '###################################################################################################################################################################
                    Catch CheckStockType_Glue_ex1 As Exception
                        Lbl_Message.Text = CheckStockType_Glue_ex1.ToString
                        Exit Sub
                    End Try
                Loop
            End If
            dbr_CheckStockType_Glue_LIST = Nothing
        Catch CheckStockType_Glue_ex2 As Exception
            Lbl_Message.Text = CheckStockType_Glue_ex2.ToString
            Exit Sub
        Finally
            SP_CheckStockType_Glue_SqlCon.Close()
            SP_CheckStockType_Glue_SqlCon.Dispose()
        End Try
        SP_CheckStockType_Glue_SqlCon = Nothing
        SP_CheckStockType_Glue_QueryStr = Nothing
        SP_CheckStockType_Glue_SqlCmd = Nothing
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim SP_CheckStockType_JR_SqlCon As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim SP_CheckStockType_JR_QueryStr As String = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION_DETAIL where tno = '" & TxtBx_SO.Text.ToUpper & "' and tstk like 'WJ%'"
        Dim SP_CheckStockType_JR_SqlCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(SP_CheckStockType_JR_QueryStr, SP_CheckStockType_JR_SqlCon)
        Try
            SP_CheckStockType_JR_SqlCon.Open()
            Dim dbr_CheckStockType_JR_LIST As System.Data.SqlClient.SqlDataReader = SP_CheckStockType_JR_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If dbr_CheckStockType_JR_LIST.HasRows Then
                Do While dbr_CheckStockType_JR_LIST.Read()
                    Try
                        '###################################################################################################################################################################
                        StockCheckJR = "Y"
                        '###################################################################################################################################################################
                    Catch CheckStockType_JR_ex1 As Exception
                        Lbl_Message.Text = CheckStockType_JR_ex1.ToString
                        Exit Sub
                    End Try
                Loop
            End If
            dbr_CheckStockType_JR_LIST = Nothing
        Catch CheckStockType_JR_ex2 As Exception
            Lbl_Message.Text = CheckStockType_JR_ex2.ToString
            Exit Sub
        Finally
            SP_CheckStockType_JR_SqlCon.Close()
            SP_CheckStockType_JR_SqlCon.Dispose()
        End Try
        SP_CheckStockType_JR_SqlCon = Nothing
        SP_CheckStockType_JR_QueryStr = Nothing
        SP_CheckStockType_JR_SqlCmd = Nothing
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim SP_CheckStockType_LR_SqlCon As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim SP_CheckStockType_LR_QueryStr As String = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION_DETAIL where tno = '" & TxtBx_SO.Text.ToUpper & "' and tstk like 'WL%'"
        Dim SP_CheckStockType_LR_SqlCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(SP_CheckStockType_LR_QueryStr, SP_CheckStockType_LR_SqlCon)
        Try
            SP_CheckStockType_LR_SqlCon.Open()
            Dim dbr_CheckStockType_LR_LIST As System.Data.SqlClient.SqlDataReader = SP_CheckStockType_LR_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If dbr_CheckStockType_LR_LIST.HasRows Then
                Do While dbr_CheckStockType_LR_LIST.Read()
                    Try
                        '###################################################################################################################################################################
                        StockCheckWL = "Y"
                        '###################################################################################################################################################################
                    Catch CheckStockType_LR_ex1 As Exception
                        Lbl_Message.Text = CheckStockType_LR_ex1.ToString
                        Exit Sub
                    End Try
                Loop
            End If
            dbr_CheckStockType_LR_LIST = Nothing
        Catch CheckStockType_LR_ex2 As Exception
            Lbl_Message.Text = CheckStockType_LR_ex2.ToString
            Exit Sub
        Finally
            SP_CheckStockType_LR_SqlCon.Close()
            SP_CheckStockType_LR_SqlCon.Dispose()
        End Try
        SP_CheckStockType_LR_SqlCon = Nothing
        SP_CheckStockType_LR_QueryStr = Nothing
        SP_CheckStockType_LR_SqlCmd = Nothing
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim SP_CheckStockType_Ribbon_SqlCon As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim SP_CheckStockType_Ribbon_QueryStr As String = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION_DETAIL where tno = '" & TxtBx_SO.Text.ToUpper & "' and tdesc1 like '%ribbon%' or tno = '" & TxtBx_SO.Text.ToUpper & "' and tdesc1 like '%ribbon%'"
        Dim SP_CheckStockType_Ribbon_SqlCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(SP_CheckStockType_Ribbon_QueryStr, SP_CheckStockType_Ribbon_SqlCon)
        Try
            SP_CheckStockType_Ribbon_SqlCon.Open()
            Dim dbr_CheckStockType_Ribbon_LIST As System.Data.SqlClient.SqlDataReader = SP_CheckStockType_Ribbon_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If dbr_CheckStockType_Ribbon_LIST.HasRows Then
                Do While dbr_CheckStockType_Ribbon_LIST.Read()
                    Try
                        '###################################################################################################################################################################
                        StockCheckRibbon = "Y"
                        '###################################################################################################################################################################
                    Catch CheckStockType_Ribbon_ex1 As Exception
                        Lbl_Message.Text = CheckStockType_Ribbon_ex1.ToString
                        Exit Sub
                    End Try
                Loop
            End If
            dbr_CheckStockType_Ribbon_LIST = Nothing
        Catch CheckStockType_Ribbon_ex2 As Exception
            Lbl_Message.Text = CheckStockType_Ribbon_ex2.ToString
            Exit Sub
        Finally
            SP_CheckStockType_Ribbon_SqlCon.Close()
            SP_CheckStockType_Ribbon_SqlCon.Dispose()
        End Try
        SP_CheckStockType_Ribbon_SqlCon = Nothing
        SP_CheckStockType_Ribbon_QueryStr = Nothing
        SP_CheckStockType_Ribbon_SqlCmd = Nothing
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim SP_CheckStockType_OPPT_SqlCon As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim SP_CheckStockType_OPPT_QueryStr As String = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION_DETAIL where tno = '" & TxtBx_SO.Text.ToUpper & "' and tdesc1 like '%OPPT%' or tno = '" & TxtBx_SO.Text.ToUpper & "' and tdesc1 like '%OPPT%'"
        Dim SP_CheckStockType_OPPT_SqlCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(SP_CheckStockType_OPPT_QueryStr, SP_CheckStockType_OPPT_SqlCon)
        Try
            SP_CheckStockType_OPPT_SqlCon.Open()
            Dim dbr_CheckStockType_OPPT_LIST As System.Data.SqlClient.SqlDataReader = SP_CheckStockType_OPPT_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If dbr_CheckStockType_OPPT_LIST.HasRows Then
                Do While dbr_CheckStockType_OPPT_LIST.Read()
                    Try
                        '###################################################################################################################################################################
                        StockCheckFR = "Y"
                        '###################################################################################################################################################################
                    Catch CheckStockType_OPPT_ex1 As Exception
                        Lbl_Message.Text = CheckStockType_OPPT_ex1.ToString
                        Exit Sub
                    End Try
                Loop
            End If
            dbr_CheckStockType_OPPT_LIST = Nothing
        Catch CheckStockType_OPPT_ex2 As Exception
            Lbl_Message.Text = CheckStockType_OPPT_ex2.ToString
            Exit Sub
        Finally
            SP_CheckStockType_OPPT_SqlCon.Close()
            SP_CheckStockType_OPPT_SqlCon.Dispose()
        End Try
        SP_CheckStockType_OPPT_SqlCon = Nothing
        SP_CheckStockType_OPPT_QueryStr = Nothing
        SP_CheckStockType_OPPT_SqlCmd = Nothing
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '###################################################################################################################################################################
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        '------------------------------------------------------------------------------------------
        ' BEGIN EMAIL NOTIFICATION
        '------------------------------------------------------------------------------------------
        Dim FromName As String = "SAPS E-SERVICE"
        Dim FromEmail As String = "itteam.sbgroup@gmail.com"
        Dim Subject As String = "SAPS SO READ : " & TxtBx_SO.Text.ToUpper

        Dim smtp As New System.Net.Mail.SmtpClient
        smtp.Host = "smtp.gmail.com"
        smtp.Credentials = New System.Net.NetworkCredential("itteam.sbgroup@gmail.com", "wsc4143pk")
        smtp.EnableSsl = True
        smtp.Port = 587

        Dim msg As New System.Net.Mail.MailMessage()
        msg.From = New System.Net.Mail.MailAddress(FromEmail, FromName)
        '---> msg.To.Add(New System.Net.Mail.MailAddress("samuel@sbgroup.com.my", "Samuel"))
        msg.To.Add(New System.Net.Mail.MailAddress("cath@sbgroup.com.my", "Catherine Teh"))

        If TxtBx_CustomerType.Text = "LC" Then
            '--> Customer Service Local
            msg.To.Add(New System.Net.Mail.MailAddress("kelly@sbgroup.com.my", "Kelly Chan"))
            msg.To.Add(New System.Net.Mail.MailAddress("salesco-1@sbgroup.com.my", "Han Chok Min Jie"))
            msg.To.Add(New System.Net.Mail.MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"))
            msg.To.Add(New System.Net.Mail.MailAddress("salesco-3@sbgroup.com.my", "SalesCo"))

            If StockCheckGlue = "N" Then
                '--> Store1806
                'msg.To.Add(New System.Net.Mail.MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
                msg.To.Add(New System.Net.Mail.MailAddress("store-2@sbgroup.com.my", "Kalyani "))
                msg.To.Add(New System.Net.Mail.MailAddress("store-9@sbgroup.com.my", "Chin Chin"))
                msg.To.Add(New System.Net.Mail.MailAddress("logistic-5@sbgroup.com.my", "Arveenah"))
                msg.To.Add(New System.Net.Mail.MailAddress("cyyong@sbgroup.com.my", "CY Yong"))
                msg.To.Add(New System.Net.Mail.MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"))
            Else
                '--> Logistic
                msg.To.Add(New System.Net.Mail.MailAddress("logistic-5@sbgroup.com.my", "Arveenah"))
                msg.To.Add(New System.Net.Mail.MailAddress("store-4@sbgroup.com.my", "Shuairah "))
                msg.To.Add(New System.Net.Mail.MailAddress("store-7@sbgroup.com.my", "Hazlinda"))
                msg.To.Add(New System.Net.Mail.MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"))
                msg.To.Add(New System.Net.Mail.MailAddress("logistic-10@sbgroup.com.my", "Jenny"))
                msg.To.Add(New System.Net.Mail.MailAddress("cyyong@sbgroup.com.my", "CY Yong"))
                msg.To.Add(New System.Net.Mail.MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"))
            End If
        ElseIf TxtBx_CustomerType.Text = "SG" Then
            '--> Customer Service Local
            msg.To.Add(New System.Net.Mail.MailAddress("kelly@sbgroup.com.my", "Kelly Chan"))
            msg.To.Add(New System.Net.Mail.MailAddress("salesco-1@sbgroup.com.my", "Han Chok Min Jie"))
            msg.To.Add(New System.Net.Mail.MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"))
            msg.To.Add(New System.Net.Mail.MailAddress("salesco-3@sbgroup.com.my", "SalesCo"))

            '--> Store1806
            'msg.To.Add(New System.Net.Mail.MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
            msg.To.Add(New System.Net.Mail.MailAddress("store-2@sbgroup.com.my", "Kalyani "))
            msg.To.Add(New System.Net.Mail.MailAddress("store-9@sbgroup.com.my", "Chin Chin"))
            msg.To.Add(New System.Net.Mail.MailAddress("logistic-5@sbgroup.com.my", "Arveenah"))

            '--> Customer Service Export
            msg.To.Add(New System.Net.Mail.MailAddress("exportsc-1@sbgroup.com.my", "Michelle Kang"))
            msg.To.Add(New System.Net.Mail.MailAddress("michelle.kang@sbgroup.com.my", "Daphiny Hoo Poe Yee"))

            '--> Logistic
            msg.To.Add(New System.Net.Mail.MailAddress("logistic-5@sbgroup.com.my", "Arveenah"))
            msg.To.Add(New System.Net.Mail.MailAddress("store-4@sbgroup.com.my", "Shuairah "))
            msg.To.Add(New System.Net.Mail.MailAddress("store-7@sbgroup.com.my", "Hazlinda"))
            msg.To.Add(New System.Net.Mail.MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"))
            msg.To.Add(New System.Net.Mail.MailAddress("logistic-10@sbgroup.com.my", "Jenny"))
            msg.To.Add(New System.Net.Mail.MailAddress("cyyong@sbgroup.com.my", "CY Yong"))
            msg.To.Add(New System.Net.Mail.MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"))
        ElseIf TxtBx_CustomerType.Text = "FC" Then
            '--> Customer Service Export
            msg.To.Add(New System.Net.Mail.MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"))
            msg.To.Add(New System.Net.Mail.MailAddress("exportsc-1@sbgroup.com.my", "Michelle Kang"))
            msg.To.Add(New System.Net.Mail.MailAddress("michelle.kang@sbgroup.com.my", "Daphiny Hoo Poe Yee"))

            '--> Logistic
            msg.To.Add(New System.Net.Mail.MailAddress("logistic-5@sbgroup.com.my", "Arveenah"))
            msg.To.Add(New System.Net.Mail.MailAddress("store-4@sbgroup.com.my", "Shuairah "))
            msg.To.Add(New System.Net.Mail.MailAddress("store-7@sbgroup.com.my", "Hazlinda"))
            msg.To.Add(New System.Net.Mail.MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"))
            msg.To.Add(New System.Net.Mail.MailAddress("logistic-10@sbgroup.com.my", "Jenny"))
            msg.To.Add(New System.Net.Mail.MailAddress("cyyong@sbgroup.com.my", "CY Yong"))
            msg.To.Add(New System.Net.Mail.MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"))
        Else
            '--> Customer Service Local
            msg.To.Add(New System.Net.Mail.MailAddress("kelly@sbgroup.com.my", "Kelly Chan"))
            msg.To.Add(New System.Net.Mail.MailAddress("salesco-1@sbgroup.com.my", "Han Chok Min Jie"))
            msg.To.Add(New System.Net.Mail.MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"))
            msg.To.Add(New System.Net.Mail.MailAddress("salesco-3@sbgroup.com.my", "SalesCo"))

            '--> Store1806
            'msg.To.Add(New System.Net.Mail.MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
            msg.To.Add(New System.Net.Mail.MailAddress("store-2@sbgroup.com.my", "Kalyani "))
            msg.To.Add(New System.Net.Mail.MailAddress("store-9@sbgroup.com.my", "Chin Chin"))
            msg.To.Add(New System.Net.Mail.MailAddress("logistic-5@sbgroup.com.my", "Arveenah"))

            '--> Customer Service Export
            msg.To.Add(New System.Net.Mail.MailAddress("exportsc-1@sbgroup.com.my", "Michelle Kang"))
            msg.To.Add(New System.Net.Mail.MailAddress("michelle.kang@sbgroup.com.my", "Daphiny Hoo Poe Yee"))

            '--> Logistic
            msg.To.Add(New System.Net.Mail.MailAddress("logistic-5@sbgroup.com.my", "Arveenah"))
            msg.To.Add(New System.Net.Mail.MailAddress("store-4@sbgroup.com.my", "Shuairah "))
            msg.To.Add(New System.Net.Mail.MailAddress("store-7@sbgroup.com.my", "Hazlinda"))
            msg.To.Add(New System.Net.Mail.MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"))
            msg.To.Add(New System.Net.Mail.MailAddress("logistic-10@sbgroup.com.my", "Jenny"))
            msg.To.Add(New System.Net.Mail.MailAddress("cyyong@sbgroup.com.my", "CY Yong"))
            msg.To.Add(New System.Net.Mail.MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"))
        End If

        If StockCheckGlue = "Y" Then
            '--> Glue
            'msg.To.Add(New System.Net.Mail.MailAddress("stacy@sbgroup.com.my", "Stacy Chooi"))
            msg.To.Add(New System.Net.Mail.MailAddress("co-3@sbgroup.com.my", "Elmer"))
            msg.To.Add(New System.Net.Mail.MailAddress("haiqal.bakar@sbgroup.com.my", "Haiqal"))
            msg.To.Add(New System.Net.Mail.MailAddress("st952@sbgroup.com.my", "Muhammad Rudzaimie"))
            'msg.To.Add(New System.Net.Mail.MailAddress("ystoh@sbgroup.com.my", "Mr TYS"))
        ElseIf StockCheckRibbon = "Y" Then
            '--> Ribbon
            msg.To.Add(New System.Net.Mail.MailAddress("stacy@sbgroup.com.my", "Stacy Chooi"))
            'msg.To.Add(New System.Net.Mail.MailAddress("production-4@sbgroup.com.my", "Jothi"))
        ElseIf StockCheckRibbon = "FR" Or StockCheckWL = "Y" Then
            'msg.To.Add(New System.Net.Mail.MailAddress("planner-3@sbgroup.com.my", "Simon Yew Chee Wang"))
            msg.To.Add(New System.Net.Mail.MailAddress("planner-5@sbgroup.com.my", "Jess Ng"))
            msg.To.Add(New System.Net.Mail.MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "))
            msg.To.Add(New System.Net.Mail.MailAddress("converting-2@sbgroup.com.my", "Claudia"))
        ElseIf StockCheckJR = "Y" Then
            '--> Production
            'msg.To.Add(New System.Net.Mail.MailAddress("planner-3@sbgroup.com.my", "Simon Yew Chee Wang"))
            msg.To.Add(New System.Net.Mail.MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "))
        Else
            'msg.To.Add(New System.Net.Mail.MailAddress("planner-3@sbgroup.com.my", "Simon Yew Chee Wang"))
            msg.To.Add(New System.Net.Mail.MailAddress("planner-5@sbgroup.com.my", "Jess Ng"))
            msg.To.Add(New System.Net.Mail.MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "))
            msg.To.Add(New System.Net.Mail.MailAddress("converting-2@sbgroup.com.my", "Claudia"))
        End If
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim EmailUserName, EmailUserDept As String
        EmailUserName = Nothing
        EmailUserDept = Nothing

        Dim con_Check_Recepient As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim cmd_Check_Recepient As New SqlCommand
        Try
            cmd_Check_Recepient.CommandText = "Select * from tbl_authentication where email ='" & User.Identity.Name.ToUpper() & "'"
            cmd_Check_Recepient.Connection = con_Check_Recepient
            con_Check_Recepient.Open()
            Dim rd_Check_Recepient As System.Data.SqlClient.SqlDataReader = cmd_Check_Recepient.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If rd_Check_Recepient.HasRows Then
                If rd_Check_Recepient.Read Then
                    EmailUserName = rd_Check_Recepient("Name")
                    EmailUserDept = rd_Check_Recepient("Department")
                End If
            End If
        Catch ex As Exception
            con_Check_Recepient.Close()
            Response.Redirect("main_menu.aspx")
        Finally
            con_Check_Recepient.Close()
        End Try
        con_Check_Recepient.Dispose()
        cmd_Check_Recepient.Dispose()
        con_Check_Recepient = Nothing
        cmd_Check_Recepient = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        msg.Subject = Subject
        msg.Body = "Dear All," & _
                   vbNewLine & vbNewLine & _
                   "Please be informed that " & User.Identity.Name.ToUpper() & " " & EmailUserName & _
                   " has read sales order ETD and will be processed it in the production and/or delivery" & _
                   vbNewLine & vbNewLine & _
                   "Customer   : " & TxtBx_Customer.Text.ToUpper & _
                   vbNewLine & vbNewLine & _
                   "S/O Number : " & TxtBx_SO.Text.ToUpper & _
                   vbNewLine & vbNewLine & _
                   vbNewLine & vbNewLine & _
                   "Info 1 : " & Txtbx_Info1.Text.ToUpper & _
                   vbNewLine & vbNewLine & _
                   "Info 2 : " & Txtbx_Info2.Text.ToUpper & _
                   vbNewLine & vbNewLine & _
                   "Info 3 : " & TxtBx_Info3.Text.ToUpper & _
                   vbNewLine & vbNewLine & _
                   vbNewLine & vbNewLine & _
                   "Thank you." & _
                   vbNewLine & vbNewLine & _
                   "SAPS SOSystem Notification."
        Try
            smtp.Send(msg)
        Catch ex As FormatException
            Lbl_Message.Text = ("Format Exception: " & ex.Message)
        Catch ex As SmtpException
            Lbl_Message.Text = ("SMTP Exception:  " & ex.Message)
        Catch ex As Exception
            Lbl_Message.Text = ("General Exception:  " & ex.Message)
        End Try
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        ClearVariable()
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Lbl_Message.Text = "OK. File is downloaded."
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    End Sub

    Protected Sub btnLoad2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad2.Click
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim CmdDownloadFile, CheckFile As String
        CmdDownloadFile = Nothing
        CheckFile = Nothing
        CheckFile = "N"
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim con_GetSO_FIle As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim cmd_GetSO_FIle As New SqlCommand
        Try
            cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" & TxtBx_SO.Text & "'"
            cmd_GetSO_FIle.Connection = con_GetSO_FIle
            con_GetSO_FIle.Open()
            Dim rd_GetSO_FIle As System.Data.SqlClient.SqlDataReader = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If rd_GetSO_FIle.Read Then
                LstFiles2.Text = rd_GetSO_FIle("FlagFileUpload2")
                CmdDownloadFile = rd_GetSO_FIle("FlagFileUpload2")
                CheckFile = "Y"
            Else
                CheckFile = "N"
                con_GetSO_FIle.Close()
                Exit Sub
            End If
        Catch ex As Exception
            con_GetSO_FIle.Close()
            Lbl_Message.Text = "Error Download File :" & ex.ToString
            Exit Sub
        Finally
            con_GetSO_FIle.Close()
        End Try
        con_GetSO_FIle.Dispose()
        cmd_GetSO_FIle.Dispose()
        con_GetSO_FIle = Nothing
        cmd_GetSO_FIle = Nothing
        '**********************************************************************************************************************        
        Dim value1 As String = LstFiles2.Text
        Dim value2 As String = value1.Replace("http://192.168.1.210/SAPS/", "D:\SAPS\")
        Dim value3 As String = value2 'value1.Replace("http://192.168.1.210/SAPS/", "DocNo")
        '**********************************************************************************************************************        
        'LstFiles.Text
        'Dim filename As System.String = LstFiles.Text
        Dim filename As System.String = value2 'value3

        If CheckFile = "Y" Then
            Response.Clear()
        End If

        ' set the http content type to "APPLICATION/OCTET-STREAM
        Response.ContentType = "APPLICATION/OCTET-STREAM"

        ' initialize the http content-disposition header to
        ' indicate a file attachment with the default filename
        Dim disHeader As System.String = "Attachment; Filename=""" & filename & """"
        Response.AppendHeader("Content-Disposition", disHeader)

        ' transfer the file byte-by-byte to the response object
        Dim fileToDownload As New System.IO.FileInfo(value2)
        Response.Flush()
        Response.WriteFile(fileToDownload.FullName)
        '**********************************************************************************************************************
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    End Sub

    Protected Sub BTNLOAD3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNLOAD3.Click
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim CmdDownloadFile, CheckFile As String
        CmdDownloadFile = Nothing
        CheckFile = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim con_GetSO_FIle As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim cmd_GetSO_FIle As New SqlCommand
        Try
            cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" & TxtBx_SO.Text & "'"
            cmd_GetSO_FIle.Connection = con_GetSO_FIle
            con_GetSO_FIle.Open()
            Dim rd_GetSO_FIle As System.Data.SqlClient.SqlDataReader = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If rd_GetSO_FIle.Read Then
                LSTFILES3.Text = rd_GetSO_FIle("FlagFileUpload3")
                CmdDownloadFile = rd_GetSO_FIle("FlagFileUpload3")
                CheckFile = "Y"
            Else
                CheckFile = "N"
                con_GetSO_FIle.Close()
                Exit Sub
            End If
        Catch ex As Exception
            con_GetSO_FIle.Close()
            Lbl_Message.Text = "Error Download File :" & ex.ToString
            Exit Sub
        Finally
            con_GetSO_FIle.Close()
        End Try
        con_GetSO_FIle.Dispose()
        cmd_GetSO_FIle.Dispose()
        con_GetSO_FIle = Nothing
        cmd_GetSO_FIle = Nothing
        '**********************************************************************************************************************        
        Dim value1 As String = LSTFILES3.Text
        Dim value2 As String = value1.Replace("http://192.168.1.210/SAPS/", "D:\SAPS\")
        Dim value3 As String = value2 'value1.Replace("http://192.168.1.210/SAPS/", "DocNo")
        '**********************************************************************************************************************        
        'LstFiles.Text
        'Dim filename As System.String = LstFiles.Text
        Dim filename As System.String = value2 'value3

        If CheckFile = "Y" Then
            Response.Clear()
        End If

        ' set the http content type to "APPLICATION/OCTET-STREAM
        Response.ContentType = "APPLICATION/OCTET-STREAM"

        ' initialize the http content-disposition header to
        ' indicate a file attachment with the default filename
        Dim disHeader As System.String = "Attachment; Filename=""" & filename & """"
        Response.AppendHeader("Content-Disposition", disHeader)

        ' transfer the file byte-by-byte to the response object
        Dim fileToDownload As New System.IO.FileInfo(value2)
        Response.Flush()
        Response.WriteFile(fileToDownload.FullName)
        '**********************************************************************************************************************
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    End Sub

    Protected Sub BTNLOAD4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNLOAD4.Click
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim CmdDownloadFile, CheckFile As String
        CmdDownloadFile = Nothing
        CheckFile = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim con_GetSO_FIle As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim cmd_GetSO_FIle As New SqlCommand
        Try
            cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" & TxtBx_SO.Text & "'"
            cmd_GetSO_FIle.Connection = con_GetSO_FIle
            con_GetSO_FIle.Open()
            Dim rd_GetSO_FIle As System.Data.SqlClient.SqlDataReader = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If rd_GetSO_FIle.Read Then
                LSTFILES4.Text = rd_GetSO_FIle("FlagFileUpload4")
                CmdDownloadFile = rd_GetSO_FIle("FlagFileUpload4")
                CheckFile = "Y"
            Else
                CheckFile = "N"
                con_GetSO_FIle.Close()
                Exit Sub
            End If
        Catch ex As Exception
            con_GetSO_FIle.Close()
            Lbl_Message.Text = "Error Download File :" & ex.ToString
            Exit Sub
        Finally
            con_GetSO_FIle.Close()
        End Try
        con_GetSO_FIle.Dispose()
        cmd_GetSO_FIle.Dispose()
        con_GetSO_FIle = Nothing
        cmd_GetSO_FIle = Nothing
        '**********************************************************************************************************************        
        Dim value1 As String = LSTFILES4.Text
        Dim value2 As String = value1.Replace("http://192.168.1.210/SAPS/", "D:\SAPS\")
        Dim value3 As String = value2 'value1.Replace("http://192.168.1.210/SAPS/", "DocNo")
        '**********************************************************************************************************************        
        'LstFiles.Text
        'Dim filename As System.String = LstFiles.Text
        Dim filename As System.String = value2 'value3

        If CheckFile = "Y" Then
            Response.Clear()
        End If

        ' set the http content type to "APPLICATION/OCTET-STREAM
        Response.ContentType = "APPLICATION/OCTET-STREAM"

        ' initialize the http content-disposition header to
        ' indicate a file attachment with the default filename
        Dim disHeader As System.String = "Attachment; Filename=""" & filename & """"
        Response.AppendHeader("Content-Disposition", disHeader)

        ' transfer the file byte-by-byte to the response object
        Dim fileToDownload As New System.IO.FileInfo(value2)
        Response.Flush()
        Response.WriteFile(fileToDownload.FullName)
        '**********************************************************************************************************************
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    End Sub

    Protected Sub BTNLOAD5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNLOAD5.Click
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim CmdDownloadFile, CheckFile As String
        CmdDownloadFile = Nothing
        CheckFile = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim con_GetSO_FIle As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim cmd_GetSO_FIle As New SqlCommand
        Try
            cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" & TxtBx_SO.Text & "'"
            cmd_GetSO_FIle.Connection = con_GetSO_FIle
            con_GetSO_FIle.Open()
            Dim rd_GetSO_FIle As System.Data.SqlClient.SqlDataReader = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If rd_GetSO_FIle.Read Then
                LSTFILES5.Text = rd_GetSO_FIle("FlagFileUpload5")
                CmdDownloadFile = rd_GetSO_FIle("FlagFileUpload5")
                CheckFile = "Y"
            Else
                CheckFile = "N"
                con_GetSO_FIle.Close()
                Exit Sub
            End If
        Catch ex As Exception
            con_GetSO_FIle.Close()
            Lbl_Message.Text = "Error Download File :" & ex.ToString
            Exit Sub
        Finally
            con_GetSO_FIle.Close()
        End Try
        con_GetSO_FIle.Dispose()
        cmd_GetSO_FIle.Dispose()
        con_GetSO_FIle = Nothing
        cmd_GetSO_FIle = Nothing
        '**********************************************************************************************************************        
        Dim value1 As String = LSTFILES5.Text
        Dim value2 As String = value1.Replace("http://192.168.1.210/SAPS/", "D:\SAPS\")
        'Dim value3 As String = value1.Replace("http://192.168.1.210/SAPS/", "DocNo")
        '**********************************************************************************************************************        
        'LstFiles.Text
        'Dim filename As System.String = LstFiles.Text
        Dim filename As System.String = value2 'value3

        If CheckFile = "Y" Then
            Response.Clear()
        End If

        ' set the http content type to "APPLICATION/OCTET-STREAM
        Response.ContentType = "APPLICATION/OCTET-STREAM"

        ' initialize the http content-disposition header to
        ' indicate a file attachment with the default filename
        Dim disHeader As System.String = "Attachment; Filename=""" & filename & """"
        Response.AppendHeader("Content-Disposition", disHeader)

        ' transfer the file byte-by-byte to the response object
        Dim fileToDownload As New System.IO.FileInfo(value2)
        Response.Flush()
        Response.WriteFile(fileToDownload.FullName)
        '**********************************************************************************************************************
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    End Sub

    Protected Sub BTNLOAD6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNLOAD6.Click
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim CmdDownloadFile, CheckFile As String
        CmdDownloadFile = Nothing
        CheckFile = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim con_GetSO_FIle As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim cmd_GetSO_FIle As New SqlCommand
        Try
            cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" & TxtBx_SO.Text & "'"
            cmd_GetSO_FIle.Connection = con_GetSO_FIle
            con_GetSO_FIle.Open()
            Dim rd_GetSO_FIle As System.Data.SqlClient.SqlDataReader = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If rd_GetSO_FIle.Read Then
                LSTFILES6.Text = rd_GetSO_FIle("FlagFileUpload6")
                CmdDownloadFile = rd_GetSO_FIle("FlagFileUpload6")
                CheckFile = "Y"
            Else
                CheckFile = "N"
                con_GetSO_FIle.Close()
                Exit Sub
            End If
        Catch ex As Exception
            con_GetSO_FIle.Close()
            Lbl_Message.Text = "Error Download File :" & ex.ToString
            Exit Sub
        Finally
            con_GetSO_FIle.Close()
        End Try
        con_GetSO_FIle.Dispose()
        cmd_GetSO_FIle.Dispose()
        con_GetSO_FIle = Nothing
        cmd_GetSO_FIle = Nothing
        '**********************************************************************************************************************        
        Dim value1 As String = LSTFILES6.Text
        Dim value2 As String = value1.Replace("http://192.168.1.210/SAPS/", "D:\SAPS\")
        Dim value3 As String = value2 'value1.Replace("http://192.168.1.210/SAPS/", "DocNo")
        '**********************************************************************************************************************        
        'LstFiles.Text
        'Dim filename As System.String = LstFiles.Text
        Dim filename As System.String = value2 'value3

        If CheckFile = "Y" Then
            Response.Clear()
        End If

        ' set the http content type to "APPLICATION/OCTET-STREAM
        Response.ContentType = "APPLICATION/OCTET-STREAM"

        ' initialize the http content-disposition header to
        ' indicate a file attachment with the default filename
        Dim disHeader As System.String = "Attachment; Filename=""" & filename & """"
        Response.AppendHeader("Content-Disposition", disHeader)

        ' transfer the file byte-by-byte to the response object
        Dim fileToDownload As New System.IO.FileInfo(value2)
        Response.Flush()
        Response.WriteFile(fileToDownload.FullName)
        '**********************************************************************************************************************
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    End Sub

    Protected Sub BTNLOAD7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNLOAD7.Click
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim CmdDownloadFile, CheckFile As String
        CmdDownloadFile = Nothing
        CheckFile = Nothing
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim con_GetSO_FIle As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim cmd_GetSO_FIle As New SqlCommand
        Try
            cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" & TxtBx_SO.Text & "'"
            cmd_GetSO_FIle.Connection = con_GetSO_FIle
            con_GetSO_FIle.Open()
            Dim rd_GetSO_FIle As System.Data.SqlClient.SqlDataReader = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            If rd_GetSO_FIle.Read Then
                LSTFILES7.Text = rd_GetSO_FIle("FlagFileUpload7")
                CmdDownloadFile = rd_GetSO_FIle("FlagFileUpload7")
                CheckFile = "Y"
            Else
                CheckFile = "N"
                con_GetSO_FIle.Close()
                Exit Sub
            End If
        Catch ex As Exception
            con_GetSO_FIle.Close()
            Lbl_Message.Text = "Error Download File :" & ex.ToString
            Exit Sub
        Finally
            con_GetSO_FIle.Close()
        End Try
        con_GetSO_FIle.Dispose()
        cmd_GetSO_FIle.Dispose()
        con_GetSO_FIle = Nothing
        cmd_GetSO_FIle = Nothing
        '**********************************************************************************************************************        
        Dim value1 As String = LSTFILES7.Text
        Dim value2 As String = value1.Replace("http://192.168.1.210/SAPS/", "D:\SAPS\")
        Dim value3 As String = value2 'value1.Replace("http://192.168.1.210/SAPS/", "DocNo")
        '**********************************************************************************************************************        
        'LstFiles.Text
        'Dim filename As System.String = LstFiles.Text
        Dim filename As System.String = value2 'value3

        If CheckFile = "Y" Then
            Response.Clear()
        End If

        ' set the http content type to "APPLICATION/OCTET-STREAM
        Response.ContentType = "APPLICATION/OCTET-STREAM"

        ' initialize the http content-disposition header to
        ' indicate a file attachment with the default filename
        Dim disHeader As System.String = "Attachment; Filename=""" & filename & """"
        Response.AppendHeader("Content-Disposition", disHeader)

        ' transfer the file byte-by-byte to the response object
        Dim fileToDownload As New System.IO.FileInfo(value2)
        Response.Flush()
        Response.WriteFile(fileToDownload.FullName)
        '**********************************************************************************************************************
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    End Sub

    Protected Sub Btn_SO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_SO.Click
        Response.Redirect("form_sales_order_dept1.aspx")
    End Sub
End Class
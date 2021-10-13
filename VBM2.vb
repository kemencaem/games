Imports RestSharp
Imports Newtonsoft.Json

Public Class Category_Details
    <JsonProperty("id")>
    Public Property CatId As Integer
    <JsonProperty("parent_id")>
    Public Property CatParentId As Integer
    <JsonProperty("name")>
    Public Property CatName As String
    <JsonProperty("is_active")>
    Public Property CatIsActive As Boolean
    <JsonProperty("position")>
    Public Property CatPosition As Integer
    <JsonProperty("level")>
    Public Property CatLevel As Integer
    <JsonProperty("children")>
    Public Property CatChildren As String
    <JsonProperty("created_at")>
    Public Property CatCreatedAt As String
    <JsonProperty("updated_at")>
    Public Property CatUpdatedAt As String
    <JsonProperty("path")>
    Public Property CatPath As String
    <JsonProperty("available_sort_by")>
    Public Property CatAvailableSortBy As IList(Of String)
    <JsonProperty("include_in_menu")>
    Public Property CatIncludeInMenu As Boolean
End Class

Public Class C_Details
    <JsonProperty("category")>
    Public Property Category As Category_Details
End Class


Public Class Login_Details
        Public Property User As String
        Public Property Pass As String
    End Class

    Public Class Product_Details
        <JsonProperty("id")>
        Public Property Product_ID As Integer

        <JsonProperty("status")>
        Public Property Product_STATUS As Integer

        <JsonProperty("visibility")>
        Public Property Product_VISBLTY As Integer

        <JsonProperty("name")>
        Public Property Product_NAME As String

        <JsonProperty("price")>
        Public Property Product_PRICE As Integer

        <JsonProperty("sku")>
        Public Property Product_SKU As String
    End Class

Public Class SItem
    <JsonProperty("item_id", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_ID As Integer?
    <JsonProperty("product_id", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_PID As Integer?
    <JsonProperty("stock_id", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_SID As Integer?
    <JsonProperty("qty", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_Qtty As Integer
    <JsonProperty("is_in_stock", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_InStock As Boolean
    <JsonProperty("is_qty_decimal", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_Decimal As Boolean?
    <JsonProperty("show_default_notification_message", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_SDNM As Boolean?
    <JsonProperty("use_config_min_qty", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_UCNQ As Boolean?
    <JsonProperty("min_qty", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_MQtty As Integer?
    <JsonProperty("use_config_min_sale_qty", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_UCMSQtty As Integer?
    <JsonProperty("min_sale_qty", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_MaxSQtty As Integer?
    <JsonProperty("use_config_max_sale_qty", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_UCMSQ As Boolean?
    <JsonProperty("max_sale_qty", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_MinSQtty As Integer?
    <JsonProperty("use_config_backorders", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_UCB As Boolean?
    <JsonProperty("backorders", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_BO As Integer?
    <JsonProperty("use_config_notify_stock_qty", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_UCNSQtty As Boolean?
    <JsonProperty("notify_stock_qty", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_NSQtty As Integer?
    <JsonProperty("use_config_qty_increments", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_UCQttyInc As Boolean?
    <JsonProperty("qty_increments", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_QttyInc As Integer?
    <JsonProperty("use_config_enable_qty_inc", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_UCEQttyInc As Boolean?
    <JsonProperty("enable_qty_increments", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_EQttyInc As Boolean?
    <JsonProperty("use_config_manage_stock", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_UCMS As Boolean?
    <JsonProperty("manage_stock", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_MS As Boolean?
    <JsonProperty("low_stock_date", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_LSD As Object
    <JsonProperty("is_decimal_divided", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_IDD As Boolean?
    <JsonProperty("stock_status_changed_auto", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property S_SSCA As Integer?
End Class


Public Class SET_SKU
    <JsonProperty("stockItem")>
    Public Property SKU_SItem As SItem
End Class

Public Class VBM2

        Private Property Rest_Client As RestClient

        'Creates a new Interogation for the REST API with a mode 
        Private Function Interogate(ByVal zone As String, ByVal mode As Method) As RestRequest
            Dim ask = New RestRequest(zone, mode)
            ask.RequestFormat = DataFormat.Json
            Return ask
        End Function


    Private Function NewInterogation(ByVal WHERE As String, ByVal mode As Method, ByVal KEY_Token As String) As RestRequest
        Dim ask = New RestRequest(WHERE, mode)
        ask.RequestFormat = DataFormat.Json
        ask.AddHeader("Authorization", "Bearer " & KEY_Token)
        ask.AddHeader("Accept", "application/json")
        Return ask
    End Function


    ' Gets the Administrator Token must supply username and password
    ' path_REST_API = REST API Administrator token path
    Public Function ReadToken(ByVal u_name As String, ByVal p_word As String) As String
            Dim DataX = New Login_Details()
            Dim path_REST_API As String
            path_REST_API = "/rest/V1/integration/admin/token"
            Dim ask = Interogate(path_REST_API, Method.POST)
            DataX.User = u_name
            DataX.Pass = p_word
        Dim json As String = JsonConvert.SerializeObject(uname, Formatting.Indented)
        ask.AddParameter("application/json", json, ParameterType.RequestBody)
            Dim answer = Rest_Client.Execute(ask)
            If answer.StatusCode = 200 Then
                Return answer.Content
            Else
                Return answer.StatusCode
            End If
        End Function

        Public Sub New(ByVal URLWebPage As String)
            Rest_Client = New RestClient(URLWebPage)
        End Sub

        Public Sub New(ByVal URLWebPage As String, ByVal Key_Token As String)
            Rest_Client = New RestClient(URLWebPage)
            Key_Token = Key_Token
        End Sub

        'imports SKU from product
        Public Sub Import_SKU(ByVal Key_Token As String, ByVal number_SKU As String)
            Dim path_REST_API As String
            path_REST_API = "/rest/V1/products/" & number_SKU
        Dim ask = NewInterogation(path_REST_API, Method.[GET], Key_Token)
        Dim answer = Rest_Client.Execute(ask)
            If answer.StatusCode = 200 Then
                Dim product As Product_Details = JsonConvert.DeserializeObject(Of Product_Details)(answer.Content)
            Else
                ' if you need to do something else in case of error
            End If
        End Sub

    'Makes a new category in Magento 2
    Public Sub MakeCategory(ByVal categ As String)
        Dim path_REST_API As String
        path_REST_API = "/rest/V1/categories"
        Dim ask = NewInterogation(path_REST_API, Method.POST, Key_Token)
        Dim cat = New C_Details
        Dim c = New Category_Details
        c.CatName = categ
        cat.Category = c
        Dim json As String = JsonConvert.SerializeObject(cat, Formatting.Indented)
        ask.AddParameter("application/json", json, ParameterType.RequestBody)
        Dim answer = Rest_Client.Execute(ask)
        If answer.StatusCode = 200 Then
            'case ok do something here
        Else
            ' if you need to do something else in case of error
        End If
    End Sub

    Public Sub ImportAllOrders(ByVal Key_Token As String)
        Dim path_REST_API As String
        path_REST_API = "/rest/V1/orders/?searchCriteria" ' you can modify the filters and searchCriteria from here 
        Dim ask = NewInterogation(path_REST_API, Method.[GET], Key_Token)
        Dim answer = Rest_Client.Execute(ask)
        Form1.ListView1.Items.Clear()

        If answer.StatusCode = 200 Then
            Dim read = Linq.JObject.Parse(answer.Content)
            Form1.TextBox1.Text = answer.Content
            For ii As Integer = 0 To Val(read.Item("total_count").ToString) - 1 Step 1
                For jj As Integer = 0 To 100 Step 1 'increase if you think you have more than 100 products on 1 order
                    Try
                        Dim abx As New ListViewItem(read.Item("items")(ii)("items")(jj)("name").ToString)
                        abx.SubItems.Add(read.Item("items")(ii)("items")(jj)("price").ToString)
                        abx.SubItems.Add(read.Item("items")(ii)("items")(jj)("qty_ordered").ToString)
                        Form1.ListView1.Items.Add(abx)
                    Catch
                        GoTo 1
                    End Try
                Next
1:
            Next
        End If
    End Sub

    ' set proguct qntty for a specified product SKU
    Public Function SetProductQty(ByVal setX As SET_SKU, ByVal nameX As String) As Boolean
        Dim path_REST_API As String
        path_REST_API = "/rest/V1/products/" & nameX & "/stockItems/" & setX.SKU_SItem.S_ID
        Dim ask = NewInterogation(path_REST_API, Method.PUT, Key_Token)
        Dim json As String = JsonConvert.SerializeObject(setX, Formatting.Indented)
        ask.AddParameter("application/json", json, ParameterType.RequestBody)
        Dim answer = Rest_Client.Execute(ask)
        If answer.StatusCode = 200 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class

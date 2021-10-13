Public Class Form1

    Private Shared Sub MakeCategory(ByVal categ As String)
        Dim vbm2 = New VBM2(URLAddress, Key_Token)
        vbm2.MakeCategory(categ)
    End Sub
    Private Shared Sub ImportAllOrders(ByVal token As String)
        Dim vbm2 = New VBM2(URLAddress)
        vbm2.ImportAllOrders(token)
    End Sub
    Private Shared Sub SetProductQty(ByVal qtty As String, ByVal skuprd As String)
        Dim vbm2 = New VBM2(URLAddress, Key_Token)
        Dim update_this_sku = New SET_SKU
        Dim sku = New SItem
        sku.S_ID = 2
        sku.S_InStock = True
        sku.S_Qtty = qtty
        update_this_sku.SKU_SItem = sku
        Dim result = vbm2.SetProductQty(update_this_sku, skuprd)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        URLAddress = String.Format(URLAddress, ip_address)
        MakeCategory(TextBox2.Text)
        MsgBox("Done!")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        URLAddress = String.Format(URLAddress, ip_address)
        SetProductQty(TextBox4.Text, TextBox3.Text)
        MsgBox("Done!")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ImportAllOrders(Key_Token)
        MsgBox("Done!")
    End Sub
End Class

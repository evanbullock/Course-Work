''''''''THIS IS MY VERSION OF THE EQUIPMENT RENTAL SYSTEM for THE UREC.
' HANDSWIPE TECHNOLOGY, and BAR SCANNER TECHNOLOGY WOULD BE USED but
' I did not test the validity of them. If i had the tech i wouldve tested them.
'updates could be made in the future for security and fixes.
'
'
'By no means is this system perfect, it has flaws but thats how every 1st version of a system has.
'
'
'
'If I had more time , There are a list of more things i would implement and/or changed, but I am happy with what I have so far.
'
'This is over 1000 lines of code, but alot of it is repetitive.
'
'
'
'
'
'I also think the security on this system is very weak, but this isnt designed for security.
'I could definitely gain access to this system by just running a looped script until a username and password is found.
'
'
'

'SQLServer->ASP.NET->PowerBI
'
'THANKS FOR READING MY NONSENSE COMMENTS NOW ENJOY;)
'
'BUT ARE IS ANYBODY GOING TO READ THIS?
'
'-Evan




''Username=Admin
''Password=AdminPass
Imports System.Data
Imports System.Data.SqlClient
Partial Class EquipmentRentalUREC
    Inherits System.Web.UI.Page

    ''AWHOLEBUNCHOFDATATABLES,ADAPTERS,COMMANDBUILDERS,and one connection.
    Public Shared con As New SqlConnection("Data Source = cb-ot-devst04.ad.wsu.edu;Initial Catalog = MF325191evanbullock;Persist Security Info = True; User ID = evanbullock; Password = !@#qWe11559661;")
    Public Shared daPass As New SqlDataAdapter("SELECT * FROM Password", con)
    Public Shared sbPass As New SqlCommandBuilder(daPass)
    Public Shared dtPass As New DataTable

    Public Shared daInv As New SqlDataAdapter("SELECT * FROM InventoryIn", con)
    Public Shared sbInv As New SqlCommandBuilder(daInv)
    Public Shared dtInv As New DataTable

    Public Shared dtInvAval As New DataTable

    Public Shared daInvCats As New SqlDataAdapter("SELECT DISTINCT Category FROM InventoryIn", con)
    Public Shared sbInvCats As New SqlCommandBuilder(daInvCats)
    Public Shared dtInvCats As New DataTable


    Public Shared daOut As New SqlDataAdapter("SELECT * FROM InventoryIn where CheckedOut=1", con)
    Public Shared sbOut As New SqlCommandBuilder(daOut)
    Public Shared dtOut As New DataTable

    Public Shared daUsage As New SqlDataAdapter("SELECT * FROM EquipmentUsage", con)
    Public Shared sbUsage As New SqlCommandBuilder(daUsage)
    Public Shared dtUsage As New DataTable

    Public Shared daUsagefilter As New SqlDataAdapter("SELECT * FROM EquipmentUsage where Returned =0", con)
    Public Shared sbUsagefilter As New SqlCommandBuilder(daUsagefilter)
    Public Shared dtUsagefilter As New DataTable

    Public Shared daPatrons As New SqlDataAdapter("SELECT * FROM Patrons", con)
    Public Shared sbPatrons As New SqlCommandBuilder(daPatrons)
    Public Shared dtPatrons As New DataTable

    Public Shared daCharges As New SqlDataAdapter("SELECT * FROM Charges", con)
    Public Shared sbCharges As New SqlCommandBuilder(daCharges)
    Public Shared dtCharges As New DataTable



    Public Shared IDtemp ' not used but dont want to delete
    Private Sub EquipmentRentalUREC_Init(sender As Object, e As EventArgs) Handles Me.Init
        MultiView1.SetActiveView(View1)

        daInv.FillSchema(dtInv, SchemaType.Mapped)
        daInv.Fill(dtInv)

        daUsagefilter.FillSchema(dtUsagefilter, SchemaType.Mapped)
        daUsagefilter.Fill(dtUsagefilter)

        daUsage.FillSchema(dtUsage, SchemaType.Mapped)
        daUsage.Fill(dtUsage)

        daPatrons.FillSchema(dtPatrons, SchemaType.Mapped)
        daPatrons.Fill(dtPatrons)

        daOut.FillSchema(dtOut, SchemaType.Mapped)
        daOut.Fill(dtOut)

        daInvCats.FillSchema(dtInvCats, SchemaType.Mapped)
        daInvCats.Fill(dtInvCats)

        daCharges.FillSchema(dtCharges, SchemaType.Mapped)
        daCharges.Fill(dtCharges)




        Try
            With DropDownList1
                .DataSource = dtInvCats
                .DataTextField = "Category"
                .DataValueField = "Category"
                .DataBind()
            End With
            With DropDownList11
                .DataSource = dtInvCats
                .DataTextField = "Category"
                .DataValueField = "Category"
                .DataBind()
            End With

            With DropDownList12
                .DataSource = dtInv
                .DataTextField = "ItemType"
                .DataValueField = "ItemCode"
                .DataBind()
            End With
            With DropDownList5
                .DataSource = dtUsagefilter
                .DataTextField = "ItemType"
                .DataValueField = "ItemCode"
                .DataBind()
            End With
            With DropDownList4
                .DataSource = dtUsagefilter
                .DataTextField = "ItemType"
                .DataValueField = "ItemCode"
                .DataBind()
            End With
            With DropDownList7
                .DataSource = dtPatrons
                .DataTextField = "PatronName"
                .DataValueField = "PatronID"
                .DataBind()

            End With
            GridView1.DataSource = dtUsagefilter
            GridView1.DataBind()
            GridView2.DataSource = dtUsagefilter
            GridView2.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        If dtInvAval.Columns.Count > 0 Then Exit Sub
        dtInvAval.Columns.Add("Type", GetType(String))
        dtInvAval.Columns.Add("ItemCode", GetType(String))
    End Sub


    ''PASSWORD LOGIN !
    '
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim user As String = TextBox2.Text
        Dim pass As String = TextBox1.Text
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim passcmd As New SqlCommand("SELECT UserID,Password from Password where UserID=@p1 and Password =@p2", con)
            With passcmd.Parameters
                .Clear()
                .AddWithValue("@p1", user)
                .AddWithValue("@p2", pass)
            End With
            daPass = New SqlDataAdapter(passcmd)
            daPass.Fill(dtPass) 'fill with potential passwords
            If (dtPass.Rows.Count > 0) Then 'if any rows are filled that means the userid and pass matched and were found.
                'correct
                Response.Write("Login successful.")

                MultiView1.SetActiveView(View2)
            Else
                'false
                'userid and/or password not found
                Label1.Visible = True
                TextBox1.Text = ""
            End If
        Catch ex As Exception

        Finally
            con.Close()
        End Try

    End Sub
    '


    'enter Patron ID BUTTON CLICK for Checking out items
    'technically this would cause an error if patron ID is not stored already, but This is something i figured out last minute.
    '-> this would be fixed in system updates in the future.
    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox3.Text = "" And TextBox4.Text = "" Then
            'no patron id entered
            Label6.Visible = True
            Label7.Visible = True
            Exit Sub
        End If
        If TextBox3.Text IsNot "" And TextBox4.Text = "" Then

            IDtemp = TextBox3.Text
        End If
        If TextBox3.Text = "" And TextBox4.Text IsNot "" Then
            IDtemp = TextBox4.Text

        End If
        If TextBox3.Text IsNot "" And TextBox4.Text IsNot "" Then
            'both fields were filled, handswipe overrides
            IDtemp = TextBox3.Text

        End If
        Label6.Visible = False
        Label7.Visible = False
        MultiView3.SetActiveView(View9)
    End Sub

    'view for check out in
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dtInvCats.Rows.Clear()
        daInvCats.Fill(dtInvCats) 'dt Fill for InvCategories,refreshed data




        With DropDownList1
                .DataSource = dtInvCats
                .DataTextField = "Category"
                .DataValueField = "Category"
                .DataBind()
            End With
            MultiView2.SetActiveView(View4)
    End Sub

    'DROPDOWN LIST CATEGORIES and ITEMS REFRESHING FOR CHECKING OUT ITEM
    'Load 2nd drop downlist with items based of selected category
    'retrieved some help code from:::::
    'https://www.codeguru.com/columns/vb/using-parameterized-queries-and-reports-in-vb.net-database-applications.htm
    'THIS WAS THE HARDEST THING TO FIGURE OUT FROM TEH PROJECT!
    'Reused SQLreader consistently with rest of system
    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        'clear old rows
        dtInvAval.Rows.Clear()
        'search for items
        Dim searchItemscmd As New SqlCommand("SELECT * FROM InventoryIn where Category=@p1 and CheckedOut=0", con)
        searchItemscmd.Parameters.AddWithValue("p1", DropDownList1.SelectedValue)
        Try
            con.Open()
            'create reader to find values
            Dim readerItems As SqlDataReader = searchItemscmd.ExecuteReader()
            'if any values are true 
            If readerItems.HasRows Then
                'while looping store each found item as row into datatable
                While readerItems.Read()
                    Dim dr As DataRow = dtInvAval.NewRow
                    dr.Item("Type") = readerItems.GetString(2) '(2) is the itemtype column

                    dr.Item("ItemCode") = readerItems.GetString(3) '(3) is the itemCode Column
                    dtInvAval.Rows.Add(dr) 'addinto dt

                End While
                'now fill the below dropdown with values found by the reader
                With DropDownList2
                    .DataSource = dtInvAval
                    .DataTextField = "Type"
                    .DataValueField = "ItemCode"
                    .DataBind()
                End With


            End If

        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try
        'i tried many different ways, at one point i had 5 different try statements with code commented out here.
        'This was the way that i found that work
    End Sub

    'view check in standard
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'check in 
        dtInv.Rows.Clear()
        daInv.Fill(dtInv) 'refill for refreshed data
        dtUsagefilter.Rows.Clear()
        daUsagefilter.Fill(dtUsagefilter)
        GridView1.DataSource = dtUsagefilter
        GridView1.DataBind()
        'refill drop downs
        With DropDownList5
            .DataSource = dtUsagefilter
            .DataTextField = "ItemType"
            .DataValueField = "ItemCode"
            .DataBind()
        End With
        With DropDownList4
            .DataSource = dtUsagefilter
            .DataTextField = "ItemType"
            .DataValueField = "ItemCode"
            .DataBind()
        End With
        DropDownList4.Visible = False

        Label14.Visible = False
        Label4.Visible = False
        Label11.Visible = False
        Label15.Visible = False

        If dtUsagefilter.Rows.Count < 1 Then
            Label14.Visible = True

        End If
        MultiView2.SetActiveView(View5)
    End Sub



    'view manual check in
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'manual check in 
        dtInv.Rows.Clear()
        daInv.Fill(dtInv)
        dtUsagefilter.Rows.Clear()
        daUsagefilter.Fill(dtUsagefilter)
        GridView1.DataSource = dtUsagefilter
        GridView1.DataBind()
        'refill drop downs
        With DropDownList5
            .DataSource = dtUsagefilter
            .DataTextField = "ItemType"
            .DataValueField = "ItemCode"
            .DataBind()
        End With
        With DropDownList4
            .DataSource = dtUsagefilter
            .DataTextField = "ItemType"
            .DataValueField = "ItemCode"
            .DataBind()
        End With

        Label12.Visible = False

        Label13.Visible = False
        If dtUsagefilter.Rows.Count < 1 Then
            Label13.Visible = True

        End If
        MultiView2.SetActiveView(View6)

    End Sub


    'manual check in item button click
    Protected Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim item = DropDownList5.SelectedItem
        Dim id = DropDownList5.SelectedValue
        ''update, reload, view data, refill
        Call returnManualUpdate()
        dtInv.Rows.Clear()
        daInv.Fill(dtInv)
        dtUsagefilter.Rows.Clear()
        daUsagefilter.Fill(dtUsagefilter)
        GridView1.DataSource = dtUsagefilter
        GridView1.DataBind()
        'refill drop downs
        With DropDownList5
            .DataSource = dtUsagefilter
            .DataTextField = "ItemType"
            .DataValueField = "ItemCode"
            .DataBind()
        End With
        With DropDownList4
            .DataSource = dtUsagefilter
            .DataTextField = "ItemType"
            .DataValueField = "ItemCode"
            .DataBind()
        End With
        Label12.Visible = True

    End Sub

    ''check in manually update 
    Private Sub returnManualUpdate()
        Dim cmdUpdateReport As New SqlCommand("UPDATE EquipmentUsage SET Returned=1 WHERE ItemCode= @p3", con)
        Dim cmdUpdateInv As New SqlCommand("UPDATE InventoryIn SET CheckedOut=0 WHERE ItemCode= @p2", con)

        With cmdUpdateReport.Parameters
            .Clear()
            .AddWithValue("@p3", DropDownList5.SelectedValue)


        End With
        With cmdUpdateInv.Parameters
            .Clear()
            .AddWithValue("@p2", DropDownList5.SelectedValue)


        End With
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmdUpdateReport.ExecuteNonQuery()
            cmdUpdateInv.ExecuteNonQuery()

        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    'view for charge/damage
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'charge damage item
        dtInv.Rows.Clear()
        daInv.Fill(dtInv)
        dtUsagefilter.Rows.Clear()
        daUsagefilter.Fill(dtUsagefilter)
        GridView2.DataSource = dtUsagefilter
        GridView2.DataBind()
        'refill drop downs
        With DropDownList5
            .DataSource = dtUsagefilter
            .DataTextField = "ItemType"
            .DataValueField = "ItemCode"
            .DataBind()
        End With
        With DropDownList4
            .DataSource = dtUsagefilter
            .DataTextField = "ItemType"
            .DataValueField = "ItemCode"
            .DataBind()
        End With
        'show ID
        TextBox30.Text = DropDownList7.SelectedValue
        MultiView2.SetActiveView(View7)

    End Sub
    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'admin 
        MultiView2.SetActiveView(View8)
        MultiView4.SetActiveView(View10)

    End Sub
    Protected Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If TextBox11.Text = "AdminPass" Then
            MultiView4.SetActiveView(View11)
        Else
            Response.Write("Admin Password not correct!")
            Label8.Visible = True
        End If
    End Sub

    'admin views
    Protected Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        'powerbi charts
        MultiView5.SetActiveView(View12)
    End Sub

    'add/remove view
    Protected Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        MultiView5.SetActiveView(View13)
        'add/remove
    End Sub

    'edit view
    Protected Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        MultiView5.SetActiveView(View14)

        'edit
    End Sub

    'patron info view
    Protected Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        MultiView2.SetActiveView(View15)
        'patron info
    End Sub

    'view patron table
    Protected Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        GridView3.DataSource = dtPatrons
        GridView3.DataBind()
    End Sub

    'find patron information
    'retrieved some help code from:::::
    'https://www.codeguru.com/columns/vb/using-parameterized-queries-and-reports-in-vb.net-database-applications.htm
    'I used this many this code many times because it was very useful for my case. I am sourcing it here ^^^^^^
    Protected Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim id As String
        id = TextBox20.Text
        'make text empty
        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox29.Text = ""
        'sql command with parameter
        Dim searchpatroncmd As New SqlCommand("SELECT * FROM Patrons where PatronID=@p1", con)
        searchpatroncmd.Parameters.AddWithValue("p1", id)
        Try
            con.Open()
            'create reader to find values
            Dim reader As SqlDataReader = searchpatroncmd.ExecuteReader()
            'if any values are true 
            If reader.HasRows Then
                'loop while reading, store all values
                'note issues could happen if patronIDs are the same value, but this shouldn't occur
                While reader.Read()
                    TextBox21.Text = reader.GetString(1) 'name
                    TextBox22.Text = reader.GetString(2) 'email
                    TextBox23.Text = reader.GetString(3) 'phone
                    TextBox29.Text = reader.GetSqlBoolean(4) 'mem status

                End While
            Else
                'none found
                Label9.Visible = True

            End If

        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()

        End Try




    End Sub

    'store patron information
    Protected Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        'error check
        Label10.Visible = False

        If TextBox25.Text = Nothing Or CheckBoxList2.SelectedValue = Nothing Or TextBox26.Text = Nothing Or TextBox27.Text = Nothing Or TextBox28.Text = Nothing Then
            Response.Write("Check Data Entries")
            Exit Sub
        End If
        'datarow input stuff
        Dim dr As DataRow = dtPatrons.NewRow
        dr.Item("PatronID") = TextBox25.Text
        dr.Item("PatronName") = TextBox26.Text
        dr.Item("Email") = TextBox27.Text
        dr.Item("Phone") = TextBox28.Text

        dr.Item("memStatus") = CheckBoxList2.SelectedValue

        'add to table
        dtPatrons.Rows.Add(dr)


        Try
            'update data table and view
            daPatrons.Update(dtPatrons)
            dtPatrons.Rows.Clear()
            daPatrons.Fill(dtPatrons)
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        Label10.Visible = True

    End Sub



    'check in equipment button click 
    Protected Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'if no fields or filled
        Label15.Visible = False
        If TextBox7.Text = "" And DropDownList4.SelectedIndex < 0 And DropDownList4.Visible = True Then
            Response.Write("Check entries!")
            Exit Sub
        End If

        'if both fields are filled
        If TextBox7.Text IsNot "" And DropDownList4.SelectedIndex > -1 And DropDownList4.Visible = True > 0 Then
            Label15.Visible = True
            'show user error
            'make the field blank
            TextBox7.Text = ""
            'hide the ddl
            DropDownList4.Visible = False
            Exit Sub
        End If

        'if scanned 
        If TextBox7.Text IsNot "" And DropDownList4.Visible = False Then
            'update, reload dt's, view data,
            Call returnScanUpdate()
            dtInv.Rows.Clear()
            daInv.Fill(dtInv)
            dtUsagefilter.Rows.Clear()
            daUsagefilter.Fill(dtUsagefilter)
            GridView1.DataSource = dtUsagefilter
            GridView1.DataBind()
            'refill drop downs
            With DropDownList5
                .DataSource = dtUsagefilter
                .DataTextField = "ItemType"
                .DataValueField = "ItemCode"
                .DataBind()
            End With
            With DropDownList4
                .DataSource = dtUsagefilter
                .DataTextField = "ItemType"
                .DataValueField = "ItemCode"
                .DataBind()
            End With
            TextBox7.Text = ""
            Label11.Visible = True
        End If

        'if ddl is used and selected
        If DropDownList4.Visible = True And DropDownList4.SelectedIndex > -1 Then
            'update, reload dt's, view data,
            Call returnNonScanUpdate()
            dtInv.Rows.Clear()
            daInv.Fill(dtInv)
            dtUsagefilter.Rows.Clear()
            daUsagefilter.Fill(dtUsagefilter)
            GridView1.DataSource = dtUsagefilter
            GridView1.DataBind()
            'refill drop downs
            With DropDownList5
                .DataSource = dtUsagefilter
                .DataTextField = "ItemType"
                .DataValueField = "ItemCode"
                .DataBind()
            End With
            With DropDownList4
                .DataSource = dtUsagefilter
                .DataTextField = "ItemType"
                .DataValueField = "ItemCode"
                .DataBind()
            End With
            TextBox7.Text = ""
            Label11.Visible = True
        End If
    End Sub

    'check in item inventory update with scanner
    Private Sub returnScanUpdate()
        Dim cmdUpdateReport As New SqlCommand("UPDATE EquipmentUsage SET Returned=1 WHERE ItemCode= @p3", con)
        Dim cmdUpdateInv As New SqlCommand("UPDATE InventoryIn SET CheckedOut=0 WHERE ItemCode= @p2", con)

        With cmdUpdateReport.Parameters
            .Clear()
            .AddWithValue("@p3", TextBox7.Text)


        End With
        With cmdUpdateInv.Parameters
            .Clear()
            .AddWithValue("@p2", TextBox7.Text)


        End With
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmdUpdateReport.ExecuteNonQuery()
            cmdUpdateInv.ExecuteNonQuery()

        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    'check in item inventory update without scanner
    Private Sub returnNonScanUpdate()
        Dim cmdUpdateReport As New SqlCommand("UPDATE EquipmentUsage SET Returned=1 WHERE ItemCode= @p3", con)
        Dim cmdUpdateInv As New SqlCommand("UPDATE InventoryIn SET CheckedOut=0 WHERE ItemCode= @p2", con)

        With cmdUpdateReport.Parameters
            .Clear()
            .AddWithValue("@p3", DropDownList4.SelectedValue)


        End With
        With cmdUpdateInv.Parameters
            .Clear()
            .AddWithValue("@p2", DropDownList4.SelectedValue)


        End With
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmdUpdateReport.ExecuteNonQuery()
            cmdUpdateInv.ExecuteNonQuery()

        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub




    'view dropdownlist for check in
    Protected Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        DropDownList4.Visible = True
    End Sub



    'check out item!Button Click
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Label16.Visible = False
        Label5.Visible = False
        Dim itemnum As String
        Dim category As String
        Dim itemtype As String
        Dim checkedout As Boolean



        'manual input
        If TextBox5.Text Is "" Then
            'create row, fill row, add row, update, reload dt, reset variables/tools used
            Dim dr As DataRow = dtUsage.NewRow
            dr.Item("PatronID") = IDtemp.ToString()
            dr.Item("Category") = DropDownList1.SelectedValue
            dr.Item("ItemType") = DropDownList2.SelectedItem.ToString()
            dr.Item("ItemCode") = DropDownList2.SelectedValue.ToString()
            dr.Item("DateUsed") = Today
            dr.Item("Returned") = False
            dtUsage.Rows.Add(dr)
            Call CheckoutNonScanUpdate()
            daUsage.Update(dtUsage)
            dtUsage.Rows.Clear()
            daUsage.Fill(dtUsage)
            dtUsagefilter.Rows.Clear()
            daUsagefilter.Fill(dtUsagefilter)
            Label16.Visible = True
            TextBox3.Text = ""
            TextBox4.Text = ""
            DropDownList1.SelectedIndex = -1
            DropDownList2.SelectedIndex = -1
        End If



        'scan code input
        If TextBox5.Text IsNot "" Then
            'this part will be rough, essentially we have to search our SQL database for all the other fields other than the code itself
            'reusing similiar code from above
            Dim searchbycode As New SqlCommand("SELECT * FROM InventoryIn where ItemCode=@p1 and CheckedOut=0", con)
            searchbycode.Parameters.AddWithValue("p1", TextBox5.Text.ToString())
            Try
                con.Open()
                'create reader to find values
                Dim reader As SqlDataReader = searchbycode.ExecuteReader()
                'if any values are true 
                If reader.HasRows Then
                    'loop while reading, store all values

                    While reader.Read()
                        itemnum = reader.GetSqlInt32(0)
                        category = reader.GetString(1)
                        itemtype = reader.GetString(2)
                        checkedout = reader.GetBoolean(4)
                        If (checkedout = True) Then
                            Label5.Visible = True
                            con.Close()
                            Exit Sub
                        End If
                        'create row, fill row, store row
                        Dim dr As DataRow = dtUsage.NewRow
                        dr.Item("PatronID") = IDtemp.ToString()
                        dr.Item("Category") = category
                        dr.Item("ItemType") = itemtype
                        dr.Item("ItemCode") = TextBox5.Text
                        dr.Item("DateUsed") = Today
                        dr.Item("Returned") = False
                        dtUsage.Rows.Add(dr)

                    End While
                    con.Close()
                Else
                    'none found
                    Label5.Visible = True
                    Exit Sub
                End If

            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con.Close()

            End Try

            'update, reload and reset variables
            Call CheckoutScanUpdate()

            daUsage.Update(dtUsage)
            dtUsage.Rows.Clear()
            daUsage.Fill(dtUsage)
            dtUsagefilter.Rows.Clear()
            daUsagefilter.Fill(dtUsagefilter)
            Label16.Visible = True
            TextBox3.Text = ""
            TextBox4.Text = ""
            DropDownList1.SelectedIndex = -1
            DropDownList2.SelectedIndex = -1
        End If

    End Sub

    ''update inventory from checkout without barcode Scanner
    Private Sub CheckoutNonScanUpdate()

        Dim cmdUpdateInv As New SqlCommand("UPDATE InventoryIn SET CheckedOut=1 WHERE ItemCode= @p2", con)


        With cmdUpdateInv.Parameters
            .Clear()
            .AddWithValue("@p2", DropDownList1.SelectedValue)


        End With
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmdUpdateInv.ExecuteNonQuery()

        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    ''Update Inv from checkout using scanner function 
    Private Sub CheckoutScanUpdate()

        Dim cmdUpdateInv As New SqlCommand("UPDATE InventoryIn SET CheckedOut=1 WHERE ItemCode= @p2", con)


        With cmdUpdateInv.Parameters
            .Clear()
            .AddWithValue("@p2", TextBox5.Text)


        End With
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmdUpdateInv.ExecuteNonQuery()

        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    'fill data for DDL's on charge/missing view page
    'repeated algorothim from earlier
    Protected Sub DropDownList7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList7.SelectedIndexChanged
        'reset values on view
        Label17.Visible = False
        DropDownList6.SelectedIndex = -1
        DropDownList8.SelectedIndex = -1
        DropDownList9.SelectedIndex = -1
        'display selected ID#
        TextBox30.Text = DropDownList7.SelectedValue
        Dim searchpatroncmd As New SqlCommand("SELECT * FROM EquipmentUsage where PatronID=@p1 and Returned=0", con)
        searchpatroncmd.Parameters.AddWithValue("p1", DropDownList7.SelectedValue)
        Try
            con.Open()
            'create reader to find values
            Dim reader As SqlDataReader = searchpatroncmd.ExecuteReader()
            'if any values are true 
            If reader.HasRows Then
                'loop while reading, store all values
                'note issues could happen if patronIDs are the same value, but this shouldn't occur
                While reader.Read()
                    DropDownList6.Items.Add(New ListItem(reader.GetString(2), reader.GetString(2))) 'categories
                    DropDownList8.Items.Add(New ListItem(reader.GetString(3), reader.GetString(4))) 'item type
                End While
            Else
                'none found
                Label17.Visible = True
                'reset values on view

                DropDownList6.SelectedIndex = -1
                DropDownList8.SelectedIndex = -1
                DropDownList9.SelectedIndex = -1
            End If

        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()

        End Try
    End Sub

    'data entry for damaged /missing view , "Enter" button
    Protected Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim dr As DataRow = dtCharges.NewRow
        If Label17.Visible = False Then
            'means patron has records stored.
            dr.Item("PatronID") = TextBox30.Text
            dr.Item("ItemType") = DropDownList8.SelectedItem
            dr.Item("ItemCode") = DropDownList8.SelectedValue
            dr.Item("AmountPaid") = 15.0
            dr.Item("Date") = Today
            dr.Item("PayType") = DropDownList9.SelectedValue
            'insert and update
            dtCharges.Rows.Add(dr)
            daCharges.Update(dtCharges)
            dtCharges.Rows.Clear()
            daCharges.Fill(dtCharges)
            GridView4.DataSource = dtCharges
            GridView4.DataBind()
            GridView4.Visible = True 'viewdata
        End If

    End Sub
    'show gridview on view 7
    Protected Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        GridView2.Visible = True
    End Sub

    'hide gridview on view 7
    Protected Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        GridView2.Visible = False

    End Sub

    'UPDATE DAMAGED MISSING SUBMIT BUTTON
    Protected Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        'when button is pressed delete missing or damaged entries
        Label18.Visible = False

        If GridView4.Visible = True Then
            'if gridview is visible it means valid data is entered

            'delete cmmd
            Dim cmdSetDamaged As New SqlCommand("UPDATE InventoryIn SET Damaged=1 WHERE ItemCode= @p2", con)
            Dim cmdUpdateReport As New SqlCommand("UPDATE EquipmentUsage SET Returned=1 WHERE ItemCode= @p2", con)

            With cmdSetDamaged.Parameters
                .Clear()
                .AddWithValue("@p2", DropDownList8.SelectedValue) 'item code
            End With

            With cmdUpdateReport.Parameters
                .Clear()
                .AddWithValue("@p2", DropDownList8.SelectedValue) 'item code


            End With

            Try
                If con.State = ConnectionState.Closed Then con.Open()
                cmdSetDamaged.ExecuteNonQuery()
                cmdUpdateReport.ExecuteNonQuery()

                'update datatables
                dtInv.Rows.Clear()
                daInv.Fill(dtInv)
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con.Close()
            End Try

            Label18.Visible = True
        End If

    End Sub
    'insert new item click
    Protected Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Label19.Visible = False
        Label20.Visible = False

        Dim dr As DataRow = dtInv.NewRow
        If TextBox12.Text = "" Or TextBox13.Text = "" Or TextBox14.Text = "" Then

            Label19.Visible = True

            Exit Sub
        End If
        dr.Item("ItemCode") = TextBox12.Text
        dr.Item("Category") = TextBox14.Text
        dr.Item("ItemType") = TextBox13.Text
        dr.Item("CheckedOut") = False
        dtInv.Rows.Add(dr)
        daInv.Update(dtInv)
        dtInv.Rows.Clear()
        daInv.Fill(dtInv)
        Label20.Visible = True

    End Sub
    'delete item click
    Protected Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If TextBox15.Text IsNot "" Then
            'delete from barcode
            'This is a really ghetto way to "DELETE" items , Since I CANNOT run a DELETE Statement because of Foreign Key Issues with other dataTables I settled for this....
            'by this i mean setting damaged to true and checkedout to true
            Dim cmdSetDamaged As New SqlCommand("UPDATE InventoryIn SET Damaged=1,CheckedOut=1,ItemType='DELETED' WHERE ItemCode= @p2", con)
            With cmdSetDamaged.Parameters
                .Clear()
                .AddWithValue("@p2", TextBox15.Text) 'item code
            End With
            Try
                If con.State = ConnectionState.Closed Then con.Open()
                cmdSetDamaged.ExecuteNonQuery()


                'update datatables
                dtInv.Rows.Clear()
                daInv.Fill(dtInv)
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con.Close()
            End Try
            Exit Sub
        End If
        If DropDownList12.SelectedIndex > 0 And TextBox15.Text Is "" Then
            'delete from barcode
            'This is a really ghetto way to "DELETE" items , Since I CANNOT run a DELETE Statement because of Foreign Key Issues with other dataTables I settled for this....
            'by this i mean setting damaged to true and checkedout to true
            Dim cmdSetDamaged As New SqlCommand("UPDATE InventoryIn SET Damaged=1,CheckedOut=1,ItemType='DELETED' WHERE ItemCode= @p2", con)
            With cmdSetDamaged.Parameters
                .Clear()
                .AddWithValue("@p2", DropDownList12.SelectedValue) 'item code
            End With
            Try
                If con.State = ConnectionState.Closed Then con.Open()
                cmdSetDamaged.ExecuteNonQuery()


                'update datatables
                dtInv.Rows.Clear()
                daInv.Fill(dtInv)
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                con.Close()
            End Try
        End If


    End Sub

    'fills textboxes for the edit button
    Protected Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        If TextBox16.Text = "" Then
            Label21.Visible = True
            Exit Sub
        End If
        Label21.Visible = False
        'this part will be rough, essentially we have to search our SQL database for all the other fields other than the code itself
        'reusing similiar code from above
        Dim searchbycode As New SqlCommand("SELECT * FROM InventoryIn where ItemCode=@p1", con)
        searchbycode.Parameters.AddWithValue("p1", TextBox16.Text.ToString())
        Try
            con.Open()
            'create reader to find values
            Dim reader As SqlDataReader = searchbycode.ExecuteReader()
            'if any values are true 
            If reader.HasRows Then
                'loop while reading, store all values

                While reader.Read()

                    TextBox19.Text = reader.GetString(1) 'category
                    TextBox18.Text = reader.GetString(2) 'item type
                    If reader.GetBoolean(4) = True Then 'checked out true
                        CheckBoxList4.SelectedIndex = 0
                    End If
                    If reader.GetBoolean(4) = False Then 'checked out False
                        CheckBoxList4.SelectedIndex = 1
                    End If
                    If reader.IsDBNull(5) = True Then 'damage false because null value
                        CheckBoxList3.SelectedIndex = 1
                    ElseIf reader.GetBoolean(5) = True Then 'Damaged true
                        CheckBoxList3.SelectedIndex = 0
                    ElseIf reader.GetBoolean(5) = False Then 'Damaged False
                        CheckBoxList3.SelectedIndex = 1
                    End If




                End While
                con.Close()
            Else
                'none found
                Label22.Visible = True
                Exit Sub
            End If
            'hide label
            Label22.Visible = False
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub
    'edit item button click
    Protected Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Label23.Visible = False
        If TextBox16.Text = "" Or TextBox18.Text = "" Or TextBox19.Text = "" Or Label21.Visible = True Then
            Label21.Visible = True 'missing data label
            Exit Sub
        End If
        'hide label
        Label21.Visible = False
        '
        '
        '
        'PERFORM UPDATE COMMAND WITH CORRESPONDING DATA

        Dim cmdSetDamaged As New SqlCommand("UPDATE InventoryIn SET Damaged=@p1,CheckedOut=@p2,ItemType=@p3,Category=@p4 WHERE ItemCode= @p5", con)
        With cmdSetDamaged.Parameters
            .Clear()
            .AddWithValue("@p1", CheckBoxList3.SelectedValue) 'damaged boolean
            .AddWithValue("@p2", CheckBoxList4.SelectedValue)
            .AddWithValue("@p3", TextBox18.Text)
            .AddWithValue("@p4", TextBox19.Text)
            .AddWithValue("@p5", TextBox16.Text)
        End With
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmdSetDamaged.ExecuteNonQuery()


            'update datatables
            dtInv.Rows.Clear()
            daInv.Fill(dtInv)
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try



        Label23.Visible = True
    End Sub

    
End Class

<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="comp2084_lesson10.student_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Details</h1>
    <h5>All the fields are required.</h5>

    <div class="form-group">
        <label for="txtLastName" class="col-sm-2">Last Name:</label>
        <asp:TextBox ID="txtLastName" runat="server" MaxLength="50" required />
    </div>

    <div class="form-group">
        <label for="txtFirstName" class="col-sm-2">First Name:</label>
        <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" required />
    </div>
    <div class="form-group">
        <label for="txtDate" class="col-sm-2">Enrollment Date:</label>
        <asp:TextBox ID="txtDate" runat="server" TextMode="Date" required />
          <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Must be a Date"
            ControlToValidate="txtDate" CssClass="alert alert-danger"
            Type="Date" MinimumValue="2000-01-01" MaximumValue="2999-12-31"></asp:RangeValidator>

    </div>
    
    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" 
             OnClick="btnSave_Click" />

    </div>
    
     <asp:Panel ID="pnlCourses" runat="server">
        <h2>Courses</h2>

        <asp:GridView ID="grdCourses" runat="server" AutoGenerateColumns="false"
             CssClass="table table-striped table-hover" OnRowDeleting="grdCourses_RowDeleting" DataKeyNames="StudentID">
            <Columns>
                <asp:BoundField DataField="Cours.Department.Name" HeaderText="Department" />
                <asp:BoundField DataField="Cours.Title" HeaderText="Title" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" />
                <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" HeaderText="Delete" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="courses.aspx.cs" Inherits="comp2084_lesson10.courses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Courses</h1>
    <a href="course-details.aspx">Add Courses</a>
    <asp:GridView ID="grdCourses" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" OnRowDeleting="grdCourses_RowDeleting" 
        DataKeyNames="CourseID">
        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" Visible="false" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Credits" HeaderText="Credits" />
            <asp:BoundField DataField="Department.Name" HeaderText="Department" />
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="~/course-details.aspx" Text="Edit"
                 DataNavigateUrlFormatString="course-details.aspx?CourseID={0}"  DataNavigateUrlFields="CourseID" />
             <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" HeaderText="Delete" />         
            
        </Columns>

    </asp:GridView>
    
</asp:Content>

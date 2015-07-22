using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2084_lesson10.Models;

namespace comp2084_lesson10
{
    public partial class courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCourses();
            }
        }

        protected void GetCourses()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var courses = from c in db.Courses
                              select c;
                grdCourses.DataSource = courses.ToList();
                grdCourses.DataBind();
            }
        }

        protected void grdCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID using the grid's Data Key collection
            Int32 CourseID = Convert.ToInt32(grdCourses.DataKeys[selectedRow].Values["CourseID"]);

            //use EF to remove the selected student from the db
            using (DefaultConnection db = new DefaultConnection())
            {

                Course cou = (from c in db.Courses
                             where c.CourseID == CourseID
                             select c).FirstOrDefault();

                //do the delete
                db.Courses.Remove(cou);
                db.SaveChanges();
            }

            //refresh the grid
            GetCourses();
        }

       
    }
}
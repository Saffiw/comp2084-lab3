using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2084_lesson10.Models;

namespace comp2084_lesson10
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             

                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    GetStudent();
                    pnlCourses.Visible = true;
                }else
                {
                    pnlCourses.Visible = false;
                }
            }
        }

        protected void GetStudent()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                Student stu = (from s in db.Students
                               where s.StudentID == StudentID
                               select s).FirstOrDefault();

                

                txtLastName.Text = stu.LastName;
                txtFirstName.Text = stu.FirstMidName;
                txtDate.Text = stu.EnrollmentDate.ToString("yyyy-MM-dd");

                //populate student enrollments grid
                var Enrollments = from e in db.Enrollments
                                  where e.StudentID == StudentID
                                  select e;

                //bind to the grid
                grdCourses.DataSource = Enrollments.ToList();
                
                grdCourses.DataBind();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                Student stu = new Student();

                Int32 StudentID = 0;

                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
                    stu = (from s in db.Students
                           where s.StudentID == StudentID
                           select s).FirstOrDefault();

                }

                stu.LastName = txtLastName.Text;
                stu.FirstMidName = txtFirstName.Text;
                stu.EnrollmentDate = Convert.ToDateTime(txtDate.Text);

                if (StudentID == 0)
                {
                    db.Students.Add(stu);
                }
                db.SaveChanges();

                Response.Redirect("students.aspx");


            }
        }

        protected void grdCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 StudentID = Convert.ToInt32(grdCourses.DataKeys[e.RowIndex].Values["StudentID"]);

            //use EF to remove the selected student from the db
            using (DefaultConnection db = new DefaultConnection())
            {

                Student s = (from objS in db.Students
                             where objS.StudentID == StudentID
                             select objS).FirstOrDefault();

                //do the delete
                db.Students.Remove(s);
                db.SaveChanges();
            }

            //refresh the grid
            GetStudent();
        }
    }
}
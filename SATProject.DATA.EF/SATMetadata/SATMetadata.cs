using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATProject.DATA.EF//.SATMetadata
{
    #region CourseMetaData
    
    public class CourseMetaData
    {
        //public int CourseId { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        [StringLength(50, ErrorMessage = "* Value must be 50 characters or less.")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Course Description")]
        //[StringLength(50, ErrorMessage = "* Value must be 50 characters or less.")]
        public string CourseDescription { get; set; }

        [Required]
        [Display(Name = "Credit Hours")]
        public byte CreditHours { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(250, ErrorMessage = "* Value must be 250 characters or less.")]
        public string Curriculum { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(500, ErrorMessage = "* Value must be 500 characters or less.")]
        public string Notes { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }

    [MetadataType(typeof(CourseMetaData))]
    public partial class Course { }

    #endregion

    #region EnrollmentMetadata

    public class EnrollmentMetaData
    {
        //public int EnrollmentId { get; set; }
        //public int StudentId { get; set; }
        //public int ScheduledClassId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[-N/A-]")]
        public System.DateTime EnrollmentDate { get; set; }
    }

    [MetadataType(typeof(EnrollmentMetaData))]
    public partial class Enrollment { }

    #endregion

    #region ScheculedClassMetadata

    public class ScheduledClassMetaData
    {
        //public int ScheduledClassId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InstructorName { get; set; }
        public string Location { get; set; }
        public int SCSID { get; set; }
    }

    [MetadataType(typeof(ScheduledClassMetaData))]
    public partial class ScheduledClass
    {
        [Display(Name = "Class Info")]
        public string ClassInfo
        {
            get { return $"{StartDate} {Course.CourseName} {Location}"; }
        }
    }

    #endregion

    #region ScheduledClassStatusMetadata

    public class ScheduledClassStatusMetaData
    {

    }

    #endregion

    #region StudentMetadata

    public class StudentMetaData
    {
        //public int StudentId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "* Value must be 20 characters or less.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "* Value must be 20 characters or less.")]
        public string LastName { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(15, ErrorMessage = "* Value must be 15 characters or less.")]
        public string Major { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(50, ErrorMessage = "* Value must be 50 characters or less.")]
        public string Address { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(25, ErrorMessage = "* Value must be 25 characters or less.")]
        public string City { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(2, ErrorMessage = "* Value must be 2 characters or less.")]
        public string State { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(10, ErrorMessage = "* Value must be 10 characters or less.")]
        public string ZipCode { get; set; }


        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(13, ErrorMessage = "* Value must be 13 characters or less.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "* Value must be 60 characters or less.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [StringLength(133, ErrorMessage = "* Value must be 133 characters or less.")]
        [Display(Name = "Image")]
        public string PhotoUrl { get; set; }

        [Required]
        public int SSID { get; set; }
    }

    [MetadataType(typeof(StudentMetaData))]
    public partial class Student
    {
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }

    #endregion

    #region StudentStatusMetadata

    public class StudentStatusMetaData
    {
        //public int SSID { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "* Value must be 30 characters or less.")]
        [Display(Name = "Student Status")]
        public string SSName { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(250, ErrorMessage = "* Value must be 250 characters or less.")]
        [Display(Name = "Description")]
        public string SSDescription { get; set; }
    }

    #endregion
}

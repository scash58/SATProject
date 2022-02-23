using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATProject.DATA.EF//.SATMetadata
{
    #region CoursMetaData
    
    public class CoursMetaData
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

    [MetadataType(typeof(CoursMetaData))]
    public partial class Cours { }

    #endregion

    #region EnrollmentMetadata

    public class EnrollmentMetaData
    {

    }

    #endregion

    #region ScheculedClassMetadata

    public class ScheduledClassMetaData
    {

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

    }

    #endregion

    #region StudentStatusMetadata

    public class StudentStatusMetaData
    {

    }

    #endregion
}

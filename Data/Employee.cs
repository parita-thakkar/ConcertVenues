using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PST2231A1.Data
{
    [Table("Employee")]
    public class Employee
    {

        #region Constructor

        public Employee()
        {
            Customers = new HashSet<Customer>();
            DirectReports = new HashSet<Employee>();
        }

        #endregion

        #region Columns

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        public int? ReportsToId { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        #endregion

        #region Navigation Properties

        public Employee ReportsTo { get; set; }

        #endregion

        #region Entity Collections

        public ICollection<Customer> Customers { get; set; }

        public ICollection<Employee> DirectReports { get; set; }

        #endregion

    }
}

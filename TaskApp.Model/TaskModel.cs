using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskApp.Model
{
    [Table("tbl_task")]
    public class TaskModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateOnly DueDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }

        [ForeignKey("Id")]
        public int User { get; set; }
        public int Category { get; set; }
        public DateTime Reminders { get; set; }
    }
}

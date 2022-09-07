using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTrackerIssue.Entities
{
    public class TimeUnit
    {
        public static TimeUnit s = new(1, "s");
        public static TimeUnit min = new(2, "min");

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        protected TimeUnit() { }
        public TimeUnit(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

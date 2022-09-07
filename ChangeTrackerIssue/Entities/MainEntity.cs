using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTrackerIssue.Entities
{
    public class MainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeUnit TimeUnit { get; set; }
        protected MainEntity() { }
        public MainEntity(string name, TimeUnit timeUnit)
        {
            Name = name;
            TimeUnit = timeUnit;
        }
    }
}

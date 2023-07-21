using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace DemoApplication.Models
{
    [Table(Name = "TestModels")]
    public class TestModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
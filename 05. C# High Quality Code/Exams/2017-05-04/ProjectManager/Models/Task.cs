﻿using System.ComponentModel.DataAnnotations;

using ProjectManager.Enums;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Models
{
    public class Task : ITask
    {
        public Task(string name, IUser owner, TaskState state)
        {
            this.Name = name;
            this.Owner = owner;
            this.State = state;
        }

        [Required(ErrorMessage = "Task Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Task Owner is required")]
        public IUser Owner { get; set; }

        public TaskState State { get; set; }

        //public override string ToString()
        //{
        //    var builder = new StringBuilder();

        //    builder.AppendLine("    Name: " + this.Name);
        //    builder.Append("    State: " + this.st);

        //    return builder.ToString();
        //}
    }
}

using System;

namespace taskMenager.Models
{
    public class task
    {
        public task(string name, string details)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Details = details;
            Concluded = false;
            DateRegister = DateTime.Now;
            CompletionDate = null;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Details { get; private set; }
        public bool Concluded { get; private set; }
        public DateTime DateRegister { get; private set; }
        public DateTime? CompletionDate { get; private set; }
        public void UpdateTask(string name, string details, bool? concluded = false)
        {
            Name = name;
            Details = details;
            Concluded = concluded ?? false;
            CompletionDate = Concluded ? DateTime.Now : null;
        }

    }
}
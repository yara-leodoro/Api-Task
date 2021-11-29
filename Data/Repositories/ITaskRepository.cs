using System.Collections.Generic;
using taskMenager.Models;

namespace taskMenager.Data.Repositories
{
    public interface ITaskRepository
    {
        void Create(task task);
        void Update(string id, task taskUpdate);
        IEnumerable<task> listAll();
        task list(string id);

        void Delete(string id);
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;



namespace lab_42_EFCore_From_Scratch
{
    class Program
    {
        static List<ToDoItem> todos;
        static void Main(string[] args)
        {
            using (var db = new ToDoItemContext())
            {
                var todo = new ToDoItem()
                {
                    ToDoItemName = "First Task",
                    DateCreated = DateTime.Now

                };
                db.ToDoItems.Add(todo);
                db.SaveChanges();
            }
            System.Threading.Thread.Sleep(1000);
            using (var db = new ToDoItemContext())
            {
                todos = db.ToDoItems.ToList();
            }
            todos.ForEach(todo => Console.WriteLine($"{todo.ToDoItemId,-10} {todo.ToDoItemName,-20} {todo.DateCreated}"));
        }
        

    }

    class ToDoItem
    {
        public int ToDoItemId { get; set; }
        public string ToDoItemName { get; set; }
        public DateTime DateCreated { get; set; }

    }

    class ToDoItemContext : DbContext {
        public ToDoItemContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Data Source=ToDoDatabase");
            //builder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ToDoDatabase;Integrated Security=true;MultipleActiveResultSets=true");
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }

    

}

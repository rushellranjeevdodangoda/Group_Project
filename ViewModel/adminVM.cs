using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Group_Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Group_Project.ViewModel
{
    public partial class AdminVM : ObservableObject

    {
        [ObservableProperty]
        public string? firstName;
        [ObservableProperty]
        public string? lastName;
        [ObservableProperty]
        public string? password;
        [ObservableProperty]
        ObservableCollection<Student> studentlist;
        
        public DataBaseContext context;
        

        [RelayCommand]
        private void RemoveStudent(Student student)
        {
            studentlist.Remove(student);
            using (var context = new DataBaseContext())
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

        [RelayCommand]
        public void CreateStudent() 
        {
           
            Student tempStudent = new Student()
            {
                FirstName = FirstName,
                LastName = LastName,
                Password= Password, 
                // right from mvvm


            };

            if (tempStudent.FirstName != null && tempStudent.LastName != null && tempStudent.Password != null)
            {
                using (var context = new DataBaseContext())
                {
                    context.Students.Add(tempStudent);
                    context.SaveChanges();
                    studentlist.Add(tempStudent);
                    Load();
                }
                
            }


        }

        public void Load()
        {
                context = new DataBaseContext();
                var list = context.Students.ToList();
                studentlist = new ObservableCollection<Student>(list);
                OnPropertyChanged(nameof(studentlist));


        }

        [RelayCommand]
        private void UpdateStudent(Student student)
        {
            if (FirstName != null && LastName != null && Password != null)
            {
                student.FirstName = FirstName;
                student.LastName = LastName;
                student.Password = Password;
                context.SaveChanges();
                Load();
                //OnPropertyChanged(nameof(studentlist));

            }
        }
        public AdminVM()
        {
            Load();

        }

    }
}

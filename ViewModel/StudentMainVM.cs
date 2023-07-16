using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Group_Project.Model;
using Group_Project.View;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Group_Project.ViewModel
{
    public partial class StudentMainVM : ObservableObject
    {

        [ObservableProperty]
        string firstName;
        [ObservableProperty]
        string lastName;
        [ObservableProperty]
        string passwprd;
        [ObservableProperty]
        double gpa;
        [ObservableProperty]
        int studentid;
        [ObservableProperty]
        int age;
        public Student Selected_Student { get; private set; }       

        

        public StudentMainVM(Student stu)
        {
            FirstName = stu.FirstName;
            LastName = stu.LastName;
            passwprd = stu.Password;
            Gpa = stu.GPA;
            Studentid = stu.Id;
            Age = stu.Age;  
          
        }

        public StudentMainVM()
        {
            Selected_Student = new Student();

        }

        [RelayCommand]
        public void LogOut()
        {
            var win = new MainWindow();
            win.Show();
            
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }

        }

       

        [RelayCommand]
        private void UpdateStudent()
        {

            int stdid = Studentid;

            using (var db = new DataBaseContext())
            {
                Model.Student s = db.Students.SingleOrDefault(s => s.Id == Studentid);

               s.FirstName=FirstName; s.LastName=LastName;
                s.Password=Passwprd; s.Age=Age;
                db.SaveChanges();
                MessageBox.Show("Successfully Edited", "Done");





            }


        }
        [RelayCommand]
        public void Showres()
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                bool check = context.Students.Any(Student => Student.FirstName == FirstName && Student.Password == Passwprd);
                Student student = context.Students.FirstOrDefault(Student => Student.FirstName == FirstName && Student.Password == Passwprd);
                if (check)
                {
                    var data = new ResultsDetailsVM(student);
                    var window = new View.ResultsDetails(data) { DataContext = data };
                    window.Show();
                }
                else
                {
                    MessageBox.Show("User not found", "Errors");
                }
            }





        }





    }
}

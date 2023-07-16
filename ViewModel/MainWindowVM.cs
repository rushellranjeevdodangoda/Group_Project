using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Group_Project.Model;
using Group_Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Group_Project.ViewModel
{
    public partial class MainWindowVM:ObservableObject
    {
        [ObservableProperty]
        public string? adusername;
        [ObservableProperty]
        public string? adpassword;
        [ObservableProperty]
        public string? strusername;
        [ObservableProperty]
        public string? strpassword;
        public MainWindowVM()
        {

        }

        [RelayCommand]
        public void Adminlogin()
        {
            using (DataBaseContext context =new DataBaseContext())
            {
                bool check = context.Teachers.Any(Teacher => Teacher.UserName == Adusername && Teacher.Password == Adpassword);
               // Teacher teacher = context.Teachers.FirstOrDefault(Teacher => Teacher.UserName == Adusername && Teacher.Password == Adpassword);
                if (check)
                {
                    
                    var window = new View.adminMenu();
                    window.Show();
                }
                else
                {
                    MessageBox.Show("User not found", "Errors");
                }
            }            
        }

        [RelayCommand]
        public void StudentLogin()
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                bool check = context.Students.Any(Student => Student.FirstName == Strusername && Student.Password == Strpassword);
               Student student = context.Students.FirstOrDefault(Student => Student.FirstName == Strusername && Student.Password == Strpassword);
                if (check)
                {
                    var data = new StudentMainVM(student);                  
                    var window = new View.StudentMain(data) { DataContext = data};
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show("User not found", "Errors");
                }
            }


        }



    }
}

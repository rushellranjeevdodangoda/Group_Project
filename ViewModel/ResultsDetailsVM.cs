using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Group_Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Group_Project.ViewModel
{
    public partial class ResultsDetailsVM : ObservableObject
    {
        [ObservableProperty]
        public int studentid;

        [ObservableProperty]
        public int modulid;

        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        ObservableCollection<Result> studentResults;

        [ObservableProperty]
        ObservableCollection<Result> selectedModules;

        [ObservableProperty]
        ObservableCollection<int> combolist;

        public Student Selected_Student { get; private set; }

        public ResultsDetailsVM(Student stu)
        {
            Studentid = stu.Id;
            using (var db = new DataBaseContext())
            {
                LoadData(Studentid);
            }

            using (var db = new DataBaseContext())
            {

                var list = db.Modules.Select(u => u.Id).ToList();
                combolist = new ObservableCollection<int>(list);
            }

        }



        public ResultsDetailsVM()
        {
            using (var db = new DataBaseContext())
            {
                Selected_Student = new Student();
                var list = db.Modules.Select(u => u.Id).ToList();
                Combolist = new ObservableCollection<int>(list);
            }
        }


       


        public void LoadData(int id)
        {
            
                using (var db = new DataBaseContext())
                {
                    //var list = db.Modules.ToList();
                    var grd = db.Results.Where(Result => Result.StudentID == id).ToList();
                    StudentResults = new ObservableCollection<Result>(grd);
                return;
                }

           

        }




       




        [RelayCommand]
        public void Save()

        {

            try
            {

                foreach (var result in StudentResults)
                {
                    using (var db = new DataBaseContext())
                    {

                        Result checkd = db.Results.Find(result.Id);
                        if (checkd == null)
                        {
                            MessageBox.Show("Results Not Found");

                            return;
                        }
                        checkd.Grade = result.Grade;
                        db.SaveChanges();
                        LoadData(Studentid);


                    }


                }

                MessageBox.Show("Grades saved.");
              

            }
            catch
            {
                MessageBox.Show("Unhandled Exception", "Error");
            }



        }





        [RelayCommand]
        public void Addmodule()
        {
            if (Modulid == 0 || Modulid == null)
            {
                MessageBox.Show("Select the Module", "Error");
                return;
            }
            else
            {
                try
                {
                    using (var db = new DataBaseContext())
                    {



                        Module a = db.Modules.Find(Modulid);
                        if (a == null)
                        {
                            MessageBox.Show("Enter a valid Module ID", "Error");
                            return;
                        }



                    }




                    Result r = new Result()
                    {
                        StudentID = Studentid,
                        ModuleID = Modulid,
                        Grade = 0
                    };
                    using (var db = new DataBaseContext())
                    {
                        Result re = db.Results.SingleOrDefault(r => r.ModuleID == Modulid && r.StudentID == Studentid);

                        if (re == null)
                        {
                            db.Results.Add(r);
                            db.SaveChanges();

                            LoadData(Studentid);
                            MessageBoxResult result = MessageBox.Show("Module succesfully Added to student", "Done");
                        }
                        else
                        {
                            MessageBox.Show("Module Already exists", "Error");
                            return;
                        }


                    }
                }
                catch
                {
                    MessageBox.Show("Error", "No");
                }
            }

        }

       



    }
}

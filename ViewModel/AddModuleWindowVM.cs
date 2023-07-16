using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group_Project.Model;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace Group_Project.ViewModel
{
    public partial class AddModuleWindowVM:ObservableObject
    {
        public AddModuleWindowVM()
        {
            Load();

        }

        [ObservableProperty]
        public int id;
        [ObservableProperty]
        public int credit;
        [ObservableProperty]
        public string? code;
        [ObservableProperty]
        public string? name;
        [ObservableProperty]
        ObservableCollection<Module> modulelist;

        public DataBaseContext context;


        [RelayCommand]
        private void RemoveModule(Module module)
        {
            modulelist.Remove(module);
            using (var context = new DataBaseContext())
            {
                context.Modules.Remove(module);
                context.SaveChanges();
            }
        }

        [RelayCommand]
        public void CreateModule()
        {

            Module temp = new Module();
            {
                
                temp.Name = Name;
                temp.Code = Code;
                temp.Credit = Credit;


            };

            if (temp.Name != null && temp.Code != null && temp.Credit>=0)
            {
                using (var context = new DataBaseContext())
                {
                    context.Modules.Add(temp);
                    context.SaveChanges();
                    modulelist.Add(temp);
                    Load();
                }

            }


        }

        public void Load()
        {
            context = new DataBaseContext();
            var list = context.Modules.ToList();
            modulelist = new ObservableCollection<Module>(list);
            OnPropertyChanged(nameof(modulelist));


        }

        [RelayCommand]
        private void UpdateModule(Module module)
        {
            if (name != null && code != null && credit>=0)
            {
                module.Name = name;
                module.Code = code;
                module.Credit = credit;
                context.SaveChanges();
                Load();
                //OnPropertyChanged(nameof(studentlist));

            }
        }
      


    }
}

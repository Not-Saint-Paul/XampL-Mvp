using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abc
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        class View
        {
            public delegate void DirectoryPathChanged(string newPath);
            private List<DirectoryPathChanged> listUpdatePath = new List<DirectoryPathChanged>();
            public void DirectoryPathChange(string newPath)
            {
                foreach(var delegateFunction in listUpdatePath)
                {
                    delegateFunction(newPath);
                }
            }
            public void AddDirectoryPathChangedDelegate(DirectoryPathChanged directoryPathChanged)
            {
                listUpdatePath.Add(directoryPathChanged);
            }
        }
        class Model
        {
            public delegate void UpdateModel();
            private List<UpdateModel> listUpdateDelegates = new List<UpdateModel>();
            string pathToDirecvtory;
            public void SetModlelData(string newValue)
            {
                pathToDirecvtory = newValue;
                foreach(var delegateFunction in listUpdateDelegates)
                {
                    delegateFunction();
                }
            }
            public void AddUpdateDelegate(UpdateModel additableDelegate)
            {
                listUpdateDelegates.Add(additableDelegate);
            }
        }
        class Presenter
        {
            private Model _model;
            private View _view;
            public Model Model
            {
                get
                {
                    return _model;
                }
                set
                {
                    _model = value;
                    _model.AddUpdateDelegate(DataChanged);
                }
            }
            public View View
            {
                get
                {
                    return _view;
                }
                set
                {
                    _view = value;
                    _view.AddDirectoryPathChangedDelegate(SetData);
                }
            }
            void DataChanged()
            {
                Console.WriteLine("Controller Data changed");
            }

            public void SetData(string newPath)
            {
                _model.SetModlelData(newPath);
            }
        }

        [STAThread]
        static void Main()
        {
            Presenter presentor = new Presenter();
            Presenter presentor2 = new Presenter();
            presentor.Model = new Model();
            presentor2.Model = presentor.Model;
            //presentor.SetData("C:\\");
            View view = new View();
            presentor.View = view;
            view.DirectoryPathChange("C:\\");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Abc.View());
        }
    }
}

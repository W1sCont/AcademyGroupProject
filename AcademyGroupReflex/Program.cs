using System.Reflection;

namespace Program_15
{
    class MainClass
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            
            // втсановити SoapFormatter

            try
            {
                // AcademyGroup
                Assembly academyAssembly = Assembly.LoadFrom("DLL/AcademyGroup.dll");
                Type[] allTypeAcademy = academyAssembly.GetTypes();
                // foreach (Type type in allTypeAcademy) { Console.WriteLine(type.FullName); }
                
                Type academyType = academyAssembly.GetType("lesson15.AcademyGroup");
                if (academyType != null)
                {
                    object academyObj = Activator.CreateInstance(academyType);

                    MethodInfo[] allMethodAcademy = academyType.GetMethods();
                    // foreach (MethodInfo method in allMethodAcademy) { Console.WriteLine($"{method.ReturnType.Name} {method.Name}"); }
                    MethodInfo acadAdd = academyType.GetMethod("Add");
                    MethodInfo acadEdit = academyType.GetMethod("Edit");
                    MethodInfo acadRemove = academyType.GetMethod("Remove");
                    MethodInfo acadSearch = academyType.GetMethod("Search");
                    MethodInfo acadSort = academyType.GetMethod("Sort");
                    MethodInfo acadSave = academyType.GetMethod("Save");
                    MethodInfo acadLoad = academyType.GetMethod("Load");
                    MethodInfo acadSaveSoap = academyType.GetMethod("SaveSoap");
                    MethodInfo acadLoadSoap = academyType.GetMethod("LoadSoap");
                    MethodInfo acadSaveXml = academyType.GetMethod("SaveXml");
                    MethodInfo acadLoadXml = academyType.GetMethod("LoadXml");
                    MethodInfo acadSaveJson = academyType.GetMethod("SaveJson");
                    MethodInfo acadLoadJson = academyType.GetMethod("LoadJson");
                    
                    
                    // Student (в бібліотеці Person через серіалізацію)
                    Assembly studentAssembly = Assembly.LoadFrom("DLL/Person.dll");
                    Type[] allTypeStudent = studentAssembly.GetTypes();
                    // foreach (Type type in allTypeStudent) { Console.WriteLine(type.FullName); }
                    Type studentType = studentAssembly.GetType("lesson15.Student");
                    PropertyInfo[] allProp = studentType.GetProperties();
                    // foreach (PropertyInfo prop in allProp) { Console.WriteLine(prop); }
                    
                    bool stop = true;
                    while (stop)
                    {
                        academyObj.GetType().GetMethod("Print").Invoke(academyObj, null);
                        Console.WriteLine("Enter command");
                        Console.WriteLine(
                            "1-Add, 2-Edit, 3-Remove, 4-Search, 5-Sort, 6-Save, 7-Load, 8-Iterator, \n9-SaveSoap, 10-LoadSoap, 11-SaveXml, 12-LoadXml, 13-SaveJson, 14-LoadJson, 0-Exit");
                        string? strCommand = Console.ReadLine();
                        switch (strCommand)
                        {
                            case "1":
                                object st = Activator.CreateInstance(studentType);
                                PropertyInfo nameProp = st.GetType().GetProperty("Name");
                                PropertyInfo surnameProp = st.GetType().GetProperty("SurName");
                                PropertyInfo ageProp = st.GetType().GetProperty("Age");
                                PropertyInfo phoneProp = st.GetType().GetProperty("Phone");
                                PropertyInfo gpaProp = st.GetType().GetProperty("GPA");
                                PropertyInfo groupNumberProp = st.GetType().GetProperty("GroupNumber");
                                Console.WriteLine("Enter name:");
                                string? str = Console.ReadLine();
                                nameProp.SetValue(st, str);
                                Console.WriteLine("Enter surname:");
                                str = Console.ReadLine();
                                surnameProp.SetValue(st, str);
                                Console.WriteLine("Enter age:");
                                int age = int.Parse(Console.ReadLine() ?? "0");
                                ageProp.SetValue(st, age);
                                Console.WriteLine("Enter phone:");
                                str = Console.ReadLine();
                                phoneProp.SetValue(st, str);
                                Console.WriteLine("Enter grade point average:");
                                int avg = int.Parse(Console.ReadLine() ?? "0");
                                gpaProp.SetValue(st, avg);
                                Console.WriteLine("Enter group number:");
                                int num = int.Parse(Console.ReadLine() ?? "0");
                                groupNumberProp.SetValue(st, num);
                                if (acadAdd != null)
                                {
                                    acadAdd.Invoke(academyObj, new object[] { st });
                                }
                                break;
                            case "2":
                                Console.WriteLine("Enter surname for edit");
                                string? str_edit = Console.ReadLine();
                                acadEdit.Invoke(academyObj, new object[] { str_edit });
                                break;
                            case "3":
                                Console.WriteLine("Enter surname for remove");
                                string? str_remove = Console.ReadLine();
                                acadRemove.Invoke(academyObj, new object[] { str_remove });
                                break;
                            case "4":
                                Console.WriteLine("Enter surname for search");
                                string? str_search = Console.ReadLine();
                                object stSearch = Activator.CreateInstance(studentType);
                                stSearch = acadSearch.Invoke(academyObj, new object[] { str_search });
                                Console.WriteLine();
                                if (stSearch != null) stSearch.GetType().GetMethod("Print").Invoke(stSearch, null);
                                else Console.WriteLine("Student not found");
                                break;
                            case "5":
                                Console.WriteLine("Enter 'name', 'surname' or 'gpa' for sort");
                                string? str_sort = Console.ReadLine();
                                acadSort.Invoke(academyObj, new object[] { str_sort ?? "" });
                                break;
                            case "6":
                                Console.WriteLine("Enter filename.txt to save");
                                string? str_save = Console.ReadLine();
                                acadSave.Invoke(academyObj, new object[] { str_save ?? "" });
                                break;
                            case "7":
                                Console.WriteLine("Enter filename.txt to load");
                                string? str_load = Console.ReadLine();
                                acadLoad.Invoke(academyObj, new object[] { str_load });
                                break;
                            case "8":
                                Console.WriteLine("Lesson 16 Iterator");
                                MethodInfo iterator = academyType.GetMethod("GetEnumerator");
                                if (iterator != null)
                                {
                                    object iteratorObj = iterator.Invoke(academyObj, null);
                                    foreach (object var in (System.Collections.IEnumerable)iteratorObj)
                                    {
                                        Console.WriteLine(var);
                                    }
                                }
                                else { Console.WriteLine("Method GetEnumerator not found!"); }
                                break;
                            case "9":
                                Console.WriteLine("Enter filename.txt to save SOAP");
                                string? str_save_soap = Console.ReadLine();
                                acadSaveSoap.Invoke(academyObj, new object[] { str_save_soap });
                                break;
                            case "10":
                                Console.WriteLine("Enter filename.txt to load SOAP");
                                string? str_load_soap = Console.ReadLine();
                                acadLoadSoap.Invoke(academyObj, new object[] { str_load_soap });
                                break;
                            case "11":
                                Console.WriteLine("Enter filename.txt to save XML");
                                string? str_save_xml = Console.ReadLine();
                                acadSaveXml.Invoke(academyObj, new object[] { str_save_xml });
                                break;
                            case "12":
                                Console.WriteLine("Enter filename.txt to load XML");
                                string? str_load_xml = Console.ReadLine();
                                acadLoadXml.Invoke(academyObj, new object[] { str_load_xml });
                                break;
                            case "13":
                                Console.WriteLine("Enter filename.txt to save Json");
                                string? str_save_json = Console.ReadLine();
                                acadSaveJson.Invoke(academyObj, new object[] { str_save_json });
                                break;
                            case "14":
                                Console.WriteLine("Enter filename.txt to load Json");
                                string? str_load_json = Console.ReadLine();
                                acadLoadJson.Invoke(academyObj, new object[] { str_load_json });
                                break;
                            case "0":
                                stop = false;
                                break;
                            default:
                                Console.WriteLine("Unknown command!");
                                break;
                        }
                    }
                }
                else Console.WriteLine("Type AcademyGroup not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
        }
    }
}
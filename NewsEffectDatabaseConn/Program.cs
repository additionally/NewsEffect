//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NewsEffectDatabaseConn
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            using (var context = new CompanyTimesEntities())
//            {
//                Console.WriteLine("Welcome to Effect. An Intra-company news service.");
//                Console.WriteLine("Have an account? (yes/no)");
//                string accountanswer = Console.ReadLine();
//                if (accountanswer == "yes")
//                {
//                    Console.WriteLine("Sign up");
//                    //int assignedcompid = 1;
//                    //var maxcompidquery = (from c in context.companies
//                    //                      select c.comp_id);
//                    //while (maxcompidquery.Contains(assignedcompid))
//                    //{
//                    //    assignedcompid++;
//                    //}

//                    Console.WriteLine("Please Enter The Company Name");
//                    string incompname = Console.ReadLine();

//                    var checkcompnamequery = (from c in context.Companies
//                                          select c.name);
//                    if (checkcompnamequery.Contains(incompname))
//                    {
//                        Console.WriteLine("Company Name already exists");
//                        Console.WriteLine("Would you like to log in? (yes/no)");
//                        //basically go to login page
//                        //else is start sign up again
//                    }
//                    else
//                    {
//                        company co = new company() { name = incompname };
//                        context.companies.Add(co);
//                    }
//                    Console.WriteLine("Enter a department name");
//                    string indepname = Console.ReadLine();
//                    Console.WriteLine("Please enter the department location");
//                    string inlocname = Console.ReadLine();
//                    Console.WriteLine("Choose the company");
//                    string indeptcompname = Console.ReadLine();

//                    //int assigneddeptid = 1;
//                    //var maxdeptidquery = (from d in context.departments
//                    //                     select d.dept_id);
//                    //while (maxdeptidquery.Contains(assigneddeptid))
//                    //{
//                    //    assigneddeptid++;
//                    //}

//                    //int assignedlocid = 1;
//                    //var maxlocidquery = (from l in context.locations
//                    //                     select l.location_id);
//                    //while (maxlocidquery.Contains(assignedlocid))
//                    //{
//                    //    assignedlocid++;
//                    //}
//                    var checklocnamequery = (from l in context.locations
//                                             select l.name);
//                    if (checklocnamequery.Contains(inlocname))
//                    {
//                        //nothing i guess. we just don't want to add it to the table
//                        //else is start sign up again
//                    }
//                    else
//                    {
//                        location loc = new location() { name = inlocname };
//                        context.locations.Add(loc);
//                    }
//                    //add another location and yes answer starts process all over

//                    var deptlocidquery = (from l in context.locations
//                             where l.name == inlocname
//                             select l.location_id);

//                    int deptloc = Convert.ToInt32(deptlocidquery);

//                    var deptcoidquery = (from c in context.companies
//                                         where c.name == indeptcompname
//                                          select c.comp_id);

//                    int deptco = Convert.ToInt32(deptcoidquery);

//                    department dept = new department() { name = indepname, fk_company_comp_id = deptco, fk_locations_location_id = deptloc };
                    
//                        Console.WriteLine("Please Enter the employee's name");
//                        Console.WriteLine("First Name");
//                        string inemployeefn = Console.ReadLine();
//                        Console.WriteLine("Last Name");
//                        string inemployeeln = Console.ReadLine();
//                        Console.WriteLine("Choose the department");
//                        string inempdeptname = Console.ReadLine();

//                        var empdeptidquery = (from d in context.departments
//                                              where d.name == inempdeptname
//                                             select d.dept_id);

//                        int empdept = Convert.ToInt32(empdeptidquery);

//                        employee emp = new employee() { fk_departments_dept_id = empdept, firstname = inemployeefn, lastname = inemployeeln };
                        

//                    //setting manager also sets password - as id is not set until we have it
//                        Console.WriteLine("Please Enter the employee's name");
//                        Console.WriteLine("First Name");
//                        string inmanempfn = Console.ReadLine();
//                        Console.WriteLine("Last Name");
//                        string inmanempln = Console.ReadLine();
//                        Console.WriteLine("Please Enter their manager's name");
//                        Console.WriteLine("First Name");
//                        string inmanfn = Console.ReadLine();
//                        Console.WriteLine("Last Name");
//                        string inmanln = Console.ReadLine();
                        
//                    var empmanquery = (from e in context.employees
//                                           where e.firstname == inmanempfn && e.lastname == inmanempln
//                                              select e.employeeid);
//                    int selectedemp = Convert.ToInt32(empmanquery);

//                    var manforempquery = (from e in context.employees
//                                       where e.firstname == inmanfn && e.lastname == inmanln
//                                       select e.employeeid);
//                    int selectedman = Convert.ToInt32(empmanquery);

//                    var em = context.employees.Find(selectedemp);
//                    em.managerid = selectedman;
//                    em.password = "password" + selectedemp;

                        
//                    context.SaveChanges();

//                }
//                else
//                {
//                    Console.WriteLine("Log In");
//                }
                
            
//            }

//            // using (var context = new CompanyTimesEntities())
//            //{
                
//            //}

//        }
//    }


//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsEffectDatabaseConn
{
    public class DatabaseRepository : IDatabaseRepositroy
    {

        //string incompname;
        //string indepname;
        //string inlocname;
        //string indeptcompname;
        //string inemployeefn;
        //string inemployeeln;
        //string inempdeptname;
        //string inmanempfn;
        //string inmanempln;
        //string inmanfn;
        //string inmanln;
        string inpassword;
        //string pwd = "password";
        //List<string> companynames;

        public List<string> readcomp()
        {
            using (var context = new CompanyTimesEntities())
            {
                var readcompnamequery = (from c in context.Companies
                                         select c.name);

                List<string> companynames = readcompnamequery.ToList();
                return companynames;
            }
        }

        public List<string> readloc()
        {
            using (var context = new CompanyTimesEntities())
            {
                var readlocnamequery = (from l in context.Locations
                                         select l.name);

                List<string> locationnames = readlocnamequery.ToList();
                return locationnames;
            }
        }

        public List<string> readdept()
        {
            using (var context = new CompanyTimesEntities())
            {
                var readdeptnamequery = (from d in context.Departments
                                         select d.name);

                List<string> departmentnames = readdeptnamequery.ToList();
                return departmentnames;
            }
        }

        public List<string> reademplastname()
        {
            using (var context = new CompanyTimesEntities())
            {
                var readlastnamequery = (from e in context.Employees
                                         select e.lastname);

                List<string> lastnames = readlastnamequery.ToList();
                return lastnames;
            }
        }

        public List<string> readempfirstname(string inlname)
        {
            using (var context = new CompanyTimesEntities())
            {
                var readfirstnamequery = (from e in context.Employees
                                          where e.lastname == inlname
                                         select e.firstname);

                List<string> firstnames = readfirstnamequery.ToList();
                return firstnames;
            }
        }

        public List<int> readempid()
        {
            using (var context = new CompanyTimesEntities())
            {
                var readempidquery = (from e in context.Employees
                                      select e.employee_id);

                List<int> empids = readempidquery.ToList();
                return empids;
            }
        }

        public bool checkcomp(string incompname)
        {
                if (readcomp().Contains(incompname))
                {
                    return false;
                    //basically go to login page
                    //else is start sign up again
                }
                else
                {
                    return true;
                }
        }

        public bool checkemp(int empid)
        {
            if (readempid().Contains(empid))
            {
                return false;
                //basically go to login page
                //else is start sign up again
            }
            else
            {
                return true;
            }
        }

         public bool checkloc(string inlocname)
        {
                if (readloc().Contains(inlocname))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

         public int getemployeeid(string infname, string inlname)
         {
             using (var context = new CompanyTimesEntities())
             {
                 var empmanquery = (from e in context.Employees
                                    where e.firstname == infname && e.lastname == inlname
                                    select e.employee_id);
                 int empid = Convert.ToInt32(empmanquery);
                 return empid;
             }
         }
         public int getdepartmentid(string depname)
         {
             using (var context = new CompanyTimesEntities())
             {
                 var empdeptidquery = (from d in context.Departments
                                       where d.name == depname
                                       select d.dept_id);

                 int empdept = Convert.ToInt32(empdeptidquery);
                 return empdept;
             }
         }

         public int getlocationid(string inlocname)
         {
             using (var context = new CompanyTimesEntities())
             {
                 var deptlocidquery = (from l in context.Locations
                                       where l.name == inlocname
                                       select l.location_id);

                 int deptloc = Convert.ToInt32(deptlocidquery);
                 return deptloc;
             }
         }

        public void registercomp(string incompname)
        {
            using (var context = new CompanyTimesEntities())
            {
            if (checkcomp(incompname) == true)
            {
                Company co = new Company() { name = incompname };
                context.Companies.Add(co);
                context.SaveChanges();
            }
            }
        }


        public void registerdept(string indepname, string inlocname, string indeptcompname)
        {
            using (var context = new CompanyTimesEntities())
            {

                if (checkloc(inlocname) == true)
                {
                    Location loc = new Location() { name = inlocname };
                    context.Locations.Add(loc);
                }

                int deptloc = getlocationid(inlocname);

                var deptcoidquery = (from c in context.Companies
                                     where c.name == indeptcompname
                                     select c.comp_id);

                int deptco = Convert.ToInt32(deptcoidquery);

                Department dept = new Department() { name = indepname, fk_company_comp_id = deptco, fk_location_location_id = deptloc };
                context.SaveChanges();
            }
        }

        public void registeremployee(string inemployeefn, string inemployeeln, string inempdeptname)
        {
            using (var context = new CompanyTimesEntities())
            {
                var empdeptidquery = (from d in context.Departments
                                      where d.name == inempdeptname
                                      select d.dept_id);

                int empdept = Convert.ToInt32(empdeptidquery);

                Employee emp = new Employee() { fk_department_dept_id = empdept, firstname = inemployeefn, lastname = inemployeeln };
                context.SaveChanges();
            }
        }

        public void registermanager(string inmanempfn, string inmanempln, string inmanfn, string inmanln)
        {
            using (var context = new CompanyTimesEntities())
            {
            int selectedemp = getemployeeid(inmanempfn, inmanempln);
            int selectedman = getemployeeid(inmanfn, inmanln);

                var em = context.Employees.Find(selectedemp);
                em.manager_id = selectedman;
                context.SaveChanges();
            }
        }
        
        public bool currentpassword(string inmanempfn, string inmanempln)
        {
            using (var context = new CompanyTimesEntities())
            {
            int selectedemp = getemployeeid(inmanempfn, inmanempln);
            
                var em = context.Employees.Find(selectedemp);

            if (em.password == null || em.password == inpassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            }

        public bool confirmpassword(string password1, string confirmedpassword)
        {
            if (password1 == confirmedpassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void generatepassword(string inmanempfn, string inmanempln, string password1, string confirmedpassword)
        {
            using (var context = new CompanyTimesEntities())
            {
        
            if (currentpassword(inmanempfn, inmanempln) == true && confirmpassword(password1, confirmedpassword) == true)
            {
               int selectedemp = getemployeeid(inmanempfn, inmanempln);
                var em = context.Employees.Find(selectedemp);
                em.password = confirmedpassword;
                context.SaveChanges();
            }
              
            }
        }
        public void removedept(string indepname)
        {
            using (var context = new CompanyTimesEntities())
            {
                var deptforremove = context.Departments.Where(d => d.name == indepname);
                foreach (var deptrev in deptforremove)
                {
                    context.Departments.Remove(deptrev);
                    context.SaveChanges();
                }

            }
        }

        public void removeemp(string inmanempfn, string inmanempln)
        {
            using (var context = new CompanyTimesEntities())
            {
                var empforremove = context.Employees.Where(e => e.firstname == inmanempfn && e.lastname == inmanempln);
                foreach (var emprev in empforremove)
                {
                    context.Employees.Remove(emprev);
                    context.SaveChanges();
                }
            }
        }

        public void changeconame(string incompname, string newcompname)
        {
            using (var context = new CompanyTimesEntities())
            {
                var c = context.Companies.Find(incompname);
                c.name = newcompname;
                context.SaveChanges();
            }
        }

        public void changedeptname(string indepname, string newdeptname)
        {
            using (var context = new CompanyTimesEntities())
            {
                var d = context.Departments.Find(indepname);
                d.name = newdeptname;
                context.SaveChanges();
            }
        }

        public void changedeptloc(string indepname, string inlocname)
        {
            using (var context = new CompanyTimesEntities())
            {
                var d = context.Departments.Find(indepname);
                if (checkloc(inlocname) == true)
                {
                    Location loc = new Location() { name = inlocname };
                    context.Locations.Add(loc);
                }

                int deptloc = getlocationid(inlocname);
                d.fk_location_location_id = deptloc;
                context.SaveChanges();
            }
        }

        public void changeempdept(string inmanempfn, string inmanempln, string depname)
        {
            using (var context = new CompanyTimesEntities())
            {
                int selectedemp = getemployeeid(inmanempfn, inmanempln);
                var em = context.Employees.Find(selectedemp);
                int empdept = getdepartmentid(depname);
                em.fk_department_dept_id = empdept;
                context.SaveChanges();
            }
        }

        public void changeempnames(string inmanempfn, string inmanempln, string newempfname, string newemplname)
        {
            using (var context = new CompanyTimesEntities())
            {
                int selectedemp = getemployeeid(inmanempfn, inmanempln);
                var em = context.Employees.Find(selectedemp);
                em.firstname = newempfname;
                em.lastname = newemplname;
                context.SaveChanges();
            }
        }

        public bool login(int userid, string pass)
        {
            using (var context = new CompanyTimesEntities())
            {
            if (checkemp(userid) == false)
            {
                var em = context.Employees.Find(userid);
                if (em.password == pass)
                {
                    return true;
                    //go to login in page
                }
                else
                {
                    return false;
                }
                }
            else
            {
                return false;
            }
            }
            
        }
     }
}

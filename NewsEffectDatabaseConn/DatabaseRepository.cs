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
        int empdept;
        int empdep;
        int deptco;
        int deptloc;
        int manid;
        string inpassword;
        int empid;
        int employeedept;
        int deptcomid;
        int exstdeptco;
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

         public bool checkdept(string indeptname)
         {
             if (readdept().Contains(indeptname))
             {
                 return false;
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
             }
             else
             {
                 return true;
             }
         }

         public bool checkmanager(int empid)
         {
             using (var context = new CompanyTimesEntities())
             {
                 var hasmanquery = (from e in context.Employees
                                    where e.employee_id == empid
                                    select e.manager_id);
                 
                 if (hasmanquery.SingleOrDefault() == null)
                 {
                     return false;
                 }
                 else
                 {
                     return true;
                 }
             }
         }
         public bool checkisamanager(int empid)
         {
             using (var context = new CompanyTimesEntities())
             {
                 var ismanquery = (from e in context.Employees
                                   where e.manager_id == empid
                                    select e.manager_id);
                 if (ismanquery == null)
                 {
                     return false;
                 }
                 else
                 {
                     return true;
                 }
             }
         }

         public int getemployeedept(int empid)
         {

             using (var context = new CompanyTimesEntities())
             {
                 
                 var deptempquery = (from e in context.Employees
                                   where e.employee_id == empid
                                   select e.fk_department_dept_id);
                 foreach (var depid in deptempquery)
                 {
                     employeedept = Convert.ToInt32(depid);
                 }

                 return employeedept;
             }
         }

        public bool checkempinsamedept(int empid, int emp2id)
         {
             using (var context = new CompanyTimesEntities())
             {
                 if (getemployeedept(empid) == getemployeedept(emp2id))
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
             }
         }
        public int getdeptcompid(string indepname)
        {
            using (var context = new CompanyTimesEntities())
            {
                var exstdepcoidquery = (from d in context.Departments
                                        where d.name == indepname
                                        select d.fk_company_comp_id);
                foreach (var id in exstdepcoidquery)
                {
                    exstdeptco = Convert.ToInt32(id);
                }
                return exstdeptco;
            }
        }

        public bool checkuniqdept(int coid, int othercoid)
        {
            if (coid == othercoid)
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

                 foreach (var id in empmanquery)
                 {
                  empid = Convert.ToInt32(id);
                 }
                 return empid;

             }
         }

         public int getmanagerid(int empid)
         {
             using (var context = new CompanyTimesEntities())
             {
                 var manidquery = (from e in context.Employees
                                    where e.employee_id == empid
                                    select e.manager_id);

                 foreach (var man in manidquery)
                 {
                     manid = Convert.ToInt32(man);
                 }
                 
                 return manid;
             }
         }
         public int getdepartmentid(string depname)
         {
             using (var context = new CompanyTimesEntities())
             {
                 var empdeptidquery = (from d in context.Departments
                                       where d.name == depname
                                       select d.dept_id);

                 foreach (var d in empdeptidquery)
                 {
                     empdep = Convert.ToInt32(d);
                 }
                 return empdep;
             }
         }

         public int getlocationid(string inlocname)
         {
             using (var context = new CompanyTimesEntities())
             {
                 var deptlocidquery = (from l in context.Locations
                                       where l.name == inlocname
                                       select l.location_id);

                 foreach (var lid in deptlocidquery)
                 {
                     deptloc = Convert.ToInt32(lid);
                 }
                 return deptloc;
             }
         }
                 public bool checkisdetpmanager(int empid)
         {
             if (checkisamanager(empid) == true)
             {
                 if (checkmanager(empid) == false)
                 { }
                 else if (checkmanager(empid) == true && checkempinsamedept(empid, getmanagerid(empid)) == false)
                 { }
                 else
                 {
                     return false;
                 }
                 return true;
             }
             else
             {
                 return false;
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

                foreach (var coid in deptcoidquery)
                {
                    deptco = Convert.ToInt32(coid);
                }
                int exstdeptco = getdeptcompid(indepname);

                if (checkdept(indepname) == true || (checkdept(indepname) == false && checkuniqdept(exstdeptco, deptco) == true))
                {
                    Department dept = new Department() { name = indepname, fk_company_comp_id = deptco, fk_location_location_id = deptloc };
                    context.Departments.Add(dept);
                    context.SaveChanges();
                }
            }
        }

        public void registeremployee(string inemployeefn, string inemployeeln, string inempdeptname)
        {
            using (var context = new CompanyTimesEntities())
            {
                
                Employee emp = new Employee() { fk_department_dept_id = getdepartmentid(inempdeptname), firstname = inemployeefn, lastname = inemployeeln };
                context.Employees.Add(emp);
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

        public void removecompany(int empid)
        {
            using (var context = new CompanyTimesEntities())
            {
                

                    if (checkmanager(empid) == false)
                    {
                        int deptid = getemployeedept(empid);
                        var getdeptcoidquery = (from d in context.Departments
                                                where d.dept_id == deptid
                                                select d.fk_company_comp_id);

                        foreach (var id in getdeptcoidquery)
                        {
                            deptcomid = Convert.ToInt32(id);    
                        }

                        var allcodeptsquery = (from d in context.Departments
                                               where d.fk_company_comp_id == deptcomid
                                               select d.dept_id);

                        List<int> alldepcos = allcodeptsquery.ToList();

                        foreach (var dco in alldepcos)
                        {
                            var emprem = context.Employees.Where(e => e.fk_department_dept_id == dco);
                            foreach (var emp in emprem)
                            {
                                context.Employees.Remove(emp);
                                context.SaveChanges();
                            }
                        }

                        var deptcorem = context.Departments.Where(d => d.fk_company_comp_id == deptcomid);
                        foreach (var de in deptcorem)
                        {
                            context.Departments.Remove(de);
                            context.SaveChanges();
                        }

                        var corem = context.Companies.Where(c => c.comp_id == deptcomid);
                        foreach (var co in corem)
                        {
                            context.Companies.Remove(co);
                            context.SaveChanges();
                        }
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

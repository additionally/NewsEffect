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
        string pwd = "password";

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

        public void registercomp(string incompname)
        {
            using (var context = new CompanyTimesEntities())
            {
            if (checkcomp(incompname) == true)
            {
                Company co = new Company() { name = incompname };
                context.Companies.Add(co);
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

                //add another location and yes answer starts process all over

                var deptlocidquery = (from l in context.Locations
                                      where l.name == inlocname
                                      select l.location_id);

                int deptloc = Convert.ToInt32(deptlocidquery);

                var deptcoidquery = (from c in context.Companies
                                     where c.name == indeptcompname
                                     select c.comp_id);

                int deptco = Convert.ToInt32(deptcoidquery);

                Department dept = new Department() { name = indepname, fk_company_comp_id = deptco, fk_location_location_id = deptloc };
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
            }
        }
        
        public bool currentpassword(string inmanempfn, string inmanempln)
        {
            using (var context = new CompanyTimesEntities())
            {
            int selectedemp = getemployeeid(inmanempfn, inmanempln);
            int selectedman = getemployeeid(inmanfn, inmanln);
            
                var em = context.Employees.Find(selectedemp);

            if (em.password == null)
            {

            }
            else if ()
        }
            }

    public bool passwordconfirmation(string pass1, string pass2)
{
    if (pass1 == pass2)
{
    return true;
}
    else
    {
        return false;
    }
}

        public void generatepassword(string inmanempfn, string inmanempln)
        {
            using (var context = new CompanyTimesEntities())
            {
                var empmanquery = (from e in context.Employees
                                   where e.firstname == inmanempfn && e.lastname == inmanempln
                                   select e.employee_id);
                int selectedemp = Convert.ToInt32(empmanquery);

                var em = context.Employees.Find(selectedemp);

                if (em.password == null)
                {
                    ;
                }
                //em.password = pwd + selectedemp;
            }
        }
    }
}

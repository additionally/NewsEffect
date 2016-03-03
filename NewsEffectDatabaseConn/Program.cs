using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsEffectDatabaseConn
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CompanyTimesEntities())
            {
                Console.WriteLine("Welcome to Effect. An Intra-company news service.");
                Console.WriteLine("Have an account? (yes/no)");
                string accountanswer = Console.ReadLine();
                if (accountanswer == "yes")
                {
                    Console.WriteLine("Sign up");
                    int assignedcompid = 1;
                    var maxcompidquery = (from c in context.companies
                                          select c.comp_id);
                    while (maxcompidquery.Contains(assignedcompid))
                    {
                        assignedcompid++;
                    }

                    Console.WriteLine("Please Enter The Company Name");
                    string incompname = Console.ReadLine();

                    var checkcompnamequery = (from c in context.companies
                                          select c.name);
                    if (checkcompnamequery.Contains(incompname))
                    {
                        Console.WriteLine("Company Name already exists");
                        Console.WriteLine("Would you like to log in? (yes/no)");
                        //basically go to login page
                        //else is start sign up again
                    }
                    else
                    {
                        company co = new company() { comp_id = assignedcompid, name = incompname };
                        context.companies.Add(co);
                    }
                    Console.WriteLine("Please enter a location");
                    string inlocname = Console.ReadLine();
                    int assignedlocid = 1;
                    var maxlocidquery = (from l in context.locations
                                          select l.location_id);
                    while (maxlocidquery.Contains(assignedlocid))
                    {
                        assignedlocid++;
                    }
                    var checklocnamequery = (from l in context.locations
                                              select l.name);
                    if (checklocnamequery.Contains(inlocname))
                    {
                        //nothing i guess. we just don't want to add it to the 
                        //else is start sign up again
                    }
                    else
                    {
                        location loc = new location() { location_id = assignedlocid, name = inlocname };
                        context.locations.Add(loc);
                    }
                    //add another location and yes answer starts process all over

                    
                    
                    context.SaveChanges();

                }
                else
                {
                    Console.WriteLine("Log In");
                }
                
            
            }

             using (var context = new CompanyTimesEntities())
            {
                
            }


            //using (var context = new tradingsystemEntities())
            //{
            //    foreach (var broker in context.brokers)
            //    {
            //        Console.WriteLine(broker.name);
            //    }
            //}

            //using (var context = new tradingsystemEntities())
            //{
            //    var brokers = context.brokers.Where(b => b.name == "Matt");
            //    foreach (broker b in brokers)
            //    {
            //        context.brokers.Remove(b);
            //    }
            //    context.SaveChanges();
            //}
            //using (var context = new tradingsystemEntities())
            //{
            //    var query = (from b in context.brokers
            //                 where b.company.city == "London"
            //                 select b);
            //    foreach (var broker in query)
            //    {
            //        Console.WriteLine(broker.name);
            //    }
            //}
        }
    }


}


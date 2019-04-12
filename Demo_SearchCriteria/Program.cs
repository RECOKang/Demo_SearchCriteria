using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSF.Common.SearchCriteria;

namespace Demo_SearchCriteria
{
    class Program
    {
        static void Main(string[] args)
        {

            MemberCriteria critera = new MemberCriteria() { ID = "1,10", Name = "o", Title = "Manager" };
            var result = GetSample().Search(critera.EffectiveCriterias);

            foreach (var member in result)
            {
                Console.WriteLine($"ID: {member.ID}, Name: {member.Name}, Title: {member.Title}, Department: {member.Department}");
            }

            Console.ReadLine();
        }

        private static IQueryable<Member> GetSample()
        {
            return new List<Member>()
            {
                new Member { ID = 1, Name = "reco", Title = "PM", Department = "RD"},
                new Member { ID = 2, Name = "ann", Title = "PM", Department = "TECH"},
                new Member { ID = 3, Name = "backy", Title = "PM", Department = "RD"},
                new Member { ID = 4, Name = "gina", Title = "TopEmployee", Department = "RD"},
                new Member { ID = 5, Name = "Candy", Title = "PM", Department = "Sales"},
                new Member { ID = 6, Name = "barry", Title = "Employee", Department = "RD"},
                new Member { ID = 7, Name = "andy", Title = "Employee", Department = "RD"},
                new Member { ID = 8, Name = "xiao", Title = "Manager", Department = "TotalManagment"},
                new Member { ID = 9, Name = "tango", Title = "Manager", Department = "Sales"}
            }.AsQueryable();
        }
    }
}
